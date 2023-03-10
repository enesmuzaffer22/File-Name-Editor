using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNameEditor
{
    public partial class Form1 : Form
    {
        string folderPath = "";
        char[] specialChars = { '<', '|', ':', '"', '/', '\\', '?', '*' };

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = false;

            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button4.Enabled = false;

            textBox1.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                textBox2.Text = "Edited file name";
                textBox2.ForeColor = Color.DarkGray;
                textBox4.Text = "Edited file name";
                textBox4.ForeColor = Color.DarkGray;
                textBox3.Text = "Extension (Ex: cfg, mp3)";
                textBox3.ForeColor = Color.DarkGray;
                textBox5.Text = "Extension (Ex: cfg, mp3)";
                textBox5.ForeColor = Color.DarkGray;

                radioButton1.Checked = false;

                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button4.Enabled = true;

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button3.Enabled = false;

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, false);
                }

                listBox1.SelectionMode = SelectionMode.One;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = "Edited file name";
                textBox2.ForeColor = Color.DarkGray;
                textBox4.Text = "Edited file name";
                textBox4.ForeColor = Color.DarkGray;
                textBox3.Text = "Extension (Ex: cfg, mp3)";
                textBox3.ForeColor = Color.DarkGray;
                textBox5.Text = "Extension (Ex: cfg, mp3)";
                textBox5.ForeColor = Color.DarkGray;

                radioButton2.Checked = false;

                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button3.Enabled = true;

                textBox4.Enabled = false;
                textBox5.Enabled = false;
                button4.Enabled = false;

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, false);
                }

                listBox1.SelectionMode = SelectionMode.MultiSimple;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                listBox1.Items.Clear();
                comboBox1.Items.Clear();

                folderPath = folderDialog.SelectedPath;
                textBox1.Text = folderPath;

                string[] fileList = Directory.GetFiles(folderPath);

                HashSet<string> extensions = new HashSet<string>();

                foreach (string file in fileList)
                {
                    listBox1.Items.Add(Path.GetFileName(file));

                    foreach (string fileExtension in Directory.GetFiles(folderPath))
                    {
                        string extension = Path.GetExtension(fileExtension);

                        if (!string.IsNullOrEmpty(extension))
                        {
                            extensions.Add(extension.Substring(1));

                            if (!extensions.Contains(extension))
                            {
                                extensions.Add(extension);
                                comboBox1.Items.Add(extension);
                            }
                        }
                    }
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Edited file name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Edited file name";
                textBox2.ForeColor = Color.DarkGray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Extension (Ex: cfg, mp3)")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Extension (Ex: cfg, mp3)";
                textBox3.ForeColor = Color.DarkGray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Edited file name")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Edited file name";
                textBox4.ForeColor = Color.DarkGray;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Extension (Ex: cfg, mp3)")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Extension (Ex: cfg, mp3)";
                textBox5.ForeColor = Color.DarkGray;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, false);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedExtension = comboBox1.SelectedItem.ToString();

            listBox1.Items.Clear();

            string[] files = Directory.GetFiles(folderPath, "*" + selectedExtension);

            foreach (string file in files)
            {
                listBox1.Items.Add(Path.GetFileName(file));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(folderPath == "")
            {
                MessageBox.Show("The file path is not selected.");
            } else
            {
                listBox1.Items.Clear();
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
                comboBox1.Text = "Select extension";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int j = 0; j <= 31; j++)
            {
                if (!(textBox5.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 33; j <= 47; j++)
            {
                if (!(textBox5.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 58; j <= 64; j++)
            {
                if (!(textBox5.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 91; j <= 96; j++)
            {
                if (!(textBox5.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 123; j <= 127; j++)
            {
                if (!(textBox5.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            int flag2 = 0;

            for (int j = 0; j < specialChars.Length; j++)
            {
                if (!(textBox4.Text.IndexOf(specialChars[j]) == -1))
                {
                    flag2 = 1;
                }
            }

            if ((flag != 1) && (flag2 != 1))
            {
                if (listBox1.SelectedItem == null)
                    return;

                string selectedFile = listBox1.SelectedItem.ToString();
                string newFileName = textBox4.Text;
                string newExtension = textBox5.Text;

                if (string.IsNullOrEmpty(newFileName) || string.IsNullOrEmpty(newExtension))
                    return;

                string newFileNameWithExtension = newFileName + "." + newExtension;

                string oldFilePath = Path.Combine(folderPath, selectedFile);
                string newFilePath = Path.Combine(folderPath, newFileNameWithExtension);

                if (File.Exists(newFilePath))
                {
                    MessageBox.Show("There is already a file with this name. Please check the changes you want to make.");
                }
                else
                {
                    File.Move(oldFilePath, newFilePath);
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, newFileNameWithExtension);
                }

                textBox4.Clear();
                textBox5.Clear();
            } else
            {
                if(flag == 1)
                    MessageBox.Show("Do not use special characters while typing the extension.");

                if(flag2 == 1)
                    MessageBox.Show("Do not use special characters while typing the file name.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int j = 0; j <= 31; j++)
            {
                if (!(textBox3.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 33; j <= 47; j++)
            {
                if (!(textBox3.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 58; j <= 64; j++)
            {
                if (!(textBox3.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 91; j <= 96; j++)
            {
                if (!(textBox3.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            for (int j = 123; j <= 127; j++)
            {
                if (!(textBox3.Text.IndexOf(Convert.ToChar(j)) == -1))
                {
                    flag = 1;
                }
            }

            int flag2 = 0;

            for (int j = 0; j < specialChars.Length; j++)
            {
                if (!(textBox2.Text.IndexOf(specialChars[j]) == -1))
                {
                    flag2 = 1;
                }
            }

            if ((flag != 1) && (flag2 != 1))
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    if (listBox1.SelectedItem == null)
                        return;

                    string selectedFile = listBox1.SelectedItems[i].ToString();
                    string newFileName = textBox2.Text + " (" + (i + 1) + ")";
                    string newExtension = textBox3.Text;

                    if (string.IsNullOrEmpty(newFileName) || string.IsNullOrEmpty(newExtension))
                        return;

                    string newFileNameWithExtension = newFileName + "." + newExtension;

                    string oldFilePath = Path.Combine(folderPath, selectedFile);
                    string newFilePath = Path.Combine(folderPath, newFileNameWithExtension);

                    if (File.Exists(newFilePath))
                    {
                        MessageBox.Show("There is already a file with this name. Please check the changes you want to make.");
                        break;
                    }
                    else
                    {
                        File.Move(oldFilePath, newFilePath);
                    }
                }

                listBox1.Items.Clear();
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
            } else
            {
                if (flag == 1)
                    MessageBox.Show("Do not use special characters while typing the extension.");

                if (flag2 == 1)
                    MessageBox.Show("Do not use special characters while typing the file name.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
