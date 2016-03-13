using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BGService
{
    public static class StaticServicer
    {
        public static string GetStrValue(this XmlNode obj, string name)
        {
            if (obj.Attributes[name] == null)
                return "";

            return obj.Attributes[name].Value;
        }

        public static int GetIntValue(this XmlNode obj, string name)
        {
            var ret = obj.Attributes[name];

            if (ret == null)
                return 0;

            var retInt = Convert.ToInt32(ret.Value);
            return retInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetLenth(this string obj, int len)
        {
            if (obj == null)
                return string.Empty;

            if (obj.Length <= len)
                return obj;

            return obj.Substring(0, len);
        }

        /// <summary>
        /// 不足需要补充
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetLenthRe(this string obj, int len, string str)
        {
            if (obj == null)
                return string.Empty;

            if (obj.Length  < len)
            {
                return obj.PadRight(len);
            }

            return obj.Substring(0, len);
        }
    }
}
