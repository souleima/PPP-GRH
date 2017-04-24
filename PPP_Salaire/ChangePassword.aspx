<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PPP_Salaire.ChangePassword" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>


<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Changer mot de passe
</asp:Content>

    <asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
 <form id="form1" runat="server">
   
     <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Edit">
         <EditItemTemplate>
             login:
             <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>' />
             <br />
             password:
             <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
             <br />
             <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
             &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
         </EditItemTemplate>
         <InsertItemTemplate>
             login:
             <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>' />
             <br />
             password:
             <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
             <br />

             <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
             &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
         </InsertItemTemplate>
         <ItemTemplate>
             login:
             <asp:Label ID="loginLabel" runat="server" Enabled Text='<%# Bind("login") %>' />
             <br />
             password:
             <asp:Label ID="passwordLabel" runat="server" Text='<%# Bind("password") %>' />
             <br />
             <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifier" />
             &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Supprimer" />
             &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nouveau" />
         </ItemTemplate>
     </asp:FormView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" DeleteCommand="DELETE FROM [Employes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Employes] ([login], [password]) VALUES (@login, @password)" SelectCommand="SELECT [login], [password] FROM [Employes] WHERE ([login] = @login)" UpdateCommand="UPDATE [Employes] SET [login] = @login, [password] = @password WHERE [Id] = @Id">
         <DeleteParameters>
             <asp:Parameter Name="Id" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="login" Type="String" />
             <asp:Parameter Name="password" Type="String" />
         </InsertParameters>
         <SelectParameters>
             <asp:SessionParameter Name="login" SessionField="user" Type="String" />
         </SelectParameters>
         <UpdateParameters>
             <asp:Parameter Name="login" Type="String" />
             <asp:Parameter Name="password" Type="String" />
             <asp:Parameter Name="Id" Type="Int32" />
         </UpdateParameters>
     </asp:SqlDataSource>
     </form>
   
      
        </asp:Content>


