using FD.Tiny.Common.Utility.Json;
using FD.Tiny.FormBuilder.Demo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.Demo
{
    public class JsonConfig
    {
        public static void Config()
        {
            JsonHelper.Setting.Converters.Add(new DataSourceConvert());
            JsonHelper.Setting.Converters.Add(new LabelConverter());
        }
    }
}
