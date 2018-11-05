using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class AutomapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<FormMappingProfile>();                
            });
        }
    }
}
