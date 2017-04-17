<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="SalaireEmploye.aspx.cs" Inherits="PPP_Salaire.SalaireEmploye" %>


<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Gestion Salaire Employe
</asp:Content>

<asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

    <form id="form1" runat="server">

        <br />
        <div>
            <style>
                .tt {
                    border-spacing: 10px;
                    border-collapse: separate;
                    width: 100% !important;
                    margin: auto;
                }
            </style>

            <div class="panel panel-danger">

                <div class="panel-body">
                    <asp:Table ID="TableInfoEmploye" runat="server" CssClass="tt">
                    </asp:Table>   
                    <asp:Label ID="LabelDate" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <br />

        <div>
            <asp:Table ID="TableInfoSalaire" runat="server" CssClass="table">
            </asp:Table>
        </div>
        <br />
        <br />


        <table class="table">
            <tr>
                <th>
                    <h4>Rémunérations</h4>
                </th>
                <th>
                    <h4>Cotisations</h4>
                </th>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Table ID="TableInfoRemun" runat="server" CssClass="table">
                    </asp:Table>
                </td>
                <td style="vertical-align: top">
                    <asp:Table ID="TableInfoCotis" runat="server" CssClass="table">
                    </asp:Table>
                </td>
            </tr>
            <tfoot>
                <tr>
                    <td>
                        <asp:Label Text="Salaire brut =" runat="server"></asp:Label>
                        <asp:Label ID="LblSalaireBrut" Text="0" runat="server"></asp:Label>
                        <asp:Label Text="Net a payer =" runat="server"></asp:Label>
                        <asp:Label ID="LblNetAPayer" Text="0" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="BtnCalculerSalaire" runat="server" Text="Calculer Salaire"
                            OnClick="BtnCalculerSalaire_Click" CssClass="btn btn-info" />
                        <asp:Button ID="BtnSauvgarder" runat="server" Text="Sauvgarder"
                            OnClick="BtnSauvgarder_Click" CssClass="btn btn-success" />
                        <asp:Button ID="BtnImprimer" runat="server" Text="Imprimer"
                            OnClick="BtnImprimer_Click" CssClass="btn btn-primary" />
                        <a href="GestionSalaire.aspx" class="btn btn-default">Retour</a>                    </td>
                </tr>
            </tfoot>
        </table>


        <br />

    </form>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

</asp:Content>
