﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="KantinSite.Panel.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<h4>Kategori Ekle</h4>

	<div class="col-md-4">
	<div class="form-group">	
			<asp:Label CssClass="control-label" Text="Kategori Adı" runat="server" />
			<asp:TextBox CssClass="form-control" ID="txtktgr" runat="server"></asp:TextBox>
		</div>
		<asp:Button CssClass="btn  btn-info" ID="btKaydet" runat="server" OnClick="btKaydet_Click" Text="Kaydet" />

	</div>
</asp:Content>
