<%@ Page Title="" Language="C#" MasterPageFile="~/Back/AdminBack.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="news.Back.AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-fluid">
        <div class="layui-row">
            <form class="layui-form">
                <div class="layui-form-item">
                    <label for="L_email" class="layui-form-label">
                        <span class="x-red">*</span>用户名</label>
                    <div class="layui-input-inline">
                        <input type="text" id="L_email" name="email" required="" lay-verify="email" autocomplete="off" class="layui-input">
                    </div>
                    <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>将会成为您唯一的登入名
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="L_username" class="layui-form-label">
                        <span class="x-red">*</span>昵称</label>
                    <div class="layui-input-inline">
                        <input type="text" id="L_username" name="username" required="" lay-verify="nikename" autocomplete="off" class="layui-input">
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="L_pass" class="layui-form-label">
                        <span class="x-red">*</span>密码</label>
                    <div class="layui-input-inline">
                        <input type="password" id="L_pass" name="pass" required="" lay-verify="pass" autocomplete="off" class="layui-input">
                    </div>
                    <div class="layui-form-mid layui-word-aux">6到16个字符</div>
                </div>
                <div class="layui-form-item">
                    <label for="L_repass" class="layui-form-label">
                        <span class="x-red">*</span>确认密码</label>
                    <div class="layui-input-inline">
                        <input type="password" id="L_repass" name="repass" required="" lay-verify="repass" autocomplete="off" class="layui-input">
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="L_repass" class="layui-form-label"></label>
                    <button class="layui-btn" lay-filter="add" lay-submit="">增加</button>
                </div>
            </form>
        </div>
    </div>
    <script>
        layui.use(['form', 'layer', 'jquery'],
            function () {
                $ = layui.jquery;
                var form = layui.form,
                    layer = layui.layer;

                //自定义验证规则
                form.verify({
                    email: function (value) {
                        if (value.length < 6) {
                            return '用户名至少得6个字符啊';
                        }
                    },
                    nikename: function (value) {
                        if (value.length < 5) {
                            return '昵称至少得5个字符啊';
                        }
                    },
                    pass: [/(.+){6,12}$/, '密码必须6到12位'],
                    repass: function (value) {
                        if ($('#L_pass').val() != $('#L_repass').val()) {
                            return '两次密码不一致';
                        }
                    }
                });

                //监听提交
                form.on('submit(add)',
                    function (data) {
                        console.log(data);
                        //发异步，把数据提交给php
                        $.ajax({
                            url: "/Back/AddUser.ashx", //请求后端路径
                            type: "post",
                            data: {
                                username: $("#L_email").val(),
                                pass: $("#L_pass").val(),
                                nickName: $("#L_username").val(),
                            },
                            success: function (data) {
                                if (data == "true") {
                                    layer.alert("添加管理员成功", {
                                        icon: 6
                                    },
                                        function () {
                                            //关闭当前frame
                                            xadmin.close();

                                            // 可以对父窗口进行刷新 
                                            xadmin.father_reload();
                                        });
                                } else {
                                    layer.alert("用户名已存在！", {
                                        icon: 2
                                    });
                                }
                                
                            },
                            error: function () {
                                layer.alert("添加管理员失败！", {
                                    icon: 2
                                });
                            }

                        });

                        return false;
                    });

            });

    </script>
</asp:Content>
