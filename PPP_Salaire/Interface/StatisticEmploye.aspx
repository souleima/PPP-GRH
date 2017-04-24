<%@ Page Title="" Language="C#" MasterPageFile="~/Interface/pppMaster.Master" AutoEventWireup="true" CodeBehind="StatisticEmploye.aspx.cs" Inherits="PPP_Salaire.StatisticEmploye" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Statistique
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                Statistique nbre de jours par rapport à la date debut 
            </div>
            <div class="panel-body">
                <table style="border: 1px solid black; font-family: Arial">
                    <tr>
                        <td>
                            <b>Select Chart Type</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Chart ID="Chart" runat="server" DataSourceID="SqlDSEmployeConge">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDSEmployeConge" runat="server"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</asp:Content>
