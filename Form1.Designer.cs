namespace Graphics3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.color_button = new System.Windows.Forms.Button();
            this.fill_button = new System.Windows.Forms.Button();
            this.draw_panel = new System.Windows.Forms.PictureBox();
            this.pen_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.draw_panel)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // color_button
            // 
            this.color_button.BackColor = System.Drawing.Color.Black;
            this.color_button.ForeColor = System.Drawing.Color.Black;
            this.color_button.Location = new System.Drawing.Point(22, 37);
            this.color_button.Name = "color_button";
            this.color_button.Size = new System.Drawing.Size(32, 30);
            this.color_button.TabIndex = 2;
            this.color_button.UseVisualStyleBackColor = false;
            this.color_button.Click += new System.EventHandler(this.color_button_Click);
            // 
            // fill_button
            // 
            this.fill_button.Location = new System.Drawing.Point(251, 41);
            this.fill_button.Name = "fill_button";
            this.fill_button.Size = new System.Drawing.Size(143, 23);
            this.fill_button.TabIndex = 3;
            this.fill_button.Text = "Flood fill with color";
            this.fill_button.UseVisualStyleBackColor = true;
            this.fill_button.Click += new System.EventHandler(this.fill_button_Click);
            // 
            // draw_panel
            // 
            this.draw_panel.BackColor = System.Drawing.Color.White;
            this.draw_panel.Location = new System.Drawing.Point(22, 89);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(564, 460);
            this.draw_panel.TabIndex = 4;
            this.draw_panel.TabStop = false;
            this.draw_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseDown);
            this.draw_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseMove);
            this.draw_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseUp);
            // 
            // pen_button
            // 
            this.pen_button.Location = new System.Drawing.Point(74, 41);
            this.pen_button.Name = "pen_button";
            this.pen_button.Size = new System.Drawing.Size(143, 23);
            this.pen_button.TabIndex = 5;
            this.pen_button.Text = "Pen";
            this.pen_button.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Flood fill with picture";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pen_button);
            this.Controls.Add(this.draw_panel);
            this.Controls.Add(this.fill_button);
            this.Controls.Add(this.color_button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Almost Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.draw_panel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button color_button;
        private System.Windows.Forms.Button fill_button;
        private System.Windows.Forms.PictureBox draw_panel;
        private System.Windows.Forms.Button pen_button;
        private System.Windows.Forms.Button button1;
    }
}

