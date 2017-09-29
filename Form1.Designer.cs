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
			this.color_button = new System.Windows.Forms.Button();
			this.fill_button = new System.Windows.Forms.Button();
			this.draw_panel = new System.Windows.Forms.PictureBox();
			this.pen_button = new System.Windows.Forms.Button();
			this.picture_button = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.draw_panel)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// color_button
			// 
			this.color_button.BackColor = System.Drawing.Color.Black;
			this.color_button.ForeColor = System.Drawing.Color.Black;
			this.color_button.Location = new System.Drawing.Point(11, 25);
			this.color_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.color_button.Name = "color_button";
			this.color_button.Size = new System.Drawing.Size(24, 24);
			this.color_button.TabIndex = 2;
			this.color_button.UseVisualStyleBackColor = false;
			this.color_button.Click += new System.EventHandler(this.color_button_Click);
			// 
			// fill_button
			// 
			this.fill_button.Location = new System.Drawing.Point(188, 30);
			this.fill_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.fill_button.Name = "fill_button";
			this.fill_button.Size = new System.Drawing.Size(107, 19);
			this.fill_button.TabIndex = 3;
			this.fill_button.Text = "Flood fill with color";
			this.fill_button.UseVisualStyleBackColor = true;
			this.fill_button.Click += new System.EventHandler(this.fill_button_Click);
			// 
			// draw_panel
			// 
			this.draw_panel.BackColor = System.Drawing.Color.White;
			this.draw_panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.draw_panel.Location = new System.Drawing.Point(0, 0);
			this.draw_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.draw_panel.Name = "draw_panel";
			this.draw_panel.Size = new System.Drawing.Size(462, 456);
			this.draw_panel.TabIndex = 4;
			this.draw_panel.TabStop = false;
			this.draw_panel.SizeChanged += new System.EventHandler(this.draw_panel_SizeChanged);
			this.draw_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseDown);
			this.draw_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseMove);
			this.draw_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseUp);
			// 
			// pen_button
			// 
			this.pen_button.Location = new System.Drawing.Point(57, 30);
			this.pen_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pen_button.Name = "pen_button";
			this.pen_button.Size = new System.Drawing.Size(107, 19);
			this.pen_button.TabIndex = 5;
			this.pen_button.Text = "Pen";
			this.pen_button.UseVisualStyleBackColor = true;
			// 
			// picture_button
			// 
			this.picture_button.Location = new System.Drawing.Point(321, 30);
			this.picture_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.picture_button.Name = "picture_button";
			this.picture_button.Size = new System.Drawing.Size(107, 19);
			this.picture_button.TabIndex = 6;
			this.picture_button.Text = "Flood fill with picture";
			this.picture_button.UseVisualStyleBackColor = true;
			this.picture_button.Click += new System.EventHandler(this.picture_button_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.color_button);
			this.panel1.Controls.Add(this.picture_button);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.fill_button);
			this.panel1.Controls.Add(this.pen_button);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(462, 77);
			this.panel1.TabIndex = 7;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(188, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Clear";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(462, 456);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.draw_panel);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MinimumSize = new System.Drawing.Size(478, 495);
			this.Name = "Form1";
			this.Text = "Almost Paint";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.draw_panel)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button color_button;
        private System.Windows.Forms.Button fill_button;
        private System.Windows.Forms.PictureBox draw_panel;
        private System.Windows.Forms.Button pen_button;
        private System.Windows.Forms.Button picture_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
	}
}

