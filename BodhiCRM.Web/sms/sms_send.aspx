<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sms_send.aspx.cs" Inherits="BodhiCRM.Web.sms.sms_send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>短信发送</title>
    <link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
  <script type="text/javascript" charset="utf-8" src="../js/JSLoading.js"></script>
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
                title: "病患选择(多选)",
                url: 'dialog/dialog_patient_multi.aspx',
                onclose: function () {
                    
                    var trHtml = this.returnValue;
                    //alert(trHtml);
                    if (trHtml.length > 0) {
                        $(".rule-multi-porp").empty();//清空
                        $(".rule-multi-porp").append(trHtml);//追加html
                        $(".rule-multi-porp").ruleMultiPorp();//重新绑定样式规则
                    }
                }
            }).showModal();
            //将容器对象传进去
            d.data = obj;
        }
        function MainSelectChange(obj) {
            var objval = obj.value;
           
            if (objval != "" && typeof (objval) != "undefined") {
                $.ajax({
                    type: "post",
                    url: "../tools/admin_ajax.ashx?action=get_sms_template&tempid=" + objval + "&time=" + Math.random(),
                    dataType: "html",
                    success: function (data, textStatus) {
                        //alert(data);
                        $("#txtContent").text(data);
                    }
                });
            }
            else {
                $("#txtContent").text('');
            }

        }
        //获得选中的发送患者
        function setCheckedPatient() {
            
            var fields;
            $(':checkbox:checked').each(function () {
                var txt = $("input[name='hdMobile']");
                fields = ($(':checkbox').map(function () {
                    if (this.checked)
                        return this.value;
                    
                }).get().join(","));

                $(txt).val(fields);
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="sms_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="sms_list.aspx"><span>管理员</span></a>
            <i class="arrow"></i>
            <span>发送短信</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">发送短信</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>选择接收方</dt>
                <dd>
                    <div class="rule-multi-porp">
                       
                     </div>
                     <input type="hidden" name="hidSn" id="hidSn" runat="server"/>
                    <input type="hidden" name="hidName" id="hidName" runat="server"/>
                    <input type="hidden" name="hidMobile" id="hidMobile" runat="server"/>
                     <a class="icon-btn add pati-btn" onclick="showPatientDialog(this);"><span>选择病患</span></a>
                </dd>
            </dl>
            <dl>
                <dt>选择模板</dt>
                <dd>
                  <div class="rule-single-select">
                    <asp:DropDownList id="ddlsmsTemplate" runat="server" datatype="*" errormsg="请选择短信模板" sucmsg=" " onchange="MainSelectChange(this);"></asp:DropDownList>
                  </div>
                </dd>
              </dl>
            <dl>
                <dt>短信内容</dt>
                <dd>
                    <asp:TextBox ID="txtContent" class="txtContent" runat="server" CssClass="input normal" TextMode="MultiLine" ReadOnly="true"></asp:TextBox></dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input type="hidden" name="hdMobile" /> 
                <asp:Button ID="btnSubmit" runat="server" Text="发送" CssClass="btn" OnClick="btnSubmit_Click"  OnClientClick="ShowProgressBar();setCheckedPatient(); return true;"  />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

        <!--loading-->
        <div id="divProgress" style="text-align: center; display: none; position: fixed; top: 50%; left: 50%;">
            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/skin/loading.gif" />
            <br />
            <font color="#1B3563" size="2px">短信发送中</font>
        </div>
        <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; left: 0px; position: absolute; top: 0px;">
        </div>
         <!--/工具栏-->
    </form>
</body>
</html>
