<%@ Page Title="" Language="C#" MasterPageFile="~/Interface/pppMaster.Master" AutoEventWireup="true" CodeBehind="ParametrerSalaireV2.aspx.cs" Inherits="PPP_Salaire.ParametrerSalaireV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <style>
    </style>
    <!-- custom style goes here -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Parametrer Salaire
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PppContentPlaceHolder" runat="server">


    <form id="form1" runat="server">

        <div class="row">

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>Attributs Salaire</h3>
                        <asp:CheckBoxList ID="ChkListAttSalaire" runat="server">
                        </asp:CheckBoxList>
                        <asp:ListBox ID="ListBoxAttSalaire" Width="83%" Height="200px"
                            Visible="false" runat="server"></asp:ListBox>
                        <asp:Button Text="Ajouter à la Règle" ID="BtnSelectAttSalaire" runat="server"
                            Visible="false" CssClass="btn btn-default" OnClick="BtnSelectAttSalaire_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>les remunerations</h3>
                        <asp:CheckBoxList ID="ChkListRemuneration" runat="server">
                        </asp:CheckBoxList>
                        <asp:ListBox ID="ListBoxRemuneration" Width="83%" Height="200px"
                            Visible="false" runat="server"></asp:ListBox>
                        <asp:Button Text="Ajouter à la Règle" ID="BtnSelectRemuneration" runat="server"
                            Visible="false" CssClass="btn btn-default" OnClick="BtnSelectRemuneration_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>les cotisations</h3>
                        <asp:CheckBoxList ID="ChkListCotisation" runat="server">
                        </asp:CheckBoxList>
                        <asp:ListBox ID="ListBoxCotisation" Width="83%" Height="200px"
                            Visible="false" runat="server"></asp:ListBox>
                        <asp:Button Text="Ajouter à la Règle" ID="BtnSelectCotisation" runat="server"
                            Visible="false" CssClass="btn btn-default" OnClick="BtnSelectCotisation_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="BtnSaisirRegle" Text="Saisir la Regle" CssClass="btn btn-default" runat="server" OnClick="BtnSaisirRegle_Click" />
        <br />
        <div class="panel panel-default" runat="server" id="PanelCalc" visible="false">
            <div class="panel-heading">
                <div runat="server" id="goregle"></div>
            </div>
            <div class="panel-body">


                <div class="row">

                    <div class="col-md-4" id="DivKeys" runat="server">

                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_1" Text="1" runat="server" OnClick="btn_1_Click" CssClass="btn btn-default" /></td>
                                <td>
                                    <asp:Button ID="btn_2" Text="2" runat="server" OnClick="btn_2_Click" CssClass="btn btn-default" /></td>
                                <td>
                                    <asp:Button ID="btn_3" Text="3" runat="server" OnClick="btn_3_Click" CssClass="btn btn-default" /></td>
                                <td>
                                    <asp:Button ID="btn_po" Text="(" runat="server" OnClick="btn_po_Click" CssClass="btn btn-default" /></td>
                                <td>
                                    <asp:Button ID="btn_supp" Text="<-" runat="server" OnClick="btn_supp_Click" CssClass="btn btn-default" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_4" Text="4" runat="server" OnClick="btn_4_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_5" Text="5" runat="server" OnClick="btn_5_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_6" Text="6" runat="server" OnClick="btn_6_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_pf" Text=")" runat="server" OnClick="btn_pf_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_mult" Text="*" runat="server" OnClick="btn_mult_Click" CssClass="btn btn-default" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_7" Text="7" runat="server" OnClick="btn_7_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_8" Text="8" runat="server" OnClick="btn_8_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_9" Text="9" runat="server" OnClick="btn_9_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_plus" Text="+" runat="server" OnClick="btn_plus_Click" CssClass="btn btn-default" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_0" Text="0" runat="server" OnClick="btn_0_Click1" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_point" Text="." runat="server" OnClick="btn_point_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_moins" Text="-" runat="server" OnClick="btn_moins_Click" CssClass="btn btn-default" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_div" Text="/" runat="server" OnClick="btn_div_Click" CssClass="btn btn-default" />
                                </td>
                            </tr>
                        </table>

                        <br />

                        <asp:Button ID="BtnSauvgarder" runat="server" Text="Sauvgarder" CssClass="btn btn-success" OnClick="BtnSauvgarder_Click" />
                    </div>
                    <div class="col-md-8">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div id="ExpressionDiv" runat="server" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btn_0" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_1" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_2" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_3" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_4" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_5" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_6" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_7" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_8" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_9" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_po" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_supp" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_pf" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_mult" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_plus" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_point" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_moins" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btn_div" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="BtnSelectCotisation" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="BtnSelectAttSalaire" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="BtnSelectRemuneration" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                </div>
            </div>
        </div>
    </form>
</asp:Content>
