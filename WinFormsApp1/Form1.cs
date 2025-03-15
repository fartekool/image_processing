using System.ComponentModel;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		Bitmap image;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				image = new Bitmap(dialog.FileName);
				pictureBox1.Image = image;
				pictureBox1.Refresh();
			}
		}

		private void èíâåğñèÿToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new InvertFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void îòòåíêèÑåğîãîToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new GrayScaleFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ñåïèÿToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new SepiaFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ñáğîñÔèëüòğàToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new OriginalFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ïîâûñèòüßğêîñòüToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new BrightnessIncreaseFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ñäâèãÂïğàâîÍà50ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new ShiftFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ğàçìûòèåToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new BlurFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
			if (backgroundWorker1.CancellationPending != true)
				image = newImage;
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				pictureBox1.Image = image;
				pictureBox1.Refresh();
			}
			progressBar1.Value = 0;
		}

		private void òèñíåíèåToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new EmbossingFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new MotionblurFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ñåğûéÌèğToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new GrayWorldFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ğàñòÿæåíèåÊîíòğàñòíîñòèToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new AutoLevelsFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void ôèëüòğÑîáåëÿToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new SobelFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void ñòåêëîToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new GlassFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}
	}
}
