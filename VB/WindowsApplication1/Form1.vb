Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraPrinting

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
			Me.categoriesTableAdapter.Fill(Me.nwindDataSet.Categories)

		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim compLink As New CompositeLink(New PrintingSystem())
			Dim gridLink As New PrintableComponentLink()
			gridLink.Component = gridControl1
			Dim headerLink As New Link()
			AddHandler headerLink.CreateDetailArea, AddressOf headerLink_CreateDetailArea
			Dim footerLink As New Link()
			AddHandler footerLink.CreateDetailArea, AddressOf footerLink_CreateDetailArea
			compLink.Links.Add(headerLink)
			compLink.Links.Add(gridLink)
			compLink.Links.Add(footerLink)

			compLink.ShowPreviewDialog()
		End Sub

		Private Sub footerLink_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			Dim brick As New TextBrick(BorderSide.None,0,Color.White,Color.Gray,Color.Blue)
			brick.Text = "some footer text"
			brick.Rect = New RectangleF(0,0,400,20)
			e.Graph.DrawBrick(brick)
		End Sub

		Private Sub headerLink_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Graph.DrawString("Some header text",New RectangleF(0,0,400,20))
		End Sub
	End Class
End Namespace