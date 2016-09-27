<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="label_edit.aspx.cs" Inherits="BodhiCRM.Web.marketing.label_edit" %>

<%@ Import Namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑标签信息</title>
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

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="homecare_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="label_list.aspx"><span>标签信息</span></a>
            <i class="arrow"></i>
            <span>编辑标签信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">标签信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>标签名称</dt>
                <dd>
                    <asp:TextBox ID="txtLNAME" runat="server" CssClass="input normal" name="txtLNAME" datatype="*"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>标签类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlType" runat="server" >
                            <asp:ListItem Value="无类型" Selected="True">无类型</asp:ListItem>
                            <asp:ListItem Value="按病种">按病种</asp:ListItem>
                            <asp:ListItem Value="按等级">按等级</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>是否有效</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="cbStatus" runat="server" Checked="True" />
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox TextMode="MultiLine" ID="txtRemark" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
