using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFSP
{
	public partial class DirectoryChooser : UserControl
	{
		public event EventHandler FileSelected;

		private string selectedDirPath;
		public string SelectedDirPath { get { return selectedDirPath; } }

		public DirectoryChooser()
		{
			InitializeComponent();
			selectedDirPath = null;
		}

		private void btnFile_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog openDig = new FolderBrowserDialog())
			{
				if(openDig.ShowDialog() == DialogResult.OK)
				{
					this.txtFileName.Text = openDig.SelectedPath;
					selectedDirPath = openDig.SelectedPath;

					if(FileSelected != null)
					{
						FileSelected(this, EventArgs.Empty);
					}
				}
			}
		}
	}
}
