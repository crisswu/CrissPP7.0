using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Qiniu.Util;
using Qiniu.JSON;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading;
using Qiniu.RS;
using Qiniu.RS.Model;
using System.IO;
using Qiniu.CDN;

namespace Bowtech
{
    public partial class BL71_Option_UpDownLoad : Form
    {
        BL71_Main Main;
        //七牛 接口
        string AK = "BjSys2_mqjjij_xW_9IROgvkNcssC5qh91Nx9khH";
        string SK = "cULYrizgRT432gUWtQO1umAa29Gk1Lntb7vbj-QL";

        SQLite dal;
        public BL71_Option_UpDownLoad(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;

            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            Qiniu.JSON.JsonHelper.JsonSerializer = new AnotherJsonSerializer();
            Qiniu.JSON.JsonHelper.JsonDeserializer = new AnotherJsonDeserializer();

        }

        #region 切换图片
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnUp.Image = Properties.Resources.b5_3;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
           btnUp.Image = Properties.Resources.b5;
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }

        private void btnUp_MouseEnter(object sender, EventArgs e)
        {
            btnUp.Image = Properties.Resources.Cloud;
        }

        private void btnUp_MouseLeave(object sender, EventArgs e)
        {
            btnUp.Image = Properties.Resources.Up1;
        }

        private void btnDown_MouseEnter(object sender, EventArgs e)
        {
            btnDown.Image = Properties.Resources.Cloud;
        }

        private void btnDown_MouseLeave(object sender, EventArgs e)
        {
            btnDown.Image = Properties.Resources.Down1;
        }

        private void btnFile_MouseEnter(object sender, EventArgs e)
        {
            btnFile.Image = Properties.Resources.Cloud;
        }

        private void btnFile_MouseLeave(object sender, EventArgs e)
        {
            btnFile.Image = Properties.Resources.Up2;
        }

        #endregion

        private void BL71_Option_ConnectDB_Load(object sender, EventArgs e)
        {
            

           // UploadFile222();
        }

        public void UploadFile222()
        {
            lblWate.Visible = true;
            Application.DoEvents();

            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            string bucket = "mydb";
            string saveKey = "version0.txt";
            string localFile = Application.StartupPath + "\\version0.txt";
            // 上传策略，参见 
            // https://developer.qiniu.com/kodo/manual/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            putPolicy.Scope = bucket + ":" + saveKey;
            //putPolicy.Scope = bucket;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            // putPolicy.DeleteAfterDays = 1;
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);




            UploadManager um = new UploadManager();

            //先删除
            BucketManager bm = new BucketManager(mac);
            bm.Delete(bucket, saveKey);

