using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team159.Models
{
    public class EnumHelper
    {
        public static IList<SelectListItem> ToSelectList(Type enumType)
        {
            IList<SelectListItem> listItem = new List<SelectListItem>();
            if (enumType.IsEnum)
            {
                Array values = Enum.GetValues(enumType);
                if (values.Length > 0)
                {
                    foreach (int item in values)
                    {
                        listItem.Add(new SelectListItem { Value = item.ToString(), Text = Enum.GetName(enumType, item) });
                    }
                }
            }
            else
            {
                throw new ArgumentException("请传入正确的枚举！");
            }
            return listItem;
        }
    }
}
