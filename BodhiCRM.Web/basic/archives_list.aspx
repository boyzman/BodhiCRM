<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="archives_list.aspx.cs" Inherits="BodhiCRM.Web.basic.archives_list" %>
<%@ Import namespace="BodhiCRM.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>病患档案合并查询</title>
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
  <span>病患档案合并查询</span>
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
      
      <th align="center" width="11%">病历号</th>
      <th align="center" width="11%">姓名</th>
      <th align="center" width="11%">性别</th>
      <th align="center" width="11%">年龄</th>
      <th align="center" width="11%">电话</th>
      <th align="center" width="11%">身份证号</th>
      <th align="center" width="11%">登记时间</th>
      <th width="8%">状态</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
     
      <td style="text-align:center"><%# Eval("PATIENT_SN") %></td>
      <td style="text-align:center"><%# Eval("CNAME") %></td>
      <td style="text-align:center"><%# Eval("GENDER_ID").ToString() == "1" ? "男" : "女"%></td>
      <td style="text-align:center"><%# Utils.CalculateAgeCorrect(DateTime.Parse(Eval("BIRTH_DATE").ToString()),DateTime.Now)%></td>
      <td style="text-align:center"><%# Eval("MOBILE_TEL") %></td>
      <td style="text-align:center"><%# Eval("ID_CARD_CODE") %></td>
      <td style="text-align:center"><%#string.Format("{0:g}",Eval("CREATE_TIME"))%></td>
      <td style="text-align:center"><%#Eval("STATUS").ToString().Trim() == "Y" ? "正常" : "禁用"%></td>
    </tr>
      <tr>
          <td colspan="8" style="padding-left:50px;padding-right:50px">
         <ul class="tabs">
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_1">病患家属信息</a></li>
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_2">门诊信息</a></li>
			<li><a href="#" name=".tab<%#(Container.ItemIndex+1) %>_3">居家护理信息</a></li>       
		</ul>
		
		<div class="content">
			<div class="tab<%#(Container.ItemIndex+1) %>_1">
			    <asp:Repeater ID="rptList_family" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr>
                                <th align="left" width="9%">家属姓名</th>
                                <th align="left" width="9%">关系</th>
                                <th align="left" width="9%">性别</th>
                                <th align="left" width="9%">年龄</th>
                                <th align="left" width="9%">电话</th>
                                <th align="left" width="9%">登记时间</th>
                                <th width="8%">状态</th>                                     
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>                              
                            <td><%# Eval("CNAME") %></td>
                            <td><%# Eval("PATIENT_RELATION") %></td>
                            <td><%#Eval("GENDER_ID").ToString() == "1" ? "男" : "女"%></td>
                            <td><%# Utils.CalculateAgeCorrect(DateTime.Parse(Eval("BIRTH_DATE").ToString()),DateTime.Now)%></td>
                            <td><%# Eval("MOBILE_TEL") %></td>
                            <td><%#string.Format("{0:g}",Eval("CREATE_TIME"))%></td>
                            <td align="center"><%#Eval("STATUS").ToString().Trim() == "Y" ? "正常" : "无效"%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
			</div>
			<div class="tab<%#(Container.ItemIndex+1) %>_2">
                <asp:Repeater ID="rptList_outpatient" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                            <tr> 
                                <th align="left" width="10%">就诊日期</th>
                                <th align="left" width="50%">医嘱信息</th>
                                <th align="left" width="10%">就诊结果</th>
                                <th align="left" width="30%">开药信息</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#string.Format("{0:g}",Eval("visit_date"))%></td>
                            <td><%# Eval("soap_text") %></td>
                            <td><%# Eval("ch_disease_name") %></td>
                            <td><%# Eval("ch_trade_name") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        
                      </table>
                    </FooterTemplate>
                </asp:Repeater>
			</div>
			<div class="tab<%#(Container.ItemIndex+1) %>_3">
			     <asp:Repeater ID="rptList_homecare" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center" width="12%">医师姓名</th>
                            <th align="center" width="22%">探访时间</th>
                            <th align="center" width="22%">探访地点</th>
                            <th align="center" width="44%">检查结果</th> 
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#new BodhiCRM.BLL.EMPLOYEE().GetModel(Convert.ToInt32(Eval("EMPLOYEE_ID"))).REAL_NAME%></td>
                        <td align="center"><%#Eval("VISIT_DT","{0:yyyy-MM-dd}")%></td>
                        <td align="center"><%#Eval("VISIT_PLACE")%></td>
                        <td align="center"><%#Eval("REMARK")%></td>
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
