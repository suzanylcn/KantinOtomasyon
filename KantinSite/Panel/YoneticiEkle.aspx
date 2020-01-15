<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="YoneticiEkle.aspx.cs" Inherits="KantinSite.Panel.YoneticiEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

	<h4>Yönetici Ekle</h4>
	<div class="col-md-4">


	        <div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Adı Soyadı"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtAdSoyad" runat="server"></asp:TextBox>
	        </div> 
		  

	     <div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Kullanıcı Adı"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtKullanici" runat="server"></asp:TextBox>
	        </div>

		<div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Mail"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtmail" runat="server"></asp:TextBox>
	        </div>

		<div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Şifre"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtsifre" runat="server"></asp:TextBox>
	        </div>

		<asp:Button CssClass="btn btn-info" ID="btnKaydet" Onclick="btnKaydet_Click" runat="server" Text="Kaydet" />

 </div>
</asp:Content>
