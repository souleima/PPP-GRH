<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="GestionEmploye.aspx.cs" Inherits="PPP_Salaire.GestionEmploye" %>

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
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse" />
                <asp:BoundField DataField="Num_SS" HeaderText="Num_SS" SortExpression="Num_SS" />
                <asp:BoundField DataField="Date_dEmbauche" HeaderText="Date_dEmbauche" SortExpression="Date_dEmbauche" />
            
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT * FROM [Employes]" DeleteCommand="DELETE FROM [Employes] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [Employes] ([Nom], [Prenom], [Adresse], [Num_SS], [Date_dEmbauche], [Salaire_Id]) VALUES (@Nom, @Prenom, @Adresse, @Num_SS, @Date_dEmbauche, @Salaire_Id)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Employes] SET [Nom] = @Nom, [Prenom] = @Prenom, [Adresse] = @Adresse, [Num_SS] = @Num_SS, [Date_dEmbauche] = @Date_dEmbauche, [Salaire_Id] = @Salaire_Id WHERE [Id] = @original_Id">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="Num_SS" Type="Int32" />
                <asp:Parameter Name="Date_dEmbauche" Type="DateTime" />
                <asp:Parameter Name="Salaire_Id" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="Num_SS" Type="Int32" />
                <asp:Parameter Name="Date_dEmbauche" Type="DateTime" />
                <asp:Parameter Name="Salaire_Id" Type="Int32" />
                <asp:Parameter Name="original_Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
    </form>
        </asp:Content>

