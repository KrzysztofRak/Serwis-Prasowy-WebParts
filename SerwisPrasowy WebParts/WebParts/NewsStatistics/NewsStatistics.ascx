<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsStatistics.ascx.cs" Inherits="SerwisPrasowy_WebParts.WebParts.StatystykiNewsow.StatystykiNewsow" %>
<style type="text/css">


    .auto-style4 {
        height: 23px;
        width: 330px;
    }
    .auto-style3 {
        width: 205px;
        text-align: left;
    }
    .auto-style6 {
        width: 342%;
    }
    .auto-style10 {
        height: 23px;
        text-align: left;
    }
    .auto-style13 {
        height: 23px;
        width: 205px;
        text-align: left;
    }
    .auto-style14 {
        text-align: left;
    }
    </style>

<div>

<asp:FormView ID="FormViewNewsStatistics" runat="server" Height="197px" Width="260px">
    <ItemTemplate>
        <table class="auto-style6">
            <tr>
                <td class="auto-style10" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066FF" Text="Statystyki naszych newsów"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" colspan="2"></td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="LabelAddedTodayNum" runat="server" ForeColor="Black" Text="Dodanych dzisiaj: "></asp:Label>
                    <asp:Label ID="LabelAddedTodayNumVal" runat="server" Text='<%#Eval("AddedToday") %>'></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="LabelAveragePerDayNum" runat="server" ForeColor="Black" Text="Średnia ilość newsów na dzień: "></asp:Label>
                    <asp:Label ID="LabelAveragePerDayNumVal" runat="server" Text='<%#Eval("AveragePerDay") %>'></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="LabelLeastNewsInCat" runat="server" ForeColor="Black" Text="Najmniej newsów w kategorii: "></asp:Label>
                    <asp:Label ID="LabelLeastNewsInCatVal" runat="server" Text='<%#Eval("LeastNewsInCategory") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="LabelNumInLastWeek" runat="server" ForeColor="Black" Text="Dodanych w ciągu ostatniego tygodnia: "></asp:Label>
                    <asp:Label ID="LabelNumInLastWeekVal" runat="server" Text='<%#Eval("AddedInLastWeek") %>'></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="LabelMostNewsInCat" runat="server" ForeColor="Black" Text="Najwięcej newsów w kategorii: "></asp:Label>
                    <asp:Label ID="LabelMostNewsInCatVal" runat="server" Text='<%#Eval("MostNewsInCategory") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LabelTotalNum" runat="server" ForeColor="Black" Text="Ilość wszystkich newsów: "></asp:Label>
                    <asp:Label ID="LabelTotalNumVal" runat="server" Text='<%#Eval("TotalNews") %>'></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:Label ID="LabelLatestNews" runat="server" ForeColor="Black" Text="Najświeższy news: "></asp:Label>
                    <asp:HyperLink ID="HyperLinkLatestNewsVal" runat="server" NavigateUrl='<%#Eval("LatestNewsUrl") %>'><%#Eval("LatestNewsTitle") %></asp:HyperLink>
                </td>
            </tr>
        </table>
    </ItemTemplate>

    
</asp:FormView>




</div>





