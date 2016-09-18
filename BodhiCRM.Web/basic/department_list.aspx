<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department_list.aspx.cs" Inherits="BodhiCRM.Web.basic.department_list" %>
<%@ Import namespace="BodhiCRM.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>部门管理</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
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
  <span>部门管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="department_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>      
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本部门及下属子部门，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="table-container-half">
  <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
  <HeaderTemplate>
  <table width="50%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="6%">选择</th>
      <th width="8%">部门名称</th>
      <th width="12%">是否有效</th>
      <th width="12%">是否默认</th>
      <th width="12%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center" width="6%">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
        <asp:HiddenField ID="hidLayer" Value='<%#Eval("CLASS_LAYER") %>' runat="server" />
      </td>
      
      <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
          <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
          <%#Eval("DEPT_NAME")%></td>
      
      <td align="center"><%#Convert.ToString(Eval("ACTIVE")) == "Y" ? "√" : "×"%></td>
      <td align="center"><%#Convert.ToString(Eval("IS_SYS")) == "Y" ? "√" : "×"%></td>
     
      <td align="center" style="white-space:nowrap;word-break:break-all;overflow:hidden;">
        <a href="department_edit.aspx?action=<%#DTEnums.ActionEnum.Add %>&id=<%#Eval("ID")%>&level=<%#Eval("DEPT_LEVEL")%>">添加子级</a>
        <a href="department_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>&level=<%#Eval("DEPT_LEVEL")%>">修改</a>
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

</form>
</body>
</html>
