<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TourAgency.Models.Tour>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Вы действительно хотите удалить?</h3>
<fieldset>
    <legend>Tour</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdTour) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdTour) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.nameTour) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nameTour) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.description) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.description) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.price) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.price) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.startDate) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.startDate) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Обратно к списку", "Index") %>
    </p>
<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
