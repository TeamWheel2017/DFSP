using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace DFSP //Duplicate File Search Program
{
	public class FileData
	{
		public string FileName { get; set; }
		public long FileSize { get; set; }
		public string FileHash { get; set; }
		public string FilePath { get; set; }

		public FileData(string FileName, long FileSize, string FileHash, string FilePath)
		{
			this.FileName = FileName;
			this.FileSize = FileSize;
			this.FileHash = FileHash;
			this.FilePath = FilePath;
		}
	}

	public class FileDataComparer : IComparer<FileData>
	{
		public int Compare(FileData x, FileData y)
		{
			if (x.FileSize > y.FileSize)
			{
				return 1;
			}
			else if (x.FileSize < y.FileSize)
			{
				return -1;
			}
			else
			{
				return (x.FileHash).CompareTo(y.FileHash);
			}
		}
	}

	public class DFSP
	{
		private List<FileData> fileList;
		private List<List<int>> duplicateFileList;
		private string searchPath;
		private string resultPath;
		private Stopwatch stopwatch;

		public event EventHandler SearchStarted;
		public event EventHandler SearchFinished;

		public DFSP(string searchPath, string resultPath)
		{
			if (Directory.Exists(searchPath) == false)
			{
				throw new Exception("Searching Path Not Exist");
			}

			if (Directory.Exists(resultPath) == false)
			{
				throw new Exception("Result Path Not Exist");
			}

			this.searchPath = searchPath;
			this.resultPath = resultPath;

			fileList = new List<FileData>();
			duplicateFileList = new List<List<int>>();

			stopwatch = new Stopwatch();
		}

		public void Run()
		{
			if (SearchStarted != null)
			{
				SearchStarted(this, EventArgs.Empty);
			}

			stopwatch.Start();

			AddAllFilesInPath(searchPath);
			
			fileList.Sort(new FileDataComparer());
			
			FindAllDuplicatePairs();

			stopwatch.Stop();

			CreateResultDocumentInHtml();

			if(SearchFinished != null)
			{
				SearchFinished(this, EventArgs.Empty);
			}
		}

		private void AddAllFilesInPath(string path)
		{
			string[] files = Directory.GetFiles(path);
			string[] directories = Directory.GetDirectories(path);

			if (files.Length != 0) //추가할 파일이 있으면
			{
				foreach (var item in files)
				{
					string fileName = Path.GetFileName(item);

					long fileSize = (new FileInfo(item)).Length;

					StringBuilder hashInStringBuilder = new StringBuilder();
					byte[] fileInByte;
					using (FileStream fs = new FileStream(item, FileMode.Open))
					using (BinaryReader br = new BinaryReader(fs))
					{
						fileInByte = br.ReadBytes(1000000);
					}
					byte[] hashInByteArr = (new MD5CryptoServiceProvider()).ComputeHash(fileInByte);
					for (int i = 0; i < hashInByteArr.Length; i++)
					{
						hashInStringBuilder.Append(hashInByteArr[i].ToString("X2"));
					}
					String fileHash = hashInStringBuilder.ToString();

					string filePath = Path.GetDirectoryName(item);

					fileList.Add(new FileData(fileName, fileSize, fileHash, filePath));
				}
			}

			if (directories.Length != 0) //하위 디렉토리가 있으면
			{
				foreach (var item in directories)
				{
					AddAllFilesInPath(item);
				}
			}
		}

		private void FindAllDuplicatePairs()
		{
			for (int i = 0; i < fileList.Count - 1; i++)
			{
				int j;

				for (j = 1; j < fileList.Count - i; j++)
				{
					if (IsSameFile(i, i + j) == false)
					{
						break;
					}
				}

				if (j > 1) //중복 원소가 있을 경우
				{
					List<int> list = new List<int>(j);

					for (int k = 0; k < j; k++)
					{
						list.Add(i + k);
					}

					duplicateFileList.Add(list);

					i += j - 1;
				}
			}
		}

		private bool IsSameFile(int idx1, int idx2)
		{
			if (fileList[idx1].FileSize == fileList[idx2].FileSize)
			{
				if (fileList[idx1].FileHash == fileList[idx2].FileHash)
				{
					return true;
				}
			}

			return false;
		}

		private void CreateResultDocumentInHtml()
		{
			using (FileStream fs = new FileStream(Path.Combine(resultPath, "DFSP Result.html"), FileMode.Create))
			using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
			{
				sw.WriteLine("<html>");
				sw.WriteLine("<head>");
				sw.WriteLine("<meta charset=\"UTF-8\">");
				sw.WriteLine("<title>Duplicate File Search Program</title>");
				sw.WriteLine("</head>");
				sw.WriteLine("<body>");
				sw.WriteLine("<h1>Result</h1>");
				sw.WriteLine("<hr/>");
				sw.WriteLine("<ul>");
				sw.WriteLine("<li>");
				sw.WriteLine("<h3>Summary</h3>");
				sw.WriteLine("<ul>");
				sw.WriteLine("<li>Searched Directory : " + searchPath + "</li>");
				sw.WriteLine("<li>Total File Num : " + fileList.Count.ToString() + "</li>");
				sw.WriteLine("<li>Duplicate File Num : " + duplicateFileList.Count.ToString() + " pairs</li>");
				sw.WriteLine("<li>Total Processing Time : " + GetStopwatchElapsedTimeInHMS() + "</li>");
				sw.WriteLine("</ul>");
				sw.WriteLine("</li>");
				sw.WriteLine("<li>");
				sw.WriteLine("<h3>Duplicate Files</h3>");

				for (int i = 0; i < duplicateFileList.Count; i++)
				{
					List<int> curItem = duplicateFileList[i];

					sw.WriteLine("<table border=\"1\" width=\"100%\">");
					sw.WriteLine("<tr align=\"center\">");
					sw.WriteLine("<th>Match #</th>");
					sw.WriteLine("<th>File Name</th>");
					sw.WriteLine("<th>File Size</th>");
					sw.WriteLine("<th>File Hash</th>");
					sw.WriteLine("<th>Directory</th>");
					sw.WriteLine("</tr>");

					for (int j = 0; j < curItem.Count; j++)
					{
						sw.WriteLine("<tr align=\"center\">");

						if (j == 0)
						{
							sw.WriteLine("<td rowspan=\"" + curItem.Count + "\">" + (i + 1) + "</td>");
						}

						sw.WriteLine("<td><a href=\"" + Path.Combine(fileList[curItem[j]].FilePath, fileList[curItem[j]].FileName) + "\">" + fileList[curItem[j]].FileName + "</a></td>");
						sw.WriteLine("<td>" + fileList[curItem[j]].FileSize + "</td>");
						sw.WriteLine("<td>" + fileList[curItem[j]].FileHash + "</td>");
						sw.WriteLine("<td><a href=\"" + fileList[curItem[j]].FilePath + "\">" + fileList[curItem[j]].FilePath + "</a></td>");
						sw.WriteLine("</tr>");
					}

					sw.WriteLine("</table>");
					sw.WriteLine("<p/>");
				}

				sw.WriteLine("</li>");
				sw.WriteLine("</ul>");
				sw.WriteLine("</body>");
				sw.WriteLine("</html>");
			}
		}

		private string GetStopwatchElapsedTimeInHMS()
		{
			StringBuilder strBuilder = new StringBuilder();

			if (stopwatch.Elapsed.Hours > 0)
			{
				strBuilder.Append(stopwatch.Elapsed.Hours + "H ");
			}

			if (stopwatch.Elapsed.Minutes > 0)
			{
				strBuilder.Append(stopwatch.Elapsed.Minutes + "M ");
			}

			if (stopwatch.Elapsed.Seconds > 0)
			{
				strBuilder.Append(stopwatch.Elapsed.Minutes);
			}
			else
			{
				strBuilder.Append("0");
			}

			if (stopwatch.Elapsed.Milliseconds > 0)
			{
				strBuilder.Append("." + stopwatch.Elapsed.Milliseconds);
			}

			strBuilder.Append("S");

			return strBuilder.ToString();
		}
	}
}
