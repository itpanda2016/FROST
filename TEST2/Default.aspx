<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TEST2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <a href="javascript:;" onclick="myfunction()">click</a>
</body>
<script type="text/javascript">
    function myfunction() {
        alert("<%=hello %>");
    }
</script>

</html>
