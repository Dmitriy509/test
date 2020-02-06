namespace DisplayTree
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.catalogTreeView = new System.Windows.Forms.TreeView();
            this.fillTableBtn = new System.Windows.Forms.Button();
            this.fillTreeBtn = new System.Windows.Forms.Button();
            this.ClearTableBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catalogTreeView
            // 
            this.catalogTreeView.Location = new System.Drawing.Point(12, 12);
            this.catalogTreeView.Name = "catalogTreeView";
            this.catalogTreeView.Size = new System.Drawing.Size(203, 327);
            this.catalogTreeView.TabIndex = 0;
            // 
            // fillTableBtn
            // 
            this.fillTableBtn.Location = new System.Drawing.Point(237, 12);
            this.fillTableBtn.Name = "fillTableBtn";
            this.fillTableBtn.Size = new System.Drawing.Size(180, 40);
            this.fillTableBtn.TabIndex = 1;
            this.fillTableBtn.Text = "Заполняем catalog_level";
            this.fillTableBtn.UseVisualStyleBackColor = true;
            this.fillTableBtn.Click += new System.EventHandler(this.fillTableBtn_Click);
            // 
            // fillTreeBtn
            // 
            this.fillTreeBtn.Location = new System.Drawing.Point(237, 58);
            this.fillTreeBtn.Name = "fillTreeBtn";
            this.fillTreeBtn.Size = new System.Drawing.Size(180, 40);
            this.fillTreeBtn.TabIndex = 2;
            this.fillTreeBtn.Text = "Отобразить Catalog_level";
            this.fillTreeBtn.UseVisualStyleBackColor = true;
            this.fillTreeBtn.Click += new System.EventHandler(this.fillTreeBtn_Click);
            // 
            // ClearTableBtn
            // 
            this.ClearTableBtn.Location = new System.Drawing.Point(237, 104);
            this.ClearTableBtn.Name = "ClearTableBtn";
            this.ClearTableBtn.Size = new System.Drawing.Size(180, 40);
            this.ClearTableBtn.TabIndex = 3;
            this.ClearTableBtn.Text = "Очистить Catalog_level";
            this.ClearTableBtn.UseVisualStyleBackColor = true;
            this.ClearTableBtn.Click += new System.EventHandler(this.ClearTableBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 348);
            this.Controls.Add(this.ClearTableBtn);
            this.Controls.Add(this.fillTreeBtn);
            this.Controls.Add(this.fillTableBtn);
            this.Controls.Add(this.catalogTreeView);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView catalogTreeView;
        private System.Windows.Forms.Button fillTableBtn;
        private System.Windows.Forms.Button fillTreeBtn;
        private System.Windows.Forms.Button ClearTableBtn;
    }
}

