<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="ParametrerEmploye.aspx.cs" Inherits="PPP_Salaire.ParametrerEmploye" %>


<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Parametrage d'interface employé
</asp:Content>

<asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

 <form id="formemployer" runat="server">
     <asp:CheckBoxList ID="fields" runat="server">
      
     </asp:CheckBoxList>


     <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />


     </form>
</asp:Content>

