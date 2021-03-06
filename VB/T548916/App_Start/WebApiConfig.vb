﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Namespace T548916

	Public Module WebApiConfig
		Public Sub Register(ByVal config As HttpConfiguration)
			config.MapHttpAttributeRoutes()

			config.Routes.MapHttpRoute(name:= "DefaultApi", routeTemplate:= "api/{controller}/{action}/{id}", defaults:= New With {
				Key .action = "Get",
				Key .id = RouteParameter.Optional
			})
		End Sub
	End Module

End Namespace
