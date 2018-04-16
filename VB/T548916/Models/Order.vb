Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace T548916.Models
	Public Class Order
		Public Property OrderID() As Integer
		Public Property OrderDate() As Date
		Public Property CustomerID() As String
		Public Property CustomerName() As String
		Public Property ShipCountry() As String
		Public Property ShipCity() As String
	End Class
End Namespace
