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
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.groupBoxSrtItem = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            this.groupBoxSrtItem.SuspendLayout();
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
            this.textBoxFilePath.Location = new System.Drawing.Point(12, 14);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(435, 20);
            this.textBoxFilePath.TabIndex = 0;
            this.textBoxFilePath.TextChanged += new System.EventHandler(this.textBoxFilePath_TextChanged);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(453, 12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // listViewSrtItems
            // 
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
            this.listViewSrtItems.Location = new System.Drawing.Point(12, 40);
            this.listViewSrtItems.MultiSelect = false;
            this.listViewSrtItems.Name = "listViewSrtItems";
            this.listViewSrtItems.ShowGroups = false;
            this.listViewSrtItems.Size = new System.Drawing.Size(776, 244);
            this.listViewSrtItems.TabIndex = 2;
            this.listViewSrtItems.UseCompatibleStateImageBehavior = false;
            this.listViewSrtItems.View = System.Windows.Forms.View.Details;
            this.listViewSrtItems.SelectedIndexChanged += new System.EventHandler(this.listViewSrtItems_SelectedIndexChanged);
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
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "#";
            this.columnHeaderNumber.Width = 40;
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.Location = new System.Drawing.Point(6, 19);
            this.numericUpDownNumber.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumber.TabIndex = 3;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(132, 19);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrom.TabIndex = 4;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(238, 19);
            this.textBoxTo.Name = "textBoxTo";
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
            this.textBoxText.Size = new System.Drawing.Size(764, 97);
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
            this.groupBoxSrtItem.Size = new System.Drawing.Size(776, 148);
            this.groupBoxSrtItem.TabIndex = 5;
            this.groupBoxSrtItem.TabStop = false;
            this.groupBoxSrtItem.Text = "Details";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxSrtItem);
            this.Controls.Add(this.listViewSrtItems);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.textBoxFilePath);
            this.Name = "Form1";
            this.Text = "SRT Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            this.groupBoxSrtItem.ResumeLayout(false);
            this.groupBoxSrtItem.PerformLayout();
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
    }
}

