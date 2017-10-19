using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.POIFS.Properties;
using NPOI.SS.UserModel;    //载入基础操作库
using NPOI.HSSF.UserModel;  //Excel2003版
using NPOI.XSSF.UserModel;  //Excel2007版
using System.Data;
using NPOI.HPSF;    //2003的Excel：可以使用文档属性DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();和SummaryInformation si = PropertySetFactory.CreateSummaryInformation();

namespace FROST.Utility {
    /// <summary>
    /// Excel版本
    /// </summary>
    public enum ExcelVersion {
        xls = 2003,
        xlsx = 2007
    }
    /// <summary>
    /// 将Excel（2003、2007版）文件转为DataTable【后面有样式设置代码注释】
    /// </summary>
    public class NpoiHelper {
        /// <summary>
        /// 将Excel文件输出为DataTable
        /// </summary>
        /// <param name="filename">自动适配2003/2007版本</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string filename) {
            DataTable dt = new DataTable();
            //用IWorkbook是因为该对象是最高级的创建/读取对象，可适配2003/2007版本
            IWorkbook wk = null;
            if (!File.Exists(filename))
                return null;
            string ext = filename.Substring(filename.LastIndexOf(".")).ToString().ToLower();
            FileStream fs = File.OpenRead(filename);        //用File.OpenRead方法读取指定路径的文件，返回FileStream流
            if (ext == ".xlsx") {
                wk = new XSSFWorkbook(fs);
            }
            else {
                wk = new HSSFWorkbook(fs);
            }
            ISheet sheet = wk.GetSheetAt(0);    //获取第0张工作表
            IRow row = sheet.GetRow(0);     //获取表头（第1行），然后以此设置 dt 的字段名称为第1行的内容
            for (int i = 0; i < row.Cells.Count; i++) {
                DataColumn dc = new DataColumn(GetCellValue(row.Cells[i]));
                dt.Columns.Add(dc);
            }
            //将表头也添加到dt中，因为输出的时候也需要
            //后期将此处修改为转换后的模板表头
            DataRow rowHead = dt.NewRow();
            for (int i = 0; i < row.Cells.Count; i++) {
                rowHead[i] = GetCellValue(row.Cells[i]);
            }
            //dt.Rows.Add(rowHead);     //上面获取到了表头，但现在暂时不添加，因为DT的列名就是表头了（20170511）
            //开始处理所有行的数据，从第2(1)行开始
            DataRow drHave = dt.NewRow(); //创建一个有1-6列内容的字段，用来存储重复的行数据
            for (int k = 1; k <= sheet.LastRowNum; k++) {
                IRow rows = sheet.GetRow(k);
                //正常情况下只需要下面这两句
                DataRow dr = dt.NewRow();   //创建与dt表结构一致的记录row
                for (int j = rows.FirstCellNum; j < rows.LastCellNum; j++) {
                    dr[j] = GetCellValue(rows.Cells[j]);        //获取循环单元格的值
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// Datatable导出Excel，默认表名：sheet1+rows.count
        /// 暂时这样，后面再优化：20160928
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strFileName">不含扩展名</param>
        public static void DataTableToExcel(DataTable dt, string strFileName, ExcelVersion ver,bool hasColumnName = true) {
            //不自动追加扩展名
            string filename = strFileName;
            //DocumentSummaryInformation、SummaryInformation仅支持2003
            IWorkbook hwk = null;    //IWorkbook无属性设置
            if (ver == ExcelVersion.xls) {
                hwk = new HSSFWorkbook();
            }
            else if (ver == ExcelVersion.xlsx) {
                hwk = new XSSFWorkbook();
            }
            ISheet sheet = hwk.CreateSheet("sheet1（" + dt.Rows.Count.ToString() + "）");
            sheet.DefaultRowHeight = 20 * 20;   //设置表格默认行高
            sheet.SetColumnWidth(0, 12 * 256);  //列宽：使用填写的值 * 256（tip数），得出实际列宽为【填写的值】
            sheet.SetColumnWidth(1, 18 * 256);  //列宽：使用填写的值 * 256（tip数），得出实际列宽为【填写的值】

            int isHeader = 0;
            if (hasColumnName) {
                IRow rowHeader = sheet.CreateRow(isHeader);
                for (int j = 0; j < dt.Columns.Count; j++) {
                    ICell cell = rowHeader.CreateCell(j);
                    cell.SetCellValue(dt.Columns[j].ColumnName);
                }
                isHeader = 1;
            }
            for (int i = 0; i < dt.Rows.Count; i++) {
                IRow row = sheet.CreateRow(i +isHeader);
                for (int k = 0; k < dt.Columns.Count; k++) {
                    ICell cell = row.CreateCell(k);
                    cell.SetCellValue(dt.Rows[i][k].ToString());
                }
            }
            FileStream fs = new FileStream(filename, FileMode.Create);
            hwk.Write(fs);
            hwk.Close();
            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// 获取不同类型cell的值，并返回通用的string
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellValue(ICell cell) {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType) {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Numeric:
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                        return cell.DateCellValue.ToString();
                    else
                        return cell.NumericCellValue.ToString();
                case CellType.Formula:
                    switch (cell.CachedFormulaResultType) {
                        case CellType.String:
                            string strFORMULA = cell.StringCellValue;
                            if (strFORMULA != null && strFORMULA.Length > 0) {
                                return strFORMULA;
                            }
                            else {
                                return null;
                            }
                        case CellType.Numeric:
                            return cell.NumericCellValue.ToString();
                        case CellType.Boolean:
                            return cell.BooleanCellValue.ToString();
                        case CellType.Error:
                            return cell.ErrorCellValue.ToString();
                        default:
                            return "";
                    }
                case CellType.Unknown:
                default:
                    return cell.ToString();
            }
        }
    }
}
/**
 * 生成表格时的相关样式设计
 *         //XSSFWorkbook hwk = new XSSFWorkbook();
        //IFont font = hwk.CreateFont();
        //font.IsBold = true;
        //font.FontHeight = 10;
        //ICellStyle style = hwk.CreateCellStyle();
        //style.Alignment = HorizontalAlignment.Center;
        //style.VerticalAlignment = VerticalAlignment.Center;
        //XSSFCellStyle xcellstyle = new XSSFCellStyle();
        //style.SetFont(font);

        //xcellstyle.SetFont(font);

        //IRow row = sheet.CreateRow(0);
        //ICell cell = row.CreateCell(0);
        //cell.CellStyle = style;
        //row.Height = 22 * 20;       //设备行高：使用填写的值 * 20（tip数），得出实际行高为【填写的值】

        //row.RowStyle = style;
        //cell.SetCellValue("helloworld");
        //row.CreateCell(1).SetCellValue(DateTime.Now.ToString());
        //row.Cells[1].CellStyle = style;
        //row.CreateCell(2).SetCellValue(33.33);
        //row.CreateCell(3).SetCellFormula("C1*10");
        //row.CreateCell(4).SetCellFormula("sum(C1:D1)");

        //IRow row2 = sheet.CreateRow(1);
        //IFont font2 = hwk.CreateFont();
        //font2.IsBold = true;

        //ICellStyle style2 = hwk.CreateCellStyle();
        //font2.FontHeight = 14;   //字体大小：与数值字号对应
        //style2.SetFont(font2);
        //sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 2, 0, 5));     //合并单元格

        //row2.CreateCell(0).SetCellValue("好吧，合并单元格的值");      //合并前、合并后都可以
        //row2.Cells[0].CellStyle = style2;
        //sheet.CreateRow(0).CreateCell(1).SetCellValue(DateTime.Now.ToString());
    **/
    
