using System;
using System.Threading;
using System.Xml.Linq;
using System.IO;
class Program {
    static void Main(string[] args) {
        //if (File.Exists("test.xml")) {
        //    XDocument xd = XDocument.Load("test.xml");
        //    XElement root = xd.Root;
        //    foreach (XElement item in root.Elements()) {
        //        Console.WriteLine("\"" + item.Attribute("name").Value + "\"");
        //        Console.Write("    ");
        //        foreach (var item2 in item.Elements()) {

        //            if (item2.HasElements) {
        //                Console.WriteLine(item2.Name + ":\"" + item2.Attribute("id").Value + "\"");

        //                foreach (XElement item3 in item2.Elements()) {
        //                    Console.Write("    ");
        //                    if (item3.HasElements) {
        //                        Console.WriteLine("还有？");
        //                    }
        //                    else {
        //                        Console.Write("    ");
        //                        Console.Write(item3.Name + ":\"" + item3.Value + "\"");
        //                    }
        //                }
        //                Console.WriteLine();
        //            }
        //            else {
        //                Console.Write(item2.Name + ":\"" + item2.Value + "\"");
        //                Console.Write("    ");
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //else {
        //    Console.WriteLine("文件不存在。");
        //}
        //Console.Write(root);
        XDocument xd = new XDocument();
        XElement root = new XElement("app");
        XElement t1 = new XElement("table");
        t1.SetAttributeValue("name", "sendtime");
        t1.SetElementValue("sendhour", "9");
        t1.SetElementValue("password", "123");

        XElement t2 = new XElement("table");
        t2.SetAttributeValue("name", "rule");
        XElement r1 = new XElement("row");
        r1.SetAttributeValue("id", "1");
        r1.SetElementValue("type", "text");
        r1.SetElementValue("value", "hello");
        XElement r2 = new XElement("row");
        r2.SetAttributeValue("id", "2");
        r2.SetElementValue("type", "mpnews");
        r2.SetElementValue("value", "");
        t2.Add(r1);
        t2.Add(r2);
        root.Add(t1);
        root.Add(t2);
        xd.Add(root);
        xd.Save("hello.xml");

        Console.ReadKey();
    }
}