using Subtitles.Gui.Command;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace Subtitles.Gui
{
    public partial class Form1 : Form
    {
        private SrtModel srtModel = new SrtModel();
        private CommandModel commandModel = new CommandModel();

        public Form1()
        {
            InitializeComponent();

            srtModel.SrtItemsLoaded += SrtModel_SrtItemsLoaded;
            srtModel.SrtItemsShifted += SrtModel_SrtItemsShifted;
            srtModel.NumberSelectedChanged += SrtModel_NumberSelectedChanged;
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

            numericUpDownNumber.Minimum = srtModel.SrtItems.Any() ? srtModel.SrtItems.First().Number : 0;
            numericUpDownNumber.Maximum = srtModel.SrtItems.Any() ? srtModel.SrtItems.Last().Number : 0;
        }

        private void SrtModel_SrtItemsShifted(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSrtItems.Items)
            {
                item.SubItems[1].Text = ((SrtItem)item.Tag).From.ToString();
                item.SubItems[2].Text = ((SrtItem)item.Tag).To.ToString();
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

            this.srtModel.ClearSrtItems();
            this.commandModel.Clear();
            this.srtModel.AddSrtItems(srtItems);
        }

        private void openFileDialogSrt_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBoxFilePath.Text = openFileDialogSrt.FileName;

            buttonReload_Click(sender, e);
        }

        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            buttonReload.Enabled = buttonSave.Enabled = System.IO.File.Exists(textBoxFilePath.Text);
        }

        private void listViewSrtItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSrtItems.SelectedItems.Count < 1) { return; }

            this.srtModel.NumberSelected = ((SrtItem) listViewSrtItems.SelectedItems[0].Tag).Number;
        }

        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.srtModel.NumberSelected = (uint) numericUpDownNumber.Value;
        }

        private void SrtModel_NumberSelectedChanged(object sender, uint numberSelected)
        {
            var srtItemSelected = this.srtModel.SrtItems.FirstOrDefault(a => a.Number == numberSelected);

            if (srtItemSelected == null) { return; }


            int index = 0;
            foreach (ListViewItem selectedItem in listViewSrtItems.Items)
            {
                if (selectedItem.Tag == srtItemSelected)
                {
                    index = selectedItem.Index;
                    break;
                }
            }


            if (!listViewSrtItems.SelectedIndices.Contains(index))
            {
                listViewSrtItems.SelectedIndices.Add(index);
            }

            numericUpDownNumber.Value = srtItemSelected.Number;
            textBoxFrom.Text = srtItemSelected.From.ToString();
            textBoxTo.Text = srtItemSelected.To.ToString();
            textBoxText.Text = srtItemSelected.Text.ToString();
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
            uint number = ((SrtItem) listViewSrtItems.SelectedItems[0].Tag).Number;


            // Get duration
            int duration = (int) dateTimePickerShiftDuration.Value.TimeOfDay.TotalMilliseconds + (int) numericUpDownShiftDurationMilliseconds.Value;


            if (radioButton1.Checked)
            {
                this.commandModel.AddCommmand(new CommandShiftSrtItems(this.srtModel, number, multiplier * duration, true));
                this.commandModel.Redo();
            }

            if (radioButton2.Checked)
            {
                var numbersSelected = listViewSrtItems.SelectedItems.Cast<ListViewItem>().Select(lvi => lvi.Tag).Cast<SrtItem>().Select(i => i.Number);

                this.commandModel.AddCommmand(new CommandShiftSrtItemsSelected(this.srtModel, numbersSelected, multiplier * duration));
                this.commandModel.Redo();
            }

            if (radioButton3.Checked)
            {
                this.commandModel.AddCommmand(new CommandShiftSrtItems(this.srtModel, number, multiplier * duration, false));
                this.commandModel.Redo();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBoxFilePath.Text)) { return; }

            this.srtModel.Save(System.IO.File.OpenWrite(textBoxFilePath.Text));
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            this.commandModel.Undo();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            this.commandModel.Redo();
        }

        private void control_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("FileNameW")
                || !(e.Data.GetData("FileNameW") is string[])
                || ((string[]) e.Data.GetData("FileNameW")).Length != 1
                || !((string[]) e.Data.GetData("FileNameW"))[0].EndsWith(".srt"))
            {
                return;
            }

            e.Effect = DragDropEffects.Link;
        }

        private void control_DragDrop(object sender, DragEventArgs e)            
        {
            var filePath = ((string[]) e.Data.GetData("FileNameW"))[0];

            textBoxFilePath.Text = filePath;

            buttonReload_Click(sender, e);
        }
    }
}