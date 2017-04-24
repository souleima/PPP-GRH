<%@ Page Title="" Language="C#" MasterPageFile="~/Interface/pppMaster.Master" AutoEventWireup="true" CodeBehind="AjouterConge.aspx.cs" Inherits="PPP_Salaire.AjouterConge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
    <form id="form1" runat="server">

        <div class="panel panel-default">
            <div class="panel-heading">
                Formulaire Conges
            </div>
            <div class="panel-body">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Remplir le formulaire çi-dessous pour ajouter un nouveau type de conge"></asp:Label>
                <br />
                <asp:FormView ID="FormView" runat="server" DefaultMode="Insert" DataSourceID="SqlDSConge">
                    <EditItemTemplate>
                        Nom:
            <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        Nom:
            <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        Nom:
            <asp:Label ID="NomLabel" runat="server" Text='<%# Bind("Nom") %>' />
                        <br />

                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="SqlDSConge" runat="server"></asp:SqlDataSource>
            </div>
        </div>

    </form>
</asp:Content>
