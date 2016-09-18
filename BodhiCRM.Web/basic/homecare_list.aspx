<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homecare_list.aspx.cs" Inherits="BodhiCRM.Web.basic.homecare_list" %>
<%@ Import Namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>居家护理信息</title>
    <link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" charset="utf-8" src="../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            var arr = [{ 'id': 'txtKeywords', 'desc': '患者姓名、医师姓名' }];
            for (var i = 0; i < arr.length; i++) {
                watermark(arr[i].id, arr[i].desc);
            }
        });
     </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>居家护理信息</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="homecare_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>

                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                      <%-- <div class="menu-list">
                            <div class="rule-date-input">
                               <asp:TextBox ID="txtVisitdt" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                            </div>                
                        </div>--%>
                    </div>
                    <div class="r-list">  
                       
                        <asp:TextBox ID="txtVisitdt" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" ToolTip="探访日期" /> 
                     
                      <%-- <asp:LinkButton ID="lbtnSearch_dt" runat="server" CssClass="btn-search" OnClick="btnSearch_dt_Click">查询</asp:LinkButton>--%>             
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keywords" /> 
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-searchs" OnClick="btnSearch_Click" >查询</asp:LinkButton>
                           
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center" width="5%">选择</th>
                            <th align="center" width="12%">患者姓名</th>
                            <th align="center" width="12%">医师姓名</th>
                            <th align="center" width="12%">探访时间</th>
                            <th align="center" width="12%">探访地点</th>
                            <th align="center" width="40%">检查结果</th>
                            <th align="center" width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                        </td>
                        <td align="center">
                            <div class="user-box">
                                <h4><b><%#new BodhiCRM.BLL.PATIENT().GetModel(Eval("PATIENT_SN").ToString()).CNAME%></b> </h4>
                            </div>
                        </td>
                        <td align="center"><%#new BodhiCRM.BLL.EMPLOYEE().GetModel(Convert.ToInt32(Eval("EMPLOYEE_ID"))).REAL_NAME%></td>
                        <td align="center"><%#Eval("VISIT_DT","{0:yyyy-MM-dd}")%></td>
                        <td align="center"><%#Eval("VISIT_PLACE")%></td>
                        <td align="center"><%#Eval("REMARK")%></td>
                        <td align="center"><a href="homecare_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
                  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>

