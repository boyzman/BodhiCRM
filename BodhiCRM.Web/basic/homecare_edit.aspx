<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homecare_edit.aspx.cs" Inherits="BodhiCRM.Web.basic.homecare_edit" %>

<%@ Import namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑居家护理信息</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/PCASClass.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/dateformat.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
    //初始化病患选择
    function showPatientDialog(obj) {
        var d = top.dialog({
            width: 1000,
            height: 500,
            id: 'patiDialogId',
            padding: 0,
            title: "病患选择",
            url: 'dialog/dialog_patient.aspx'
        }).showModal();
        //将容器对象传进去
        d.data = obj;
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="homecare_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="homecare_list.aspx"><span>居家护理信息</span></a>
  <i class="arrow"></i>
  <span>编辑居家护理信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">居家护理信息</a></li>
      </ul>
    </div>
  </div>
</div>

    <div class="tab-content">
         <dl>
            <dt>病患姓名</dt>
            <dd>
                <asp:TextBox ID="txtPNAME" runat="server" CssClass="input normal" name="txtPNAME" ReadOnly="true" ></asp:TextBox>
                <input type="hidden" name="hidSn" id="hidSn" runat="server"/>
                <a class="icon-btn add pati-btn" onclick="showPatientDialog(this);"><span>选择病患</span></a>
            </dd>
        </dl>
        <dl>
            <dt>医师姓名</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlEmplId" runat="server" datatype="*" errormsg="请选择医师" sucmsg=" "></asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>探访日期</dt>
            <dd>
                <asp:TextBox ID="txtVisitdt" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
            </dd>
        </dl>
         <dl>
            <dt>探访地点</dt>
            <dd>
                <asp:TextBox ID="txtVisitPlace" runat="server" CssClass="input normal" ></asp:TextBox></dd>
        </dl>
       
        <dl>
            <dt>检查结果</dt>
            <dd>
                <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine"></asp:TextBox></dd>
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
