Imports System
Imports System.Collections.Generic

Namespace T548916.Models
	Public Class Employee
		Public Property Address() As String
		Public Property BirthDate() As Date
		Public Property City() As String
		Public Property Email() As String
		Public Property FirstName() As String
		Public Property HireDate() As Date
		Public Property HomePhone() As String
		Public Property ID() As Integer
		Public Property LastName() As String
		Public Property Notes() As String
		Public Property Phone() As String
		Private privatePicture As String
		Public Property Picture() As String
			Get
				Return privatePicture
			End Get
			Friend Set(ByVal value As String)
				privatePicture = value
			End Set
		End Property
		Public Property Position() As String
		Public Property Prefix() As String
		Public Property Skype() As String
		Public Property State() As String
		Public Property StateID() As Integer()
		Public Property Tasks() As List(Of EmployeeTask)
	End Class
End Namespace