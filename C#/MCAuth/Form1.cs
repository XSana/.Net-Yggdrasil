using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using MCAuth.json;

namespace MCAuth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var JsonData = Auth(textBox1.Text,textBox2.Text);
            if (JsonData != "") {
                //判断返回信息是否有效，有效则进行反序列化
                auth AuthData;
                var jsonText = new MemoryStream(Encoding.UTF8.GetBytes(JsonData));
                var jsonRead = new DataContractJsonSerializer(typeof(auth));
                AuthData = jsonRead.ReadObject(jsonText) as auth;
                jsonText.Close();
                var Mes = new StringBuilder();
                Mes.Append("name:").Append(AuthData.selectedProfile.name).Append("\n");
                Mes.Append("uuid:").Append(AuthData.selectedProfile.id).Append("\n");
                Mes.Append("token:").Append(AuthData.clientToken);
                if (AuthData.twitch(AuthData.user) != "")
                {
                    Mes.Append("\n").Append("twitch:").Append(AuthData.twitch(AuthData.user));
                }
                MessageBox.Show(Mes.ToString());
            }
        }
        
        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        private string Auth(string user,string password)
        {
            var ret = string.Empty;
            try
            {
                var data = "{\"agent\":{\"name\":\"Minecraft\",\"version\":\"1\"},\"username\":\"" + user + "\",\"password\":\"" + password + "\",\"requestUser\":\"true\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(data); //转化
                var webReq = (HttpWebRequest)WebRequest.Create(new Uri(@"https://authserver.mojang.com/authenticate"));
                webReq.Method = "POST";
                webReq.ContentType = "application/json";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                var response = (HttpWebResponse)webReq.GetResponse();
                var sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
