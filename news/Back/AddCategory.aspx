<%@ Page Title="" Language="C#" MasterPageFile="~/Back/AdminBack.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="news.Back.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layui-fluid">
        <div class="layui-row">
            <form class="layui-form">
                <div class="layui-form-item">
                    <label for="L_email" class="layui-form-label">
                        <span class="x-red">*</span>分类名称</label>
                    <div class="layui-input-inline">
                        <input type="text" id="L_email" name="email" required="" lay-verify="email" autocomplete="off" class="layui-input">
                    </div>
                    <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>分类展示
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
                        if (value.length < 1) {
                            return '分类名不能为空！';
                        }
                    },
                });

                //监听提交
                form.on('submit(add)',
                    function (data) {
                        console.log(data);
                        //发异步，把数据提交给php
                        $.ajax({
                            url: "/Back/AddCategory.ashx", //请求后端路径
                            type: "post",
                            data: {
                                catename: $("#L_email").val(),
                            },
                            success: function (data) {
                                if (data == "true") {
                                    layer.alert("添加分类成功", {
                                        icon: 6
                                    },
                                        function () {
                                            //关闭当前frame
                                            xadmin.close();

                                            // 可以对父窗口进行刷新 
                                            xadmin.father_reload();
                                        });
                                } else {
                                    layer.alert("分类已存在！", {
                                        icon: 2
                                    });
                                }
                                
                            },
                            error: function () {
                                layer.alert("添加分类失败！", {
                                    icon: 2
                                });
                            }

                        });


                        return false;
                    });

            });

    </script>
</asp:Content>

