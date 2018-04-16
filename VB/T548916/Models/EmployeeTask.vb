Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters
Imports System

Namespace T548916.Models
	<JsonConverter(GetType(StringEnumConverter))>
	Public Enum Priority
		High
		Normal
		Low
		Urgent
	End Enum
	Public Class EmployeeTask
		Public Property Completion() As Integer
		Public Property DueDate() As Date
		Public Property ID() As Integer
		Public Property Priority() As Priority
		Public Property StartDate() As Date
		Public Property Status() As String
		Public Property Subject() As String
	End Class
End Namespace