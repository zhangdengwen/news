<%@ Page Title="" Language="C#" MasterPageFile="~/WebIndex.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="news.news" %>
<%-- 子模板页的CSS或者JS代码区域编写 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/detail.css">
</asp:Content>
<%-- 子模板内容替换区域代码编写 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- 新闻详情页的主体部分 -->
    <section id="contents">
        <div class="middle">
            <!-- 新闻盒子部分 -->
            <div class="content-detail">
                <h1>
                    <asp:Literal ID="title" runat="server"></asp:Literal>
                </h1>
                <p class="detail--intro">
                    <asp:Label ID="nickName" runat="server" Text=""></asp:Label>
                    <asp:Literal ID="titleMini" runat="server"></asp:Literal>
                </p>
                <div class="detail-box">
                    <asp:Literal ID="content" runat="server"></asp:Literal>
                </div>

                <!-- 评论区 -->
                <div class="comment-box">
                    <h2>
                        <asp:Label ID="commentNum" runat="server" Text="0"></asp:Label>
                        条评论
                    </h2>
                    <%
                        if (Session["userInfo"] != null)
                        {
                    %>
                    <asp:Image ID="userImg" CssClass="user-img" runat="server" />
                    <%}
    else
    { %>
                    请登录！
                    <%} %>
                    <asp:TextBox ID="commentSay" CssClass="commentSay" runat="server"></asp:TextBox>
                    <asp:Button ID="commentBtn" CssClass="commentBtn" runat="server" Text="评论" OnClick="sendComment" />
                    <!-- 评论列表 -->
                    <div class="comment-list">
                        <asp:Repeater ID="commentList" runat="server">
                            <ItemTemplate>
                                <!-- 单个评论内容盒子开始 -->
                                <div class="comment-item">
                                    <asp:Image ImageUrl='<%# Eval("userAvatar") %>' CssClass="item-left" runat="server" />
                                    <div class="item-right">
                                        <a href="#"><%# Eval("nickName") %></a>
                                        <span><%# Eval("createtime") %></span>
                                        <p><%# Eval("comment") %></p>
                                    </div>
                                </div>
                                <!-- 单个评论内容盒子结束 -->
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!-- 用户介绍模块 -->
            <div class="detail-user">
                <asp:Image ID="userImage" runat="server" />
                <asp:Label ID="usersName" runat="server" CssClass="user--name" Text="Label"></asp:Label>
                <div class="news-list">
                    <ul>
                        <asp:Repeater ID="sendList" runat="server">
                            <ItemTemplate>
                                <li><a href="news.aspx?id=<%# Eval("id") %>"><%# Eval("title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
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
     <!-- 返回顶部盒子 -->
     <a href="javascript:void(0);" id="return-box">
        <img src="./img/top.jpg" alt="">
    </a>
    <!-- jquery库引入 -->
    <script src="./js/jquery-3.3.1.min.js"></script>
    <script src="./js/global.js"></script>
    <script>
        // 评论功能实现
        $("#comment-btn").click(function(){
            //获取评论内容
            var say = $("#comment-say").val();
            // 判断内容输入是否为空
            if(say.trim() == "")
            {
                alert("请输入评论内容");
                $("#comment-say").focus();
                return;
            }
            //实现输入内容后，追加评论显示到下面的盒子中
            // DOM节点生成追加  $(html标签).appendTo(指定位置) 末尾追加
            // 前置追加：$(html标签).prependTo(指定位置) 
            $('<div class="comment-item"><img src="'+$(".user-img").attr('src')+'" class="item-left" alt=""><div class="item-right"><a href="#">花少爷</a><span>1小时前</span><p>'+say+'</p></div></div>').prependTo(".comment-list");

            //清空输入文本的值
            $("#comment-say").val("");
        });
    </script>

</asp:Content>
