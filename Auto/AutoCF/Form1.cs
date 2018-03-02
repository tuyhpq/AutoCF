using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoCF
{
    public partial class AutoCF : Form
    {
        public const string APP_NAME = "AutoCF";
        public const string FOLDER_RECORD_NAME = "record";
        public const string URL_SERVER = @"https://taly.herokuapp.com/api/auto/info";
        public const string PATH_FILE = @"C:\Program Files\Internet Explorer\.autocf";

        public static string Path_Record = "";
        public static bool isEnd = false;

        Information data = new Information();

        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public AutoCF()
        {
            if (CheckMultiApplication())
            {
                Environment.Exit(1);
                return;
            }
            InitializeComponent();

            Path_Record = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Nox\" + FOLDER_RECORD_NAME);

            if (registryKey.GetValue(APP_NAME) == null)
            {
                registryKey.SetValue(APP_NAME, Application.ExecutablePath);
                MessageBox.Show("Khởi động lần đầu thành công!");

                if (!File.Exists(PATH_FILE))
                {
                    File.Create(PATH_FILE).Close();
                    SetTimeForFile(5);
                }
                else
                {
                    // Chưa cài đặt nhưng có file cấu hình
                    EndExpire();
                }
            }
            else if (!File.Exists(PATH_FILE))
            {
                // Đã cài đặt nhưng mất file cấu hình
                EndExpire();
            }
        }

        private void AutoCF_Load(object sender, EventArgs e)
        {
            while (!API.CheckForInternetConnection())
            {
                Thread.Sleep(5000);
            }
            Install();
            TimeTick();
            timerTime.Enabled = true;
        }

        void Install()
        {
            using (var webClient = new MyWebClient())
            {
                try
                {
                    var json = webClient.DownloadString(URL_SERVER);
                    data = JsonConvert.DeserializeObject<Information>(json);
                    if (data.stop == true)
                    {
                        EndExpire("Bảo trì hệ thống!!!");
                    }
                    labelAuthor.Text = data.author;
                }
                catch
                {
                    EndExpire();
                    MessageBox.Show("Không thể lấy dữ liệu từ server!");
                    Environment.Exit(1);
                }
            }
        }

        // Ẩn ứng dụng khi bị đóng
        private void AutoCF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.Visible = true;
            }
        }
        // Ẩn ứng dụng khi bị thu nhỏ
        private void AutoCF_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }
        // Hiện ứng dụng khi click vào nó ở dạng ẩn (thu nhỏ)
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        // Cài đặt auto
        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (isEnd == false)
            {
                API.CopyFile(data, Path_Record);
            }
        }

        // Gia hạn
        private void btnExtend_Click(object sender, EventArgs e)
        {
            Input input = new Input(data);
            input.ShowDialog();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            TimeTick();
        }

        bool increaseTime = false;
        private void TimeTick()
        {
            if (!File.Exists(PATH_FILE))
            {
                EndExpire();
                return;
            }

            int time = GetTimeFromFile();
            if (time <= 0)
            {
                EndExpire();
                return;
            }

            if (increaseTime == true)
            {
                time--;
                SetTimeForFile(time);
            }
            increaseTime = !increaseTime;

            labelTime.Text = "Thời gian sử dụng: " + time + " phút";
        }

        public static void AddTime(int count)
        {
            if (count == 60 * 24 * 5)
            {
                if (SetTimeForFile(0))
                {
                    isEnd = false;
                    MessageBox.Show("Reset thành công!");
                }
                return;
            }

            int time = GetTimeFromFile();

            time += count;

            if (SetTimeForFile(time))
            {
                isEnd = false;
                MessageBox.Show("Bạn được cộng " + count + " phút");
            }
        }

        private void EndExpire(string message = "Hết hạn!!!")
        {
            isEnd = true;
            labelTime.Text = message;
            API.DeleteDirectory(Path_Record);
        }

        private static int GetTimeFromFile()
        {
            try
            {
                string decode = API.Decode(File.ReadAllText(PATH_FILE));
                int time = int.Parse(decode);
                return time;
            }
            catch (Exception Ex)
            {
                isEnd = true;
                API.DeleteDirectory(Path_Record);
                MessageBox.Show("Lỗi đọc file: \n" + Ex.Message);
                return 0;
            }
        }

        private static bool SetTimeForFile(int time)
        {
            try
            {
                string encode = API.Encode(time.ToString());
                File.WriteAllText(PATH_FILE, encode);
                return true;
            }
            catch (Exception Ex)
            {
                isEnd = true;
                API.DeleteDirectory(Path_Record);
                MessageBox.Show("Lỗi ghi file: \n" + Ex.Message);
                return false;
            }
        }

        private bool CheckMultiApplication()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("Chương trình đã chạy!");
                return true;
            }
            return false;
        }

    }
}
