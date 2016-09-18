<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patient_edit.aspx.cs" Inherits="BodhiCRM.Web.basic.patient_edit" %>

<%@ Import namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑病患信息</title>
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
        $("#txtIdcard").change(
            function () {
                var usercode = $('#txtIdcard').val();
                if (usercode == '' || usercode.length != 18) {
                    alert('请输入18位正确身份证号');
                    return false;
                }
                //年龄
                var date = new Date();
                var year = date.getFullYear();
                var birthday_year = parseInt(usercode.substr(6, 4));
                var userage = year - birthday_year;
                $('#txtAge').val(userage);
                //生日
                var birth = usercode.substring(6, 10) + "-" + usercode.substring(10, 12) + "-" + usercode.substring(12, 14);
                $('#txtBIRTH_DATE').val(birth);
                //性别
                if (parseInt(usercode.substr(16, 1)) % 2 == 1) {
                    $('#cbGENDER_ID').val("男");
                } else {
                    $('#cbGENDER_ID').val("女");
                }
                return false;
            }
            );
        
        var mypcas = new PCAS("txtProvince,所属省份", "txtCity,所属城市", "txtArea,所属地区");
        var areaAll = '<%=areaAll %>';
        var areaArr = areaAll.split(",");
        if (areaArr.length == 3) {
            mypcas.SetValue(areaArr[0], areaArr[1], areaArr[2]);
        }
    });
    
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="patient_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="patient_list.aspx"><span>病患信息</span></a>
  <i class="arrow"></i>
  <span>编辑病患信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">病患信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>病历号</dt>
    <dd><asp:TextBox ID="txtSN" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="../tools/admin_ajax.ashx?action=patient_validate"></asp:TextBox> <span class="Validform_checktip">*字母、数字、下划线，不可修改</span></dd>
  </dl>
  <dl>
    <dt>姓名</dt>
    <dd><asp:TextBox ID="txtCNAME" runat="server" CssClass="input normal" datatype="*1-20"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>身份证号</dt>
    <dd><asp:TextBox ID="txtIdcard" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " ajaxurl="../tools/admin_ajax.ashx?action=idcard_validate" ></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>性别</dt>
    <dd>
      <div class="rule-single-checkbox-sex">
          <asp:CheckBox ID="cbGENDER_ID" runat="server" Checked="True" />
      </div>
    </dd>
  </dl>
  <dl>
    <dt>出生日期</dt>
    <dd>
      <asp:TextBox ID="txtBIRTH_DATE" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的出生日期" sucmsg=" "  />
    </dd>
  </dl>
  <dl>
    <dt>年龄</dt>
    <dd><asp:TextBox ID="txtAge" runat="server" CssClass="input normal" datatype="*0-20"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>身高</dt>
    <dd><asp:TextBox ID="txtHeight" runat="server" CssClass="input normal" datatype="n1-3"></asp:TextBox>cm</dd>
  </dl>
    <dl>
    <dt>体重</dt>
    <dd><asp:TextBox ID="txtWeight" runat="server" CssClass="input normal" datatype="n1-3"></asp:TextBox>kg</dd>
  </dl>
  <dl>
    <dt>所在地区</dt>
    <dd>
       <select id="txtProvince" name="txtProvince" class="select" runat="server"></select>
        <select id="txtCity" name="txtCity" class="select" runat="server" datatype="*2-20"></select>
        <select id="txtArea" name="txtArea" class="select"  runat="server"></select><span class="Validform_checktip">*请选择城市</span>
    </dd>
  </dl>
   <dl>
    <dt>地址</dt>
    <dd><asp:TextBox ID="txtAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
   <dl>
    <dt>手机号码</dt>
    <dd><asp:TextBox ID="txtTel" runat="server" CssClass="input normal" datatype="lm" sucmsg=" " ajaxurl="../tools/admin_ajax.ashx?action=patient_mobile_validate"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>EMAIL地址</dt>
    <dd><asp:TextBox ID="txtEMAIL" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>是否有效</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
      </div>
    </dd>
  </dl>
  <dl>
    <dt>备注</dt>
    <dd><asp:TextBox TextMode="MultiLine" ID="txtRemark" runat="server" CssClass="input normal"></asp:TextBox> </dd>
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
