Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports T548916.Models
Imports DevExtreme.AspNet.Data
Imports DevExtreme.AspNet.Mvc
Imports System.Net.Http.Formatting
Imports Newtonsoft.Json
Imports System.Web.Http.ModelBinding

Namespace T548916.Controllers
	Public Class DataController
		Inherits ApiController

		Private db As New InMemoryEmployeesDataContext()

		<HttpGet>
		Public Function [Get](ByVal loadOptions As DataSourceLoadOptions) As HttpResponseMessage
			Return Request.CreateResponse(DataSourceLoader.Load(db.Employees, loadOptions))
		End Function
		<HttpGet>
		Public Function GetStates(ByVal loadOptions As DataSourceLoadOptions) As HttpResponseMessage
			Return Request.CreateResponse(DataSourceLoader.Load(SampleData.States, loadOptions))
		End Function
		<HttpPost>
		Public Function Post(ByVal form As FormDataCollection) As HttpResponseMessage
			Dim values = form.Get("values")

			Dim newEmployee = New Employee()
			JsonConvert.PopulateObject(values, newEmployee)

			Validate(newEmployee)
			If Not ModelState.IsValid Then
				Return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState))
			End If

			db.Employees.Add(newEmployee)
			db.SaveChanges()

			Return Request.CreateResponse(HttpStatusCode.Created)
		End Function

		<HttpPut>
		Public Function Put(ByVal form As FormDataCollection) As HttpResponseMessage
			Dim key = Convert.ToInt32(form.Get("key"))
			Dim values = form.Get("values")
			Dim employee = db.Employees.First(Function(e) e.ID = key)

			JsonConvert.PopulateObject(values, employee)

			Validate(employee)
			If Not ModelState.IsValid Then
				Return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState))
			End If

			db.SaveChanges()

			Return Request.CreateResponse(HttpStatusCode.OK)
		End Function

		<HttpDelete>
		Public Sub Delete(ByVal form As FormDataCollection)
			Dim key = Convert.ToInt32(form.Get("key"))
			Dim employee = db.Employees.First(Function(e) e.ID = key)

			db.Employees.Remove(employee)
			db.SaveChanges()
		End Sub
		Public Function GetFullErrorMessage(ByVal modelState As ModelStateDictionary) As String
			Dim messages = New List(Of String)()

			For Each entry In modelState
				For Each [error] In entry.Value.Errors
					messages.Add([error].ErrorMessage)
				Next [error]
			Next entry

			Return String.Join(" ", messages)
		End Function
	End Class
End Namespace