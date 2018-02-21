<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestNews.ascx.cs" Inherits="SerwisPrasowy_WebParts.WebParts.OstatnieNewsy.OstatnieNewsy" %>
<style type="text/css">


    .auto-style10 {
        width: 341px;
    }

    .auto-style3 {
        height: 23px;
    }
    .auto-style6 {
        width: 341px;
        text-align: center;
    }
    .auto-style7 {
        text-align: left;
    }
    .auto-style8 {
        width: 341px;
        height: 23px;
    }
    </style>

<p>
    <table style="width:100%;">
        <tr>
            <td class="auto-style10"><strong>
                <asp:Label ID="LabelShowLastNewsFromCategory" runat="server" Font-Size="Medium" Text="Pokaż ostatniego newsa z kategorii: " ForeColor="#0066FF"></asp:Label>
                </strong></td>
            <td colspan="2">
                <asp:DropDownList ID="DropDownListCategories" runat="server" Height="16px" OnSelectedIndexChanged="DropDownListCategories_SelectedIndexChanged" Width="189px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style3">
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="3">
                <asp:LinkButton ID="LinkBtnNewsTitle" runat="server" Font-Bold="False" Font-Size="Medium" Font-Underline="False" ForeColor="#009900">LinkBtnNewsTitle</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">
                <asp:Label ID="LabelShortDescription" runat="server" Font-Italic="True" Text="LabelShortDescription" Font-Size="Small"></asp:Label>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style6" rowspan="3">
                <asp:Image ID="ImageNews" runat="server" />
            </td>
            <td class="auto-style7" rowspan="3">
                <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="LabelAuthor" runat="server" Font-Italic="True" Text="Autor: "></asp:Label>
                <asp:Label ID="LabelAuthorVal" runat="server" Font-Italic="True" Text="AutorName"></asp:Label>
            </td>
            <td rowspan="3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="LabelCreated" runat="server" Font-Italic="True" Text="Utworzony: "></asp:Label>
                <asp:Label ID="LabelCreatedVal" runat="server" Font-Italic="True" Text="Date"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="LabelCreated0" runat="server" Font-Italic="True" Text="Kategoria: "></asp:Label>
                <asp:Label ID="LabelCategories" runat="server" Font-Italic="True" Text="Category"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</p>

<p>
&nbsp;&nbsp;&nbsp;
</p>


