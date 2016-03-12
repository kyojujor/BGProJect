using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BGService
{
    public static class  XmlServicer
    {
        public static string GetStrValue(this XmlNode obj,string name)
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
    }
}
