<%@ Page  MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="PPP_Salaire.AddCategory" %>

<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>


<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Ajouter Catégorie
</asp:Content>

    <asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

        <form id="form1" runat="server">
            <asp:FormView ID="FormView1" runat="server" BackColor="Blue" DataKeyNames="Id" DataSourceID="SqlDataSource2" DefaultMode="Insert" CssClass="table table-hover table-striped">
                <EditItemTemplate>
                    Id:
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Nom:
                    <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    Nom:
                    <asp:TextBox ID="NomTextBox" runat="server" Text='<%# Bind("Nom") %>' />
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
                </ItemTemplate>
            </asp:FormView>
        
     
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" DeleteCommand="DELETE FROM [Categories] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Categories] ([Nom]) VALUES (@Nom)" SelectCommand="SELECT * FROM [Categories]" UpdateCommand="UPDATE [Categories] SET [Nom] = @Nom WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nom" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nom" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        
     
    </form>
</asp:Content>
