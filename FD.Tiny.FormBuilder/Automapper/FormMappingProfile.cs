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

            JsonHelper.Setting.Converters.Add(new DataSourceConvert());
            //formPo to form           
            CreateMap<FormPO, Form>()
                .ForMember(dest => dest.group_list, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<FormGroup>>(src.FORM_CONFIG));
                });
                  
            CreateMap<LabelPO, Label>()                
               // .IncludeAllDerived()
                .ForMember(dest=> dest.data_type, opt => {
                    opt.MapFrom(src => (DataType)src.DATA_TYPE);
                })
                .ForMember(dest=>dest.label_type,opt=>
                {
                    opt.MapFrom(src => (LabelType)src.LABEL_TYPE);
                })
                .ForMember(dest => dest.label_config, opt => {
                    opt.MapFrom(src => JsonHelper.Instance.Deserialize<LabelConfig>(src.LABEL_CONFIG));
                })         
            .ConvertUsing<LabelDtoConvert>()
            ;

            CreateMap<LabelPO, ControlLabel>()
            //    .ForMember(dest => dest.label_config, opt => opt.Ignore())
            //.ForMember(dest => dest.label_config, opt =>
            //   {
            //       opt.MapFrom(src => JsonHelper.Instance.Deserialize<ControlConfig>(src.LABEL_CONFIG));
            //   })
            .IncludeBase<LabelPO, Label>()
            ;

            CreateMap<LabelPO, VariableLabel>()
             //   .ForMember(dest => dest.label_config, opt => opt.Ignore())
            //.ForMember(dest => dest.label_config, opt =>
            //{
            //    opt.MapFrom(src => JsonHelper.Instance.Deserialize<VariableConfig>(src.LABEL_CONFIG));
            //})
             .IncludeBase<LabelPO, Label>()
            ;

            CreateMap<LabelPO, ConditionLabel>()

                  //.ForMember(dest => dest.label_config, opt =>
                  //{
                  //    opt.MapFrom(src => JsonHelper.Instance.Deserialize<ConditionConfig>(src.LABEL_CONFIG));
                  //})
              .IncludeBase<LabelPO, Label>()
            ;


            CreateMap<FormStorePO, FormStore>()
                .ForMember(dest => dest.label_data_list, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Deserialize<List<LabelData>>(src.DATA_STORE_CONTENT));
                });              

            //form to formPo
            //CreateMap<Category, CategoryPO>();
            CreateMap<Form, FormPO>()
                .ForMember(dest=>dest.FORM_CONFIG,opt=> {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.group_list));
                });

            //label to labelPo
            CreateMap<Label, LabelPO>()
                .ForMember(dest => dest.DATA_TYPE, opt =>
                {
                    opt.MapFrom(src => (int)src.data_type);
                })
                .ForMember(dest => dest.LABEL_TYPE, opt =>
                   {
                       opt.MapFrom(src => (int)src.label_type);
                   })
                    .ForMember(dest => dest.LABEL_CONFIG, opt =>
                    {
                        opt.MapFrom(src => JsonHelper.Instance.Serialize(src.label_config));
                    });


            CreateMap<ControlLabel, LabelPO>()
                .IncludeBase<Label, LabelPO>();

            CreateMap<VariableLabel, LabelPO>()
                  .IncludeBase<Label, LabelPO>();

            CreateMap<ConditionLabel, LabelPO>()
                  .IncludeBase<Label, LabelPO>();




            CreateMap<FormStore, FormStorePO>()
                .ForMember(dest => dest.DATA_STORE_CONTENT, opt =>
                {
                    opt.MapFrom(src => JsonHelper.Instance.Serialize(src.label_data_list));
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


            //dict mapper
            CreateMap<DictionaryPO, Dict>();
            CreateMap<Dict, DictionaryPO>();
        }
    }
}
