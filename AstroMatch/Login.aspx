<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="AstroMatch.Login" %>
<asp:Content ID="ContentSuccess" ContentPlaceHolderID="MaincontentPlaceHolder" runat="server">
    <div style="width:50%;margin-left:25%;margin-right:25%;">
  <center>
            <img src="https://li.hamburg.de/resource/image/651956/portrait_ratio1x1/1024/1024/dde09090198d9248538681882c258502/3B32AA69D915E341319498308C2EFC72/profilbild.jpg" alt="Usuario's Foto" style="width: 100px; height: 100px; border-radius: 50%;"/>
       
       
    
    <h1 class ="display-1 text-dark"></h1>
 <asp:TextBox class="form-control form-control-lg rounded" ID="txtemail" runat="server" placeholder="Usuario"></asp:TextBox>
<asp:TextBox class="form-control form-control-lg rounded" ID="txtPassword" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
<asp:Button class="btn btn-primary" ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
      </center> 

       
   

</div>
</asp:Content><%--  --%>