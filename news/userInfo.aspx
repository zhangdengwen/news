<%@ Page Title="" Language="C#" MasterPageFile="~/UserTemplete.Master" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="news.userInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .introduce{
            width:200px;
            height:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-list">
        <form runat="server">
            <h3>编辑资料</h3>
            <div class="content-item">
                <p>
                    头像：
                    <asp:Image ID="imgBox" CssClass="head-img" runat="server" />
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </p> 
                <p>昵称：
                    <asp:TextBox ID="nickNames" runat="server"></asp:TextBox>
                </p>
                <p>
                    介绍：
                    <asp:TextBox ID="introduce" CssClass="introduce" TextMode="MultiLine" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="notice" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <asp:Button ID="btn" runat="server" CssClass="update--btn" Text="修改资料" OnClick="btn_Click" />
                </p>
            </div>
        </form>
    </div>
</asp:Content>
