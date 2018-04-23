using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
#region #usings
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;
#endregion #usings

namespace DXRichEdit_SL_Formatting
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DXRichEdit_SL_Formatting.Search.docx");
            richEditControl1.LoadDocument(stream, DocumentFormat.OpenXml);

            this.biClickMe.ItemClick += new DevExpress.Xpf.Bars.ItemClickEventHandler(biClickMe_ItemClick);
        }

        void biClickMe_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            #region #formatting
            DocumentRange range = richEditControl1.Document.Selection;

            SubDocument doc = range.BeginUpdateDocument();

            CharacterProperties charprop = doc.BeginUpdateCharacters(range);
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
