<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="kayıtol.aspx.cs" Inherits="KantinSite.kayıtol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 


<section class="ftco-section">
		<div class="container">

			<div class="row justify-content-center mb-5 pb-3">
				<div class="col-md-7 heading-section ftco-animate text-center fadeInUp ftco-animated">
					<span class="subheading">Aşağıda hesap oluşturabilirsin.</span>
				</div>
			</div>

			<div class="row">

				<div class="contact-form col-md-4" style="margin-left: auto;margin-right: auto;">
				
						
					<div id="uyarı" runat="server"></div>	
					
					<div class="form-group">
						<asp:TextBox CssClass="form-control" placeholder="Adı Soyadı" ID="txtAdi"  runat="server"></asp:TextBox>
					</div>

					<div class="form-group">
						<asp:TextBox CssClass="form-control" placeholder="Kullanıcı Adı" ID="txtkullanici"  runat="server"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:TextBox CssClass="form-control" placeholder="E-posta" ID="txtposta" runat="server"></asp:TextBox>
					</div>

					<div class="form-group">
						<asp:TextBox CssClass="form-control" placeholder="Şifre" type="password" ID="txtSifre" runat="server"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Button CssClass="btn btn-primary" OnClick="btnGiris_Click" ID="btnGiris" runat="server" Text="Kaydet" />

					</div>
				</div>
			</div>

		</div>
	</section>











</asp:Content>
