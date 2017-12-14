<%@ Page MasterPageFile="~/Interface/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="GestionEmploye.aspx.cs" Inherits="PPP_Salaire.GestionEmploye" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>


<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Gestion des Employés
</asp:Content>

    <asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

        <form id="form1" runat="server">
        <!-- Nav Starts -->

       
        <br />
        <br />
        <asp:GridView ID="GridViewEmployer" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-striped table-bordered table-condensed" OnSelectedIndexChanged="GridViewEmployer_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" />
                <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse" />
            
                <asp:BoundField DataField="NumSS" HeaderText="NumSS" SortExpression="NumSS" />
                <asp:BoundField DataField="DateEmbauche" HeaderText="DateEmbauche" SortExpression="DateEmbauche" />
                <asp:BoundField DataField="CategorieId_Id" HeaderText="CategorieId_Id" SortExpression="CategorieId_Id" />
                <asp:BoundField DataField="Salaire_Id" HeaderText="Salaire_Id" SortExpression="Salaire_Id" />
            
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT * FROM [Employes] WHERE ([login] &lt;&gt; @login)" DeleteCommand="DELETE FROM [Employes] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [Employes] ([login], [password], [Nom], [Prenom], [Adresse], [NumSS], [DateEmbauche], [CategorieId_Id], [Salaire_Id]) VALUES (@login, @password, @Nom, @Prenom, @Adresse, @NumSS, @DateEmbauche, @CategorieId_Id, @Salaire_Id)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Employes] SET [login] = @login, [password] = @password, [Nom] = @Nom, [Prenom] = @Prenom, [Adresse] = @Adresse, [NumSS] = @NumSS, [DateEmbauche] = @DateEmbauche, [CategorieId_Id] = @CategorieId_Id, [Salaire_Id] = @Salaire_Id WHERE [Id] = @original_Id">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="NumSS" Type="Int32" />
                <asp:Parameter Name="DateEmbauche" Type="DateTime" />
                <asp:Parameter Name="CategorieId_Id" Type="Int32" />
                <asp:Parameter Name="Salaire_Id" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="login" SessionField="user" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="NumSS" Type="Int32" />
                <asp:Parameter Name="DateEmbauche" Type="DateTime" />
                <asp:Parameter Name="CategorieId_Id" Type="Int32" />
                <asp:Parameter Name="Salaire_Id" Type="Int32" />
                <asp:Parameter Name="original_Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
    </form>
        </asp:Content>

