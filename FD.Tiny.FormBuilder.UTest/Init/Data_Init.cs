using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest.Init
{
    public class Data_Init
    {
        protected DataService _dataService { get; set; }

        public Data_Init()
        {
            _dataService = AutofacExt.GetFromFac<DataService>();
        }

        public void Inits()
        {
            AddAddressData();
        }

        private int AddData(Data data)
        {
            if (_dataService.IsExistData(data.data_name))
            {
                var dbData = _dataService.GetData(data.data_name);
                data.data_id = dbData.data_id;
                _dataService.SaveData(data, 0);
                return data.data_id;
            }
            return _dataService.AddData(data, 0);
        }


        public void AddAddressData()
        {
            var data = new Data()
            {
                data_name = "楼盘地址",
            };
            var dataId = AddData(data);

            var data1 = new Data()
            {
                data_name = "产权地址",
                syn_data_id = dataId,
            };
            AddData(data1);

            var data2 = new Data()
            {
                data_name = "产权坐落",
                syn_data_id = dataId,
            };
            AddData(data1);
        }

    }
}
