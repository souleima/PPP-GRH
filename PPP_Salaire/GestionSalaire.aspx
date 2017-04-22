<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="GestionSalaire.aspx.cs" Inherits="PPP_Salaire.GestionSalaire" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--  <link href="Content/bootstrap.min.css" rel="stylesheet" />-->
    <link href="Content/MyCss.less" rel="stylesheet" />
    <style>
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Gestion Salaire
</asp:Content>

<asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
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
                            <asp:DropDownList ID="DropDownListRecherche" Width="200px" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="saisir la chaine à rechercher :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtArechrcher" Width="200px" runat="server" CssClass="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <br />
                <asp:Button runat="server" Width="150px" ID="btnSearch" Text="Search"
                    CssClass="btn btn-primary" OnClick="btnSearch_Click"/>
                <asp:Button runat="server" Width="150px" ID="BtnReset" Text="Reset"
                    CssClass="btn btn-default" OnClick="btnReset_Click"/>
                                </center>
                        </td>
                    </tr>
                </table>
                    </center>
                <br />


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
