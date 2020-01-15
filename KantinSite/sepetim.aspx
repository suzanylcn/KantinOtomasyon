<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sepetim.aspx.cs" Inherits="KantinSite.sepetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<section class="ftco-section ftco-cart">
		<div class="container">
			<div class="row">



				<div class="col-md-12 ftco-animate">
					<div class="cart-list">
						
						<table class="table">
							<thead class="thead-primary">
								<tr class="text-center">
									<th>&nbsp;</th>
									<th>&nbsp;</th>
									<th>Ürün</th>
									<th>Fiyat</th>
								</tr>
							</thead>
							
							<%foreach (var item in sepetList)
								{%>


							<tbody>
								<tr class="text-center">
									<td class="product-remove"><a href="sepetim.aspx?urunId=<%:item.id %>&islem=sil"><span class="icon-close"></span></a></td>

									<td class="image-prod">
										<div class="img" style="background-image: url('resimler/urun/<%:item.resim%>');"></div>
									</td>

									<td class="product-name">
										<h3><%:item.ad %></h3>
									</td>

									<td class="price"><%:item.fiyat %>₺</td>



								</tr>
							</tbody>


							<%} %>

							
						</table>
						<div id="uyarıKutu" runat="server"></div>	
						<div id="uyarı" runat="server"></div>	
					</div>
				</div>
			</div>
			<div class="row justify-content-end">
				<div class="col col-lg-3 col-md-6 mt-5 cart-wrap ftco-animate">
					<div class="cart-total mb-3">
						<h3>Sipariş Tutarı</h3>
						<p class="d-flex">
						
						
						<p class="d-flex total-price">
							<span>Toplam</span>
							<span><%:toplam %>₺</span>
						</p>
					</div>
					<p class="text-center"><a href="sepetim.aspx?islem=siparisonay" class="btn btn-primary py-3 px-4">Sepeti Onayla</a></p>
				</div>
			</div>
		</div>
	</section>
	
</asp:Content>
