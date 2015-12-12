<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TourAgency.Models.Contract>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Вы действительно хотите отменить контракт?</h3>
<fieldset>
    <legend>Contract</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdContract) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdContract) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.condition) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.condition) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.idTour) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idTour) %>
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
