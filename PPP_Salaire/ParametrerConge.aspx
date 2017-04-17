<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="ParametrerConge.aspx.cs" Inherits="PPP_Salaire.ParametrerConge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                Specification : 
            </div>
            <div class="panel-body">

        <asp:Label ID="Label1" runat="server" Text="Retour Vendredi :">  </asp:Label>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Oui" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Non"/>
            </div>
            </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                Formulaire Ajout Conges
            </div>
            <div class="panel-body">
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Insert" CellPadding="4" ForeColor="#333333">
            <EditItemTemplate>
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                NbJours:
                <asp:TextBox ID="NbJoursTextBox" runat="server" Text='<%# Bind("NbJours") %>' />
                <br />
                Justifié:
                <asp:TextBox ID="JustifiéTextBox" runat="server" Text='<%# Bind("Justifié") %>' />
                <br />
                Par_Jours_De_Travail:
                <asp:TextBox ID="Par_Jours_De_TravailTextBox" runat="server" Text='<%# Bind("Par_Jours_De_Travail") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                NbJours:
                <asp:TextBox ID="NbJoursTextBox" runat="server" Text='<%# Bind("NbJours") %>' />
                <br />
                Justifié:
                <asp:TextBox ID="JustifiéTextBox" runat="server" Text='<%# Bind("Justifié") %>' />
                <br />
                Par_Jours_De_Travail:
                <asp:TextBox ID="Par_Jours_De_TravailTextBox" runat="server" Text='<%# Bind("Par_Jours_De_Travail") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </InsertItemTemplate>
            <ItemTemplate>
                Nom:
                <asp:Label ID="NomLabel" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                NbJours:
                <asp:Label ID="NbJoursLabel" runat="server" Text='<%# Bind("NbJours") %>' />
                <br />
                Justifié:
                <asp:Label ID="JustifiéLabel" runat="server" Text='<%# Bind("Justifié") %>' />
                <br />
                Par_Jours_De_Travail:
                <asp:Label ID="Par_Jours_De_TravailLabel" runat="server" Text='<%# Bind("Par_Jours_De_Travail") %>' />
                <br />

            </ItemTemplate>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:FormView>
                </div>
            </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                Conges Ajouté à la base de donnée : 
            </div>
            <div class="panel-body">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT DISTINCT [Nom], [NbJours], [Justifié], [Par_Jours_De_Travail] FROM [Conges]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-hover" 
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="NbJours" HeaderText="NbJours" SortExpression="NbJours" />
                <asp:BoundField DataField="Par_Jours_De_Travail" HeaderText="Par_Jours_De_Travail" SortExpression="Par_Jours_De_Travail" />
                <asp:BoundField DataField="Justifié" HeaderText="Justifié" SortExpression="Justifié" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" DeleteCommand="DELETE FROM [Conges] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Conges] ([Nom], [NbJours], [Par_Jours_De_Travail], [Justifié]) VALUES (@Nom, @NbJours, @Par_Jours_De_Travail, @Justifié)" SelectCommand="SELECT * FROM [Conges]" UpdateCommand="UPDATE [Conges] SET [Nom] = @Nom, [NbJours] = @NbJours, [Par_Jours_De_Travail] = @Par_Jours_De_Travail, [Justifié] = @Justifié WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="NbJours" Type="Int32" />
                <asp:Parameter Name="Par_Jours_De_Travail" Type="Int32" />
                <asp:Parameter Name="Justifié" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="NbJours" Type="Int32" />
                <asp:Parameter Name="Par_Jours_De_Travail" Type="Int32" />
                <asp:Parameter Name="Justifié" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
                </div>
            </div>
    </form>

</asp:Content>
