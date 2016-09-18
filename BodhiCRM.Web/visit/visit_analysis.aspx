<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visit_analysis.aspx.cs" Inherits="BodhiCRM.Web.visit.visit_analysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
    <title>随访统计</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
     <script type="text/javascript" src="../scripts/Highcharts/highcharts.js" charset="gbk"></script>
    <script type="text/javascript" src="../scripts/Highcharts/modules/exporting.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: '随访信息统计'
                },
               
                xAxis: {
                    type: 'category',
                    labels: {
                        rotation: -45,
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '随访患者数'
                    }
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '随访数: <b>{point.y} 个</b>'
                },
                series: [{
                    color: '#7EB826',
                    name: 'Population',
                    data: [
                       <%=chatsBind()%>
                    ],
                    dataLabels: {
                        enabled: true,
                        rotation: -90,
                        color: '#FFFFFF',
                        align: 'right',
                        format: '{point.y}', // one decimal
                        y: 10, // 10 pixels down from the top
                        style: {
                            fontSize: '13px',
                            fontFamily: 'Verdana, sans-serif'
                        }
                    }
                }]
            });
        });
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </form>
</body>
</html>
