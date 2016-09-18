<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visit_list.aspx.cs" Inherits="BodhiCRM.Web.visit.visit_list" %>
<%@ Import namespace="BodhiCRM.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>随访信息记录</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/tabStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laytab.js"></script>
<script>
	$(function(){
	    loadTab();
	    var arr = [{ 'id': 'txtKeywords', 'desc': '病历号、患者姓名、患者电话、随访人' }];
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
  <span>随访信息记录</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
       
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="table-container">
  <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" >
    <tr>
      <th align="center" width="8%">病历号</th>
      <th align="center" width="8%">姓名</th>
      <th align="center" width="8%">随访人员</th>
      <th align="center" width="10%">随访标题</th>
      <th align="center" width="8%">随访类型</th>
      <th align="center" width="10%">随访开始时间</th>
      <th align="center" width="10%">随访结束时间</th>
      <th align="center" width="10%">随访频次</th>
      <th align="center" width="8%">随访进度</th>
      <th align="center" width="15%">随访内容</th>
      <th width="5%">操作</th> 
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td style="text-align:center"><%# Eval("PATIENT_SN") %></td>
      <td style="text-align:center"><%# new BodhiCRM.BLL.PATIENT().GetModel(Eval("PATIENT_SN").ToString()).CNAME  %></td>
      <td style="text-align:center"><%# new BodhiCRM.BLL.EMPLOYEE().GetModel(Convert.ToInt32(Eval("EMPL_ID"))).REAL_NAME %></td>
      <td style="text-align:center"><%# Eval("VISIT_TITLE")%></td>
      <td style="text-align:center"><%# Eval("VISIT_TYPE") %></td>
      <td style="text-align:center"><%# string.Format("{0:g}",Eval("VISIT_STARTDT"))%></td>
      <td style="text-align:center"><%# string.Format("{0:g}",Eval("VISIT_ENDDT")) %></td>
      <td style="text-align:center"><%# (Eval("VISIT_FREQUENCY").ToString().Trim()=="单次"?"单次":"每"+Eval("VISIT_FREQUENCYNO")+Eval("VISIT_FREQUENCY")+"随访一次") %></td>
      <td style="text-align:center"><%# Eval("VISIT_STATUS")%></td>
      <td style="text-align:center"><%# Eval("REMARK")%></td>
      <td align="center"><a href="visit_detail_edit.aspx?action=<%#DTEnums.ActionEnum.Add %>&pid=<%#Eval("id")%>">立即随访</a></td>
    </tr>
      <tr>
          <td colspan="8" style="padding-left:50px;padding-right:50px">
         <%--<ul class="tabs">
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_1">病患家属信息</a></li>
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_2">门诊信息</a></li>
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_3">居家护理信息</a></li>       
		</ul>--%>
		
		<div class="content">
			<%--<div class="tab<%#(Container.ItemIndex+1) %>_1">--%>
			    <asp:Repeater ID="rptList_visit_detail" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th align="left" width="15%">随访进度</th>
                                <th align="left" width="15%">随访时间</th>
                                <th align="left" width="15%">下次随访时间</th>
                                <th align="left" width="15%">记录人员</th>
                                <th align="left" width="15%">记录时间</th>
                                <th align="left" width="20%">记录内容</th>
                                 <th width="5%">操作</th>                              
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>    
                            <td><%# Eval("VISIT_DETAIL_STATUS") %></td>                          
                            <td><%# string.Format("{0:g}",Eval("VISIT_DT")) %></td>
                            <td><%# string.Format("{0:g}",Eval("VISIT_NEXTDT")) %></td>
                            <td><%# new BodhiCRM.BLL.MANAGER().GetModel(Convert.ToInt32(Eval("VISIT_USER_ID"))).REAL_NAME%></td>
                            <td><%# string.Format("{0:g}",Eval("ADD_TIME")) %></td>
                            <td><%# Eval("REMARK") %></td>
                            <td align="center"><a href="visit_detail_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&pid=<%#Eval("visit_id")%>">修改</a></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
			</div>
			
		</div>

          </td>
        </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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
