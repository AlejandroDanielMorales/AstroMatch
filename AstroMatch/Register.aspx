 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AstroMatch.Register" %>
<asp:Content ID="ContentSuccess" ContentPlaceHolderID="MaincontentPlaceHolder" runat="server">
    <center>
        <div style="width:40%;margin-left:20%;margin-right:20%; background-image: url('imagen.jpg');
  background-repeat: no-repeat;
  background-size: cover;">
             <img src="https://c.wallhere.com/photos/d8/57/3840x2400_px_animals_bull_Colorful_digital_art_Ethernet_USB_Wires-526627.jpg!d" alt="Usuario's Foto" style="width: 100%; height: 100%; border-radius: 50%;"/>
       
       
            <h1 class="display-1 text-dark">Register</h1>
            <asp:Label class="text-secondary" ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="lblHalfName" runat="server" Text="Half Name:"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" ID="txtHalfName" runat="server"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox  class="form-control form-control-sm rounded" ID="txtEmail" runat="server"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox  class="form-control form-control-sm rounded" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="lblDateOfBirth" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox  class="form-control form-control-sm rounded" ID="txtDateOfBirth" runat="server"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="lblGender" runat="server" Text="Gender (M/F/X):"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />
             <asp:Label class="text-secondary" ID="Label4" runat="server" Text="Agregar foto de perfil"></asp:Label><br />
            <asp:FileUpload ID="fileUploadProfilePicture" runat="server" /><br /><br />
            <asp:Button class="btn btn-primary" ID="btnRegister" runat="server" Text="Register" OnClick="RegisterUser" />
            <a href="Login.aspx" class="btn btn-primary">Login</a>
            
        </div>
        </center>
</asp:Content>
 