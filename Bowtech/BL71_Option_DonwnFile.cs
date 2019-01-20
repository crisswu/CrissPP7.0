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
using Qiniu.CDN;

namespace Bowtech
{
    public partial class BL71_Option_DonwnFile : Form
    {
        BL71_Main Main;
        //七牛 接口
        string AK = "BjSys2_mqjjij_xW_9IROgvkNcssC5qh91Nx9khH";
        string SK = "cULYrizgRT432gUWtQO1umAa29Gk1Lntb7vbj-QL";

        SQLite dal;
        public BL71_Option_DonwnFile(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Main = M;
        }

        #region 切换图片
        private void btnDel_MouseEnter(object sender, EventArgs e)
        {
            btnDel.Image = Properties.Resources.Cloud;
        }

        private void btnDel_MouseLeave(object sender, EventArgs e)
        {
            btnDel.Image = Properties.Resources.DelFile;
        }
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }
        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }

        private void btnDown_MouseEnter(object sender, EventArgs e)
        {
            btnDown.Image = Properties.Resources.Cloud;
        }
        private void btnDown_MouseLeave(object sender, EventArgs e)
        {
            btnDown.Image = Properties.Resources.Down1;
        }
        #endregion

        private void BL71_Option_ConnectDB_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            Qiniu.JSON.JsonHelper.JsonSerializer = new AnotherJsonSerializer();
            Qiniu.JSON.JsonHelper.JsonDeserializer = new AnotherJsonDeserializer();
            ListFiles();
        }

        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        //下载
        private void btnDown_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string SaveFile = folderBrowserDialog1.SelectedPath;
                string fileName = grd.SelectedRows[0].Cells[0].Value.ToString();
                DownloadFile(fileName, SaveFile);
            }
            
        }

        /// <summary>
        /// 获取空间文件列表          
        /// </summary>
        public void ListFiles()
        {
            try
            {
                CdnRefresh();

                // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
                // 实际应用中，请自行设置您的AccessKey和SecretKey
                Mac mac = new Mac(AK, SK);
            string bucket = "allfile";
            string marker = ""; // 首次请求时marker必须为空
            string prefix = null; // 按文件名前缀保留搜索结果
            string delimiter = null; // 目录分割字符(比如"/")
            int limit = 100; // 单次列举数量限制(最大值为1000)
            BucketManager bm = new BucketManager(mac);
                List<FileDesc> items = new List<FileDesc>();
                List<string> commonPrefixes = new List<string>();
                do
                {
                    ListResult result = bm.ListFiles(bucket, prefix, marker, limit, delimiter);
                    Console.WriteLine(result);
                    marker = result.Result.Marker;
                    if (result.Result.Items != null)
                    {
                        items.AddRange(result.Result.Items);
                    }
                    if (result.Result.CommonPrefixes != null)
                    {
                        commonPrefixes.AddRange(result.Result.CommonPrefixes);
                    }
                } while (!string.IsNullOrEmpty(marker));

                foreach (string cp in commonPrefixes)
                {
                    Console.WriteLine(cp);
                }
                foreach (var item in items)
                {
                    Console.WriteLine(item.Key);
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("FileName");
                dt.Columns.Add("FileSize");

                for (int i = 0; i < items.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["FileName"] = items[i].Key;
                    long size = items[i].Fsize / 1000;
                    string FS = size > 1000 ? (size / 1000).ToString() + "MB" : size + "KB";
                    dr["FileSize"] = FS;
                    dt.Rows.Add(dr);
                }
                grd.DataSource = dt;


            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 下载可公开访问的文件
        /// </summary>
        public void DownloadFile(string FileName, string SaveFile)
        {
            lblWate.Visible = true;
            Application.DoEvents();


            Random rd = new Random();
            int dom = rd.Next(0, 999999);
            // 文件URL
            string rawUrl = "http://omwseoozy.bkt.clouddn.com/"+ FileName + "?id=" + dom;
            // 要保存的文件名，如果已存在则默认覆盖
            string saveFile = SaveFile+"\\"+FileName;// Application.StartupPath + "\\Bowtech.db";
            // 可公开访问的url，直接下载
            HttpResult result = DownloadManager.Download(rawUrl, saveFile);
            string res = result.ToString();
            if (res.Substring(0, 8) == "code:200")
            {
                lblWate.Visible = false;
                Application.DoEvents();
                MessageBox.Show("下载完成", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除文件吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                lblWate.Visible = true;
                Application.DoEvents();

                // 生成(上传)凭证时需要使用此Mac
                // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
                // 实际应用中，请自行设置您的AccessKey和SecretKey
                Mac mac = new Mac(AK, SK);
                string bucket = "allfile";
                string fileName = grd.SelectedRows[0].Cells[0].Value.ToString();
                string saveKey = fileName;


                PutPolicy putPolicy = new PutPolicy();
                putPolicy.Scope = bucket + ":" + saveKey;

                putPolicy.SetExpires(3600);

                string jstr = putPolicy.ToJsonString();
                string token = Auth.CreateUploadToken(mac, jstr);

                //先删除
                BucketManager bm = new BucketManager(mac);
                HttpResult result = bm.Delete(bucket, saveKey);
                string res = result.ToString();
                if (res.Substring(0, 8) == "code:200")
                {
                    lblWate.Visible = false;
                    Application.DoEvents();
                    Main.AlertMsg("删除完成！");
                    ListFiles();
                }
                else
                {
                    Main.AlertMsg(res);
                }
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
            string[] dirs = new string[] { "http://omwseoozy.bkt.clouddn.com/" };
            var result = cdnMgr.RefreshDirs(dirs);
            // 或者使用下面的方法
            //RefreshRequest request = new RefreshRequest();
            //request.AddDirs(dirs);
            //var result = cdnMgr.RefreshUrlsAndDirs(request);
            Console.WriteLine(result);
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

}
