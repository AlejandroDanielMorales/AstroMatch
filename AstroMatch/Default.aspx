<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AstroMatch.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MaincontentPlaceHolder" runat="server">

        <div class="row">
            <div class="col-md-3">
              
                          <div class="card text-white mb-3" runat="server" id="divCurrentUserCard" style="max-width: 18rem;">
                              <center>
                                 <img src='<%#currentUser.ProfilePhoto.Url%>' class="card-img-top" alt="Foto de perfil" style="border-radius: 50%;" />
                                 </center>
                                <div class="card-body">
                                    <h5 class="card-title" id="userFullName" runat="server"></h5>
                                    <p class="card-text" id="userSign" runat="server"></p>
                                    <p class="card-text" id="userElement" runat="server"></p>
                                    <p class="card-text" id="birthday" runat="server"></p>
                                    <p class="card-text" id="userGender" runat="server"></p>
                                </div>
                            </div>
                        </div>

                    
            
            <div class="col-md-8">
                <div class="container" style="max-height: 500px; overflow-y: auto;">
                    <div class="row" style="margin-top: 50px; margin-left: 25px; margin-right: 25px; margin-bottom: 50px;">
                        <asp:Repeater ID="rptUsers2" runat="server">
                            <ItemTemplate>
                                <div class="col-12 col-md-6 col-lg-4 mb-2">
                                    <center>
                                        <div class='<%# GetCardCssClass(Eval("UserSign.Element").ToString())%>' style="max-width: 18rem;">
                                            <center>
                                           <img src='<%# Eval("ProfilePhoto.Url")%>' alt="Usuario's Foto" style="width: 100px; height: 100px; border-radius: 50%;" />
                                            </center>
                                            <h3><%# Eval("Name") %> <%# Eval("HalfName") %></h3>
                                            <p>Email: <%# Eval("Email") %></p>
                                            <p>Date of Birth: <%# Eval("DateOfBirth") %></p>
                                            <p>Sign: <%# Eval("Sign") %></p>
                                        </div>
                                    </center>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>

