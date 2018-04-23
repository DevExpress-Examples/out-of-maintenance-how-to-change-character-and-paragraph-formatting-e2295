Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports System.Windows.Media
#Region "#usings"
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usings

Namespace AgRichEditTemplate
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			richEdit1.ApplyTemplate()
			richEdit1.RichControl.VerticalScrollBarVisibility = System.Windows.Visibility.Collapsed
			richEdit1.RichControl.HorizontalScrollBarVisibility = System.Windows.Visibility.Collapsed

		End Sub

		Private Sub AgMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
'			#Region "#formatting"
			Dim range As DocumentRange = richEdit1.RichControl.Document.Selection

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
