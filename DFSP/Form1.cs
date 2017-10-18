using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DFSP
{
	public partial class Form1 : Form
	{
		private DFSP dfsp;

		public Form1()
		{
			InitializeComponent();
		}

		private void SearchStart_Click(object sender, EventArgs e)
		{
			if(SearchingDirChooser.SelectedDirPath == null)
			{
				MessageBox.Show("'검색할 디렉토리' 항목이 입력되지 않았습니다.", "DFSP", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if(ResultSavingDirChooser.SelectedDirPath == null)
			{
				MessageBox.Show("'결과가 저장될 디렉토리' 항목이 입력되지 않았습니다.", "DFSP", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dfsp = new DFSP(SearchingDirChooser.SelectedDirPath, ResultSavingDirChooser.SelectedDirPath);
			dfsp.SearchStarted += Dfsp_SearchStarted;
			dfsp.SearchFinished += Dfsp_SearchFinished;
			
			dfsp.Run();
		}

		private void Dfsp_SearchStarted(object sender, EventArgs e)
		{
			SearchStart.Text = "검색 중...";
			SearchStart.Enabled = false;
		}

		private void Dfsp_SearchFinished(object sender, EventArgs e)
		{
			MessageBox.Show("검색이 완료되었습니다.", "DFSP");

			SearchStart.Text = "검색 시작";
			SearchStart.Enabled = true;
		}

		private void OpenResultSavedDir_Click(object sender, EventArgs e)
		{
			if (ResultSavingDirChooser.SelectedDirPath == null)
			{
				MessageBox.Show("'결과가 저장될 디렉토리' 항목이 입력되지 않았습니다.", "DFSP", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if(dfsp == null)
			{
				MessageBox.Show("검색이 이루어지지 않았습니다. '검색 시작' 버튼을 클릭해 주세요.", "DFSP", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Process.Start(ResultSavingDirChooser.SelectedDirPath);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/TeamWheel2017");
		}

		private void Help_Click(object sender, EventArgs e)
		{
			MessageBox.Show(@"DFSP : Duplicate File Search Program
                                                                                                                                                           
이 프로그램은 중복 파일들을 찾는 프로그램 입니다.

<사용법>
'검색할 디렉토리' 항목에 중복 파일이 있는지 검사할 디렉토리를 입력합니다.
'결과가 저장될 디렉토리' 항목에 검사 결과 파일이 저장될 디렉토리를 입력합니다.

검사 결과는 '결과가 저장될 디렉토리'에 'DFSP Result.html'이란 이름으로 저장됩니다.

<주의사항>
이 프로그램은 파일들의 앞 특정 바이트를 따서 해쉬 결과를 비교하여 파일 중복을 확인합니다.
차이점이 적은 파일이면 중복 파일이라고 오검사 할 수 있으니 반드시 검사 결과를 확인하시기 바랍니다.

[Credit]
Team Wheel
2017.10.18.", "DFSP");
		}
	}
}
