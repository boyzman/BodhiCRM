<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="family_list.aspx.cs" Inherits="BodhiCRM.Web.basic.family_list" %>
<%@ Import namespace="BodhiCRM.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>病患家属信息列表</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>病患家属信息列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="family_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
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
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="8%">选择</th>
      <th align="left" width="9%">家属姓名</th>
      <th align="left" width="9%">病患姓名</th>
      <th align="left" width="9%">病患病历号</th>
      <th align="left" width="9%">关系</th>
      <th align="left" width="9%">性别</th>
      <th align="left" width="9%">年龄</th>
      <th align="left" width="9%">电话</th>
      <th align="left" width="9%">登记时间</th>
      <th width="8%">状态</th>
      <th width="8%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
      </td>
      <td><a href="family_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>"><%# Eval("CNAME") %></a></td>
      <td><%# Eval("PNAME") %></td>
      <td><%# Eval("PATIENT_SN") %></td>
      <td><%# Eval("PATIENT_RELATION") %></td>
      <td><%#Eval("GENDER_ID").ToString() == "1" ? "男" : "女"%></td>
      <td><%# Utils.CalculateAgeCorrect(DateTime.Parse(Eval("BIRTH_DATE").ToString()),DateTime.Now)%></td>
      <td><%# Eval("MOBILE_TEL") %></td> 
      <td><%#string.Format("{0:g}",Eval("CREATE_TIME"))%></td>
      <td align="center"><%#Eval("STATUS").ToString().Trim() == "Y" ? "正常" : "无效"%></td>
      <td align="center"><a href="family_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
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
