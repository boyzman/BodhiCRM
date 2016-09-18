﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="BodhiCRM.Web.center" %>
<%@ Import namespace="BodhiCRM.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理首页</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<div class="nlist-1">
  <ul>
    <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
    <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
    <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
  </ul>
</div>
<div class="line10"></div>

<div class="nlist-2">
  <h3><i></i>站点信息</h3>
  <ul>
    <li>站点名称：<%=sysConfig.webname %></li>
    <li>公司名称：<%=sysConfig.webcompany %></li>
    <li>网站域名：<%=sysConfig.weburl %></li>
    <li>安装目录：<%=sysConfig.webpath %></li>
    <li>网站管理目录：<%=sysConfig.webmanagepath %></li>
    <li>附件上传目录：<%=sysConfig.filepath %></li>
    <li>服务器名称：<%=Server.MachineName%></li>
    <li>服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"] %></li>
    <li>NET框架版本：<%=Environment.Version.ToString()%></li>
    <li>操作系统：<%=Environment.OSVersion.ToString()%></li>
    <li>IIS环境：<%=Request.ServerVariables["SERVER_SOFTWARE"]%></li>
    <li>服务器端口：<%=Request.ServerVariables["SERVER_PORT"]%></li>
    <li>目录物理路径：<%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></li>
    <li>系统版本：V<%=Utils.GetVersion()%></li>
    <li>升级通知：<asp:Literal ID="LitUpgrade" runat="server"/></li>
  </ul>
</div>
<div class="line20"></div>

<div class="nlist-3">
  <ul>
    <li><a onclick="parent.linkMenuTree(true, 'sys_config');" class="icon-setting" href="javascript:;"></a><span>系统设置</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_list');" class="icon-manaer" href="javascript:;"></a><span>管理员</span></li>
    <li><a onclick="parent.linkMenuTree(true, 'manager_log');" class="icon-log" href="javascript:;"></a><span>系统日志</span></li>
  </ul>
</div>

<div class="nlist-4">
  
  <h3><i class="msg"></i>官方消息</h3>
  <ul>
    <asp:Literal ID="LitNotice" runat="server"/>
  </ul>
</div>
<!--/内容-->

</form>
</body>
</html>
