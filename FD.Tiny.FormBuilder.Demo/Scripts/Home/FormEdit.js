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

var DataType = { Number: 0, String: 1, Date: 2 }
var LabelType = { control: 0, variable: 1, condition: 2 }
var ValueMethod = { Const: 0, Formula:1}

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
					condition_list:[]
				}
			},
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '普通文本',
				form:null,
				inner_value: '',
				default_value: '',
				label_type: LabelType.control,
				label_config: {
					control_type: 'input_base',
					label_sort:0,
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
var RelateRule = { 赋值: 'assignment', 加载地图: 'loadmap', 加载子下拉框:'loadsubselect'}
var ValueMethod = { 常量: 0, 公式: 1 }
var DataSourceType = { Dict: 0, Custom: 1, DataApi:2}
//根据值获取属性名称
function getPropByValue(obj, val) {
    var result=''
    for (var pro in obj) {
        if (obj[pro] === val) {
            result = pro
        }
    }
    return result
}


var dfFormEditVm = new Vue({
    el: '.df-form-edit',
    components: {
        'label-template': labelTemplate,
        'quill-rtf': quillRtf,
        'dynamic-form': dynamicForm,
        'vue-scrollbar': Vue2Scrollbar
    },
    data() {
        return {
			FormComponents: FormComponents,
			DataType: DataType,
			LabelType: LabelType,
            RelateRule: RelateRule,
            ValueMethod: ValueMethod,
            DataSourceType: DataSourceType,
            DictTest: DictTest,
            activeComponentsName: '表单标签',
            setLableList: [],
            currentLabelData: {},
            currentLabelindex: -1,
            oldLabelData: {},
			oldIndex: -1,
			labelActiveName:'control',
            tabActiveName: 'normal',
            labelEditChange: true,
            formPreviewVisible: false,
            formSetVisible: false,
            formId: parseInt(getParam('formId')),
            customerForm: {
                form_name: '',
                form_type: '',
                form_share: false,
                form_des: ''
            },
            customerFormRules: {
                form_name: [{ required: true, message: '请输入表单名称', trigger: 'blur' }],
                form_type: [{ required: true, message: '请选择表单类型', trigger: 'change' }]
            },
            labelWidth: 120,
            column: 1,
            align: 'right',
            previewFormSetVisible: false,
            //添加关联dialog
            relateAddDialog: false,
            //添加关联form
            relateAddForm: {
                relateName: '',
                operatorStr: '',
                label: ''
            },
            //添加条件dialog
            conditionAddDialog: false,
            //添加条件form
            conditionAddForm: {
                conditionExpr: '',
                valueMethod: '',
                innerValue: ''
            },
            //临时的数据源设置
            tempDataSourceConfig: {
                data_source_type: '',
                dic_type_id: '',
                dic_par_ids: '',
                separtor: '',
                value: '',
                api_id:'',
                api_name: '',
                parameter_list: []
            },
            dictIndeterminate: false,
            dictIndeterminateCheckAll: false,
            dictChecked: [],
            //数据源
            dataApis: [],
            //临时的数据源api参数设置
            tempDataApiParam:[],
        }
    },
    computed: {
        dictPars() {
            var result = []
            this.DictTest.forEach(item => {
                if (this.tempDataSourceConfig.dic_type_id === item.dic_type_id) {
                    result = item.child
                }
            })
            return result
        },
        dictParIds() {
            var result = []
            this.dictPars.forEach(item => {
                result.push(item.dic_par_id)
            })
            return result
        },
    },
    methods: {
        //更新Label
        updateData(evt) {
            this.updateSort()
            console.log(this.setLableList)
        },
        //新增Label
        addData(evt) {
            this.setLableList = clone(this.setLableList)
            for (let i = 0; i < this.setLableList.length; i++) {
                if (this.setLableList[i].label_id === 0) {
                    this.setLableList[i].form_id = this.formId
                    var param = {
                        label: this.setLableList[i]
                    }
                    post('/Form/AddLabel', param, () => {
                        this.setLableList.splice(i, 1)
                    }).then(
                        res => {
                            this.setLableList[i].label_id = res
                            this.updateSort()
                        }
                    )
                }
            }
            console.log(this.setLableList)
        },
        //更新排序
        updateSort() {
            this.setLableList.forEach((item,index) => {
                if (item.label_sort !== index) {
                    item.label_sort = index
                    this.saveLabel(item)
                }
            })
        },
        //保存Label
        saveLabel(label) {
            var param = {
                label: label
            }
            post('/Form/SaveLabel', param).then(
                res => {
                    console.log('保存Label',res)
                    this.oldLabelData = clone(label)
                }
            )
        },
        //选择Label
        settingData(index) {
            if (this.currentLabelindex !== -1 && JSON.stringify(this.oldLabelData) !== JSON.stringify(this.currentLabelData)) {
                this.$confirm('未保存, 继续将不会保存更改！', '提示', {
                    confirmButtonText: '继续',
                    cancelButtonText: '取消',
                    type: 'warning'
                }).then(() => {
                    this.setLableList[this.oldIndex] = this.oldLabelData
                    this.currentLabelindex = index
                    this.currentLabelData = this.setLableList[index]
                    this.initDataSourceConfig()
                    this.oldIndex = index
                    this.oldLabelData = clone(this.currentLabelData)
                    this.tabActiveName='normal'
                    this.labelEditChange = false
                    setTimeout(() => { this.labelEditChange = true }, 0)
                }).catch(() => {
                })
            } else {
                this.currentLabelindex = index
                this.currentLabelData = this.setLableList[index]
                this.initDataSourceConfig()
                this.oldIndex = index
                this.oldLabelData = clone(this.currentLabelData)
                this.labelEditChange = false
                this.tabActiveName = 'normal'
                setTimeout(() => { this.labelEditChange = true }, 0)
            }
        },
        //初始化DataSourceConfig
        initDataSourceConfig() {
            if (this.currentLabelData.label_config.data_source_config) {
                for (var pro in this.currentLabelData.label_config.data_source_config) {
                    this.tempDataSourceConfig[pro] = this.currentLabelData.label_config.data_source_config[pro]
                }
            }
        },
        //数据源类型更改回调
        handledDataTypeChange(val) {
            this.tempDataSourceConfig = {
                data_source_type: val,
                dic_type_id: '',
                dic_par_ids: '',
                separtor: '',
                value: '',
                api_name: '',
                parameter_list: []
            }
            this.tempDataApiParam.splice(0, this.tempDataApiParam.length)
        },
        //数据源类型-字典类型更改回调
        handledDictTypeChange() {
            this.dictChecked = []
            this.dictIndeterminate = false
        },
        //数据源类型-字典类型-全选点击
        handleDictIndeterminateCheckAll(val) {
            this.dictChecked = val ? this.dictParIds : []
            this.dictIndeterminate = false
        },
        //数据源类型-字典类型-复选框更改回调
        handledDictCheckedChange(value) {
            let checkedCount = value.length
            this.dictIndeterminateCheckAll = checkedCount === this.dictPars.length
            this.dictIndeterminate = checkedCount > 0 && checkedCount < this.dictPars.length
        },
        //数据源类型-自定义类型-结果预览
        getDataSourceConfigCustomResult() {
            var result=''
            if (this.tempDataSourceConfig.value !== '' && this.tempDataSourceConfig.separtor !== '') {
                var arr = this.tempDataSourceConfig.value.split(this.tempDataSourceConfig.separtor)
                arr.forEach(item => {
                    if (result === '') {
                        result += '"' + item + '"'
                    } else {
                        result += ',"' + item + '"'
                    }
                    
                })
            }
            return '[' + result+']'
        },
        //数据源类型-api类型更改回调
        handledDataApiChange(val) {
            this.tempDataApiParam.splice(0, this.tempDataApiParam.length)
            this.dataApis.forEach(item => {
                if (item.api_id === val) {
                    item.request_parameter_list.forEach(_item => {
                        this.tempDataApiParam.push({
                            parameter_name: _item.parameter_name,
                            parameter_name_chs: _item.parameter_name_chs,
                            is_required: _item.is_required,
                            parameter_value: _item.is_required?'变量1':''
                        })
                    })
                }
            })
        },
        //获取标签项
        getLableConfigItem(attr) {
            var option = null
            this.currentLabelData.label_config.control_options.forEach(item => {
                if (item.key === attr) {
                    option = item
                }
            })
            return option
        },
        //保存标签配置
        saveLabelConfig() {
            this.$refs['Form' + this.currentLabelData.label_id].validate((valid) => {
                if (valid) {
                    this.currentLabelData.label_config.data_source_config = null
                    if (this.tempDataSourceConfig.data_source_type === DataSourceType.Custom) {
                        this.currentLabelData.label_config.data_source_config = {
                            data_source_type: this.tempDataSourceConfig.data_source_type,
                            separtor: this.tempDataSourceConfig.separtor,
                            value: this.tempDataSourceConfig.value

                        }
                    } else if (this.tempDataSourceConfig.data_source_type === DataSourceType.Dict) {
                        this.currentLabelData.label_config.data_source_config = {
                            data_source_type: this.tempDataSourceConfig.data_source_type,
                            dic_type_id: this.tempDataSourceConfig.dic_type_id,
                            dic_par_ids: this.dictChecked.join(',')
                        }
                    } else if (this.tempDataSourceConfig.data_source_type === DataSourceType.DataApi) {
                        var parameter_list=[]
                        this.tempDataApiParam.forEach(item => {
                            if (item.parameter_value !== '') {
                                var obj = {}
                                obj[item.parameter_name] = item.parameter_value
                                parameter_list.push(obj)
                            }
                        })
                        this.currentLabelData.label_config.data_source_config = {
                            data_source_type: this.tempDataSourceConfig.data_source_type,
                            api_id: this.tempDataSourceConfig.api_id,
                            parameter_list: parameter_list
                        }
                    }
                    console.log(this.currentLabelData)
                    return
                    this.saveLabel(this.currentLabelData)
                }
            })
        },
        //删除标签
        removeConfig() {
            this.$confirm('此操作将移除该组件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                var param = {
                    labelId: this.currentLabelData.label_id
                }
                post('/Form/DelLabel', param).then(
                    res => {
                        console.log('删除标签',res)
                        this.currentLabelindex = -1
                        this.currentLabelData = {}
                        this.getLabelList()
                    }
                )
            }).catch(() => {
            })
        },
        //获取LabelList
        getLabelList() {
            var param = {
                formId: this.formId
            }
            get('/Form/GetLabelList', param).then(
                res => {
                    console.log('获取LabelList',res)
                    this.setLableList=res
                }
            )
        },
        //获取Form
        getForm() {
            var param = {
                formId: this.formId
            }
            get('/Form/Get', param).then(
                res => {
                    console.log('获取Form',res)
                }
            )
        },
        //测试取回
        getRetrieve() {
            var param = {
                storeId: 43
            }
            get('/Form/Retrieve', param).then(
                res => {
                    console.log('form取回',res)
                }
            )
        },
        //提交表单
        submitPreviewForm() {
            this.$refs.DynamicForm.submitForm()
        },
        //刷新表单
        previewFormFresh() {
            this.$refs.DynamicFormScrollbar.scrollToY(0)
        },
        //表单dialog打开回调
        formPreviewOpen() {
            document.getElementById('DynamicFormScrollbar').style.maxHeight = getDialogScrollHeight() + 'px'
            if (this.$refs.DynamicForm) {
                this.$refs.DynamicForm.refreshFrom()
            }
        },
        //表单加载完成回调
        onSuccess() {
            console.log('加载成功')
        },
        //表单加载错误回调
        onError(err) {
            console.log(err)
        },
        //空表单回调
        onEmpty() {
            console.log('空表单')
        },
        //获取除了自己的所有标签
        getLabelsExceptSelf() {
            var result=[]
            this.setLableList.forEach(item => {
                if (item.label_id !== this.currentLabelData.label_id) {
                    result.push(item)
                }
            })
            return result
        },
        //根据label_id获取标签
        getLabelByLabelId(label_id) {
            var result = null
            this.setLableList.forEach(item => {
                if (item.label_id === label_id) {
                    result = item
                }
            })
            return result
        },
        //添加关联dialog关闭回调
        relateAddDialogClose() {
            this.$refs.RelateAddForm.resetFields()
        },
        //新增关联
        relateAdd() {
            this.$refs.RelateAddForm.validate(valid => {
                if (valid) {
                    var relate = {
                        label_id: this.currentLabelData.label_id,
                        relate_name: this.relateAddForm.relateName,
                        operator_str: this.relateAddForm.operatorStr,
                        label: this.getLabelByLabelId(this.relateAddForm.label)
                    }
                    if (this.currentLabelData.label_config.relate_config) {
                        this.currentLabelData.label_config.relate_config.relate_list.push(relate)
                    } else {
                        this.currentLabelData.label_config.relate_config = {
                            relate_list: [relate]
                        }
                    }
                    this.relateAddDialog = false
                }
            })
        },
        //删除关联
        relateDelete(index) {
            this.currentLabelData.label_config.relate_config.relate_list.splice(index,1)
        },
        //获取关联操作名称
        getRelateRuleProp(val) {
            return getPropByValue(RelateRule, val)
        },
        //添加条件dialog关闭回调
        conditionAddDialogClose() {
            this.$refs.ConditionAddForm.resetFields()
        },
        //新增条件
        conditionAdd() {
            this.$refs.ConditionAddForm.validate(valid => {
                if (valid) {
                    var condition = {
                        condition_expr: this.conditionAddForm.conditionExpr,
                        condition_item: {
                            value_method: this.conditionAddForm.valueMethod,
                            inner_value: this.conditionAddForm.innerValue
                        }
                    }
                    if (this.currentLabelData.label_config.condition_config) {
                        this.currentLabelData.label_config.condition_config.condition_list.push(condition)
                    } else {
                        this.currentLabelData.label_config.condition_config = {
                            condition_list: [condition]
                        }
                    }
                    this.conditionAddDialog = false
                }
            })
        },
        //删除提交
        conditionDelete(index) {
            this.currentLabelData.label_config.condition_config.condition_list.splice(index, 1)
        },
        //获取取值方式名称
        getValueMethodProp(val) {
            return getPropByValue(ValueMethod,val)
        },
        getDataApi() {
            var param = { name: '' }
            get('/DataApi/Index', param).then(
                res => {
                    this.dataApis = res
                    console.log('DataApi',res)
                }
            )
        },
        //初始化界面样式
        initStyle() {
            document.getElementById('DfFormEedit').style.display='block'
            var height = document.documentElement.clientHeight
            document.getElementById('FormContent').style.height = (height - 86) + 'px'
            document.getElementById('FormLabelContent').style.maxHeight = (height - 106) + 'px'
            document.getElementById('FormRight').style.height = (height - 20) + 'px'
        },
    },
    mounted() {
        this.getForm()
        this.getLabelList()
        this.getRetrieve()
        this.initStyle()
        this.getDataApi()
    }
})

