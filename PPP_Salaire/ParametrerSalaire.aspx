<%@ Page MasterPageFile="~/pppMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="ParametrerSalaire.aspx.cs" Inherits="PPP_Salaire.ParametrerSalaire" %>


<asp:Content ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="pageTiltleHolder" runat="server">
    Parametrage Salaire
</asp:Content>

<asp:Content ContentPlaceHolderID="PppContentPlaceHolder" runat="server">

    <form id="form1" runat="server">


        <div class="row">

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>Attributs Salaire</h3>
                        <asp:TextBox ID="TxtAttributSalaire" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="BtnAjouterAttributSalaire" runat="server" Text="Ajouter"
                            OnClick="BtnAjouterAttributSalaire_Click" CssClass="btn btn-primary" />
                    </div>
                    <br />
                    <br />
                    <asp:ListBox ID="ListBoxAttributSalaire" runat="server" Width="83%" Height="200px"></asp:ListBox>
                    <asp:Button ID="BtnSupprimerAttributSalaire" runat="server" Text="Supprimer"
                        OnClick="BtnSuprimerAttributSalaire_Click" Enabled="False" CssClass="btn btn-default" />
                    <asp:Button Text="Règle" ID="BtnSelectAttSalaire" runat="server"
                        OnClick="BtnSelectAttSalaire_Click" Enabled="false" CssClass="btn btn-default" />
                </div>

            </div>

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>les remunerations</h3>
                        <asp:TextBox ID="TxtRemuneration" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="BtnAjouterRemuneration" runat="server" Text="Ajouter"
                            OnClick="BtnAjouterRemuneration_Click" CssClass="btn btn-primary" />
                    </div>
                    <br />
                    <br />
                    <asp:ListBox ID="ListBoxRemuneration" runat="server" Width="83%" Height="200px"></asp:ListBox>
                    <asp:Button ID="BtnSupprimerRemuneration" runat="server" Text="Supprimer"
                        OnClick="BtnSupprimerRemuneration_Click" Enabled="False" CssClass="btn btn-default" />
                    <asp:Button Text="Règle" ID="BtnSelectRemuneration" runat="server"
                        OnClick="BtnSelectRemuneration_Click" Enabled="false" CssClass="btn btn-default" />

                </div>
            </div>

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="form-group">
                        <h3>les cotisations</h3>
                        <asp:TextBox ID="TxtCotisation" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="BtnAjouterCotisation" runat="server" Text="Ajouter"
                            OnClick="BtnAjouterCotisation_Click" CssClass="btn btn-primary" />
                    </div>
                    <br />
                    <br />
                    <asp:ListBox ID="ListBoxCotisation" runat="server" Width="83%" Height="200px"></asp:ListBox>
                    <asp:Button ID="BtnSupprimerCotisitaion" runat="server" Text="Supprimer"
                        OnClick="BtnSupprimerCotisitaion_Click" Enabled="False" CssClass="btn btn-default" />
                    <asp:Button Text="Règle" ID="BtnSelectCotisation" runat="server"
                        OnClick="BtnSelectCotisation_Click" Enabled="false" CssClass="btn btn-default" />

                </div>
            </div>

        </div>

        <asp:Button ID="BtnDown" Text="Down(Saisir Regle)" CssClass="btn btn-default" runat="server" OnClick="BtnDown_Click" />
        <asp:Button ID="BtnUP" Text="Up(Clear)" CssClass="btn btn-default" Enabled="false" runat="server" OnClick="BtnUP_Click" />
        <div class="panel panel-default">
            <div class="panel-heading">
                Saisi de la regle
                    
            </div>
            <div class="panel-body">


                <div class="row">

                    <div class="col-md-4" id="DivKeys" runat="server">


                        <asp:Button ID="btn_1" Text="1" runat="server" OnClick="btn_1_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_2" Text="2" runat="server" OnClick="btn_2_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_3" Text="3" runat="server" OnClick="btn_3_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_po" Text="(" runat="server" OnClick="btn_po_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_supp" Text="<-" runat="server" OnClick="btn_supp_Click" CssClass="btn btn-default" />
                        <br />
                        <asp:Button ID="btn_4" Text="4" runat="server" OnClick="btn_4_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_5" Text="5" runat="server" OnClick="btn_5_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_6" Text="6" runat="server" OnClick="btn_6_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_pf" Text=")" runat="server" OnClick="btn_pf_Click" CssClass="btn btn-default" />
                        <br />
                        <asp:Button ID="btn_7" Text="7" runat="server" OnClick="btn_7_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_8" Text="8" runat="server" OnClick="btn_8_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_9" Text="9" runat="server" OnClick="btn_9_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_plus" Text="+" runat="server" OnClick="btn_plus_Click" CssClass="btn btn-default" />
                        <br />
                        <asp:Button ID="btn_0" Text="0" runat="server" OnClick="btn_0_Click1" CssClass="btn btn-default" />
                        <asp:Button ID="btn_point" Text="." runat="server" OnClick="btn_point_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_moins" Text="-" runat="server" OnClick="btn_moins_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_div" Text="/" runat="server" OnClick="btn_div_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btn_mult" Text="*" runat="server" OnClick="btn_mult_Click" CssClass="btn btn-default" />

                    </div>
                    <div class="col-md-8">

                        <div id="ExpressionDiv" runat="server">
                        </div>
                    </div>
                </div>



            </div>

        </div>

    </form>

</asp:Content>

