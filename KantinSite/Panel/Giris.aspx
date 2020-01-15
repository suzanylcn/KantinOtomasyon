<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="KantinSite.Panel.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	
	<link href="assets/css/suzangiris.css" rel="stylesheet" />
	<link href="assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />

</head>

<body>
	
    <form id="form1" runat="server">
        <div>

			<div class="formclass">
			
				<h4 class="baslik">GİRİŞ</h4>
				<div class="text-kutu">
					<i class="fa fa-user"></i>
					<asp:TextBox class="form-textbox" ID="txtkullaniciAdi" placeholder="Kullanıcı Adı Giriniz..."  AutoCompleteType="Disabled" runat="server"></asp:TextBox>
				</div>

				<div class="text-kutu">
					<i class="fa fa-lock"></i>
					<asp:TextBox class="form-textbox" ID="txtsifre" type="password" placeholder="Şifre Giriniz..." runat="server"></asp:TextBox>
				</div>

				<asp:Button class="btn" ID="btnGiris" OnClick="btnGiris_Click" runat="server" Text="Giriş Yap" />
			

				<strong>
					<%:uyarı %>
				</strong>
			</div>
		</div>
	</form>
    
</body>
</html>
