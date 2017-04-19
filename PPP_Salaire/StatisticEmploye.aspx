﻿<%@ Page Title="" Language="C#" MasterPageFile="~/pppMaster.Master" AutoEventWireup="true" CodeBehind="StatisticEmploye.aspx.cs" Inherits="PPP_Salaire.StatisticEmploye" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
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
                    <td colspan="2">
                         <br />
                         <asp:Chart ID="Chart" runat="server" DataSourceID="SqlDSEmployeConge">
                             <series>
                                 <asp:Series Name="Series1">
                                 </asp:Series>
                             </series>
                             <chartareas>
                                 <asp:ChartArea Name="ChartArea1">
                                 </asp:ChartArea>
                             </chartareas>
                         </asp:Chart>
                         <asp:SqlDataSource ID="SqlDSEmployeConge" runat="server"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>            

                </center>

                </div>
            
        </div>
    </form>
</asp:Content>
