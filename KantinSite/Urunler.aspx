<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="KantinSite.Urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	
	<section class="ftco-section">
		<div class="container">
			
			<div class="row justify-content-center mb-5 pb-3">
				<div class="col-md-7 heading-section ftco-animate text-center fadeInUp ftco-animated">
					<span class="subheading">Ürünler</span>
					<h2 class="mb-4"></h2>
				</div>
			</div>
			
			<div class="row">
				<%foreach (var item in urunlist)
					{%>


				<div class="col-md-3">
					<div class="menu-entry">
						<a href="#" class="img" style="background-image: url('resimler/urun/<%:item.resim %>');"></a>
						<div class="text text-center pt-4">
							<h3><a href="#"><%:item.ad %></a></h3>
							<p class="price"><span><%:item.fiyat %> ₺</span></p>


							<p><a href="Urunler.aspx?urunId=<%:item.id %>&islem=siparis" class="btn btn-primary btn-outline-primary">sipariş ver</a></p>
							
							<p><a href="Urunler.aspx?urunId=<%:item.id %>&islem=sepetekle" class="btn btn-primary btn-outline-primary">Sepete Ekle</a></p>
						
						</div>
					</div>
					
				</div>




					<%} %>

			</div>

		</div>

	</section>
</asp:Content>
