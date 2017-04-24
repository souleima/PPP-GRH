<%@ Page Title="" Language="C#" MasterPageFile="~/Interface/pppMaster.Master" EnableEventValidation="false" AutoEventWireup="true" EnableViewState="true" CodeBehind="DemanderConge.aspx.cs" Inherits="PPP_Salaire.DemanderConge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
   <link href="../Content/MyCss.less" rel="stylesheet" />
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
                <asp:Label ID="LabelExplanation" runat="server" Text="Veuillez selectionner deux dates: date debut et date fin du congé demandé (Il suffit de selectionner deux dates en cliquant sur le calendrier ci-dessous ) :"></asp:Label>
                <br />
                <br />
                <asp:Calendar ID="Calendar" runat="server" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged" Width="100%" Height="300px" BackColor="White" BorderColor="#ffffff" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" NextPrevFormat="FullMonth" DayNameFormat="Shortest" TitleFormat="Month">
                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
                
                <br />
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelList" CssClass="form-control" runat="server" Text="Selectionner votre type de conge :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" class="styled-select" runat="server" Width="180px" DataSourceID="SqlDSList" DataTextField="Nom" DataValueField="Nom" OnSelectedIndexChanged="Page_Load">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Taper la raison pour cette demande :"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FormView ID="FormDemande" CssClass="form-control" runat="server" DefaultMode="Insert" DataSourceID="SqlDSForm" OnItemInserted="FormDemande_ItemInserted" OnItemInserting="FormDemande_ItemInserting">
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
                            <br /><br />
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
                 <td><asp:Label ID="Label1" runat="server" Text="Selectionner la colonne sujet de recherche :" CssClass="form-control"></asp:Label></td>
                 <td><asp:DropDownList ID="DropDownListColumn" class="styled-select" runat="server"  Width="200px" CssClass="form-control"></asp:DropDownList></td>
                    </tr>
                    <tr>
                 <td><asp:Label ID="Label4" runat="server" Text="saisir la chaine à rechercher :" CssClass="form-control"></asp:Label></td>
                 <td><asp:TextBox ID="TxId" Width="200px" runat="server" CssClass="form-control" /></td>
                        </tr>
                    <tr>
                <td colspan ="2"><center> <br /> <asp:Button  CssClass="btn btn-primary" runat="server" ID="btnSearch" Height="50px" Width="200px" Text="Search" OnClick="FilterResult"/></center></td>
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
                    CssClass="table table-hover"
                    class="table table-striped table-bordered table-hover" >
                    <Columns>
                        <asp:TemplateField HeaderText="Cancel">
                            <ItemTemplate>
                                <asp:Button class="btn btn-danger" Height="50px" ID="BtAnuulerDemande" runat="server" Text="Annuler" Visible='<%# IsEnAttente((String)Eval("Status")) %>' OnClick="BtAnuulerDemande_Click" />
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
                <asp:Button class="btn btn-primary btn-lg btn-block"  ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" Width="100%" />
            </div>
        </div>

        <asp:SqlDataSource ID="SqlDSForm" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT [Raison] FROM [DemandeConges]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDSList" runat="server"></asp:SqlDataSource>

    </form>

</asp:Content>
