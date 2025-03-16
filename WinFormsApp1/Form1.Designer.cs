namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pictureBox1 = new PictureBox();
			menuStrip1 = new MenuStrip();
			файлToolStripMenuItem = new ToolStripMenuItem();
			открытьToolStripMenuItem = new ToolStripMenuItem();
			фильтрыToolStripMenuItem = new ToolStripMenuItem();
			точечныеToolStripMenuItem = new ToolStripMenuItem();
			инверсияToolStripMenuItem = new ToolStripMenuItem();
			оттенкиСерогоToolStripMenuItem = new ToolStripMenuItem();
			сепияToolStripMenuItem = new ToolStripMenuItem();
			повыситьЯркостьToolStripMenuItem = new ToolStripMenuItem();
			сдвигВправоНа50ToolStripMenuItem = new ToolStripMenuItem();
			серыйМирToolStripMenuItem = new ToolStripMenuItem();
			растяжениеКонтрасToolStripMenuItem = new ToolStripMenuItem();
			идеальныйОтражательToolStripMenuItem = new ToolStripMenuItem();
			стеклоToolStripMenuItem = new ToolStripMenuItem();
			матричныеToolStripMenuItem = new ToolStripMenuItem();
			размытиеToolStripMenuItem = new ToolStripMenuItem();
			тиснениеToolStripMenuItem = new ToolStripMenuItem();
			motionBlurToolStripMenuItem = new ToolStripMenuItem();
			фильтрСобеляToolStripMenuItem = new ToolStripMenuItem();
			расширениеToolStripMenuItem = new ToolStripMenuItem();
			сужениеToolStripMenuItem = new ToolStripMenuItem();
			медианаToolStripMenuItem = new ToolStripMenuItem();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			progressBar1 = new ProgressBar();
			button1 = new Button();
			фильтрШарраToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(89, 85);
			pictureBox1.Margin = new Padding(6);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(2766, 1559);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(32, 32);
			menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(11, 4, 0, 4);
			menuStrip1.Size = new Size(3042, 46);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem });
			файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			файлToolStripMenuItem.Size = new Size(90, 38);
			файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			открытьToolStripMenuItem.Size = new Size(240, 44);
			открытьToolStripMenuItem.Text = "Открыть";
			открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
			// 
			// фильтрыToolStripMenuItem
			// 
			фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem });
			фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
			фильтрыToolStripMenuItem.Size = new Size(131, 38);
			фильтрыToolStripMenuItem.Text = "Фильтры";
			// 
			// точечныеToolStripMenuItem
			// 
			точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, оттенкиСерогоToolStripMenuItem, сепияToolStripMenuItem, повыситьЯркостьToolStripMenuItem, сдвигВправоНа50ToolStripMenuItem, серыйМирToolStripMenuItem, растяжениеКонтрасToolStripMenuItem, идеальныйОтражательToolStripMenuItem, стеклоToolStripMenuItem });
			точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
			точечныеToolStripMenuItem.Size = new Size(359, 44);
			точечныеToolStripMenuItem.Text = "Точечные";
			// 
			// инверсияToolStripMenuItem
			// 
			инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
			инверсияToolStripMenuItem.Size = new Size(444, 44);
			инверсияToolStripMenuItem.Text = "Инверсия";
			инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
			// 
			// оттенкиСерогоToolStripMenuItem
			// 
			оттенкиСерогоToolStripMenuItem.Name = "оттенкиСерогоToolStripMenuItem";
			оттенкиСерогоToolStripMenuItem.Size = new Size(444, 44);
			оттенкиСерогоToolStripMenuItem.Text = "Оттенки серого";
			оттенкиСерогоToolStripMenuItem.Click += оттенкиСерогоToolStripMenuItem_Click;
			// 
			// сепияToolStripMenuItem
			// 
			сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
			сепияToolStripMenuItem.Size = new Size(444, 44);
			сепияToolStripMenuItem.Text = "Сепия";
			сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
			// 
			// повыситьЯркостьToolStripMenuItem
			// 
			повыситьЯркостьToolStripMenuItem.Name = "повыситьЯркостьToolStripMenuItem";
			повыситьЯркостьToolStripMenuItem.Size = new Size(444, 44);
			повыситьЯркостьToolStripMenuItem.Text = "Повысить яркость";
			повыситьЯркостьToolStripMenuItem.Click += повыситьЯркостьToolStripMenuItem_Click;
			// 
			// сдвигВправоНа50ToolStripMenuItem
			// 
			сдвигВправоНа50ToolStripMenuItem.Name = "сдвигВправоНа50ToolStripMenuItem";
			сдвигВправоНа50ToolStripMenuItem.Size = new Size(444, 44);
			сдвигВправоНа50ToolStripMenuItem.Text = "Сдвиг вправо на 50";
			сдвигВправоНа50ToolStripMenuItem.Click += сдвигВправоНа50ToolStripMenuItem_Click;
			// 
			// серыйМирToolStripMenuItem
			// 
			серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
			серыйМирToolStripMenuItem.Size = new Size(444, 44);
			серыйМирToolStripMenuItem.Text = "Серый мир";
			серыйМирToolStripMenuItem.Click += серыйМирToolStripMenuItem_Click;
			// 
			// растяжениеКонтрасToolStripMenuItem
			// 
			растяжениеКонтрасToolStripMenuItem.Name = "растяжениеКонтрасToolStripMenuItem";
			растяжениеКонтрасToolStripMenuItem.Size = new Size(444, 44);
			растяжениеКонтрасToolStripMenuItem.Text = "Растяжение контрастности";
			растяжениеКонтрасToolStripMenuItem.Click += растяжениеКонтрастностиToolStripMenuItem_Click;
			// 
			// идеальныйОтражательToolStripMenuItem
			// 
			идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
			идеальныйОтражательToolStripMenuItem.Size = new Size(444, 44);
			идеальныйОтражательToolStripMenuItem.Text = "Идеальный отражатель";
			идеальныйОтражательToolStripMenuItem.Click += идеальныйОтражательToolStripMenuItem_Click;
			// 
			// стеклоToolStripMenuItem
			// 
			стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
			стеклоToolStripMenuItem.Size = new Size(444, 44);
			стеклоToolStripMenuItem.Text = "Стекло";
			стеклоToolStripMenuItem.Click += стеклоToolStripMenuItem_Click;
			// 
			// матричныеToolStripMenuItem
			// 
			матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, тиснениеToolStripMenuItem, motionBlurToolStripMenuItem, фильтрСобеляToolStripMenuItem, расширениеToolStripMenuItem, сужениеToolStripMenuItem, медианаToolStripMenuItem, фильтрШарраToolStripMenuItem });
			матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
			матричныеToolStripMenuItem.Size = new Size(359, 44);
			матричныеToolStripMenuItem.Text = "Матричные";
			// 
			// размытиеToolStripMenuItem
			// 
			размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
			размытиеToolStripMenuItem.Size = new Size(359, 44);
			размытиеToolStripMenuItem.Text = "Размытие";
			размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
			// 
			// тиснениеToolStripMenuItem
			// 
			тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
			тиснениеToolStripMenuItem.Size = new Size(359, 44);
			тиснениеToolStripMenuItem.Text = "Тиснение";
			тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
			// 
			// motionBlurToolStripMenuItem
			// 
			motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
			motionBlurToolStripMenuItem.Size = new Size(359, 44);
			motionBlurToolStripMenuItem.Text = "Motion Blur";
			motionBlurToolStripMenuItem.Click += motionBlurToolStripMenuItem_Click;
			// 
			// фильтрСобеляToolStripMenuItem
			// 
			фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
			фильтрСобеляToolStripMenuItem.Size = new Size(359, 44);
			фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля";
			фильтрСобеляToolStripMenuItem.Click += фильтрСобеляToolStripMenuItem_Click;
			// 
			// расширениеToolStripMenuItem
			// 
			расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
			расширениеToolStripMenuItem.Size = new Size(359, 44);
			расширениеToolStripMenuItem.Text = "Расширение";
			расширениеToolStripMenuItem.Click += расширениеToolStripMenuItem_Click;
			// 
			// сужениеToolStripMenuItem
			// 
			сужениеToolStripMenuItem.Name = "сужениеToolStripMenuItem";
			сужениеToolStripMenuItem.Size = new Size(359, 44);
			сужениеToolStripMenuItem.Text = "Сужение";
			сужениеToolStripMenuItem.Click += сужениеToolStripMenuItem_Click;
			// 
			// медианаToolStripMenuItem
			// 
			медианаToolStripMenuItem.Name = "медианаToolStripMenuItem";
			медианаToolStripMenuItem.Size = new Size(359, 44);
			медианаToolStripMenuItem.Text = "Медиана";
			медианаToolStripMenuItem.Click += медианаToolStripMenuItem_Click;
			// 
			// backgroundWorker1
			// 
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
			backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(89, 1761);
			progressBar1.Margin = new Padding(6);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(2460, 49);
			progressBar1.TabIndex = 2;
			// 
			// button1
			// 
			button1.Location = new Point(2679, 1761);
			button1.Margin = new Padding(6);
			button1.Name = "button1";
			button1.Size = new Size(176, 49);
			button1.TabIndex = 3;
			button1.Text = "Отмена";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// фильтрШарраToolStripMenuItem
			// 
			фильтрШарраToolStripMenuItem.Name = "фильтрШарраToolStripMenuItem";
			фильтрШарраToolStripMenuItem.Size = new Size(359, 44);
			фильтрШарраToolStripMenuItem.Text = "Фильтр Шарра";
			фильтрШарраToolStripMenuItem.Click += фильтрШарраToolStripMenuItem_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(3042, 1959);
			Controls.Add(button1);
			Controls.Add(progressBar1);
			Controls.Add(pictureBox1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(6);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private ToolStripMenuItem оттенкиСерогоToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem повыситьЯркостьToolStripMenuItem;
        private ToolStripMenuItem сдвигВправоНа50ToolStripMenuItem;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private Button button1;
        private ToolStripMenuItem тиснениеToolStripMenuItem;
        private ToolStripMenuItem motionBlurToolStripMenuItem;
        private ToolStripMenuItem серыйМирToolStripMenuItem;
        private ToolStripMenuItem растяжениеКонтрасToolStripMenuItem;
        private ToolStripMenuItem фильтрСобеляToolStripMenuItem;
		private ToolStripMenuItem стеклоToolStripMenuItem;
		private ToolStripMenuItem идеальныйОтражательToolStripMenuItem;
		private ToolStripMenuItem расширениеToolStripMenuItem;
		private ToolStripMenuItem сужениеToolStripMenuItem;
		private ToolStripMenuItem медианаToolStripMenuItem;
		private ToolStripMenuItem фильтрШарраToolStripMenuItem;
	}
}
