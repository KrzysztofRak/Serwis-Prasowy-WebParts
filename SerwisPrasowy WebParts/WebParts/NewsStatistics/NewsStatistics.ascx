<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsStatistics.ascx.cs" Inherits="SerwisPrasowy_WebParts.WebParts.StatystykiNewsow.StatystykiNewsow" %>
<style type="text/css">


    .auto-style1 {
        height: 23px;
    }
    .auto-style4 {
        height: 23px;
        width: 330px;
    }
    .auto-style3 {
        width: 381px;
    }
    .auto-style5 {
        height: 23px;
        width: 381px;
    }
    </style>

<table style="width: 100%;">
    <tr>
        <td class="auto-style1" colspan="5">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066FF" Text="Statystyki naszych newsów"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" colspan="5"></td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="LabelAddedTodayNum" runat="server" Text="Dodanych dzisiaj: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelAddedTodayNumVal" runat="server" Text="Num"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style1"></td>
        <td class="auto-style1"></td>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="LabelAveragePerDayNum" runat="server" Text="Średnia ilość newsów na dzień: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelAveragePerDayNumVal" runat="server" Text="Num"></asp:Label>
        </td>
        <td class="auto-style1" colspan="4">
            <asp:Label ID="LabelLeastNewsInCat" runat="server" Text="Najmniej newsów w kategorii: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelLeastNewsInCatVal" runat="server" Text="Num"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="LabelNumInLastWeek" runat="server" Text="Dodanych w ciągu ostatniego tygodnia: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelNumInLastWeekVal" runat="server" Text="Num"></asp:Label>
        </td>
        <td class="auto-style1" colspan="4">
            <asp:Label ID="LabelMostNewsInCat" runat="server" Text="Najwięcej newsów w kategorii: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelMostNewsInCatVal" runat="server" Text="Num"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="LabelTotalNum" runat="server" Text="Ilość wszystkich newsów: " ForeColor="Black"></asp:Label>
            <asp:Label ID="LabelTotalNumVal" runat="server" Text="Num"></asp:Label>
        </td>
        <td colspan="4">
            <asp:Label ID="LabelMostPopularNews" runat="server" Text="Najpopularniejszy news: " ForeColor="Black"></asp:Label>
            <asp:HyperLink ID="HyperLinkMostPopularNewsVal" runat="server">NewsTitle</asp:HyperLink>
        </td>
    </tr>
</table>



