<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="DemanderConge.aspx.cs" Inherits="PPP_Salaire.DemanderConge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
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
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nom" DataValueField="Nom" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <p>

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT [Nom] FROM [Conge]"></asp:SqlDataSource>
        <p>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Insert" RenderOuterTable="true">
            <EditItemTemplate>
                DateDebut:
                <asp:TextBox ID="DateDebutTextBox" runat="server" Text='<%# Bind("DateDebut") %>' />
                <br />
                DateFin:
                <asp:TextBox ID="DateFinTextBox" runat="server" Text='<%# Bind("DateFin") %>' />
                <br />
                CongeID:
                <asp:TextBox ID="CongeIDTextBox" runat="server" Text='<%# Bind("CongeID") %>' />
                <br />
                NbreJours:
                <asp:TextBox ID="NbreJoursTextBox" runat="server" Text='<%# Bind("NbreJours") %>' />
                <br />
                Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                <br />
                Employe_Id:
                <asp:TextBox ID="Employe_IdTextBox" runat="server" Text='<%# Bind("Employe_Id") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                DateDebut:
                <asp:TextBox ID="DateDebutTextBox" runat="server" Text='<%# Bind("DateDebut") %>' />
                <br />
                DateFin:
                <asp:TextBox ID="DateFinTextBox" runat="server" Text='<%# Bind("DateFin") %>' />
                <br />
                CongeID:
                <asp:TextBox ID="CongeIDTextBox" runat="server" Text='<%# Bind("CongeID") %>' />
                <br />
                NbreJours:
                <asp:TextBox ID="NbreJoursTextBox" runat="server" Text='<%# Bind("NbreJours") %>' />
                <br />
                Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                <br />
                Employe_Id:
                <asp:TextBox ID="Employe_IdTextBox" runat="server" Text='<%# Bind("Employe_Id") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <td>DateDebut</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="DateDebutLabel" runat="server" Text='<%# Bind("DateDebut") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>DateFin</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="DateFinLabel" runat="server" Text='<%# Bind("DateFin") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>CongeID</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="CongeIDLabel" runat="server" Text='<%# Bind("CongeID") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>NbreJours</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="NbreJoursLabel" runat="server" Text='<%# Bind("NbreJours") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Raison</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="RaisonLabel" runat="server" Text='<%# Bind("Raison") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Employe_Id</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="Employe_IdLabel" runat="server" Text='<%# Bind("Employe_Id") %>' />
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:FormView>
        <p>
            </div></div>
            
        <div class="panel panel-default">
            <div class="panel-heading">
                Mes Demandes Conges
            </div>
            <div class="panel-body">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3"
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
                </div></div>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT [Id], [DateDebut], [DateFin], [DateSubmit], [CongeID], [NbreJours], [Raison], [Status] FROM [DemandeConges]"></asp:SqlDataSource>
        <p>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" InsertCommand="INSERT INTO [DemandeConges] ([DateDebut], [DateFin], [CongeID], [NbreJours], [Raison], [Employe_Id]) VALUES (@DateDebut, @DateFin, @CongeID, @NbreJours, @Raison, @Employe_Id)" SelectCommand="SELECT [DateDebut], [DateFin], [CongeID], [NbreJours], [Raison], [Employe_Id] FROM [DemandeConges]"></asp:SqlDataSource>
            
</form>

</asp:Content>
