<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_patient_multi.aspx.cs" Inherits="BodhiCRM.Web.dialog.dialog_patient_multi" %>
<%@ Import namespace="BodhiCRM.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>选择病患信息(多选)</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var api = top.dialog.get(window); //获取父窗体对象
    $(function () {
        //设置窗口按钮及事件
        api.button([{
            value: '确定',
            callback: function () {
                setPatientInfo();
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { }
        }
        ]);
        
        //如果有传入对象则赋值
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent(); //取得节点父对象
            //获取父对象的病历号
            var sn = $(api.data).parent().find("input[name='hidSn']").val();
            
            $(":checkbox[value='"+sn+"']").prop("checked",true);
        }
       
        
    });

    //给父窗体赋值
    function setPatientInfo() {
        var sn_value = [];
        var name_value = [];
        var mobile_value = [];
        //$('input[name="chkId"]:checked').each(function () {
        //    if($("table :input[name='chkId']").is(':checked'))
        //    {
        //        alert($("table :input[name='chkId']").val());
        //        sn_value.push($("input[name='chkId']").val());
        //        name_value.push($("input[name='chkId']").attr('title'));
        //    }
            
        //});
        var liHtml = '<span id="cblActionType">'; //返回HTML
        
        $(".ltable").find(":checkbox:checked").each(function () {
            //var sn_val = $(this).parent().next().text();
                var sn_val = $(this).val();
                sn_value.push(sn_val);
                var name_val = $(this).attr('title');
                name_value.push(name_val);
                var mobile_val = $(this).parent().nextAll('.tdm').html();
                
                mobile_value.push(mobile_val);
            });
        
        if (sn_value.length == 0)
        {
            alert('你还没有选择任何信息！');
        }
        else
        {
            
            for (var i = 0; i < name_value.length ; i++) {
                //liHtml = liHtml + '<li class="selected">'
                //+ '<a title="" href="javascript:;">' + name_value[i] + '</a>'
                //+ '<i></i></li>';
                liHtml = liHtml + '<input id="cblActionType_' + i + '" type="checkbox" name="cblActionType" checked="checked" value="' + mobile_value[i] + '" /><label for="cblActionType_' + i + '">' + name_value[i] + '</label>';
            }
            liHtml = liHtml + "</span>";
            $(api.data).parent().find("input[name='hidSn']").val(sn_value.join(","));
            $(api.data).parent().find("input[name='hidName']").val(name_value.join(","));
            $(api.data).parent().find("input[name='hidMobile']").val(mobile_value.join(","));
            api.close(liHtml).remove();
            
            return false;
        }
        
       
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<div class="div-content">
<asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="8%">选择</th>
      <th align="left" width="11%">病历号</th>
      <th align="left" width="11%">姓名</th>
      <th align="left" width="11%">性别</th>
      <th align="left" width="11%">年龄</th>
      <th align="left" width="11%">电话</th>
      <th align="left" width="11%">身份证号</th>
      <th align="left" width="11%">登记时间</th>
      <th width="8%">状态</th>
     
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <%--<asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" value="<%#Eval("PATIENT_SN")%>" />--%>
         <%--<input type="checkbox" name="chkId" ID="chkId"   value="<%# string.Format("{0},{1}",Eval("PATIENT_SN"),Eval("CNAME"))%>"/>--%>
          <input type="checkbox" name="chkId" ID="chkId" title="<%# Eval("CNAME")%>" value="<%# Eval("PATIENT_SN")%>"/>
        <%-- <input type="hidden" name="hide_SN" value="<%#Eval("PATIENT_SN")%>" />
         <input type="hidden" name="hide_NAME" value="<%#Eval("CNAME")%>" />
          <input type="hidden" name="hide_Mobile" value="<%#Eval("MOBILE_TEL")%>" />--%>
      </td>
      <td><%# Eval("PATIENT_SN") %></td>
      <td><%# Eval("CNAME") %></td>
      <td><%#Eval("GENDER_ID").ToString() == "1" ? "男" : "女"%></td>
      <td><%# Utils.CalculateAgeCorrect(DateTime.Parse(Eval("BIRTH_DATE").ToString()),DateTime.Now)%></td>
      <td class="tdm"><%# Eval("MOBILE_TEL") %></td>
      <td><%# Eval("ID_CARD_CODE") %></td>
      <td><%#string.Format("{0:g}",Eval("CREATE_TIME"))%></td>
      <td align="center"><%#Eval("STATUS").ToString().Trim() == "Y" ? "正常" : "禁用"%></td>
      
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
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
