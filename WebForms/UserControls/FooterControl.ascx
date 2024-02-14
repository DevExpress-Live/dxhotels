<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FooterControl.ascx.cs" Inherits="UserControls_FooterControl" %>
<div class="footer">
    <div class="columns content-column">
		<div class="column rightBorder">
			<h5>Getting Started Today</h5>
            <div class="text">The DevExpress ASP.NET Subscription includes 110+ WebForm Controls and 70+ MVC Extensions.</div>
            <div class="text"><a class="orangeLink" href="https://www.devexpress.com/products/try/">Download your free 30-day trial</a></div>
		</div>
		<div class="column rightBorder">
			<h5>We Are Here To Help</h5>
            <div class="text">Tell us how we can help you build the next great asp.net web app.</div>
            <div class="text"><a class="orangeLink" href="mailto:info@devexpress.com">info@devexpress.com</a></div>
		</div>
		<div class="column">
			<h5>The Following DevExpress ASP.NET Controls Were Used On This Page</h5>
            <div class="text">
                ASP.NET Images Gallery<br />
                ASP.NET Data Editors Library<br />
                ASP.NET Popup Controls
            </div>
		</div>
        <div class="clear"></div>
	</div>
	<div class="info">
        <div class="content-column">
			<div class="copyright">
				Copyright (c) <%:DateTime.Today.Year.ToString()%> Developer Express Inc.
			</div>
			<div class="logo">
                <dx:ASPxHyperLink ID="DevExpressHyperLink" runat="server" ImageUrl="~/Content/Images/172x35.svg" Width="172px" Height="35px" NavigateUrl="http://www.devexpress.com/">
                </dx:ASPxHyperLink>
			</div>
        </div>
	</div>
</div>
