using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AutoCF
{
    public static class API
    {
        public static string Encode(string str)
        {
            string encode = "";

            foreach (char c in str)
            {
                char x = (char)(((int)c) + 123);
                encode += x;
            }

            return encode;
        }

        public static string Decode(string str)
        {
            string decode = "";

            foreach (char c in str)
            {
                char x = (char)(((int)c) - 123);
                decode += x;
            }

            return decode;
        }

        public static void CopyFile(Information data, string folderName)
        {
            try
            {
                DeleteDirectory(folderName);
                System.IO.Directory.CreateDirectory(folderName);

                folderName += @"\";

                var client = new MyWebClient();
                client.DownloadFile(data.urlRecords, folderName + "records");

                for (int i = 0; i < data.urlFiles.Length; i++)
                {
                    client = new MyWebClient();
                    client.DownloadFile(data.urlFiles[i], folderName + Path.GetFileNameWithoutExtension(data.urlFiles[i]));
                }

                MessageBox.Show("Cài đặt thành công!!!");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Lỗi!\n" + Ex.Message);
            }
        }

        public static void DeleteDirectory(string folderName)
        {
            if (!System.IO.Directory.Exists(folderName))
                return;

            string[] files = Directory.GetFiles(folderName);
            string[] dirs = Directory.GetDirectories(folderName);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(folderName, false);

            Thread.Sleep(500);
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new MyWebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
