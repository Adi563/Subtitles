using System;
using System.Linq;
using System.Windows.Forms;

namespace Subtitles.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialogSrt.ShowDialog();
        }

        private void openFileDialogSrt_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBoxFilePath.Text = openFileDialogSrt.FileName;
        }

        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            var fileExists = System.IO.File.Exists(textBoxFilePath.Text);

            if (!fileExists) { return; }

            var srtItems = SrtHandler.ReadSrt(System.IO.File.OpenRead(textBoxFilePath.Text));

            listViewSrtItems.Items.Clear();
            foreach (var srtItem in srtItems)
            {
                var listViewItem = new ListViewItem(new string[] { srtItem.Number.ToString(), srtItem.From.ToString(), srtItem.To.ToString(), srtItem.Text });
                listViewSrtItems.Items.Add(listViewItem);
            }
        }
    }
}