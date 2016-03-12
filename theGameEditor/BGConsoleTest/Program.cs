using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGService;
using BGModel;
using System.Reflection;

namespace BGConsoleTest
{
    public class Program
    {
        public static readonly string url = "http://110.88.23.75:8899/mail.php";
        public static readonly string name = "sad";
        public static readonly int bg = 666;
        public static readonly string itemId = "Cs_bc_002";
        public static readonly string filePath = @"C:\game\blackGold\resServer\ini\Item\ItemUse.xml";

        public static void Main(string[] args)
        {
            //var test = BGService.MailService.SendItemAndBg(url, name, bg, itemId);
            //Console.Write(string.Format($"发送结果:{test}"));

            //var temp = BGService.MailService.HttpGet("http://tech.163.com/16/0310/11/BHPURNVE00094O5H.html", "");
            //Console.WriteLine(temp);

            //var temp = XmlHelper.Test(filePath); 
            //var ret = XmlHelper.ConvertList<ItemUse>(temp);

            var className = XmlHelper.GetHostPath(filePath);
            Type classType = XmlHelper.GetModelOfpath(className);

            MethodInfo method = typeof(XmlHelper).GetMethod("ConvertList");
            var methodTemp = method.MakeGenericMethod(classType);
            var tempP = new object[] { XmlHelper.Test(filePath) };
            var b =methodTemp.Invoke(null, tempP);
            //var T = XmlHelper.ConvertList<sbyte>(XmlHelper.Test(filePath));
            //Convert.ChangeType(b, List<classType>);
            //var c = b as IEnumerable();
            //var d = XmlHelper.temp<T>(b, classType.);
            Console.ReadKey();
        }
    }
}