            HttpResult result = um.UploadFile(localFile, saveKey, token);
            string res = result.ToString();
            if (res.Substring(0, 8) == "code:200")
            {
                lblWate.Visible = false;
                Application.DoEvents();
                Main.AlertMsg("上传完成");
            }
            else
            {
                Main.AlertMsg(res);
            }



        }

        public class AnotherJsonSerializer : IJsonSerializer
        {
            // 实现此接口的JSON序列化方法
            public string Serialize<T>(T obj) where T : new()
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.NullValueHandling = NullValueHandling.Ignore;
                return JsonConvert.SerializeObject(obj, settings);
            }
        }
        public class AnotherJsonDeserializer : IJsonDeserializer
        {
            // 实现此接口的JSON反序列化方法
            public bool Deserialize<T>(string str, out T obj) where T : new()
            {
                obj = default(T);
                bool ok = true;
                try
                {
                    obj = JsonConvert.DeserializeObject<T>(str);
                }
                catch (System.Exception)
                {
                    ok = false;
                }
                return ok;
            }
        }

        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //上传
        public void btnUp_Click(object sender, EventArgs e)
        {
            if (Main.lblVersion.Text == "需更新版本")
            {
                Main.AlertMsg("注意！注意！危险提示！！！！！！");
                if (MessageBox.Show("操作错误,当前版本为旧版本！确定要执意执行吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //UploadVersion();
                    //UploadFile();

                    Thread tr = new Thread(new ThreadStart(UploadVersion));
                    tr.Start();
                    Thread tr2 = new Thread(new ThreadStart(UploadFile));
                    tr2.Start();
                }
            }
            else
            {
                if (MessageBox.Show("确定要上传资料吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //UploadVersion();
                    //UploadFile();
                    Thread tr = new Thread(new ThreadStart(UploadVersion));
                    tr.Start();
                    Thread tr2 = new Thread(new ThreadStart(UploadFile));
                    tr2.Start();
                }
            }
            
        }
        //下载
        public void btnDown_Click(object sender, EventArgs e)
        {
            if (Main.lblVersion.Text == "请上传版本")
            {
                Main.AlertMsg("注意！注意！危险提示！！！！！！");
                if (MessageBox.Show("操作错误,当前版本为最新版本！确定要执意执行吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //DownloadFile();
                    Thread tr = new Thread(new ThreadStart(DownloadFile));
                    tr.Start();

                }
            }
            else
            {
                if (MessageBox.Show("确定要下载资料吗", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //DownloadFile();
                    Thread tr = new Thread(new ThreadStart(DownloadFile));
                    tr.Start();
                }
            }
        }
        //上传文件
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "所有文件|*.*";//设置文件类型
            OpenFileDialog1.Title = "数据文件";//设置标题
            string FileName = "";
            OpenFileDialog1.AutoUpgradeEnabled = true;//是否随系统升级而升级外观
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)//如果点的是确定就得到文件路径
            {
                // D:\Appliction\Criss++7.0代码\BL71\BL71\Bowtech\bin\Debug\BaseLib.dll
                FileName = OpenFileDialog1.FileName;//得到文件路径
                string fileName = FileName.Substring(FileName.LastIndexOf("\\")+1);
                UploadFile(FileName, fileName);//上传文件
            }

        }
        
        public void UploadFile()
        {
            lblWate.Visible = true;
            Application.DoEvents();

            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            string bucket = "mydb";
            string saveKey = "Bowtech.db";
            string localFile =  Application.StartupPath+"\\Bowtech.db";
            // 上传策略，参见 
            // https://developer.qiniu.com/kodo/manual/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
             putPolicy.Scope = bucket + ":" + saveKey;
            //putPolicy.Scope = bucket;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
           // putPolicy.DeleteAfterDays = 1;
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);




            UploadManager um = new UploadManager();

            //先删除
            BucketManager bm = new BucketManager(mac);
            bm.Delete(bucket, saveKey);

            HttpResult result = um.UploadFile(localFile, saveKey, token);
            string res = result.ToString();
            if (res.Substring(0, 8) == "code:200")
            {
                lblWate.Visible = false;
                Application.DoEvents();
                Main.AlertMsg("上传完成");
                Main.lblVersion.Text = "最新版本";
            }
            else
            {
                
                Main.AlertMsg(res);
            }



        }
        //上传文件
        public void UploadFile(string Path,string fileName)
        {
            lblWate.Visible = true;
            Application.DoEvents();

            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            string bucket = "allfile";
            string saveKey = fileName;
            string localFile = Path;
            // 上传策略，参见 
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            putPolicy.Scope = bucket + ":" + saveKey;
            //putPolicy.Scope = bucket;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            // putPolicy.DeleteAfterDays = 1;
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);




            UploadManager um = new UploadManager();

            //先删除
            BucketManager bm = new BucketManager(mac);
            bm.Delete(bucket, saveKey);

            HttpResult result = um.UploadFile(localFile, saveKey, token);
            string res = result.ToString();
            if (res.Substring(0, 8) == "code:200")
            {
                lblWate.Visible = false;
                Application.DoEvents();
                Main.AlertMsg("上传完成");

            }
            else
            {
                Main.AlertMsg(res);
            }



        }

        //上传版本
        public void UploadVersion()
        {
            lblWate.Visible = true;
            Application.DoEvents();

            int dbversion = dal.ExecuteInt("Select VersionID From Version");

            string serverVersion = getVersionName();

            Mac mac = new Mac(AK, SK);
            string bucket = "mydb";
            string saveKey = "version"+ dbversion+".txt";
            string localFile = Application.StartupPath + "\\version" + dbversion + ".txt";

            try
            {
                if (!File.Exists(localFile))
                {
                    FileStream fs = new FileStream(localFile, FileMode.Create);
                    
                    fs.Close();
                }
            }
            catch
            {

            }

            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.SetExpires(3600);
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);

            UploadManager um = new UploadManager();

            //先删除
            BucketManager bm = new BucketManager(mac);
            bm.Delete(bucket, serverVersion);

            HttpResult result = um.UploadFile(localFile, saveKey, token);
            string res = result.ToString();
            try
            {
                File.Delete(localFile);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 下载可公开访问的文件
        /// </summary>
        public void DownloadFile()
        {
            lblWate.Visible = true;
            Application.DoEvents();

            Random rd = new Random();
            int dom = rd.Next(0, 999999);
            // 文件URL
            string rawUrl = "http://omt3z8gfa.bkt.clouddn.com/Bowtech.db?id="+ dom;
            // 要保存的文件名，如果已存在则默认覆盖
            string saveFile = Application.StartupPath + "\\Bowtech.db";
            // 可公开访问的url，直接下载
            HttpResult result = DownloadManager.Download(rawUrl, saveFile);
            string res = result.ToString();
            if (res.Substring(0, 8) == "code:200")
            {
                lblWate.Visible = false;
                Application.DoEvents();
                Main.AlertMsg("下载完成");
                Main.lblVersion.Text = "最新版本";
            }
            else
            {
                Main.AlertMsg(res);
            }
        }
        /// <summary>
        /// 下载私有空间中的文件
        /// </summary>
        public void DownloadPrivateFile()
        {
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            Random rd = new Random();
            int dom = rd.Next(0, 999999);
            // 文件URL
            string rawUrl = "http://omt3z8gfa.bkt.clouddn.com/Bowtech.db?id=" + dom;
            string saveFile = Application.StartupPath + "\\Bowtech.db";
            // 设置下载链接有效期3600秒
            int expireInSeconds = 3600;
            string accUrl = DownloadManager.CreateSignedUrl(mac, rawUrl, expireInSeconds);
            // 接下来可以使用accUrl来下载文件
            HttpResult result = DownloadManager.Download(accUrl, saveFile);
            Console.WriteLine(result);
        }

        //获取服务器版本名称
        public string getVersionName()
        {
            try
            {
                CdnRefresh();

                // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
                // 实际应用中，请自行设置您的AccessKey和SecretKey
                Mac mac = new Mac(AK, SK);
                string bucket = "mydb";
                string marker = ""; // 首次请求时marker必须为空
                string prefix = null; // 按文件名前缀保留搜索结果
                string delimiter = null; // 目录分割字符(比如"/")
                int limit = 100; // 单次列举数量限制(最大值为1000)
                BucketManager bm = new BucketManager(mac);
                List<FileDesc> items = new List<FileDesc>();
                do
                {
                    ListResult result = bm.ListFiles(bucket, prefix, marker, limit, delimiter);
                    Console.WriteLine(result);
                    marker = result.Result.Marker;
                    if (result.Result.Items != null)
                    {
                        items.AddRange(result.Result.Items);
                    }
                } while (!string.IsNullOrEmpty(marker));


                for (int i = 0; i < items.Count; i++)
                {
                    //判断名称里是否包含 Version  例：Version0
                    if (items[i].Key.IndexOf("version") >= 0)
                    {
                        return items[i].Key;
                    }
                }

                return "";
            }
            catch (Exception ep)
            {
                return "";
            }
        }
        /// <summary>
        /// 缓存刷新
        /// </summary>
        public void CdnRefresh()
        {
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            CdnManager cdnMgr = new CdnManager(mac);
            string[] dirs = new string[] { "http://omt3z8gfa.bkt.clouddn.com/" };
            var result = cdnMgr.RefreshDirs(dirs);

            Console.WriteLine(result);
        }
    }
}
