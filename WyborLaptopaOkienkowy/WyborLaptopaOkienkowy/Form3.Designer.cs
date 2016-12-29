namespace WyborLaptopaOkienkowy
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.database1DataSet = new WyborLaptopaOkienkowy.Database1DataSet();
            this.notebooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notebooksTableAdapter = new WyborLaptopaOkienkowy.Database1DataSetTableAdapters.NotebooksTableAdapter();
            this.tableAdapterManager = new WyborLaptopaOkienkowy.Database1DataSetTableAdapters.TableAdapterManager();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Notebook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Processor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Graphics = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAMM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HDDCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SSDCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sizee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Weightt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pricee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notebooksBindingSource
            // 
            this.notebooksBindingSource.DataMember = "Notebooks";
            this.notebooksBindingSource.DataSource = this.database1DataSet;
            // 
            // notebooksTableAdapter
            // 
            this.notebooksTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.NotebooksTableAdapter = this.notebooksTableAdapter;
            this.tableAdapterManager.UpdateOrder = WyborLaptopaOkienkowy.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 152);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(923, 43);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nowy wybór";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 13);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(923, 133);
            this.textBox2.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Notebook,
            this.Processor,
            this.Graphics,
            this.RAMM,
            this.HDDCapacity,
            this.SSDCapacity,
            this.Sizee,
            this.Weightt,
            this.Pricee});
            this.listView1.Location = new System.Drawing.Point(11, 201);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(923, 153);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Notebook
            // 
            this.Notebook.Text = "Laptop";
            this.Notebook.Width = 155;
            // 
            // Processor
            // 
            this.Processor.Text = "Procesor";
            this.Processor.Width = 139;
            // 
            // Graphics
            // 
            this.Graphics.Text = "Karta graficzna";
            this.Graphics.Width = 147;
            // 
            // RAMM
            // 
            this.RAMM.Text = "RAM [GB]";
            this.RAMM.Width = 72;
            // 
            // HDDCapacity
            // 
            this.HDDCapacity.Text = "HDD [GB]";
            this.HDDCapacity.Width = 70;
            // 
            // SSDCapacity
            // 
            this.SSDCapacity.Text = "SSD [GB]";
            // 
            // Sizee
            // 
            this.Sizee.Text = "Przekątna ekranu [cale]";
            this.Sizee.Width = 134;
            // 
            // Weightt
            // 
            this.Weightt.Text = "Waga [kg]";
            this.Weightt.Width = 71;
            // 
            // Pricee
            // 
            this.Pricee.Text = "Cena [zł]";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 421);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Podsumowanie";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebooksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource notebooksBindingSource;
        private Database1DataSetTableAdapters.NotebooksTableAdapter notebooksTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Notebook;
        private System.Windows.Forms.ColumnHeader Processor;
        private System.Windows.Forms.ColumnHeader Graphics;
        private System.Windows.Forms.ColumnHeader RAMM;
        private System.Windows.Forms.ColumnHeader HDDCapacity;
        private System.Windows.Forms.ColumnHeader SSDCapacity;
        private System.Windows.Forms.ColumnHeader Sizee;
        private System.Windows.Forms.ColumnHeader Weightt;
        private System.Windows.Forms.ColumnHeader Pricee;
    }
}