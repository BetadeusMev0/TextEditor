using System.Diagnostics.Contracts;

namespace TextEditor
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox.Text= string.Empty;
        }

        private string path = "";

        private string tmp = "";


        private void SetPath(string path) 
        {
            this.path = path;
            PathLabel.Text = path;
        }


        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) SaveToFile(); 
            switch (e.KeyCode) 
            {
                case Keys.F1:
                    Point point = this.Location;
                    point.X += 8;
                    point.Y += 30 + buttonContext.Height;
                    contextMenuStrip1.Show(point);
                    break;
                case Keys.F2:
                    richTextBox.Text = string.Empty;
                    break;
                case Keys.F4:
                    WriteOpenFile();
                    break;
                case Keys.F5:
                    SaveFile();
                    break;
                case Keys.F6:
                    CreateCatalog();
                    break;

                case Keys.F7:
                    DeleteFile();
                    break;

                case Keys.Enter:
                    if (isCreate)
                    {
                        Directory.CreateDirectory(richTextBox.Text);
                        SetPath(richTextBox.Text + "\\" + richTextBox.Text + ".txt");
                        richTextBox.Text = tmp;
                        SaveToFile();
                        labelStatus.Text = "";
                        isCreate= false;
                    }


                    break;
            } 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile() 
        {
            saveFileDialog1.Filter = "TXT(*.TXT)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox.Text);
                SetPath(saveFileDialog1.FileName);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            WriteOpenFile();
        }
        private void WriteOpenFile() 
        {
            openFileDialog1.Filter = "TXT(*.TXT)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Text = File.ReadAllText(openFileDialog1.FileName);
                SetPath(openFileDialog1.FileName);
            }
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile() 
        {
            if (path != null && path != "")
                File.WriteAllText(path, richTextBox.Text);
        }

        private void buttonCreateCatalog_Click(object sender, EventArgs e)
        {
            CreateCatalog();
        }

        private void CreateCatalog() 
        {
            tmp = richTextBox.Text;
            labelStatus.Text = "¬ведите им€ каталога";
            richTextBox.Text = string.Empty;
            isCreate = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        private void DeleteFile() 
        {
            File.Delete(path);
            SetPath("");
        }



        private bool isCreate = false;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point point = this.Location;
            point.X += 8;
            point.Y += 30 + buttonContext.Height;
            contextMenuStrip1.Show(point);
        }

        private void daasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = string.Empty;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteOpenFile();

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCatalog();
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        private void buttonContext_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(buttonContext,"f1 дл€ быстрого доступа");
        }

        private void daasToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}