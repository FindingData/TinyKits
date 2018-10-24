using AutoMapper;
using FD.Tiny.Common.Utility.Helper;
using FD.Tiny.Common.Utility.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class FormMappingProfile : Profile
    {
        public FormMappingProfile()
        {
            //formPo to form
            // CreateMap<CategoryPO, Category>();
            CreateMap<FormPO, Form>();
            CreateMap<FormVariablePO, FormVariable>()                            
            .ForMember(dest => dest.database_config, opt =>
            {
                opt.MapFrom(src => JsonHelper.Instance.Deserialize<DatabaseConfig>(src.DATABASE_CONFIG));
            })
            .ForMember(dest => dest.data_type, opt =>
            {
                opt.MapFrom(src => (DataType)src.DATA_TYEP);
            })
              .ForMember(dest => dest.variable_type, opt =>
              {
                  opt.MapFrom(src => (VariableType)src.VARIABLE_TYPE);
              }).ConvertUsing<FormVariableDtoConvert>();

            CreateMap<FormVariablePO, LabelVariable>()
                  .ForMember(dest => dest.value_method, opt =>
                  {
                      opt.MapFrom(src => (ValueMethod)src.VALUE_METHOD);
                  })
                .IncludeBase<FormVariablePO,FormVariable>();
            CreateMap<FormVariablePO, ConditionVariable>()                
                .IncludeBase<FormVariablePO, FormVariable>()
                  .ForMember(dest => dest.condition_list, opt =>
                  {
                      opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<Condition>>(src.CONDITION_CONFIG));
                  });                

            CreateMap<LabelPO, Label>()
                .ForMember(dest=> dest.data_type, opt => {
                    opt.MapFrom(src => (DataType)src.DATA_TYPE);
                })
                .ForMember(dest => dest.label_config, opt =>
                   {
                       opt.MapFrom(src => JsonHelper.Instance.Deserialize<LabelConfig>(src.LABEL_CONFIG));
                   });
            CreateMap<FormStorePO, FormStore>()
                .ForMember(dest => dest.label_data_list, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<LabelData>>(src.DATA_STORE_CONTENT));
                })
                .ForMember(dest => dest.form_data_list, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<FormData>>(src.FORM_STORE_CONTENT));
                });


            //form to formPo
            //CreateMap<Category, CategoryPO>();
            CreateMap<Form, FormPO>();
            CreateMap<FormVariable, FormVariablePO>()
                .ForMember(dest => dest.DATABASE_CONFIG, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.database_config));
                })
                .ForMember(dest => dest.DATA_TYEP, opt =>
                {
                    opt.MapFrom(src => (int)src.data_type);
                })
              .ForMember(dest => dest.VARIABLE_TYPE, opt =>
               {
                   opt.MapFrom(src => (int)src.variable_type);
               });


            CreateMap<LabelVariable, FormVariablePO>()
                  .ForMember(dest => dest.VALUE_METHOD, opt =>
                  {
                      opt.MapFrom(src => (int)src.value_method);
                  })
              .IncludeBase<FormVariable, FormVariablePO>();

            CreateMap<ConditionVariable, FormVariablePO>()
                   .ForMember(dest => dest.CONDITION_CONFIG, opt =>
                   {
                       opt.MapFrom(src => JsonHelper.Instance.Serialize(src.condition_list));
                   })
                .IncludeBase<FormVariable, FormVariablePO>();

            CreateMap<Label, LabelPO>()
                .ForMember(dest => dest.DATA_TYPE, opt => {
                    opt.MapFrom(src => (int)src.data_type);
                })
                .ForMember(dest => dest.LABEL_CONFIG, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.label_config));
                });

            CreateMap<FormStore, FormStorePO>()
                .ForMember(dest => dest.DATA_STORE_CONTENT, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.label_data_list));
                })
                .ForMember(dest => dest.FORM_STORE_CONTENT, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.form_data_list));
                });

            //apiPo to api
            CreateMap<ApiPO, Api>().ForMember(dest => dest.request_parameter_list, opt =>
            {
                opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<ApiParameter>>(src.REQUEST_PARAMETER_CONTENT));
            })
            .ForMember(dest => dest.response_parameter_list, opt =>
            {
                opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<ApiParameter>>(src.RESPONSE_PARAMETER_CONTENT));
            });


            //api to apiDto
            CreateMap<Api, ApiPO>().ForMember(dest => dest.REQUEST_PARAMETER_CONTENT, opt =>
            {
                opt.MapFrom(src => JsonHelper.Instance.Serialize(src.request_parameter_list));
            })
            .ForMember(dest => dest.RESPONSE_PARAMETER_CONTENT, opt =>
            {
                opt.MapFrom(src => JsonHelper.Instance.Serialize(src.response_parameter_list));
            });

            //dbPo to db
            CreateMap<DbTablePO, DbTable>();
            CreateMap<DbColumnPO, DbColumn>()
                .ForMember(dest => dest.data_type, opt =>
                {
                    opt.MapFrom(src => (DataType)src.DATA_TYPE);
                });

            //db to dbPo
            CreateMap<DbTable, DbTablePO>();
            CreateMap<DbColumn, DbColumnPO>()
                .ForMember(dest => dest.DATA_TYPE, opt =>
                {
                    opt.MapFrom(src => (int)src.data_type);
                });
        }
    }
}
