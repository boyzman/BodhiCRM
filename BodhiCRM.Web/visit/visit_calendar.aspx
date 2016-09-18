<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visit_calendar.aspx.cs" Inherits="BodhiCRM.Web.visit.visit_calendar" %>
<%@ Import Namespace="BodhiCRM.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>随访任务设置</title>
    <link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href='../scripts/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../scripts/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script src='../scripts/fullcalendar/lib/moment.min.js'></script>
    <script src='../scripts/fullcalendar/fullcalendar.min.js'></script>
    <script src='../scripts/fullcalendar/locale-all.js'></script>
    <script type="text/javascript" src="../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script>
        $(function () {
            var arr = [{ 'id': 'txtKeywords', 'desc': '患者病历号、随访进度' }];
            for (var i = 0; i < arr.length; i++) {
                watermark(arr[i].id, arr[i].desc);
            }
            var initialLocaleCode = 'zh-cn';

            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,listMonth'
                },
                defaultDate: '2016-09-12',
                locale: initialLocaleCode,
                buttonIcons: true, // show the prev/next text
                weekNumbers: true,
                navLinks: true, // can click day/week names to navigate views
                editable: true,
                eventLimit: true, // allow "more" link when too many events
                events: [
                  <%=CalenBind(keywords) %>
			],

		    //eventClick: function (calEvent, jsEvent, view) {
		    //    showUpdateDialog(this);
		    //}
		});

        });
        //初始化病患选择
        function showUpdateDialog(obj) {
            var d = top.dialog({
                width: 1000,
                height: 500,
                id: 'visitDialogId',
                padding: 0,
                title: "编辑随访信息",
                url: 'dialog/dialog_visit_update.aspx'
            }).showModal();
            //将容器对象传进去
            d.data = obj;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>随访任务设置</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="visit_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                        </ul>

                    </div>
                    <div class="r-list">  
                      <%-- <asp:LinkButton ID="lbtnSearch_dt" runat="server" CssClass="btn-search" OnClick="btnSearch_dt_Click">查询</asp:LinkButton>--%>             
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keywords" /> 
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-searchs" OnClick="lbtnSearch_Click" >查询</asp:LinkButton>
                           
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <div id='calendar'></div>
    </form>
</body>
</html>
