using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BGService
{
    public class XmlHelper
    {

        /// <summary>
        /// MODEL类的命名空间
        /// </summary>
        public static readonly string AssemblyNameModel = "BGModel";
         /// <summary>
         /// Model层中所有的class的集合
         /// </summary>
        public static readonly List<Type> BgModelClassList;

         static XmlHelper()
        {
            Assembly asm = Assembly.Load(AssemblyNameModel);
            BgModelClassList = asm.GetTypes().ToList();
        }
        /// <summary>
        /// 反射xml文件，将类和文件一一对应
        /// 生成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Convert<T>(XmlNode xmlNode) where T : new()
        {
            if (xmlNode == null)
            {
                return default(T);
            }

            Type t = typeof(T);
            var retT = new T();
            var temp = t.GetProperties();
            if (temp != null)
            {
                foreach (PropertyInfo property in temp)
                {
                    //Console.WriteLine("type:" + property.PropertyType);
                    //Console.WriteLine("name:" + property.Name);
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(retT, xmlNode.GetIntValue(property.Name)); //向retT的这个属性段加值
                    }
                    else
                    {
                        property.SetValue(retT, xmlNode.GetStrValue(property.Name)); //向retT的这个属性段加值
                    }
                }
            }
            return retT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlNodeList"></param>
        /// <returns></returns>
        public static List<T> ConvertList<T>(XmlNodeList xmlNodeList) where T : new()
        {
            var retTList = new List<T>();
            if (xmlNodeList == null || xmlNodeList.Count == 0)
            {
                return retTList;
            }

            foreach (XmlNode item in xmlNodeList)
            {
                var tempT = Convert<T>(item);
                retTList.Add(tempT);
            }

            return retTList;
        }

        public static XmlNodeList Test(string hostAddressXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(hostAddressXml);

            var nodeList = doc.SelectNodes("/Object/Property");
            if (nodeList != null && nodeList.Count > 0)
            {
                return nodeList;
            }

            return null;
        }

        /// <summary>
        /// 获得本地xml所对应的model 类
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static Type GetModelOfpath(string className)
        {
            if(string.IsNullOrWhiteSpace(className) )
            return null;

            var retType = BgModelClassList.FirstOrDefault(x => x.Namespace.Contains(AssemblyNameModel)
                                    && x.Name == className);
            if (retType!=null)
            {
                return retType;
            }
            return null;
        }

        /// <summary>
        /// 获得.xml前面的文件名
        /// C:\game\blackGold\resServer\ini\Item\ItemUse.xml
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetHostPath(string path)
        {
            var key = ".xml";

            if (!path.ToLower().Contains(key))
            {
                return string.Empty;
            }

            var list = path.Split('\\').ToList().FindAll(x=>!string.IsNullOrWhiteSpace(x));
            if (list.Count > 0)
            {
                var temp = list[list.Count - 1];
                if (temp.ToLower().Contains(key))
                {
                    var className = temp.Split('.')[0];
                    if (!string.IsNullOrWhiteSpace(className))
                    {
                        return className;
                    }
                }
            }

            return string.Empty;
        }

        public static T temp<T>(object obj, T tt)
        {
            //var a = tt.GetType();
            return (T)obj;
        }
    }
}
