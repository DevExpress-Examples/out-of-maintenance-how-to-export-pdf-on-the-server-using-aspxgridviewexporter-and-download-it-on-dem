Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.IO
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Save_Click(ByVal sender As Object, ByVal e As EventArgs)
		WriteToPdfOnServer()
	End Sub

	Private Sub WriteToPdfOnServer()
		Dim path As String = GetPath()
		Using sr As New StreamWriter(path)
			Exporter.WritePdf(sr.BaseStream)
		End Using
	End Sub
	Private Function GetPath() As String
        Dim dirpath As String = Server.MapPath("~\App_Data")
		Dim filename As String = String.Format("{0}.pdf", ASPxGv.ID)
        Dim path As String = String.Format("{0}\{1}", dirpath, filename)
		Return path
	End Function
	Protected Sub Export_Click(ByVal sender As Object, ByVal e As EventArgs)
		Response.Buffer = True
		Response.Clear()
		Response.AddHeader("Content-Disposition", "attachment;filename=" & ASPxGv.ID & ".pdf")
		Response.ContentType = "application/pdf"
		Dim bytes() As Byte = File.ReadAllBytes(GetPath())
		Response.BinaryWrite(bytes)
		Response.Flush()
	End Sub
End Class