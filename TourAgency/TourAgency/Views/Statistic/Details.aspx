<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TourAgency.Models.Statistic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Детализация</h2>

<fieldset>
    <legend>Statistic</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.IdStatistic) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IdStatistic) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.idTour) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idTour) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.specific) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.specific) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.countContract) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.countContract) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Изменить", "Edit", new {  id=Model.IdStatistic }) %> |
    <%: Html.ActionLink("Обратно к списку", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
