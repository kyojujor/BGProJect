using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;

namespace BGService
{
    public class MailService
    {
        /// <summary>
        /// 
        /// http://110.88.23.75:8899/mail.php?name=的定位球的&bg=1&item=Cs_bc_002
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <param name="bg"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static string SendItemAndBg(string address, string name, int bg = 0, string item = "")
        {
            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(name))
                return "端口号或角色名不能为空";

            var paramsStr = "name=" + name + "&";
            if (bg != 0)
                paramsStr += "bg=" + bg + "&";
            if (!string.IsNullOrWhiteSpace(item))
                paramsStr += "item" + item + "&";

            paramsStr = paramsStr.Trim('&');

            return HttpGet(address, paramsStr);

        }

        /// <summary>
        /// httpGet请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            var a = Url + (postDataStr == "" ? "" : "?") + postDataStr;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(a);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

    }
}
