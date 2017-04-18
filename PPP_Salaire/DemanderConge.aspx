<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="DemanderConge.aspx.cs" Inherits="PPP_Salaire.DemanderConge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Demande Conge
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

    <form id="form1" runat="server">
    
        <div class="panel panel-default">
            <div class="panel-heading">
                Formulaire Conges
            </div>
            <div class="panel-body">
        <asp:Label ID="LabelList" runat="server" Text="Selectionner votre type de conge"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDSList" DataTextField="Nom" DataValueField="Nom" OnSelectedIndexChanged="Page_Load">
        </asp:DropDownList>
                <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>

        <asp:FormView ID="FormDemande" runat="server" DefaultMode="Insert" DataSourceID="SqlDSForm" OnItemInserted="FormDemande_ItemInserted" OnItemInserting="FormDemande_ItemInserting">
            <EditItemTemplate>
                Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                <br />
                Employe_Id:
                <asp:TextBox ID="Employe_IdTextBox" runat="server" Text='<%# Bind("Employe_Id") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                <br />
                Employe_Id:
                <asp:TextBox ID="Employe_IdTextBox" runat="server" Text='<%# Bind("Employe_Id") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </InsertItemTemplate>
            <ItemTemplate>
                Raison:
                <asp:Label ID="RaisonLabel" runat="server" Text='<%# Bind("Raison") %>' />
                <br />

                Employe_Id:
                <asp:Label ID="Employe_IdLabel" runat="server" Text='<%# Bind("Employe_Id") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
            </div>
        </div>
            
        <div class="panel panel-default">
            <div class="panel-heading">
                Mes Demandes Conges
            </div>
            <div class="panel-body">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDSGrid"
                AllowPaging="True" PageSize="7"
                    AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="DateDebut" HeaderText="DateDebut" SortExpression="DateDebut" />
                    <asp:BoundField DataField="DateFin" HeaderText="DateFin" SortExpression="DateFin" />
                    <asp:BoundField DataField="DateSubmit" HeaderText="DateSubmit" SortExpression="DateSubmit" />
                    <asp:BoundField DataField="CongeID" HeaderText="CongeID" SortExpression="CongeID" />
                    <asp:BoundField DataField="NbreJours" HeaderText="NbreJours" SortExpression="NbreJours" />
                    <asp:BoundField DataField="Raison" HeaderText="Raison" SortExpression="Raison" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Cancel">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible='<%# IsEnAttente((String)Eval("Status")) %>'/>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("Id") %>'/>
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
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:SqlDataSource ID="SqlDSGrid" runat="server"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDSForm" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT [Raison], [Employe_Id] FROM [DemandeConges]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDSList" runat="server"></asp:SqlDataSource>
            
        </form>

</asp:Content>
