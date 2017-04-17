<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="StatisticsConge.aspx.cs" Inherits="PPP_Salaire.StatisticsConge" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 592px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
    
     <form id="form1" runat="server">
         
         <div class="panel panel-default">
            <div class="panel-heading">
                Statistique nbre de jours par rapport à la date debut 
            </div>
            <div class="panel-body">
                <center>
        <table style="border:1px solid black; font-family:Arial">
                <tr>
                    <td>
                        <b> Select Chart Type</b>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                         <br />
                         <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" Height="549px" Width="691px" RightToLeft="No">
                             <series>
                                 <asp:Series Name="Series1" XValueMember="Id" YValueMembers="Expr1">
                                 </asp:Series>
                             </series>
                             <chartareas>
                                 <asp:ChartArea Name="ChartArea1">
                                 </asp:ChartArea>
                             </chartareas>
                         </asp:Chart>
                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PPPConnectionString %>" SelectCommand="SELECT Employes.Id, COUNT(DemandeConges.NbreJours) AS Expr1 FROM DemandeConges INNER JOIN Employes ON DemandeConges.Employe_Id = Employes.Id
Group By Employes.Id" ></asp:SqlDataSource>
                    </td>
                </tr>
            </table>            

                </center>

                </div>
            
        </div>
         <div class="panel panel-default">
            <div class="panel-heading">
                Liste des employes
            </div>
            <div class="panel-body">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" PageSize="7"
                    AllowSorting="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse" />
                <asp:BoundField DataField="Num_SS" HeaderText="Num_SS" SortExpression="Num_SS" />
                <asp:BoundField DataField="Date_dEmbauche" HeaderText="Date_dEmbauche" SortExpression="Date_dEmbauche" />
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
                
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmployes" TypeName="PPP_Salaire.Repositories.EmployeRepository"></asp:ObjectDataSource>
</div>
        </div>
</form>
</asp:Content>
