using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    public static class PrinterUtils
    {
        static string Text { get; set; }
        public static void Print(string TextToPrint)
        {
            Text = TextToPrint;
            PrintDocument Document = new PrintDocument();
            Document.DocumentName = "Разплащателен Документ";
            Document.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = Document;
            printDialog.ShowDialog();
            Document.Dispose();

        }

        private static void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(Text, new Font("Time New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }
    }
}
