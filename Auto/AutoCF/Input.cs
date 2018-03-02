using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace AutoCF
{
    public class Activate
    {
        public int time;
    }

    public partial class Input : Form
    {
        Information data;

        public Input(Information data)
        {
            InitializeComponent();
            this.data = data;
            tbPass.PasswordChar = '*';
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string code = tbPass.Text;
            int time = 0;

            using (var webClient = new MyWebClient())
            {
                try
                {
                    var json = webClient.DownloadString(data.urlCheck + code);
                    var result = JsonConvert.DeserializeObject<Activate>(json);
                    time = result.time;
                }
                catch
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ server!");
                    time = 0;
                }
            }
            if (time > 0)
            {
                AutoCF.AddTime(time);
            }
            this.Close();
        }
    }
}
