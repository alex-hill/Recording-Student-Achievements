using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Word files (*.docx)|*.docx|All files (*)|*.*";
            openFileDialog1.InitialDirectory = "Desktop";
            string file = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
            }

            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            //gets the template file
            document = application.Documents.Add(Template: @file);

            //opens the document to see changes
            application.Visible = true;

            //iterates through each mergefield in the document
            Console.WriteLine(document.StoryRanges.Count);
            foreach (Microsoft.Office.Interop.Word.Shape range in document.Shapes)
            {
                if (range.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                {
                    foreach (Microsoft.Office.Interop.Word.Field field in range.TextFrame.TextRange.Fields)
                    {
                        //checks the field name looking for correct field
                        if (field.Code.Text.Contains("First Name"))
                        {
                            //selects the field
                            field.Select();
                            //types the value (cannot be empty string)
                            application.Selection.TypeText("Alex Hill");
                        }
                        else if (field.Code.Text.Contains("This Year"))
                        {
                            field.Select();
                            application.Selection.TypeText("2016");
                        }
                    }
                }
            }
        }
    }
}
