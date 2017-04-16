<%@ Page  MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddEmployer.aspx.cs" Inherits="PPP_Salaire.AddEmployer" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>


<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Ajouter Employé
</asp:Content>

    <asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

        <form id="form1" runat="server">
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="Id" DataSourceID="SqlDataSource2" DefaultMode="Insert" BackColor="Blue" CellSpacing="1" CssClass="table table-hover table-striped">
            <EditItemTemplate>
                Id:
                <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                Prenom:
                <asp:TextBox ID="PrenomTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                <br />
                Adresse:
                <asp:TextBox ID="AdresseTextBox" runat="server" Text='<%# Bind("Adresse") %>' />
                <br />
                Num_SS:
                <asp:TextBox ID="Num_SSTextBox" runat="server" Text='<%# Bind("Num_SS") %>' />
                <br />
                Date_dEmbauche:
                <asp:TextBox ID="Date_dEmbaucheTextBox" runat="server" Text='<%# Bind("Date_dEmbauche") %>' />
                <br />
                Salaire_Id:
                <asp:TextBox ID="Salaire_IdTextBox" runat="server" Text='<%# Bind("Salaire_Id") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Nom:
                <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                Prenom:
                <asp:TextBox ID="PrenomTextBox" runat="server" Text='<%# Bind("Prenom") %>' />
                <br />
                Adresse:
                <asp:TextBox ID="AdresseTextBox" runat="server" Text='<%# Bind("Adresse") %>' />
                <br />
                Num_SS:
                <asp:TextBox ID="Num_SSTextBox" runat="server" Text='<%# Bind("Num_SS") %>' />
                <br />
                Date_dEmbauche:
                <asp:TextBox ID="Date_dEmbaucheTextBox" runat="server" Text='<%# Bind("Date_dEmbauche") %>' />
                <br />
                Salaire_Id:
                <asp:TextBox ID="Salaire_IdTextBox" runat="server" Text='<%# Bind("Salaire_Id") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </InsertItemTemplate>
            <ItemTemplate>
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Nom:
                <asp:Label ID="NomLabel" runat="server" Text='<%# Bind("Nom") %>' />
                <br />
                Prenom:
                <asp:Label ID="PrenomLabel" runat="server" Text='<%# Bind("Prenom") %>' />
                <br />
                Adresse:
                <asp:Label ID="AdresseLabel" runat="server" Text='<%# Bind("Adresse") %>' />
                <br />
                Num_SS:
                <asp:Label ID="Num_SSLabel" runat="server" Text='<%# Bind("Num_SS") %>' />
                <br />
                Date_dEmbauche:
                <asp:Label ID="Date_dEmbaucheLabel" runat="server" Text='<%# Bind("Date_dEmbauche") %>' />
                <br />
                Salaire_Id:
                <asp:Label ID="Salaire_IdLabel" runat="server" Text='<%# Bind("Salaire_Id") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifier" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Supprimer" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nouveau" />
            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" DeleteCommand="DELETE FROM [Employes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Employes] ([Nom], [Prenom], [Adresse], [Num_SS], [Date_dEmbauche], [Salaire_Id]) VALUES (@Nom, @Prenom, @Adresse, @Num_SS, @Date_dEmbauche, @Salaire_Id)" SelectCommand="SELECT * FROM [Employes]" UpdateCommand="UPDATE [Employes] SET [Nom] = @Nom, [Prenom] = @Prenom, [Adresse] = @Adresse, [Num_SS] = @Num_SS, [Date_dEmbauche] = @Date_dEmbauche, [Salaire_Id] = @Salaire_Id WHERE [Id] = @Id" EnableCaching="True">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
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
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>
