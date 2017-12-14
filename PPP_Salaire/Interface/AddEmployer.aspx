<%@ Page  MasterPageFile="~/Interface/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddEmployer.aspx.cs" Inherits="PPP_Salaire.AddEmployer" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>


<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Ajouter Employé
</asp:Content>

    <asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

        <form id="form1" runat="server">
        <asp:FormView ID="FormView1" runat="server"  AllowPaging="True" DataKeyNames="Id" DataSourceID="SqlDataSource2" DefaultMode="Insert">
            <EditItemTemplate>
                Nom:
                <asp:TextBox ID="NomTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Nom") %>' />
                Prenom:
                <asp:TextBox ID="PrenomTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Prenom") %>' />
                Adresse:
                <asp:TextBox ID="AdresseTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Adresse") %>' />
                NumSS:
                <asp:TextBox ID="NumSSTextBox" CssClass="form-control" runat="server" Text='<%# Bind("NumSS") %>' />
                DateEmbauche:
                <asp:TextBox ID="DateEmbaucheTextBox" CssClass="form-control" runat="server" Text='<%# Bind("DateEmbauche") %>' />
                login:
                <asp:TextBox ID="loginTextBox" CssClass="form-control" runat="server" Text='<%# Bind("login") %>' />
                password:
                <asp:TextBox ID="passwordTextBox" CssClass="form-control" runat="server" Text='<%# Bind("password") %>' />
                Id:
                <asp:Label ID="IdLabel1" runat="server" CssClass="form-control" Text='<%# Eval("Id") %>' />
              <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Nom:
                <asp:TextBox ID="NomTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Nom") %>' />
                Prenom:
                <asp:TextBox ID="PrenomTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Prenom") %>' />
                Adresse:
                <asp:TextBox ID="AdresseTextBox" CssClass="form-control" runat="server" Text='<%# Bind("Adresse") %>' />
                NumSS:
                <asp:TextBox ID="NumSSTextBox" CssClass="form-control" runat="server" Text='<%# Bind("NumSS") %>' />
                DateEmbauche:
                <asp:TextBox ID="DateEmbaucheTextBox" CssClass="form-control" runat="server" Text='<%# Bind("DateEmbauche") %>' />
                login:
                <asp:TextBox ID="loginTextBox" CssClass="form-control" runat="server" Text='<%# Bind("login") %>' />
                password:
                <asp:TextBox ID="passwordTextBox" CssClass="form-control" runat="server" Text='<%# Bind("password") %>' />
                
                <asp:LinkButton ID="InsertCancelButton" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
            </InsertItemTemplate>
            <ItemTemplate>
          
                Nom:
                <asp:Label ID="NomLabel" runat="server" CssClass="form-control" Text='<%# Bind("Nom") %>' />
                Prenom:
                <asp:Label ID="PrenomLabel" runat="server" CssClass="form-control" Text='<%# Bind("Prenom") %>' />
                Adresse:
                <asp:Label ID="AdresseLabel" runat="server" CssClass="form-control" Text='<%# Bind("Adresse") %>' />
                NumSS:
                <asp:Label ID="NumSSLabel" runat="server" CssClass="form-control" Text='<%# Bind("NumSS") %>' />
            
                DateEmbauche:
                <asp:Label ID="DateEmbaucheLabel" CssClass="form-control" runat="server" Text='<%# Bind("DateEmbauche") %>' />
            
                login:
                <asp:Label ID="loginLabel" CssClass="form-control" runat="server" Text='<%# Bind("login") %>' />
                password:
                <asp:Label ID="passwordLabel" CssClass="form-control" runat="server" Text='<%# Bind("password") %>' />
                Id:
                <asp:Label ID="IdLabel" CssClass="form-control" runat="server" Text='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:FormView>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Ajouter" OnClick="Button1_Click" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" DeleteCommand="DELETE FROM [Employes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Employes] ([Nom], [Prenom], [Adresse], [NumSS], [DateEmbauche], [login], [password]) VALUES (@Nom, @Prenom, @Adresse, @NumSS, @DateEmbauche, @login, @password)" SelectCommand="SELECT [Nom], [Prenom], [Adresse], [NumSS], [DateEmbauche], [login], [password], [Id] FROM [Employes]" UpdateCommand="UPDATE [Employes] SET [Nom] = @Nom, [Prenom] = @Prenom, [Adresse] = @Adresse, [NumSS] = @NumSS, [DateEmbauche] = @DateEmbauche, [login] = @login, [password] = @password WHERE [Id] = @Id" EnableCaching="True">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="NumSS" Type="Int32" />
                <asp:Parameter Name="DateEmbauche" Type="DateTime" />
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="password" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String" />
                <asp:Parameter Name="Prenom" Type="String" />
                <asp:Parameter Name="Adresse" Type="String" />
                <asp:Parameter Name="NumSS" Type="Int32" />
                <asp:Parameter Name="DateEmbauche" Type="DateTime" />
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>
