Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.IO
Imports System.Reflection
#Region "#usings"
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit
#End Region ' #usings

Namespace DXRichEdit_SL_Formatting
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			Dim stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Search.docx")
			richEditControl1.LoadDocument(stream, DocumentFormat.OpenXml)

			AddHandler biClickMe.ItemClick, AddressOf biClickMe_ItemClick
		End Sub

		Private Sub biClickMe_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
'			#Region "#formatting"
			Dim range As DocumentRange = richEditControl1.Document.Selection

			Dim doc As SubDocument = range.BeginUpdateDocument()

			Dim charprop As CharacterProperties = doc.BeginUpdateCharacters(range)
			charprop.BackColor = Colors.Yellow
			charprop.AllCaps = True
			doc.EndUpdateCharacters(charprop)

			Dim parprop As ParagraphProperties = doc.BeginUpdateParagraphs(range)
			parprop.Alignment = ParagraphAlignment.Center
			doc.EndUpdateParagraphs(parprop)

			range.EndUpdateDocument(doc)
'			#End Region ' #formatting
		End Sub
	End Class
End Namespace
