using System.Drawing;

namespace Client
{
    partial class LoadForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.BtnDesigner = new System.Windows.Forms.Button();
            this.BtnManager = new System.Windows.Forms.Button();
            this.BtnCreaters = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(931, 553);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 200);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnDesigner
            // 
            this.BtnDesigner.Location = new System.Drawing.Point(104, 117);
            this.BtnDesigner.Name = "BtnDesigner";
            this.BtnDesigner.Size = new System.Drawing.Size(200, 100);
            this.BtnDesigner.TabIndex = 2;
            this.BtnDesigner.Text = "Дизайнер";
            this.BtnDesigner.UseVisualStyleBackColor = true;
            this.BtnDesigner.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnManager
            // 
            this.BtnManager.Location = new System.Drawing.Point(104, 12);
            this.BtnManager.Name = "BtnManager";
            this.BtnManager.Size = new System.Drawing.Size(200, 100);
            this.BtnManager.TabIndex = 3;
            this.BtnManager.Text = "Менеджеры";
            this.BtnManager.UseVisualStyleBackColor = true;
            this.BtnManager.Click += new System.EventHandler(this.BtnManager_Click);
            // 
            // BtnCreaters
            // 
            this.BtnCreaters.Location = new System.Drawing.Point(104, 223);
            this.BtnCreaters.Name = "BtnCreaters";
            this.BtnCreaters.Size = new System.Drawing.Size(200, 100);
            this.BtnCreaters.TabIndex = 4;
            this.BtnCreaters.Text = "Производство";
            this.BtnCreaters.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 329);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // LoadForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnCreaters);
            this.Controls.Add(this.BtnManager);
            this.Controls.Add(this.BtnDesigner);
            this.Controls.Add(this.button1);
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnDesigner;
        private System.Windows.Forms.Button BtnManager;
        private System.Windows.Forms.Button BtnCreaters;
        private System.Windows.Forms.TextBox textBox1;
    }
}

