using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace Subtitles.Gui
{
    public partial class Form1 : Form
    {
        private SrtModel srtModel = new SrtModel();

        public Form1()
        {
            InitializeComponent();

            srtModel.SrtItemsLoaded += SrtModel_SrtItemsLoaded;
            srtModel.SrtItemsShifted += SrtModel_SrtItemsLoaded;
        }

        private void SrtModel_SrtItemsLoaded(object sender, EventArgs e)
        {
            listViewSrtItems.Items.Clear();
            foreach (var srtItem in this.srtModel.SrtItems)
            {
                var listViewItem = new ListViewItem(new string[] { srtItem.Number.ToString(), srtItem.From.ToString(), srtItem.To.ToString(), srtItem.Text });
                listViewItem.Tag = srtItem;
                listViewSrtItems.Items.Add(listViewItem);
            }
        }


        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialogSrt.ShowDialog();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBoxFilePath.Text)) { return; }

            var srtItems = SrtHandler.ReadSrt(System.IO.File.OpenRead(textBoxFilePath.Text));

            this.srtModel.AddSrtItems(srtItems);
        }

        private void openFileDialogSrt_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBoxFilePath.Text = openFileDialogSrt.FileName;

            buttonReload_Click(sender, e);
        }

        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            buttonReload.Enabled = System.IO.File.Exists(textBoxFilePath.Text);
        }

        private void listViewSrtItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSrtItems.SelectedItems.Count < 1) { return; }

            numericUpDownNumber.Value = ((SrtItem)listViewSrtItems.SelectedItems[0].Tag).Number;
            textBoxFrom.Text = ((SrtItem)listViewSrtItems.SelectedItems[0].Tag).From.ToString();
            textBoxTo.Text = ((SrtItem)listViewSrtItems.SelectedItems[0].Tag).To.ToString();
            textBoxText.Text = ((SrtItem)listViewSrtItems.SelectedItems[0].Tag).Text.ToString();
        }

        private void buttonShiftBackwards_Click(object sender, EventArgs e)
        {
            ShiftSrtItems(-1);
        }

        private void buttonShiftForward_Click(object sender, EventArgs e)
        {
            ShiftSrtItems(1);
        }

        private void ShiftSrtItems(int multiplier)
        {
            if (listViewSrtItems.SelectedItems.Count < 1) { return; }

            // Get number of selected SrtItem
            uint number = ((SrtItem)listViewSrtItems.SelectedItems[0].Tag).Number;


            // Get duration
            int duration = (int)dateTimePickerShiftDuration.Value.TimeOfDay.TotalMilliseconds + (int) numericUpDownShiftDurationMilliseconds.Value;


            this.srtModel.ShiftSrtItems(number, multiplier * duration);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.srtModel.Save(System.IO.File.OpenWrite(textBoxFilePath.Text));
        }
    }
}