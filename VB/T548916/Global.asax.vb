Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing

Namespace T548916

	Public Class MvcApplication
		Inherits HttpApplication

		Protected Sub Application_Start()
			AreaRegistration.RegisterAllAreas()
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
			GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
			RouteConfig.RegisterRoutes(RouteTable.Routes)
			BundleConfig.RegisterBundles(BundleTable.Bundles)

			DevExtremeBundleConfig.RegisterBundles(BundleTable.Bundles)

			DevExtreme.AspNet.Mvc.Compatibility.DataSource.UseLegacyRouting = True
		End Sub
		Public Overrides Sub Init()
			AddHandler Me.PostAuthenticateRequest, AddressOf MvcApplication_PostAuthenticateRequest
			MyBase.Init()
		End Sub

		Private Sub MvcApplication_PostAuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs)
			If HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Contains("~/api") Then
				HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required)
			End If
		End Sub
	End Class
End Namespace
