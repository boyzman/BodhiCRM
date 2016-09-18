﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BodhiCRM.Web.login" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理员登录</title>
    <link href="skin/msgbox.css" rel="stylesheet" />
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
    });
</script>
</head>

<body class="loginbody">
<form id="form1" runat="server">
<div style="width:100%; height:100%; min-width:300px; min-height:260px;"></div>
<div class="login-wrap">
  <div class="login-logo">LOGO</div>
  <div class="login-form">
    <div class="col">
      <asp:TextBox ID="txtUserName" runat="server" CssClass="login-input" placeholder="管理员账号" title="管理员账号"></asp:TextBox>
      <label class="s user" for="txtUserName"></label>
    </div>
    <div class="col">
      <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="管理员密码" title="管理员密码"></asp:TextBox>
      <label class="icon pwd" for="txtPassword"></label>
    </div>
      <div class="col">
        <asp:DropDownList id="ddlHospitalcode" runat="server" datatype="*" sucmsg=" " CssClass="login-select">
         
        </asp:DropDownList>
      </div>
    <div class="col">
      <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login-btn" onclick="btnSubmit_Click" />
    </div>
  </div>
  <div class="login-tips"><i></i><p id="msgtip" runat="server">请输入用户名和密码</p></div>
</div>

<div class="copy-right">
  <p>版权所有 青岛卢森科技服务有限公司 Copyright © 2015 - 2016  Inc. All Rights Reserved.</p>
</div>
</form>
</body>
</html>
