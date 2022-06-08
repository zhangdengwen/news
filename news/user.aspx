<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="news.user" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>今日新闻网后台模块</title>
    <!-- 引入重置样式 -->
    <link rel="stylesheet" href="./css/reset.css">
    <link rel="stylesheet" href="./css/user.css">
    <style>
        .news--img {
            float: left;
            margin-right: 20px;
            width: 200px;
        }
    </style>
</head>
<body>
    <!-- 头部 -->
    <header id="header-top">
        <!-- 页眉区域 -->
        <div id="top-box">
            <div class="top-left">
                <ul>
                    <asp:Repeater ID="cateList" runat="server">
                        <ItemTemplate>
                            <li><a href="/index.aspx?id=<%# Eval("id") %>"><%# Eval("catename") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="top-right">
                <ul>
                    <%-- 今日新闻网 --%>
                    <li><a href="SendArticle.aspx">发文</a></li>
                    <%
                        if (Session["userInfo"] != null)
                        {
                    %>
                    <li><a href="userInfo.aspx">
                        <asp:Label ID="nick" runat="server" Text=""></asp:Label></a></li>
                    <%
                        }
                        else
                        {
                    %>
                    <li><a href="login.aspx">登陆</a></li>
                    <li><a href="login.aspx">注册</a></li>
                    <%} %>
                    <li><a href="#">反馈</a></li>
                    <li><a href="#">侵权投诉</a></li>
                </ul>
            </div>
        </div>
        <!-- 搜索区域 -->
        <div class="header-nav">
            <div class="middle">
                <a href="/index.aspx">
                    <img src="./img/logo.png" class="header--logo" alt="">
                </a>
                <!-- 搜索框 -->
                <div class="header-search">
                    <input type="text" name="search" placeholder="请输入需要搜索的资讯或昵称" id="search">
                    <input type="submit" id="search--btn" value="搜索">
                </div>
            </div>
        </div>
    </header>

    <!-- 内容主体区 -->
    <section id="content">
        <!-- 内容主体头部 -->
        <div class="content-header middle">
            <div class="content-bg"></div>
            <div class="content-introduce">
                <a href="userInfo.aspx">
                    <asp:Image ID="userImg" runat="server" />
                </a>
                <h3>
                    <asp:Label ID="nickName" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <!-- 内容的主体区域新闻列表 -->
        <div class="content-list">
            <asp:DataList ID="newsList" runat="server">
                <ItemTemplate>
                    <div class="content__item">
                        <a href="news.aspx?id=<%# Eval("id") %>">
                            <img src="<%# Eval("img") %>" class="news--img" alt="">
                            <h3>
                                <%# Eval("title") %>
                            </h3>
                            <p>0阅读 ⋅ 0评论 ⋅ <%# Eval("createtime") %></p>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </section>

    <!-- 底部内容区 -->
    <footer id="footer">
        <p>© 2021 今日新闻 中国互联网举报中心京ICP证140141号京ICP备12025439号-3京公网安备 11000002002023号</p>
        <p>
            <a href="#">网络文化经营许可证</a>
            <a href="#">跟帖评论自律管理承诺书</a>
            <a href="#">违法和不良信息举报电话：</a>400-140-2108
            公司名称：鲸否教育科技有限公司
        </p>
    </footer>
</body>
</html>
