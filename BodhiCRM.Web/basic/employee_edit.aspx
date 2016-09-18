<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employee_edit.aspx.cs" Inherits="BodhiCRM.Web.basic.employee_edit" %>

<%@ Import namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑员工信息</title>
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
    });
    
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="employee_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="patient_list.aspx"><span>员工信息</span></a>
  <i class="arrow"></i>
  <span>编辑员工信息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">员工信息</a></li>
      </ul>
    </div>
  </div>
</div>

    <div class="tab-content">
         <dl>
            <dt>员工名</dt>
            <dd>
                <asp:TextBox ID="txtEmplName" runat="server" CssClass="input normal" datatype="*1-10" sucmsg=" "></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>所属部门</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlDepartId" runat="server" datatype="*" errormsg="请选择所属部门" sucmsg=" "></asp:DropDownList>
                </div>
            </dd>
        </dl>
        
        <dl>
            <dt>职务</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlPost" runat="server" datatype="*" errormsg="请选择员工职务" sucmsg=" ">
                        <asp:ListItem Value="主任医师">主任医师</asp:ListItem>
                        <asp:ListItem Value="普通医生">普通医生</asp:ListItem>
                        <asp:ListItem Value="后勤人员">后勤人员</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
       
        <dl>
            <dt>性别</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblPrepay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">女</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">男</asp:ListItem>

                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>

        <dl>
            <dt>个人联系电话</dt>
            <dd>
                <asp:TextBox ID="txtTel" runat="server" CssClass="input normal" datatype="lm"></asp:TextBox><span class="Validform_checktip">*指员工私人联系电话</span></dd>
        </dl>

        <dl>
            <dt>邮箱</dt>
            <dd>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="le" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*联系人邮箱</span></dd>
        </dl>
        <dl>
            <dt>入职时间</dt>
            <dd>
                <asp:TextBox ID="txtHireddt" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
            </dd>
        </dl>
        <dl>
            <dt>离职时间</dt>
            <dd>
                <asp:TextBox ID="txtLeavedt" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
            </dd>
        </dl>
        <dl>
            <dt>在职状态</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="N">离职</asp:ListItem>
                        <asp:ListItem Value="Y" Selected="True">在职</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                
            </dd>
        </dl>
        <dl>
            <dt>是否有效</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblActive" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="N">无效</asp:ListItem>
                        <asp:ListItem Value="Y" Selected="True">有效</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                
            </dd>
        </dl>
        <dl>
            <dt>备注</dt>
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
