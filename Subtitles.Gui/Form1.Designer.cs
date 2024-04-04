namespace Subtitles.Gui
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogSrt = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.listViewSrtItems = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.groupBoxSrtItem = new System.Windows.Forms.GroupBox();
            this.buttonReload = new System.Windows.Forms.Button();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericUpDownShiftDurationMilliseconds = new System.Windows.Forms.NumericUpDown();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonShiftForward = new System.Windows.Forms.Button();
            this.buttonShiftBackwards = new System.Windows.Forms.Button();
            this.dateTimePickerShiftDuration = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            this.groupBoxSrtItem.SuspendLayout();
            this.groupBoxOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftDurationMilliseconds)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogSrt
            // 
            this.openFileDialogSrt.FileName = "openFileDialog1";
            this.openFileDialogSrt.Filter = "SRT|*.srt";
            this.openFileDialogSrt.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSrt_FileOk);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.AllowDrop = true;
            this.textBoxFilePath.Location = new System.Drawing.Point(12, 14);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(435, 20);
            this.textBoxFilePath.TabIndex = 0;
            this.textBoxFilePath.TextChanged += new System.EventHandler(this.textBoxFilePath_TextChanged);
            this.textBoxFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.control_DragDrop);
            this.textBoxFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(453, 12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(34, 23);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "...";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // listViewSrtItems
            // 
            this.listViewSrtItems.AllowDrop = true;
            this.listViewSrtItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSrtItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderText});
            this.listViewSrtItems.FullRowSelect = true;
            this.listViewSrtItems.GridLines = true;
            this.listViewSrtItems.HideSelection = false;
            this.listViewSrtItems.Location = new System.Drawing.Point(12, 40);
            this.listViewSrtItems.Name = "listViewSrtItems";
            this.listViewSrtItems.ShowGroups = false;
            this.listViewSrtItems.Size = new System.Drawing.Size(730, 244);
            this.listViewSrtItems.TabIndex = 2;
            this.listViewSrtItems.UseCompatibleStateImageBehavior = false;
            this.listViewSrtItems.View = System.Windows.Forms.View.Details;
            this.listViewSrtItems.SelectedIndexChanged += new System.EventHandler(this.listViewSrtItems_SelectedIndexChanged);
            this.listViewSrtItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.control_DragDrop);
            this.listViewSrtItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "#";
            this.columnHeaderNumber.Width = 40;
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From";
            this.columnHeaderFrom.Width = 100;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "To";
            this.columnHeaderTo.Width = 100;
            // 
            // columnHeaderText
            // 
            this.columnHeaderText.Text = "Text";
            this.columnHeaderText.Width = 500;
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.Location = new System.Drawing.Point(6, 19);
            this.numericUpDownNumber.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumber.TabIndex = 3;
            this.numericUpDownNumber.ValueChanged += new System.EventHandler(this.numericUpDownNumber_ValueChanged);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(132, 19);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.ReadOnly = true;
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrom.TabIndex = 4;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(238, 19);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.ReadOnly = true;
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTo.TabIndex = 4;
            // 
            // textBoxText
            // 
            this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxText.Location = new System.Drawing.Point(6, 45);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(901, 97);
            this.textBoxText.TabIndex = 4;
            // 
            // groupBoxSrtItem
            // 
            this.groupBoxSrtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSrtItem.Controls.Add(this.numericUpDownNumber);
            this.groupBoxSrtItem.Controls.Add(this.textBoxText);
            this.groupBoxSrtItem.Controls.Add(this.textBoxFrom);
            this.groupBoxSrtItem.Controls.Add(this.textBoxTo);
            this.groupBoxSrtItem.Location = new System.Drawing.Point(12, 290);
            this.groupBoxSrtItem.Name = "groupBoxSrtItem";
            this.groupBoxSrtItem.Size = new System.Drawing.Size(913, 148);
            this.groupBoxSrtItem.TabIndex = 5;
            this.groupBoxSrtItem.TabStop = false;
            this.groupBoxSrtItem.Text = "Details";
            // 
            // buttonReload
            // 
            this.buttonReload.Enabled = false;
            this.buttonReload.Location = new System.Drawing.Point(493, 12);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(53, 23);
            this.buttonReload.TabIndex = 1;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOperations.Controls.Add(this.buttonRedo);
            this.groupBoxOperations.Controls.Add(this.buttonUndo);
            this.groupBoxOperations.Controls.Add(this.buttonSave);
            this.groupBoxOperations.Controls.Add(this.numericUpDownShiftDurationMilliseconds);
            this.groupBoxOperations.Controls.Add(this.radioButton3);
            this.groupBoxOperations.Controls.Add(this.radioButton2);
            this.groupBoxOperations.Controls.Add(this.radioButton1);
            this.groupBoxOperations.Controls.Add(this.buttonShiftForward);
            this.groupBoxOperations.Controls.Add(this.buttonShiftBackwards);
            this.groupBoxOperations.Controls.Add(this.dateTimePickerShiftDuration);
            this.groupBoxOperations.Location = new System.Drawing.Point(748, 40);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Size = new System.Drawing.Size(177, 203);
            this.groupBoxOperations.TabIndex = 6;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Operations";
            // 
            // buttonRedo
            // 
            this.buttonRedo.Location = new System.Drawing.Point(59, 143);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(48, 23);
            this.buttonRedo.TabIndex = 9;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(6, 143);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(47, 23);
            this.buttonUndo.TabIndex = 8;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(6, 172);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(47, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // numericUpDownShiftDurationMilliseconds
            // 
            this.numericUpDownShiftDurationMilliseconds.Location = new System.Drawing.Point(85, 19);
            this.numericUpDownShiftDurationMilliseconds.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownShiftDurationMilliseconds.Name = "numericUpDownShiftDurationMilliseconds";
            this.numericUpDownShiftDurationMilliseconds.Size = new System.Drawing.Size(41, 20);
            this.numericUpDownShiftDurationMilliseconds.TabIndex = 6;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 91);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(101, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Selected && After";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 68);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Selected";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Selected && Previous";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonShiftForward
            // 
            this.buttonShiftForward.Location = new System.Drawing.Point(41, 114);
            this.buttonShiftForward.Name = "buttonShiftForward";
            this.buttonShiftForward.Size = new System.Drawing.Size(27, 23);
            this.buttonShiftForward.TabIndex = 2;
            this.buttonShiftForward.Text = ">>";
            this.buttonShiftForward.UseVisualStyleBackColor = true;
            this.buttonShiftForward.Click += new System.EventHandler(this.buttonShiftForward_Click);
            // 
            // buttonShiftBackwards
            // 
            this.buttonShiftBackwards.Location = new System.Drawing.Point(6, 114);
            this.buttonShiftBackwards.Name = "buttonShiftBackwards";
            this.buttonShiftBackwards.Size = new System.Drawing.Size(29, 23);
            this.buttonShiftBackwards.TabIndex = 1;
            this.buttonShiftBackwards.Text = "<<";
            this.buttonShiftBackwards.UseVisualStyleBackColor = true;
            this.buttonShiftBackwards.Click += new System.EventHandler(this.buttonShiftBackwards_Click);
            // 
            // dateTimePickerShiftDuration
            // 
            this.dateTimePickerShiftDuration.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerShiftDuration.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerShiftDuration.Name = "dateTimePickerShiftDuration";
            this.dateTimePickerShiftDuration.ShowUpDown = true;
            this.dateTimePickerShiftDuration.Size = new System.Drawing.Size(73, 20);
            this.dateTimePickerShiftDuration.TabIndex = 0;
            this.dateTimePickerShiftDuration.Value = new System.DateTime(2024, 3, 5, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.groupBoxSrtItem);
            this.Controls.Add(this.listViewSrtItems);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.textBoxFilePath);
            this.Name = "Form1";
            this.Text = "SRT Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            this.groupBoxSrtItem.ResumeLayout(false);
            this.groupBoxSrtItem.PerformLayout();
            this.groupBoxOperations.ResumeLayout(false);
            this.groupBoxOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftDurationMilliseconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogSrt;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.ListView listViewSrtItems;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.ColumnHeader columnHeaderText;
        private System.Windows.Forms.NumericUpDown numericUpDownNumber;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.GroupBox groupBoxSrtItem;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.GroupBox groupBoxOperations;
        private System.Windows.Forms.DateTimePicker dateTimePickerShiftDuration;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonShiftForward;
        private System.Windows.Forms.Button buttonShiftBackwards;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftDurationMilliseconds;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
    }
}

