namespace WAW_CAT_Tranlsate_XLZ
{
    partial class TranslateXLZ
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listSourceFiles = new System.Windows.Forms.ListBox();
            this.listTargetFiles = new System.Windows.Forms.ListBox();
            this.listXLZFiles = new System.Windows.Forms.ListBox();
            this.readSourceFiles = new System.Windows.Forms.Button();
            this.clearSourceFiles = new System.Windows.Forms.Button();
            this.readTargetFiles = new System.Windows.Forms.Button();
            this.clearTargetFiles = new System.Windows.Forms.Button();
            this.readXLZFiles = new System.Windows.Forms.Button();
            this.clearXLZFiles = new System.Windows.Forms.Button();
            this.translateFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSourceFiles
            // 
            this.listSourceFiles.FormattingEnabled = true;
            this.listSourceFiles.Location = new System.Drawing.Point(13, 13);
            this.listSourceFiles.Name = "listSourceFiles";
            this.listSourceFiles.Size = new System.Drawing.Size(165, 238);
            this.listSourceFiles.TabIndex = 0;
            this.listSourceFiles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listTargetFiles
            // 
            this.listTargetFiles.FormattingEnabled = true;
            this.listTargetFiles.Location = new System.Drawing.Point(197, 13);
            this.listTargetFiles.Name = "listTargetFiles";
            this.listTargetFiles.Size = new System.Drawing.Size(165, 238);
            this.listTargetFiles.TabIndex = 1;
            this.listTargetFiles.SelectedIndexChanged += new System.EventHandler(this.listTargetFiles_SelectedIndexChanged);
            // 
            // listXLZFiles
            // 
            this.listXLZFiles.FormattingEnabled = true;
            this.listXLZFiles.Location = new System.Drawing.Point(382, 13);
            this.listXLZFiles.Name = "listXLZFiles";
            this.listXLZFiles.Size = new System.Drawing.Size(165, 238);
            this.listXLZFiles.TabIndex = 2;
            this.listXLZFiles.SelectedIndexChanged += new System.EventHandler(this.listXLZFiles_SelectedIndexChanged);
            // 
            // readSourceFiles
            // 
            this.readSourceFiles.Location = new System.Drawing.Point(13, 258);
            this.readSourceFiles.Name = "readSourceFiles";
            this.readSourceFiles.Size = new System.Drawing.Size(75, 24);
            this.readSourceFiles.TabIndex = 3;
            this.readSourceFiles.Text = "Read Files";
            this.readSourceFiles.UseVisualStyleBackColor = true;
            // 
            // clearSourceFiles
            // 
            this.clearSourceFiles.Location = new System.Drawing.Point(13, 288);
            this.clearSourceFiles.Name = "clearSourceFiles";
            this.clearSourceFiles.Size = new System.Drawing.Size(75, 23);
            this.clearSourceFiles.TabIndex = 4;
            this.clearSourceFiles.Text = "Clear Files";
            this.clearSourceFiles.UseVisualStyleBackColor = true;
            // 
            // readTargetFiles
            // 
            this.readTargetFiles.Location = new System.Drawing.Point(197, 257);
            this.readTargetFiles.Name = "readTargetFiles";
            this.readTargetFiles.Size = new System.Drawing.Size(75, 23);
            this.readTargetFiles.TabIndex = 5;
            this.readTargetFiles.Text = "Read Files";
            this.readTargetFiles.UseVisualStyleBackColor = true;
            // 
            // clearTargetFiles
            // 
            this.clearTargetFiles.Location = new System.Drawing.Point(197, 288);
            this.clearTargetFiles.Name = "clearTargetFiles";
            this.clearTargetFiles.Size = new System.Drawing.Size(75, 23);
            this.clearTargetFiles.TabIndex = 6;
            this.clearTargetFiles.Text = "Clear Files";
            this.clearTargetFiles.UseVisualStyleBackColor = true;
            // 
            // readXLZFiles
            // 
            this.readXLZFiles.Location = new System.Drawing.Point(382, 257);
            this.readXLZFiles.Name = "readXLZFiles";
            this.readXLZFiles.Size = new System.Drawing.Size(75, 23);
            this.readXLZFiles.TabIndex = 7;
            this.readXLZFiles.Text = "Read Files";
            this.readXLZFiles.UseVisualStyleBackColor = true;
            // 
            // clearXLZFiles
            // 
            this.clearXLZFiles.Location = new System.Drawing.Point(382, 287);
            this.clearXLZFiles.Name = "clearXLZFiles";
            this.clearXLZFiles.Size = new System.Drawing.Size(75, 23);
            this.clearXLZFiles.TabIndex = 8;
            this.clearXLZFiles.Text = "Clear Files";
            this.clearXLZFiles.UseVisualStyleBackColor = true;
            // 
            // translateFiles
            // 
            this.translateFiles.Location = new System.Drawing.Point(139, 334);
            this.translateFiles.Name = "translateFiles";
            this.translateFiles.Size = new System.Drawing.Size(290, 54);
            this.translateFiles.TabIndex = 9;
            this.translateFiles.Text = "Translate";
            this.translateFiles.UseVisualStyleBackColor = true;
            // 
            // TranslateXLZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 423);
            this.Controls.Add(this.translateFiles);
            this.Controls.Add(this.clearXLZFiles);
            this.Controls.Add(this.readXLZFiles);
            this.Controls.Add(this.clearTargetFiles);
            this.Controls.Add(this.readTargetFiles);
            this.Controls.Add(this.clearSourceFiles);
            this.Controls.Add(this.readSourceFiles);
            this.Controls.Add(this.listXLZFiles);
            this.Controls.Add(this.listTargetFiles);
            this.Controls.Add(this.listSourceFiles);
            this.Name = "TranslateXLZ";
            this.Text = "Translate XLZ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listSourceFiles;
        private System.Windows.Forms.ListBox listTargetFiles;
        private System.Windows.Forms.ListBox listXLZFiles;
        private System.Windows.Forms.Button readSourceFiles;
        private System.Windows.Forms.Button clearSourceFiles;
        private System.Windows.Forms.Button readTargetFiles;
        private System.Windows.Forms.Button clearTargetFiles;
        private System.Windows.Forms.Button readXLZFiles;
        private System.Windows.Forms.Button clearXLZFiles;
        private System.Windows.Forms.Button translateFiles;
    }
}

