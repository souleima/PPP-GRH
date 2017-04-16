<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="GestionConge.aspx.cs" Inherits="PPP_Salaire.GestionConge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
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

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" PageSize="7"
                    AllowSorting="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse" />
                <asp:BoundField DataField="Num_SS" HeaderText="Num_SS" SortExpression="Num_SS" />
                <asp:BoundField DataField="Date_dEmbauche" HeaderText="Date_dEmbauche" SortExpression="Date_dEmbauche" />
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
                
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmployes" TypeName="PPP_Salaire.Repositories.EmployeRepository"></asp:ObjectDataSource>
</div>
        </div>
</form>
</asp:Content>
