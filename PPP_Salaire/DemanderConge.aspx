<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" EnableViewState="true" CodeBehind="DemanderConge.aspx.cs" Inherits="PPP_Salaire.DemanderConge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>
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
                <asp:Label ID="LabelExplanation" runat="server" Text="Veuillez selectionner deux dates: date debut et date fin du congé demandé (Il suffit de selectionner deux dates en cliquant sur le calendrier ci-dessous ) :"></asp:Label>
                <br />
                <br />
                <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged" Width="100%" Height="50%"></asp:Calendar>

                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelList" runat="server" Text="Selectionner votre type de conge :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="180px" DataSourceID="SqlDSList" DataTextField="Nom" DataValueField="Nom" OnSelectedIndexChanged="Page_Load">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Taper la raison pour cette demande :"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FormView ID="FormDemande" runat="server" DefaultMode="Insert" DataSourceID="SqlDSForm" OnItemInserted="FormDemande_ItemInserted" OnItemInserting="FormDemande_ItemInserting">
                                <EditItemTemplate>
                                    Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                                    <br />
                                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Mettre à jour" />
                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    Raison:
                <asp:TextBox ID="RaisonTextBox" runat="server" Text='<%# Bind("Raison") %>' />
                                    <br />
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insérer" />
                                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" />
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    Raison:
                <asp:Label ID="RaisonLabel" runat="server" Text='<%# Bind("Raison") %>' />
                                    <br />

                                </ItemTemplate>
                            </asp:FormView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                Mes Demandes Conges
            </div>
            <div class="panel-body">
                <br />
                <center>
                <table>
                    <tr>
                 <td><asp:Label ID="Label1" runat="server" Text="Selectionner la colonne sujet de recherche :"></asp:Label></td>
                 <td><asp:DropDownList ID="DropDownListColumn" runat="server" Height="20px"  Width="200" ></asp:DropDownList></td>
                    </tr>
                    <tr>
                 <td><asp:Label ID="Label4" runat="server" Text="saisir la chaine à rechercher :"></asp:Label></td>
                 <td><asp:TextBox ID="TxId" Width="200px" runat="server" Height="20px"  /></td>
                        </tr>
                    <tr>
                <td colspan ="2"><center> <asp:Button runat="server" ID="btnSearch" Width="200px" Text="Search" OnClick="FilterResult"/></center></td>
                </tr>
                </table>
                    </center>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Ci-dessous vous trouvez vos demandes de conges, tant que le status est 'EN_ATTENTE', vous pouvez annuler la demande correspondante. Status idique aussi la decision du dirigeant (REFUSE, ACCEPTE) ."></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridViewDemandesConge" runat="server" AllowPaging="True" PageSize="7"
                    AllowSorting="True" OnPageIndexChanging="GridViewEmploye_PageIndexChanging" OnRowDataBound="GridViewEmploye_RowDataBound"
                    CellPadding="4" ForeColor="#333333" GridLines="None"
                    CssClass="table table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Cancel">
                            <ItemTemplate>
                                <asp:Button ID="BtAnuulerDemande" runat="server" Text="Annuler" Visible='<%# IsEnAttente((String)Eval("Status")) %>' OnClick="BtAnuulerDemande_Click" />
                                <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# Eval("Id") %>' />
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

        <asp:SqlDataSource ID="SqlDSForm" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT [Raison] FROM [DemandeConges]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDSList" runat="server"></asp:SqlDataSource>

    </form>

</asp:Content>
