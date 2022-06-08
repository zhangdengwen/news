<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="news.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>今日新闻网登陆页</title>
    <!-- 引入样式表 ctrl+/ -->
    <!-- 标签名+tab键，生成html标签 -->
    <link rel="stylesheet" href="./css/reset.css">
    <!-- login登陆页的样式表 -->
    <link rel="stylesheet" href="./css/login.css">
</head>
<body>
    <form runat="server">
    <!-- 登陆框 -->
        <div id="login-box">
            <h3>今日新闻网 登陆/注册</h3>
            <p>
                <a href="#" class="active">登陆</a>
                <a href="#">注册</a>
            </p>
            <div class="login-register">
                <div class="login-login">
                    <div>
                        用户名：
                        <asp:TextBox ID="user" Text="tom" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        密&nbsp;&nbsp;&nbsp;码：
                        <asp:TextBox ID="password" Text="hello" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="comple">
                        验证码：
                        <asp:TextBox ID="verify" MaxLength="4" runat="server"></asp:TextBox>
                        <asp:Label ID="verify__code" runat="server" Text="0000"></asp:Label>
                    </div>
                    <div>
                        <%-- CausesValidation="False"的作用是，不校验数据提交表单 --%>
                        <asp:Button ID="login__btn" runat="server" Text="登录" CausesValidation="False" OnClick="login__btn_Click"/>
                    </div>
                    <div class="lianjie">
                        <a href="#">《用户协议》</a>
                        和
                        <a href="#">《用户隐私》</a>
                        <a href="#" class="login--rem">忘记密码</a>
                    </div>
                </div>
                <div class="login-reg">
                    <div>
                        用&nbsp;&nbsp;户&nbsp;&nbsp;名：<asp:TextBox ID="newUser" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：
                        <asp:TextBox ID="newPass" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        确认密码：
                        <asp:TextBox ID="rePass" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空！" ForeColor="red" ControlToValidate="newUser"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空！" ForeColor="red" ControlToValidate="newPass"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="确认密码不能为空！" ForeColor="red" ControlToValidate="rePass"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致" ControlToCompare="newPass" ForeColor="red" ControlToValidate="rePass"></asp:CompareValidator>
                        <asp:Button ID="register__btn" runat="server" Text="注册" OnClick="register__btn_Click" />
                    </div>
                    <div class="lianjie">
                        <a href="#">《用户协议》</a>
                        和
                        <a href="#">《用户隐私》</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- 引入jquery库文件 -->
    <script src="./js/jquery-3.3.1.min.js"></script>
    <!-- jquery脚本编写 -->
    <script>
        // 通过标签名获取回来的元素，获取到的是多个标签！！
        $("#login-box p a").click(function(){
            // 如果要获取当前选中的那个a链接，需要使用$(this)获取它
            $(this).addClass("active").siblings("a").removeClass("active");

            // 先获取，当前元素的索引
            var index = $(this).index();
            console.log(index);
            // 对应的框进行显示隐藏
            $(".login-register>div").eq(index).show().siblings("div").hide();
        });
    </script>
</body>
</html>
