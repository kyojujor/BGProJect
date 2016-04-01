using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel.CommonHelper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        public string Desc { get; }

        public DescriptionAttribute(string str)
        {
            Desc = str;
        }

    }
    public class SplitHelper
    {
        public static void splitDropStr<T>(string input, ref string outStr, ref List<T> ret) where T : new()
        {
            var res = new List<T>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var itemList = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var item in itemList)
                    {
                        var model = new T();
                        var proplist = typeof(T).GetProperties().ToList();
                        var list = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (proplist.Count != list.Count)
                            return;

                        for (var i = 0; i < list.Count; i++)
                        {
                            if (proplist[i].PropertyType == typeof(string))
                            {
                                proplist[i].SetValue(model, list[i]);
                            }
                            if (proplist[i].PropertyType == typeof(int))
                            {
                                proplist[i].SetValue(model, Convert.ToInt32(list[i]));
                            }
                        }
                        res.Add(model);
                    }
                    outStr = input;
                    ret = res;
                }
            }
        }
    }

}
