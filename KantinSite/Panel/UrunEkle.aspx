<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="KantinSite.Panel.UrunEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<h4>Ürün Ekle</h4>
	<div class="col-md-4">

		 <div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Kategori"></asp:Label>
            <asp:DropDownList  CssClass="form-control" ID="drpKtgr" runat="server"></asp:DropDownList>

	        </div>
		

	        <div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Ürün Adı"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txturun" runat="server"></asp:TextBox>
	        </div> 

		  

	     <div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Stok Sayısı"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtstok" runat="server"></asp:TextBox>
	        </div>

		<div class="form-group">
			<asp:Label CssClass="control-label" runat="server" Text="Fiyat"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtfiyat" runat="server"></asp:TextBox>
	        </div>

		<div class="form-group">	
			<asp:Label CssClass="control-label" Text="Resim Ekle" runat="server" />
			<asp:FileUpload ID="FileResim" runat="server" />
		</div>

		<asp:Button CssClass="btn btn-info" ID="btnKaydet" Onclick="btnKaydet_Click" runat="server" Text="Kaydet" />

 </div>
</asp:Content>
