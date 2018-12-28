﻿//数据类型
var DataType = { Number: 0, String: 1, Date: 2 }
//标签类型
var LabelType = { control: 0, variable: 1, condition: 2 }
//取值方法
var ValueMethod = { Const: 0, Formula: 1 }
//关联规则
var RelateRule = { 赋值: 'assignment', 加载地图: 'loadmap', 加载子下拉框: 'loadsubselect' }
//数据源类型
var DataSourceType = { Dict: 0, Custom: 1, DataApi: 2 }
//标签库
var FormComponents = [
    {
        component_group: '表单标签',
        component_list: [
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '变量',
                form: null,
                inner_value: '',

                label_type: LabelType.variable,
                label_config: {
                    is_parameter: false,
                    value_method: ValueMethod.Const
                }
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '条件',
                form: null,
                inner_value: '',
                label_type: LabelType.condition,
                label_config: {
                    condition_list: []
                }
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '普通文本',
                form: null,
                inner_value: '',
                default_value: '',
                label_type: LabelType.control,
                label_config: {
                    control_type: 'input_base',
                    label_sort: 0,
                    group_name: '',
                    validator_config: {
                        validator_list: []
                    },
                    data_source_config: null,
                    relate_config: {
                        relate_list: []
                    },
                    database_config: null,
                    format_config: null,
                    map_config: null,
                    control_options: [
                        { key: 'placeholder', value: '' },
                        { key: 'clearable', value: true },
                        { key: 'readonly', value: false }
                    ]
                }
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '远程文本',
                form: null,
                inner_value: '',
                label_type: LabelType.control,
                label_config: {
                    control_type: 'input_autocomplete',
                    label_sort: 0,
                    group_name: '',
                    validator_config: {
                        validator_list: []
                    },
                    data_source_config: null,
                    relate_config: {
                        relate_list: []
                    },
                    database_config: null,
                    format_config: null,
                    map_config: null,
                    control_options: [
                        { key: 'placeholder', value: '' },
                        { key: 'clearable', value: true },
                        { key: 'readonly', value: false },
                        { key: 'trigger-on-focus', value: true }
                    ]
                }
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '远程文本',
                form: null,
                inner_value: '',
                label_type: LabelType.control,
                label_config: {
                    control_type: 'select',
                    label_sort: 0,
                    group_name: '',
                    validator_config: {
                        validator_list: []
                    },
                    data_source_config: null,
                    relate_config: {
                        relate_list: []
                    },
                    database_config: null,
                    format_config: null,
                    map_config: null,
                    control_options: [
                        { key: 'placeholder', value: '' },
                        { key: 'clearable', value: true },
                        { key: 'readonly', value: false }
                    ]
                }
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '多行文本',
                control_type: 'input_textarea',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '单选框',
                control_type: 'radio',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '复选框',
                control_type: 'checkbox',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '时间选择',
                control_type: 'time',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '日期选择',
                control_type: 'date',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '是非选项',
                control_type: 'switch',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '数字框',
                control_type: 'input_number',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '滑块',
                control_type: 'slider',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            },
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '评分',
                control_type: 'rate',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {}
            }
        ]
    },
    {
        component_group: '展示标签',
        component_list: [
            {
                control_type: 'html',
                label_name_chs: 'HTML',
                label_id: 0
            },
            {
                control_type: 'rtf',
                label_name_chs: '富文本',
                label_id: 0
            },
        ]
    },
    {
        component_group: '扩展标签',
        component_list: [
            {
                control_type: 'map_gis',
                label_name_chs: 'GIS地图',
                label_id: 0
            },
            {
                control_type: 'map_baidu',
                label_name_chs: '百度地图',
                label_id: 0
            }
        ]
    }
]
//字典测试数据
var DictTest = [
    {
        dic_type_id: 4003001,
        dic_type_name: '景观',
        child: [
            { dic_par_id: 4003001001, dic_par_name: '江景' },
            { dic_par_id: 4003001002, dic_par_name: '街景' },
            { dic_par_id: 4003001003, dic_par_name: '湘江' },
            { dic_par_id: 4003001004, dic_par_name: '岳麓山' },
            { dic_par_id: 4003001005, dic_par_name: '高尔夫景' },
            { dic_par_id: 4003001006, dic_par_name: '海景' },
            { dic_par_id: 4003001007, dic_par_name: '河景' }
        ]
    },
    {
        dic_type_id: 4003002,
        dic_type_name: '朝向',
        child: [
            { dic_par_id: 4003002001, dic_par_name: '东' },
            { dic_par_id: 4003002002, dic_par_name: '南' },
            { dic_par_id: 4003002003, dic_par_name: '西' },
            { dic_par_id: 4003002004, dic_par_name: '北' },
            { dic_par_id: 4003002005, dic_par_name: '金角' },
            { dic_par_id: 4003002006, dic_par_name: '银角' },
            { dic_par_id: 4003002007, dic_par_name: '铜角' },
            { dic_par_id: 4003002008, dic_par_name: '铁角' }
        ]
    }
]