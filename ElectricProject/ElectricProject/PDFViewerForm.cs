
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ElectricProject
{
    public partial class PDFViewerForm : Form
    {
        public PDFViewerForm()
        {
            InitializeComponent();
        }

        public void Loadpdf(string path)
        {
            pdfViewer1.LoadDocument(path);
        }

    }
}
