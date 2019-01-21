using FD.Tiny.Common.Utility.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class JsonConfig
    {
        public static void Config()
        {
            JsonHelper.Setting.Converters.Add(new DataSourceConvert());
            JsonHelper.Setting.Converters.Add(new LabelConfigConvert());
        }
    }
}
