using System;
using System.Windows.Controls;
using System.Windows.Media;
#region #usings;
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace AgRichEditTemplate
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            richEdit1.ApplyTemplate();
            richEdit1.RichControl.VerticalScrollBarVisibility = System.Windows.Visibility.Collapsed;
            richEdit1.RichControl.HorizontalScrollBarVisibility = System.Windows.Visibility.Collapsed;
 
        }

        private void AgMenuItem_Click(object sender, EventArgs e)
        {
            #region #formatting
            DocumentRange range = richEdit1.RichControl.Document.Selection;
            
            SubDocument doc = range.BeginUpdateDocument();
            
            CharacterProperties charprop =  doc.BeginUpdateCharacters(range);
            charprop.BackColor = Colors.Yellow;
            charprop.AllCaps = true;
            doc.EndUpdateCharacters(charprop);

            ParagraphProperties parprop = doc.BeginUpdateParagraphs(range);
            parprop.Alignment = ParagraphAlignment.Center;
            doc.EndUpdateParagraphs(parprop);

            range.EndUpdateDocument(doc);
            #endregion #formatting
        }
    }
}
