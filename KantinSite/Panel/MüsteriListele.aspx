<%@ Page Title="" Language="C#" MasterPageFile="~/Panel/Panel.Master" AutoEventWireup="true" CodeBehind="MüsteriListele.aspx.cs" Inherits="KantinSite.Panel.MüsteriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


	<h4>Müşteriler Listesi</h4>

	<table class="table table-bordered">
		<thead>
			<tr>
				<th>#</th>
				<th>Ad Soyad</th>
				<th>Kullanıcı Adı</th>
				<th>Mail</th>
				<th>Şifre</th>
				
				<th style="width:120px;">İşlem</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var item in musteriList )
				{%>
			   <tr>

				<td><%:item.id %></td>
				<td><%:item.adsoyad %></td>
				<td><%:item.kullanıcı %></td>
				<td><%:item.mail %></td>
				<td><%:item.sifre %></td>
				<td>
					<a class="btn btn-info btn-xs" href="MüsteriListele.aspx?id=<%:item.id %>&islem=sil ">
						<i class="fa fa-trash"></i>
						Sil
					</a>
					
				</td>
			   </tr>


			<%} %>
		</tbody>
	</table>





</asp:Content>
