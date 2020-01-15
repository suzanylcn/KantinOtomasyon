<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="YoneticiListele.aspx.cs" Inherits="KantinSite.Panel.YoneticiListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<h4>Yöneticiler Listesi</h4>

	<table class="table table-bordered">
		<thead>
			<tr>
				<th>#</th>
				<th>Ad Soyad</th>
				<th>Kullanıcı Adı</th>
				<th>Mail</th>
				<th>Şifre</th>
				
				<th style="width:200px;">İşlem</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var item in yoneticiList )
				{%>
			   <tr>

				<td><%:item.id %></td>
				<td><%:item.adsoyad %></td>
				<td><%:item.kullanıcı %></td>
				<td><%:item.mail %></td>
				<td><%:item.sifre %></td>
				<td>
					<a class="btn btn-info btn-xs" href="YoneticiListele.aspx?id=<%:item.id %>&islem=sil ">
						<i class="fa fa-trash"></i>
						Sil
					</a>
					<a class="btn btn-warning btn-xs " href="YoneticiGuncelle.aspx?id=<%:item.id %>&islem=duzenle">
						<i class="fa fa-edit"></i>
						Düzenle
					</a>
				</td>
			   </tr>


			<%} %>
		</tbody>
	</table>
</asp:Content>
