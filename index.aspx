<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ComputerRepair.WebForm1" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <title>Repair - Home</title>
</asp:Content>

<asp:content ID="postNav" ContentPlaceHolderID="beforeContainer" runat="server">
     <div id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image:url('imgs/slide1.png');"></div>
                <div class="carousel-caption">
                    <h2>About</h2>
                    <a href="about.aspx" class="button">Learn more about us.</a>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('imgs/slide2.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Services</h2>
                    <a href="services.aspx" class="button">We offer a variety of services.</a>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('imgs/slide3.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Contact</h2>
                    <a href="services.aspx" class="button">Contact us for computer repair and hardware related issues.</a>
                </div>
            </div>
        </div>

        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </div>
</asp:content>

<asp:content ID="content" ContentPlaceHolderID="mainContent" runat="server">
    <h1 class="text-center">Services</h1>
    <div id="row">
        <div class="col-md-4 col-sm-4">
            <div class="hovereffect">
                <img class="img-responsive" src="imgs/stock/stock1.png" alt=""/>
                <div class="overlay">
                    <h2><a class="textIndex" href="services.aspx?id=1">Desktop</a></h2>
                    <p class="info">Hardware problems, virus issues, and more.</p>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-sm-6">
            <div class="hovereffect">
                <img class="img-responsive" src="imgs/stock/stock2.png" alt=""/>
                <div class="overlay">
                    <h2><a class="textIndex" href="services.aspx?id=2">Tablet</a></h2>
                    <p class="info">Screen Repair, OS faults, charger problems, headphone problems (Okay iPhone 7), etc.</p>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-sm-6">
            <div class="hovereffect">
                <img class="img-responsive" src="imgs/stock/stock3.png" alt=""/>
                <div class="overlay">
                    <h2><a class="textIndex" href="services.aspx?id=3">Laptop</a></h2>
                    <p class="info">Hardware problems, screen repair, virus issues, and more.</p>
                </div>
            </div>
        </div>
    </div>
</asp:content>
