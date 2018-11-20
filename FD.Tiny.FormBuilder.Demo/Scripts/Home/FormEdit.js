var DataType = { Number: 0, String: 1, Date: 2 }
var FormComponents = [
    {
        component_group: '表单标签',
        component_list: [
            {
                label_id: 0,
                form_id: 0,
                data_type: DataType.String,
                label_name_chs: '普通文本',
                control_type: 'input_base',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {
                    validator_config: {
                        validator_list: []
                    },
                    condition_config: {
                        condition_list:[]
                    },
                    data_source_config: null,
                    relate_config: {
                        relate_list: []
                    },
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
                control_type: 'input_autocomplete',
                default_value: '',
                label_sort: 0,
                group_name: '',
                label_config: {
                    validator_config: {
                        validator_list: []
                    },
                    condition_config: [],
                    data_source_config: null,
                    relate_config: [],
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
                label_name_chs: '下拉选择',
                control_type: 'select',
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
            DataType: { Number: 0, String: 1, Date: 2 },
            FormComponents: FormComponents,
            RelateRule: RelateRule,
            ValueMethod: ValueMethod,
            activeComponentsName:'表单标签',
            setLableList: [],
            currentLabelData: {},
            currentLabelindex: -1,
            oldLabelData: {},
            oldIndex: -1,
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
                label:''
            },
            //添加条件dialog
            conditionAddDialog: false,
            //添加条件form
            conditionAddForm: {
                conditionExpr: '',
                valueMethod: '',
                innerValue: ''
            },
        }
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
                this.oldIndex = index
                this.oldLabelData = clone(this.currentLabelData)
                this.labelEditChange = false
                this.tabActiveName = 'normal'
                setTimeout(() => { this.labelEditChange = true }, 0)
            }
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
            if (this.$refs.DynamicForm) {
                setTimeout(() => {
                    this.$refs.DynamicForm.refreshFrom()
                }, 0)
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
        initStyle() {
            var height = document.documentElement.clientHeight
            document.getElementById('FormContent').style.height = (height - 86) + 'px'
            document.getElementById('FormLabelContent').style.maxHeight = (height - 106) + 'px'
            document.getElementById('FormRight').style.height = (height - 20) + 'px'
            console.log(document.documentElement.clientHeight)
        },
    },
    mounted() {
        this.getForm()
        this.getLabelList()
        this.getRetrieve()
        this.initStyle()
    }
})

