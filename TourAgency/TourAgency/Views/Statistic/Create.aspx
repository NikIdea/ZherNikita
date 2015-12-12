<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TourAgency.Models.Statistic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Добавить статистику по туру</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Statistic</legend>

     <h4> Tour number </h4>
        <div class="editor-field">
            <%: Html.DropDownList("idTour") %>
            <%: Html.ValidationMessageFor(model => model.idTour) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.specific) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.specific) %>
            <%: Html.ValidationMessageFor(model => model.specific) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.countContract) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.countContract) %>
            <%: Html.ValidationMessageFor(model => model.countContract) %>
        </div>

        <p>
            <input type="submit" value="Добавить" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Обратно к списку", "Index") %>
    <%: Html.ActionLink("Главная страница", "Home", "Index")%>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
