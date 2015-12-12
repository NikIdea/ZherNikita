<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TourAgency.Models.Statistic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Изменить статистику</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Statistic</legend>

        <%: Html.HiddenFor(model => model.IdStatistic) %>



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


        <div style="visibility: hidden;" class="editor-label">
            <%: Html.LabelFor(model => model.idTour) %>
        </div>
        <div style="visibility: hidden;" class="editor-field">
            <%: Html.EditorFor(model => model.idTour) %>
            <%: Html.ValidationMessageFor(model => model.idTour) %>
        </div>


        <p>
            <input type="submit" value="Сохранить" />
        </p>
    </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Обратно к списку", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
