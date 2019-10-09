<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="WebApplication3.ShowInfo" %>

<!DOCTYPE html>
<%@ Import Namespace="WebApplication3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="css/icon.css" />
    <script type="text/javascript" src="js/jquery.min.js">
    </script>
    <script type="text/javascript" src="js/jquery.easyui.min.js">
    </script>
    <script type="text/javascript" src="js/easyui-lang-zh_CN.js">
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
       
        <table id="userList" class="easyui-datagrid" style="width:802px"
            title="用户列表" iconCls="icon-save">
        <thead>
            <tr>
                <th field="name" width="80" text-align="center">姓名</th>
                <th field="age" width="80" text-align="center">年龄</th>
                <th field="gender" width="80" text-align="center">性别</th>
                <th field="nationality" width="80" text-align="center">民族</th>
                <th field="phone" width="130" text-align="center">电话</th>
                <th field="address" width="250" text-align="center">地址</th>
                <th field="attr1" width="50" text-align="center" >操作</th>
                <th field="attr2" width="50" text-align="center" >操作</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(User user in users){%>

            <tr>
                <td><%=user.name %></td>
                <td><%=user.age %></td>
                <td><%=user.gender %></td>
                <td><%=user.nationality %></td>
                <td><%=user.phone %></td>
                <td><%=user.address %></td>
                <td><a href="Delete.aspx?id=<%=user.id %>" class="deletes" style="text-decoration:none">删除</a></td>
                <td><a href="EditUser.aspx?id=<%=user.id %>" style="text-decoration:none">修改</a> </td>
            </tr>

            <%} %>             
        </tbody>
    </table>
    </div>
        <div style="margin-top:10px">
             <a id="btn" href="AddUserInfo.aspx" class="easyui-linkbutton"  style="text-align:center">添加用户</a>
        </div>
    </form>
</body>

    <script type="text/javascript">
        window.onload = function () {
            var datas = document.getElementsByClassName("deletes");
            var dataLength = datas.length;
            for (var i = 0; i < dataLength; i++) {
                datas[i].onclick = function () {
                    if (!confirm("确定要删除吗?")) {
                        return false;
                    }
                }
            }
        };
    </script>
</html>
