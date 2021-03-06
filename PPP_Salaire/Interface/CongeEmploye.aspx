﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Interface/pppMaster.Master" AutoEventWireup="true" CodeBehind="CongeEmploye.aspx.cs" Inherits="PPP_Salaire.CongeEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
    <form id="form1" runat="server">

        <div class="panel panel-default">
            <div class="panel-heading">
                Historique des Conges
            </div>
            <div class="panel-body">
                <br />
                <center>
                    <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="Selectionner la colonne sujet de recherche :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListColumn" CssClass="form-control" Width="200px" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="saisir la chaine à rechercher :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxId" CssClass="form-control" Width="200px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <br />
                <asp:Button CssClass="btn btn-primary" runat="server" Width="200px" ID="btnSearch" Text="Search" OnClick="FilterResult" />
                                </center>
                        </td>
                    </tr>
                </table>
                    <br />
                <asp:GridView ID="GridViewDemande" runat="server" AllowPaging="True" PageSize="7"
                    AllowSorting="True" AutoGenerateSelectButton="True" OnPageIndexChanging="GridViewDemande_PageIndexChanging" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Accepter">
                            <ItemTemplate>
                                <asp:Button ID="btAccept" class="btn btn-success" runat="server" Text="Accepter" Visible='<%# IsEnAttente((String)Eval("Status")) %>' OnClick="btAccept_Click" />
                                <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("Id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Refuser">
                            <ItemTemplate> 
                                <asp:Button ID="btRefuser" class="btn btn-danger" runat="server" Text="Refuser" Visible='<%# IsEnAttente((String)Eval("Status")) %>' OnClick="btRefuser_Click" />
                                <asp:HiddenField ID="HiddenFieldID2" runat="server" Value='<%# Eval("Id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
