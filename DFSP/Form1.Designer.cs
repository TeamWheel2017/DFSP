namespace DFSP
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SearchingDirChooser = new DirectoryChooser();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ResultSavingDirChooser = new DirectoryChooser();
			this.Help = new System.Windows.Forms.Button();
			this.OpenResultSavedDir = new System.Windows.Forms.Button();
			this.SearchStart = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(640, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "DFSP : Dulplicate File Search Program";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SearchingDirChooser
			// 
			this.SearchingDirChooser.Location = new System.Drawing.Point(20, 87);
			this.SearchingDirChooser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.SearchingDirChooser.Name = "SearchingDirChooser";
			this.SearchingDirChooser.Size = new System.Drawing.Size(600, 45);
			this.SearchingDirChooser.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label2.Location = new System.Drawing.Point(17, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "■ 검색할 디렉토리";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.label3.Location = new System.Drawing.Point(18, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(189, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "■ 결과가 저장될 디렉토리";
			// 
			// ResultSavingDirChooser
			// 
			this.ResultSavingDirChooser.Location = new System.Drawing.Point(20, 180);
			this.ResultSavingDirChooser.Name = "ResultSavingDirChooser";
			this.ResultSavingDirChooser.Size = new System.Drawing.Size(600, 52);
			this.ResultSavingDirChooser.TabIndex = 4;
			// 
			// Help
			// 
			this.Help.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Help.Location = new System.Drawing.Point(498, 238);
			this.Help.Name = "Help";
			this.Help.Size = new System.Drawing.Size(122, 34);
			this.Help.TabIndex = 5;
			this.Help.Text = "도움말";
			this.Help.UseVisualStyleBackColor = true;
			this.Help.Click += new System.EventHandler(this.Help_Click);
			// 
			// OpenResultSavedDir
			// 
			this.OpenResultSavedDir.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.OpenResultSavedDir.Location = new System.Drawing.Point(210, 238);
			this.OpenResultSavedDir.Name = "OpenResultSavedDir";
			this.OpenResultSavedDir.Size = new System.Drawing.Size(220, 34);
			this.OpenResultSavedDir.TabIndex = 5;
			this.OpenResultSavedDir.Text = "결과가 저장된 디렉토리 열기";
			this.OpenResultSavedDir.UseVisualStyleBackColor = true;
			this.OpenResultSavedDir.Click += new System.EventHandler(this.OpenResultSavedDir_Click);
			// 
			// SearchStart
			// 
			this.SearchStart.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SearchStart.Location = new System.Drawing.Point(20, 238);
			this.SearchStart.Name = "SearchStart";
			this.SearchStart.Size = new System.Drawing.Size(122, 34);
			this.SearchStart.TabIndex = 5;
			this.SearchStart.Text = "검색 시작";
			this.SearchStart.UseVisualStyleBackColor = true;
			this.SearchStart.Click += new System.EventHandler(this.SearchStart_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(386, 284);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(242, 15);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://github.com/TeamWheel2017";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 308);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.SearchStart);
			this.Controls.Add(this.OpenResultSavedDir);
			this.Controls.Add(this.Help);
			this.Controls.Add(this.ResultSavingDirChooser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SearchingDirChooser);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "DFSP";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button Help;
		private System.Windows.Forms.Button OpenResultSavedDir;
		private System.Windows.Forms.Button SearchStart;
		private DirectoryChooser SearchingDirChooser;
		private DirectoryChooser ResultSavingDirChooser;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}

