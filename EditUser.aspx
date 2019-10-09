<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication3.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>修改用户信息</title>
		
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>

    <script src="js/jquery.min.js" type="text/javascript" charset="utf-8"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
			
	<script src="js/jquery.validate.min.js" type="text/javascript" charset="utf-8"></script>
	<script src="js/messages_zh.js" type="text/javascript" charset="utf-8"></script>
		<style type="text/css">
		
			#reg-header{
				width: 100%;
				border: 0px solid blue;
				
			}
			
			#reg-header-title{
				
				font-size: x-large;
				color: darkgray;
				text-align: center;
			}
			#header-right{
				border: 0px firebrick solid;
				margin-top: 17px;				
				float: right;				
			}
			
			#reg-main{
				border: 0px red solid;
				padding-bottom: 20px;
			}
			#submit{
				align-self: center;
			}
			#reg-main{
				padding-top: 10px;
			}
			.form-horizontal{
				border: 0px yellow solid;
			}
			
			.form-group{
				margin-top: 20px;
				border: 0px green solid;
                height:auto;
				
			}
			
		</style>
</head>
	<body>
		<div class="container">
			<div id="reg-header" style="margin-left:400px">					
					<span id="reg-header-title">
						修改用户信息
					</span>								
			</div>
		
			<div id="reg-main">
				<form id="form2" runat="server" lass="form-horizontal" onsubmit="return checkForm();">
					<div class="form-group ">
						<label for="username" class="col-md-3 control-label" style="color: #666666;text-align:right">姓名</label>
						<div class="col-md-4">
							<input type="text" class="form-control" name="username" value="<%=user1.name %>"/>		
						</div>
						<label id="usernameTips"> </label>

					</div>

                    <div class="form-group ">
						<label for="age" class="col-md-3 control-label" style="color: #666666;text-align:right">年龄</label>
						<div class="col-md-4">
							<input type="text" class="form-control" name="age"  value="<%=user1.age %>"/>		
						</div>
						<label id="ageTips"> </label>
					</div>

                    <div class="form-group ">
						<label for="gender" class="col-sm-3 control-label" style="color: #666666;text-align:right">性别</label>
						<div class="col-sm-4">
                            <asp:RadioButton ID="男" runat="server" GroupName="gender" Text="男" />
                            <asp:RadioButton ID="女" runat="server" GroupName="gender" Text="女"/>
                            <asp:RadioButton ID="不明" runat="server" GroupName="gender" Checked="true" Text="不明"/>
						</div>
                        <label id="genderTips"> </label>
					</div>

                    <div class="form-group ">
						<label for="nationality" class="col-md-3 control-label" style="color: #666666;text-align:right">民族</label>
						<div class="col-md-4">
							<input type="text" class="form-control" name="nationality"  value="<%=user1.nationality %>"/>		
						</div>
                        <label id="nationalityTips"> </label>
					</div>

                    <div class="form-group ">
						<label for="phone" class="col-md-3 control-label" style="color: #666666;text-align:right">电话</label>
						<div class="col-md-4">
							<input type="text" class="form-control" name="phone"  value="<%=user1.phone %>"/>		
						</div>
						<label id="phoneTips"> </label>
					</div>

                    <div class="form-group ">
						<label for="address" class="col-md-3 control-label" style="color: #666666;text-align:right">地址</label>
						<div class="col-md-4">
							<input type="text" class="form-control" name="address" value="<%=user1.address %>"  />	
                            <input type="hidden" name="id" value="<%=user1.id %>" />
						</div>
                        <label id="addressTips"> </label>
					</div>

                    <div class="form-group">
						<label for="" class="col-sm-4 control-label sr-only"></label>
						<div class="col-sm-4" style="margin-left:370px;margin-top:20px">
                            <input type="submit" style="background-color:#337ab7;;color:white;width:120px;height:35px;" value="保存" />
						</div>
					</div>
			    </form>
            </div>
			
		</div>
	
	</body>
<script type="text/javascript">
    window.onload = function () {
        var gender = "<%=user1.gender%>";
        //alert(gender);
        if (gender == "男") {
            $("#男").attr("checked", true); 
        }
        if(gender == "女"){
            $("#女").attr("checked", true);
        }
        if(gender == "不明"){
            $("#不明").attr("checked", true);
        }      
    };

    function checkForm() {
        var name = document.getElementsByName("username")[0].value;
        if (name == "" || name == null) {
            $("#usernameTips").attr("style", "color: #fc4343;font-family:arial,'宋体';font-size: 12px;")
            document.getElementById("usernameTips").innerHTML = "请输入姓名";
            return false;
        }

        var age = document.getElementsByName("age")[0].value;
        if (age == "" || age == null) {
            $("#ageTips").attr("style", "color: #fc4343;font-family:arial,'宋体';font-size: 12px;")
            document.getElementById("ageTips").innerHTML = "请输入年龄";
            return false;
        }
        if (!(/^(1[1-4][0-9]|150)$|^([1-9][0-9])$|^[0-9]$/.test(age))) {
            $("#ageTips").attr("style", "color: #fc4343;font-family:arial,'宋体';font-size: 12px;")
            document.getElementById("ageTips").innerHTML = "请输入正确格式的年龄";
            return false;
        }

       
        var phone = document.getElementsByName("phone")[0].value;
        if (phone != "" && phone != null) {
            if (!(/^1[3|4|5|8][0-9]\d{4,8}$/.test(phone))) {
                $("#phoneTips").attr("style", "color: #fc4343;font-family:arial,'宋体';font-size: 12px;")
                document.getElementById("phoneTips").innerHTML = "请输入正确格式的手机/电话";
                return false;
            }
        }

        return true;
    }

    </script>
</html>
