<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KantinSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	
	<section class="home-slider owl-carousel">
		<div class="slider-item" style="background-image: url(assets/images/bg_1.jpg);">
			<div class="overlay"></div>
			<div class="container">
				<div class="row slider-text justify-content-center align-items-center" data-scrollax-parent="true">

					<div class="col-md-8 col-sm-12 text-center ftco-animate">
						<span class="subheading">Hoşgeldiniz</span>
						<h1 class="mb-4"></h1>
						<p class="mb-4 mb-md-5"></p>
					</div>

				</div>
			</div>
		</div>

		<div class="slider-item" style="background-image: url(assets/images/bg_2.jpg);">
			<div class="overlay"></div>
			<div class="container">
				<div class="row slider-text justify-content-center align-items-center" data-scrollax-parent="true">

					<div class="col-md-8 col-sm-12 text-center ftco-animate">
						<span class="subheading">Hoşgeldiniz</span>
						<p class="mb-4 mb-md-5"></p>
					</div>

				</div>
			</div>
		</div>

		<div class="slider-item" style="background-image: url(assets/images/bg_3.jpg);">
			<div class="overlay"></div>
			<div class="container">
				<div class="row slider-text justify-content-center align-items-center" data-scrollax-parent="true">

					<div class="col-md-8 col-sm-12 text-center ftco-animate">
						<span class="subheading">Hoşgeldiniz</span>
						<h1 class="mb-4"></h1>
						<p class="mb-4 mb-md-5"></p>
					</div>

				</div>
			</div>
		</div>
	</section>



	<section class="ftco-menu">

		<div class="container">
			<div class="row justify-content-center mb-5">
				<div class="col-md-7 heading-section text-center ftco-animate">
					<span class="subheading">Keşfet</span><br />
					<h2 class="mb-4">Ürünlerimiz</h2>
					<p></p>
				</div>
			</div>
			<div class="row d-md-flex">
				<div class="col-lg-12 ftco-animate p-md-5">
					<div class="row">
						<div class="col-md-12 nav-link-wrap mb-5">
							<div class="nav ftco-animate nav-pills justify-content-center" id="v-pills-tab" role="tablist" aria-orientation="vertical">
								
								<%  foreach (var item in kategoriList)
									{ %>
										<a href="Urunler.aspx?kategoriId=<%:item.id %>" class="nav-link" style="cursor: pointer;">
											<%:item.kategoriAdi %>
										</a>
								<%  } %>
							</div>
						</div>

					</div>
				</div>
			</div>
		</div>
	</section>

</asp:Content>
