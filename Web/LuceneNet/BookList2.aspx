<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList2.aspx.cs" Inherits="Web.LuceneNet.BookList2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#SearchKey').change(function () {
                $.getJSON("Search.ashx", { "key": $(this).val() }, function (data) {
                    alert(data);
                });
            });
        });
    </script>
    <style type="text/css">
        ul {
            list-style-type: none;
        }
        li span {
            font-size: 9px;
        }
    </style>
</head>
<body>
    <form id="form1" method="get" action="BookList2.aspx">
    <div>
        请输入搜索关键字:<input type="text" name="SearchKey" value="" id="SearchKey"/>
        <input type="submit" name="btnSearch" value="一哈哈" />
        <input type="submit" name="btnInsert" value="插入测试数据" />
        <br />
        <ul>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li><a href='#'>
                    <%# Eval("Title") %></a></li>
                <li><span>&nbsp;&nbsp;
                    <%# Eval("ContentDescription") %></span></li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
    </form>
</body>
</html>
