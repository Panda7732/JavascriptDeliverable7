using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Javascriptdeliverable7
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            //if you want to call the C# code method in javascript function then write this code.
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            //disable right click on web browser control
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get the current directory of this application
            string CurrentDirectory = Directory.GetCurrentDirectory();
            //call HTML page using navigate method
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageForJavascript.html"));
        }

        private void Report()
        {
            //get html page div from id of Div
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");
            //create a simple html content
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><td><B> Hi this is my report demo</B></td></tr>");
            sb.Append("</table>");

            //assign content to the html page div which is display on browser conrol
            div.InnerHtml = sb.ToString();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //when the form is load cursor focus on the web browser control
            webBrowser1.Focus();
            //call report method which contain the report content
            Report();
        }

        public void PrintReport()
        {
            //show print dialog and call print method of webbrowser control
            DialogResult dr = printDialog1.ShowDialog();

            if (dr.ToString() =="OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }
        }
    }
}
