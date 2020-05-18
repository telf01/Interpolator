namespace Interpolator
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.outputTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(286, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Process data";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Path to file with input data: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Path to file with output data: ";
			// 
			// inputTextBox
			// 
			this.inputTextBox.Location = new System.Drawing.Point(161, 10);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.Size = new System.Drawing.Size(141, 20);
			this.inputTextBox.TabIndex = 3;
			this.inputTextBox.Text = "input.txt";
			this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
			// 
			// outputTextBox
			// 
			this.outputTextBox.Location = new System.Drawing.Point(161, 36);
			this.outputTextBox.Name = "outputTextBox";
			this.outputTextBox.Size = new System.Drawing.Size(141, 20);
			this.outputTextBox.TabIndex = 4;
			this.outputTextBox.Text = "output.txt";
			this.outputTextBox.TextChanged += new System.EventHandler(this.outputTextBox_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(316, 91);
			this.Controls.Add(this.outputTextBox);
			this.Controls.Add(this.inputTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Interpolator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.TextBox outputTextBox;
	}
}

