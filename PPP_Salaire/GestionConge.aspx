<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="GestionConge.aspx.cs" Inherits="PPP_Salaire.GestionConge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Gestion Conge
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                Liste des employes
            </div>
            <div class="panel-body">
                <br />
                <center>
                    <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Selectionner la colonne sujet de recherche :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" Width="200px" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="saisir la chaine à rechercher :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxId" Width="200px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <br />
                <asp:Button runat="server" Width="200px" ID="btnSearch" Text="Search" OnClick="FilterResult" />
                                </center>
                        </td>
                    </tr>
                </table>
                    <br />
                </center>
                <asp:GridView ID="GridViewEmploye" runat="server" AllowPaging="True" PageSize="7"
                    AllowSorting="True" OnPageIndexChanging="GridViewEmploye_PageIndexChanging"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewEmploye_SelectedIndexChanged"
                    CellPadding="4" ForeColor="#333333" GridLines="None"
                    OnRowDataBound="GridViewEmploye_RowDataBound" CssClass="table table-hover">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="pagination-ys" ForeColor="#284775" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>
    </form>

</asp:Content>
