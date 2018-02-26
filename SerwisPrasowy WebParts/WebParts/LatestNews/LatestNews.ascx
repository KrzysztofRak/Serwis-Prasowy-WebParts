<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestNews.ascx.cs" Inherits="SerwisPrasowy_WebParts.WebParts.OstatnieNewsy.OstatnieNewsy" %>
<style type="text/css">


    .auto-style3 {
        height: 23px;
        text-align: left;
    }
    .auto-style8 {
        width: 234px;
        height: 23px;
    }
    .auto-style15 {
        width: 100%;
    }
    .auto-style19 {
        width: 600px;
    }
    .auto-style20 {
        width: 234px;
    }
    </style>

<p>
    <strong>
    <asp:Label ID="LabelShowLastNewsFromCategory" runat="server" Font-Size="Medium" ForeColor="#0066FF" Text="Pokaż ostatniego newsa z kategorii: "></asp:Label>
    </strong>
    <asp:DropDownList ID="DropDownListCategories" AutoPostBack="true" DataValueField="Title" DataTextField ="Title" runat="server" Height="16px" OnSelectedIndexChanged="DropDownListCategories_SelectedIndexChanged" Width="189px">
    </asp:DropDownList>
</p>

<asp:FormView ID="FormViewLatestNews" runat="server">
    <ItemTemplate>
        <p>
            <table class="auto-style15">
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:HyperLink ID="HyperLinkNewsTitle" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600" NavigateUrl='<%#Eval("NavigateUrl") %>'><%#Eval("Title") %></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Label ID="LabelShortDescription" runat="server" Font-Italic="True" Font-Size="Small" Text='<%#Eval("ShortDescription") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Image ID="ImageNews" runat="server" ImageUrl='<%#Eval("ImageUrl") %>'/>
                    </td>
                    <td class="auto-style19">
                        <asp:Label ID="Label1" runat="server" Text=''></asp:Label>
                        <asp:Label ID="LabelDescription" runat="server" Text='<%#Eval("Content") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="LabelAuthor" runat="server" Font-Italic="True" Text="Autor: "></asp:Label>
                        <asp:Label ID="LabelAuthorVal" runat="server" Font-Italic="True" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                    </td>
                    <td rowspan="3" class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="LabelCreated0" runat="server" Font-Italic="True" Text="Kategoria: "></asp:Label>
                        <asp:Label ID="LabelCategories" runat="server" Font-Italic="True" Text='<%#Eval("Category") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="LabelCreated" runat="server" Font-Italic="True" Text="Utworzony: "></asp:Label>
                        <asp:Label ID="LabelCreatedVal" runat="server" Font-Italic="True" Text='<%#Eval("Created") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </p>
    </ItemTemplate>
</asp:FormView>

