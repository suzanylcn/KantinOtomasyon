<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="UrunListele.aspx.cs" Inherits="KantinSite.Panel.UrunListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

	<h4>Ürünler Listesi</h4>
	
	<table class="table table-bordered" id="dataTable">
		<thead>
			<tr>
				<th>#</th>
				<th>Kategori Adı</th>
				<th> Adı</th>
				<th>Stok</th>
				<th>Fiyat</th>
				
				<th style="width:200px;">İşlem</th>
			</tr>
		</thead>
		<tbody>
			
			<%foreach (var item in urunList)
				{%>
			   <tr>
				<td><%:item.id %></td>
				<td><%:item.KategoriAdi %></td>
				<td><%:item.ad %></td>
				<td><%:item.stok %></td>
				<td><%:item.fiyat %></td>
				<td>
					<a class="btn btn-info btn-xs" href="UrunListele.aspx?id=<%:item.id %>&islem=sil ">
						<i class="fa fa-trash"></i>
						Sil
					</a>
					<a class="btn btn-warning btn-xs " href="UrunGuncelle.aspx?id=<%:item.id %>&islem=duzenle">
						<i class="fa fa-edit"></i>
						Düzenle
					</a>
				</td>
			   </tr>


			<%} %>
		</tbody>
	</table>









</asp:Content>
