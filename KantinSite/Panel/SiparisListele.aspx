<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="SiparisListele.aspx.cs" Inherits="KantinSite.Panel.SiparisListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

		<h4>Siparis Listesi</h4>

	<table class="table table-bordered" id="dataTable">
		<thead>
			<tr>
				<th>#</th>
				<th>Müşteri Adı</th>
				<th>Ürün Adı</th>
				<th>Fiyat</th>
				<th>Tarih</th>
				
				<th style="width:100px;">İşlem</th>
			</tr>
		</thead>
		<tbody>
			
			<%foreach (var item in siparisList)
				{%>
			   <tr>
				<td><%:item.id %></td>
				<td><%:item.musteriAdi %></td>
				<td><%:item.urunAdi %></td>
				<td><%:item.fiyat %></td>
				<td><%:item.tarih %></td>
				<td>
					<a class="btn btn-info btn-xs" href="SiparisListele.aspx?id=<%:item.id %>&islem=sil ">
						<i class="fa fa-trash"></i>
						Sil
					</a>
					
				</td>
			   </tr>


			<%} %>
		</tbody>
	</table>


</asp:Content>
