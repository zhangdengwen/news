<%@ Page Title="" Language="C#" MasterPageFile="~/Back/AdminBack.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="news.Back.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="x-nav">
        <span class="layui-breadcrumb">
            <a href="">首页</a>
            <a href="">分类管理</a>
            <a>
                <cite>分类列表</cite></a>
        </span>
        <a class="layui-btn layui-btn-small" style="line-height: 1.6em; margin-top: 3px; float: right" onclick="location.reload()" title="刷新">
            <i class="layui-icon layui-icon-refresh" style="line-height: 30px"></i></a>
    </div>
    <div class="layui-fluid">
        <div class="layui-row layui-col-space15">
            <div class="layui-col-md12">
                <div class="layui-card">
                    <div class="layui-card-body ">

                        <form class="layui-form layui-col-space5">
                            <%-- 这里可以对用户名进行模糊查询 --%>
                            <div class="layui-inline layui-show-xs-block">
                                <asp:TextBox ID="username" placeholder="请输入分类名" autocomplete="off" class="layui-input" runat="server"></asp:TextBox>
                            </div>
                            <div class="layui-inline layui-show-xs-block">
                                <asp:Button ID="Button1" runat="server" class="layui-btn" lay-submit="" lay-filter="sreach" Text="搜索" OnClick="Button1_Click" />
                            </div>
                        </form>

                    </div>
                    <div class="layui-card-header">
                        <button type="button" class="layui-btn" onclick="xadmin.open('添加分类','AddCategory.aspx',600,400)"><i class="layui-icon"></i>添加</button>
                    </div>
                    <div class="layui-card-body layui-table-body layui-table-main">
                        <table class="layui-table layui-form">
                            <thead>
                                <tr>
                                    <th>
                                        <input type="checkbox" lay-filter="checkall" name="" lay-skin="primary">
                                    </th>
                                    <th>ID</th>
                                    <th>分类名</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="userList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input type="checkbox" name="id" value="1" lay-skin="primary">
                                            </td>
                                            <td><%# Eval("id") %></td>
                                            <td><%# Eval("catename") %></td>
                                            <td class="td-manage">
                                                <a onclick="xadmin.open('修改分类','UpdateCategory.aspx?id=<%# Eval("id") %>&catename=<%# Eval("catename") %>',600,400)" title="修改分类" href="javascript:;">
                                                    <i class="layui-icon">&#xe631;</i>
                                                </a>
                                                <a title="删除" onclick="member_del(this,'<%# Eval("id") %>')" href="javascript:;">
                                                    <i class="layui-icon">&#xe640;</i>
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="layui-card-body ">
                        <div class="page">
                            <div>
                                <% for (var i = 0; i < pageNumber; i++)
                                    { %>
                                <% if (Request["page"] == null && i == 0)
                                    { %>
                                <span class="current">1</span>
                                <% }
                                    else if (Request["page"] != null && int.Parse(Request["page"].ToString()) == (i+1))
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
            </div>
        </div>
    </div>

    <script>
        layui.use(['laydate', 'form'], function () {
            var laydate = layui.laydate;
            var form = layui.form;

            // 监听全选
            form.on('checkbox(checkall)', function (data) {

                if (data.elem.checked) {
                    $('tbody input').prop('checked', true);
                } else {
                    $('tbody input').prop('checked', false);
                }
                form.render('checkbox');
            });

            //执行一个laydate实例
            laydate.render({
                elem: '#start' //指定元素
            });

            //执行一个laydate实例
            laydate.render({
                elem: '#end' //指定元素
            });


        });

        /*用户-停用*/
        function member_stop(obj, id) {
            layer.confirm('确认要停用吗？', function (index) {

                if ($(obj).attr('title') == '启用') {

                    //发异步把用户状态进行更改
                    $(obj).attr('title', '停用')
                    $(obj).find('i').html('&#xe62f;');

                    $(obj).parents("tr").find(".td-status").find('span').addClass('layui-btn-disabled').html('已停用');
                    layer.msg('已停用!', { icon: 5, time: 1000 });

                } else {
                    $(obj).attr('title', '启用')
                    $(obj).find('i').html('&#xe601;');

                    $(obj).parents("tr").find(".td-status").find('span').removeClass('layui-btn-disabled').html('已启用');
                    layer.msg('已启用!', { icon: 5, time: 1000 });
                }

            });
        }

        /*用户-删除*/
        function member_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                //发异步删除数据
                $.ajax({
                    url: "/Back/Delete.ashx", //请求后端路径
                    type: "post",
                    data: {
                        //只要跟删除相关的操作，都可以在这里执行
                        type: "Category",
                        id: id //执行删除对应信息时的Id
                    },
                    success: function (data) {
                        if (data == "true") {
                            $(obj).parents("tr").remove();
                            layer.msg('已删除!', { icon: 1, time: 1000 });
                        } else {
                            layer.msg('删除失败！!', { icon: 2, time: 1000 });
                        }
                    },
                    error: function () {
                        layer.alert("删除信息失败！", {
                            icon: 1
                        });
                    }
                });
            });
        }



        function delAll(argument) {
            var ids = [];

            // 获取选中的id 
            $('tbody input').each(function (index, el) {
                if ($(this).prop('checked')) {
                    ids.push($(this).val())
                }
            });

            layer.confirm('确认要删除吗？' + ids.toString(), function (index) {
                //捉到所有被选中的，发异步进行删除
                layer.msg('删除成功', { icon: 1 });
                $(".layui-form-checked").not('.header').parents('tr').remove();
            });
        }
    </script>
</asp:Content>
