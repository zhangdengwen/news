<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="news.Search" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>今日新闻网首页</title>
    <!-- 引入公共样式 -->
    <link rel="stylesheet" href="./css/reset.css">
    <link rel="stylesheet" href="./css/index.css">
    <link rel="stylesheet" href="/Content/css/xadmin.css">
    <style>
        body{
            background:#fff;
        }
    </style>
</head>
<body>
    <!-- 头部 -->
    <!-- 头部 -->
    <header id="header-top">
        <!-- 页眉区域 -->
        <div id="top-box">
            <div class="top-left">
                <ul>
                    <li><a href="index.aspx">首页</a></li>
                    <asp:Repeater ID="cateList" runat="server">
                        <ItemTemplate>
                            <li><a href="/index.aspx?id=<%# Eval("id") %>"><%# Eval("catename") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="top-right">
                <ul>
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
                    <li><a href="login.aspx" style="display: inline-block;">登陆</a></li>
                    <li><a href="login.aspx" style="display: inline-block;">注册</a></li>
                    <%} %>
                    <li><a href="">反馈</a></li>
                    <li><a href="">侵权投诉</a></li>
                </ul>
            </div>
        </div>
    </header>


    <!-- 新闻的主体内容区 -->
    <section id="content">
        <!-- 左边导航 -->
        <div class="content-nav">
            <a href="/index.aspx"><img src="./img/logo.png" alt=""></a>
            <ul>
                <li class="<%if (Request["id"] == null) { Response.Write("active"); } %>"><a href="index.aspx">首页</a></li>
                <asp:Repeater ID="navList" runat="server">
                    <ItemTemplate>
                        <li class="<%# (Request["id"]!=null && Request["id"] == DataBinder.Eval(Container.DataItem, "id").ToString()) ? "active":" " %>"><a href="index.aspx?id=<%# Eval("id") %>"><%# Eval("catename") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- 中间新闻列表 -->
        <div class="content-list">
            <% if (pageNumber == 0)
                { %>
            <p style="text-align:center">未找到相关新闻哦~快来发表吧</p>
            <%} %>
            <asp:Repeater ID="newsList" runat="server">
                <ItemTemplate>
                    <div class="list-item">
                        <a href='news.aspx?id=<%#Eval("id") %>'>

                            <img src="<%# Eval("img").ToString()  %>" class="news--img" alt="<%# Eval("title") %>" title="<%# Eval("title") %>" />

                            <h3 class="news--h3">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                            </h3>
                            <div>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("catename") %>'></asp:Label>
                                <asp:Image ID="Image2" ImageUrl='<%# Eval("userAvatar") %>' runat="server" />
                                <asp:Literal ID="Label3" runat="server" Text='<%# Eval("nickName") %>'></asp:Literal>
                                ⋅ 
                                <asp:Literal ID="Label4" runat="server" Text='<%# Eval("createtime") %>'></asp:Literal>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- 分页 --%>
            <div class="layui-card-body ">
                <div class="page">
                    <div>
                        <% for (var i = 0; i < pageNumber; i++)
                            { %>
                        <% if (Request["page"] == null && i == 0)
                            { %>
                        <span class="current">1</span>
                        <% }
                            else if (Request["page"] != null && int.Parse(Request["page"].ToString()) == (i + 1))
                            { %>
                        <span class="current"><%=(i+1) %></span>
                        <%}
                            else
                            { %>
                        <a class="num" href="?page=<%=(i+1) %>"><%=(i+1) %></a>
                        <% }

                            }%>
                    </div>
                </div>
            </div>
        </div>
        <!-- 右边信息展示 -->
        <div class="content-right">
            <!-- 搜索框 -->
            <div class="header-search">
                <%-- 实现模糊搜索的功能代码 --%>
                <form action="/Search.aspx" method="get">
                    <input type="text" name="keyword" placeholder="请输入需要搜索的内容！ " id="search">
                    <input type="submit" id="search--btn" value="搜索">
                </form>
                <%-- 新增代码结束 --%>
            </div>
            <!-- 登陆显示框 -->
            <div class="right-login">
                <!-- 登陆盒子 -->
                <div class="login-box">
                    <%
                        if (Session["userInfo"] != null)
                        {
                    %>
                    <!-- 2、显示登陆后的状态 -->
                    <div class="login-register">
                        <p>
                            <a href="#">退出登陆</a>
                        </p>
                        <a href="user.aspx">
                            <asp:Image ID="userImg" runat="server" />
                        </a>
                        <h5><a href="user.aspx">
                            <asp:Label ID="nickName" runat="server" Text=""></asp:Label>
                        </a></h5>
                        <a href="SendArticle.aspx" class="send--link">发布</a>
                    </div>
                    <%
                        }
                        else
                        {
                    %>
                    <!-- 1、没有登陆时，显示点击登陆，可以跳转登陆 -->
                    <a href="login.aspx" class="send--link">登陆</a>
                    <%} %>
                </div>
            </div>
            <!-- 页脚部分 -->
            <div class="right-login">
                <p>© 2021 今日头条</p>
                <p>扫黄打非网上举报</p>
                <p>网络谣言曝光台</p>
                <p>中国互联网举报中心 京ICP证140141号</p>
                <p>京ICP备12025439号-3 网络文化经营许可证</p>
                <p>营业执照</p>
                <p>违法和不良信息举报：400-140-2108</p>
                <p>举报邮箱：jubao@toutiao.com</p>
                <p>公司名称：鲸否教育科技有限公司</p>
                <p>京公网安备 11000002002023号</p>
            </div>
        </div>
    </section>

    <!-- 返回顶部盒子 -->
    <a href="javascript:void(0);" id="return-box">
        <img src="./img/top.jpg" alt="">
    </a>
    <!-- jquery库引入 -->
    <script src="./js/jquery-3.3.1.min.js"></script>
    <script src="./js/global.js"></script>
</body>
</html>

