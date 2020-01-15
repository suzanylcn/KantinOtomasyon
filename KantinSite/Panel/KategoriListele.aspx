<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="KantinSite.Panel.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

		<h4>Kategoriler Listesi</h4>

	<table class="table table-bordered">
		<thead>
			<tr>
				<th>#</th>
				<th>Kategori Adı</th>
				
				<th style="width:200px;">İşlem</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var item in kategoriList)
				{%>
			   <tr>
				<td><%:item.id %></td>
				<td><%:item.kategoriAdi %></td>
				<td>
					<a class="btn btn-primary btn-xs" href="KategoriListele.aspx?id=<%:item.id %>&islem=sil ">
						<i class="fa fa-trash"></i>
						Sil
					</a>
					<a class="btn btn-info btn-xs " href="KategoriGüncelle.aspx?id=<%:item.id %>&islem=duzenle">
						<i class="fa fa-edit"></i>
						Düzenle
					</a>
				</td>
			   </tr>


			<%} %>
		</tbody>
	</table>





</asp:Content>
