Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web

Namespace T548916.Models
	Public Class InMemoryEmployeesDataContext
		Private Const SessionKey As String = "3fd387f5-610a-4060-9204-619ef6e6f3ef"

		Public ReadOnly Property Employees() As ICollection(Of Employee)
			Get
				Dim session = HttpContext.Current.Session
				If session(SessionKey) Is Nothing Then
					session(SessionKey) = SampleData.DataGridEmployees
				End If

				Return DirectCast(session(SessionKey), ICollection(Of Employee))
			End Get
		End Property

		Public Sub SaveChanges()
			For Each employee In Employees.Where(Function(a) a.ID = 0)
				employee.ID = Employees.Max(Function(a) a.ID) + 1
			Next employee
		End Sub
	End Class
End Namespace
