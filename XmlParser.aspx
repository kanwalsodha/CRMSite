<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XmlParser.aspx.cs" Inherits="XmlParser" MasterPageFile="~/Site.master" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div style="height: 176px; width: 800px">
            <asp:FileUpload ID="FileUploadControl" runat="server" />
            <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click"  />
            <br />
            <br />
            <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
        </div>
    
</asp:Content>