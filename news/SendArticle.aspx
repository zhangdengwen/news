<%@ Page Language="C#" MasterPageFile="~/BackTemplate.Master" AutoEventWireup="true" CodeBehind="SendArticle.aspx.cs" Inherits="news.SendArticle" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" runat="server" enctype="multipart/form-data">
        <!-- 内容主体区 -->
        <section id="content">
           <div class="article-box">
               <h3>发表新闻</h3>
                <div class="article-title">
                   <p>标题：
                       <asp:TextBox ID="title" runat="server" class="title-input"></asp:TextBox>
                   </p> 
                   <p>
                       分类：
                       <select name="category" id="" class="select-input">
                           <asp:Repeater ID="cateList" runat="server">
                               <ItemTemplate>
                                   <option value="<%# Eval("id") %>"><%# Eval("catename") %></option>
                               </ItemTemplate>
                           </asp:Repeater>
                       </select>
                   </p>
                   <!-- 新闻富文本编辑器 -->
                   <div class="article-content">
                         <!-- 加载编辑器的容器 -->
                        <script id="container" name="content" type="text/plain"></script>
                        <!-- 配置文件 -->
                        <script type="text/javascript" src="/ueditor/1.4.3/ueditor.config.js"></script>
                        <!-- 编辑器源码文件 -->
                        <script type="text/javascript" src="/ueditor/1.4.3/ueditor.all.js"></script>
                       <script type="text/javascript" src="/ueditor/1.4.3/lang/zh-cn/zh-cn.js"></script>
                        <!-- 实例化编辑器 -->
                        <script type="text/javascript">
                            var ue = UE.getEditor('container',{
                                //默认的编辑区域高度
                                initialFrameHeight:300
                            });
                        </script>
                   </div>
                   <div class="article-pic">
                       封面展示：
                       <input type="radio" name="pic" value="1" checked id="">单图
                       <input type="radio" name="pic" value="2" id="">无封面
                   </div>
                   <!-- 点击图片上传的框 -->
                   <div class="pic-detail">
                       <asp:FileUpload ID="ImgUpload" runat="server" />
                   </div>
                   <p class="pic-intro">优质的封面有利于推荐，格式支持JPEG、PNG</p>
                    <asp:Button ID="save1" runat="server" class="send--btn" Text="存为草稿" OnClick="save1_Click" />
                   <asp:Button ID="save2" runat="server" class="send--btn send--active" Text="发布" OnClick="save2_Click" />
                </div>
           </div>
        </section>
    </form>
</asp:Content>
