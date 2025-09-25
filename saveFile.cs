using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace on_off_proj
{
    public partial class saveFile : Form
    {
        private string filePath;
        private byte[] archive;
        //ZipArchive zipFile;
        public saveFile()
        {
            InitializeComponent();
        }

        public saveFile(byte[] archive_)
        {
            InitializeComponent();
            archive = archive_;
        }

        private void OpenPathButton_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.SelectedPath;
                    filePath += "\\파일명을_입력하세요.zip";
                    textBoxFilePath.Text = filePath;
                }
                else if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            if(textBoxFilePath.Text == "")
            {
                MessageBox.Show("파일 경로를 입력해주세요.");
            }
            else
            {
                filePath = textBoxFilePath.Text;
                var stream = new MemoryStream(archive);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
                MessageBox.Show("저장되었습니다.");
                this.Close();
            }
            
            // var stream = new MemoryStream(archive);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
