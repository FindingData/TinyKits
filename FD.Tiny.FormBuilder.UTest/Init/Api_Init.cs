using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder.UTest.Init
{
    public class Api_Init
    {
        protected ApiService _apiService { get; set; }

        public Api_Init()
        {
            _apiService = AutofacExt.GetFromFac<ApiService>();
        }

        public void Inits()
        {
            AddDictApiTest();
            AddPcaApiTest();
            AddGetConstructionsApiTest();
            AddGetBuildingsApiTest();
            AddHouseApi();
        }

      
        private int AddApi(Api api)
        {
            if (_apiService.IsExistApi(api.api_name))
            {
                var dbApi = _apiService.GetApi(api.api_name);
                api.api_id = dbApi.api_id;
                _apiService.SaveApi(api, 0);
                return api.api_id;
            }
            return _apiService.AddApi(api, 0);
        }

        protected  void AddDictApiTest()
        {
            var api = new Api();
            api.api_name = "获取字典";
            api.sql_content = "SELECT d.dic_par_id, d.dic_par_name FROM ompd.t_dictionary d WHERE d.dic_type_id = :dic_type_id ";
            api.request_parameter_list = ApiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = ApiService.GetResponseParamsFromSql(api.sql_content);
            AddApi(api);
        }

        protected  void AddPcaApiTest()
        {
            var api = new Api()
            {
                api_name = "获取区域"
            };
            api.sql_content = @"select p.pca_code, p.pca_name
  from ompd.t_pca p
 where p.pca_code like substr(:pca_code, 0, 4) || '%'; ";
            api.request_parameter_list = ApiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = ApiService.GetResponseParamsFromSql(api.sql_content);
            AddApi(api);
        }


        protected  void AddGetConstructionsApiTest()
        {
            var api = new Api()
            {
                api_name = "获取楼盘",
            };
            api.sql_content = @"SELECT c.construction_code, c.construction_name, c.address, c.pca_code
  FROM redas.t_construction c
 WHERE c.customer_id = :customer_id and trunc(c.pca_code,-2) = :pca_code and c.new_purpose_id = :new_purpose_id  and   rownum <= 10";
            api.request_parameter_list = ApiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = ApiService.GetResponseParamsFromSql(api.sql_content);
            AddApi(api);
        }


        protected void AddGetBuildingsApiTest()
        {
            var api = new Api()
            {
                api_name = "获取楼栋",
            };
            api.sql_content = @"SELECT b.building_code, b.building_name, b.over_floor_num, b.build_date
          FROM redas.t_building b
         WHERE b.construction_code = :construction_code
           and b.pca_code = :pca_code
           and b.customer_id = :customer_id
           and b.new_purpose_id = :new_purpose_id
           and rownum < 10;";
            api.request_parameter_list = ApiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = ApiService.GetResponseParamsFromSql(api.sql_content);
            AddApi(api);
        }


        protected void AddHouseApi()
        {
            var api = new Api()
            {
                api_name = "获取房号"
            };
            api.sql_content = @"SELECT h.house_name, h.house_code, h.build_area, h.floor_num, h.front_id
  FROM redas.t_house h
 WHERE h.construction_code = :construction_code
   and h.building_code = :building_code
   and h.pca_code = :pca_code
   and h.customer_id = :customer_id
   and h.new_purpose_id = :new_purpose_id
   and rownum < 10";
            api.request_parameter_list = ApiService.GetRequestParamsFromSql(api.sql_content);
            api.response_parameter_list = ApiService.GetResponseParamsFromSql(api.sql_content);
            AddApi(api);
        }        
    }
}
