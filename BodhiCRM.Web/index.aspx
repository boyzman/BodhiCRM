<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BodhiCRM.Web.index" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>后台管理中心</title>
<link href="scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="scripts/Tabs/easyui.css" rel="stylesheet" />
<script type="text/javascript" charset="utf-8" src="scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="scripts/jquery/jquery.nicescroll.js"></script>
<script type="text/javascript" charset="utf-8" src="scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="js/common.js"></script>
    <script src="scripts/Tabs/jQuery.easyui.js"></script>
    <script src="scripts/Tabs/outlook2.js"></script>
<script type="text/javascript">
//页面加载完成时
$(function () {
    //检测IE
    if ('undefined' == typeof(document.body.style.maxHeight)){
        window.location.href = 'ie6update.html';
    }

});
    //需要tabs时放开（还有点问题）
//function ItemClick(obj) {
//    var url = $(obj).attr("href");

//    var tabTitle = $(obj).attr("title");
   
//    var icon = "";
//    if (url == null || url == "") {
//        return;
//    }
//    addTab(tabTitle, url, icon);
//    //$(".main-container #tabs", parent.document).css("height", BrowserClientHeight() - 121);
//}

</script>
</head>

<body class="indexbody">
<form id="form1" runat="server">
  <!--全局菜单-->
  <a class="btn-paograms" onclick="togglePopMenu();"></a>
  <div id="pop-menu" class="pop-menu">
    <div class="pop-box">
      <h1 class="title"><i></i>导航菜单</h1>
      <i class="close" onclick="togglePopMenu();">关闭</i>
      <div class="list-box"></div>
    </div>
    <i class="arrow">箭头</i>
  </div>
  <!--/全局菜单-->

  <div class="main-top">
    <a class="icon-menu"></a>
    <div id="main-nav" class="main-nav"></div>
    <div class="nav-right">
      <div class="info">
        <i></i>
        <span>
          您好，<%=admin_info.USER_NAME %><br>
          <%=new BodhiCRM.BLL.MANAGER_ROLE().GetTitle(Convert.ToInt32(admin_info.ROLE_ID)) %>
        </span>
      </div>
      <div class="option">
        <i></i>
        <div class="drop-wrap">
          <div class="arrow"></div>
          <ul class="item">
            <li>
              <a href="center.aspx" target="mainframe">管理中心</a>
            </li>
            <li>
              <a href="manager/manager_pwd.aspx" onclick="linkMenuTree(false, '');" target="mainframe">修改密码</a>
            </li>
            <li>
              <asp:LinkButton ID="lbtnExit" runat="server" onclick="lbtnExit_Click">注销登录</asp:LinkButton>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
  
  <div class="main-left">
    <h1 class="logo"></h1>
    <div id="sidebar-nav" class="sidebar-nav"></div>
  </div>
   <%-- <div class="row content-tabs">
        <nav class="page-tabs J_menuTabs">
            <div class="page-tabs-content" style="margin-left: 0px;">
                <a href="javascript:;" class="J_menuTab active" data-id="home.html">首页</a>
                <a href="javascript:;" class="J_menuTab" data-id="/index.php/useradmin/system_zh.html">账号管理 <i class="fa icon-remove-sign"></i></a>
            </div>
        </nav>
        <div class="btn-group roll-nav roll-right">
            <button class="dropdown J_tabClose" data-toggle="dropdown" aria-expanded="false">
                关闭操作<span class="caret"></span>

            </button>
            <ul role="menu" class="dropdown-menu dropdown-menu-right">
                <li class="J_tabShowActive"><a>定位当前选项卡</a>
                </li>
                <li class="divider"></li>
                <li class="J_tabCloseAll"><a>关闭全部选项卡</a>
                </li>
                <li class="J_tabCloseOther"><a>关闭其他选项卡</a>
                </li>
            </ul>
        </div>
    </div>--%>
  
  <div class="main-container">
       <%-- <div id="tabs" class="easyui-tabs" fit="true" border="false" style="width: 100%;">
         </div>--%>
    <iframe id="mainframe" name="mainframe" frameborder="0" src="center.aspx"></iframe>
  </div>

</form>
</body>
</html>
