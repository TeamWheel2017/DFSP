namespace DFSP
{
	partial class DirectoryChooser
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

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.btnFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtFileName
			// 
			this.txtFileName.Enabled = false;
			this.txtFileName.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.txtFileName.Location = new System.Drawing.Point(3, 7);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(492, 27);
			this.txtFileName.TabIndex = 0;
			// 
			// btnFile
			// 
			this.btnFile.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.btnFile.Location = new System.Drawing.Point(501, 3);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(96, 34);
			this.btnFile.TabIndex = 1;
			this.btnFile.Text = "Browse";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// DirectoryChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.txtFileName);
			this.Name = "DirectoryChooser";
			this.Size = new System.Drawing.Size(600, 40);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Button btnFile;
	}
}
