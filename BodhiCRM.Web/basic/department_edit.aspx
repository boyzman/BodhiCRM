<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department_edit.aspx.cs" Inherits="BodhiCRM.Web.basic.department_edit" ValidateRequest="false" %>
<%@ Import namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑部门信息</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" src="../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>

<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
$(function () {
    //初始化表单验证
    $("#form1").initValidform();
  
});
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="department_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="department_list.aspx"><span>部门列表</span></a>
  <i class="arrow"></i>
  <span>编辑部门信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">部门信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
   <dl>
    <dt>上级部门</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlParentId" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  
  <dl>
    <dt>是否有效</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbActive" runat="server" Checked="true" />
      </div>
      <span class="Validform_checktip">*隐藏后不显示在部门信息中。</span>
    </dd>
  </dl>  
  <dl>
    <dt>部门名称</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal" ></asp:TextBox>
    </dd>
  </dl>
  <dl>
    <dt>备注说明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
