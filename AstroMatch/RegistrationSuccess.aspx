<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegistrationSuccess.aspx.cs" Inherits="AstroMatch.RegistrationSuccess" %>

<asp:Content ID="ContentSuccess" ContentPlaceHolderID="MaincontentPlaceHolder" runat="server">
    <div class="container" style="height: 90%; width: 100%">
        <div class="row" style="margin-top: 50px; margin-left: 25px; margin-right: 25px; margin-bottom: 50px;">
            <asp:Repeater ID="rptUsers" runat="server">
                <ItemTemplate>
                    <div class="col-12 col-md-6 col-lg-4 mb-2">
                        <center>
                        <img src="https://li.hamburg.de/resource/image/651956/portrait_ratio1x1/1024/1024/dde09090198d9248538681882c258502/3B32AA69D915E341319498308C2EFC72/profilbild.jpg" alt="Usuario's Foto" style="width: 100px; height: 100px; border-radius: 50%;"/>
       
                        <h3><%# Eval("Name") %> <%# Eval("HalfName") %></h3>
                        <p>Email: <%# Eval("Email") %></p>
                        <p>Date of Birth: <%# Eval("DateOfBirth") %></p>
                        <p>Sign: <%# Eval("Sign") %></p>
                        </center>
                        <!-- Agrega más campos según sea necesario -->
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
