var DataType = { Number:0,String:1,Date:2}

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
            DataType: DataType,
            formComponents: [
                {
                    component_group: '表单组件',
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
                            label_config: {}
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
                    component_group: '展示组件',
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
                    component_group: '扩展组件',
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
            ],
            setLableList: [],
            currentLabelData: {},
            currentLabelindex: -1,
            oldLabelData: {},
            oldIndex: -1,
            formPreviewVisible: false,
            formSetVisible: false,
            formKey: getParam('formKey'),
            formId: getParam('formId'),
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
            dataSource: [],
            dicSource: [],
            paramPopover: [],
            labelWidth: 120,
            column: 1,
            align: 'right',
            previewFormSetVisible: false,
            constant: [
                {
                    name: 'userId',
                    key: 'c1001'
                },
                {
                    name: 'customerId',
                    key: 'c1002'
                },
                {
                    name: 'pcaCode',
                    key: 'c1003'
                }
            ],
            dateType: ['year', 'month', 'date', 'dates', 'week', 'datetime', 'datetimerange', 'daterange'],
            timePickerRangeTemp: '',
        }
    },
    methods: {
        GetDataSourceList() {
            get('/DataSource/GetDataSourceList').then(
                res => {
                    this.dataSource = res
                }
            )
        },
        GetDicSourceList() {
            get('/DataSource/GetDicSourceList').then(
                res => {
                    this.dicSource = res
                }
            )
        },
        getDataSourceListByType(type) {
            var result = []
            this.dataSource.forEach(item => {
                if (item.type === type) {
                    result.push(item)
                }
            })
            return result
        },
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
                    post('/Form/AddLabel', param).then(
                        res => {
                            if (res.Status) {
                                this.setLableList[i].label_id = res.Result
                                this.updateSort()
                            } else {
                                this.setLableList.splice(i, 1)
                                this.$message({
                                    type: 'error',
                                    message: res.Message
                                })
                            }
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
                }).catch(() => {
                })
            } else {
                this.currentLabelindex = index
                this.currentLabelData = this.setLableList[index]
                this.oldIndex = index
                this.oldLabelData = clone(this.currentLabelData)    
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
                        console.log(res)
                        if (res.Status) {
                            this.currentLabelindex = -1
                            this.currentLabelData = {}
                            this.getLabelList()
                        }
                    }
                )
            }).catch(() => {
            })
        },
        hasMapLabel() {
            var flag = false
            this.setLableList.forEach(item => {
                if (item.label_type === 'map_gis' || item.label_type === 'map_baidu') {
                    flag = true
                }
            })
            return flag
        },
        getDataSource(id) {
            var obj = null
            this.dataSource.forEach(item => {
                if (id === item.id) {
                    obj = item
                }
            })
            return obj
        },
        paramSetting(name, key, index) {
            var addFlag = true
            this.currentLabelData.label_option.params.forEach(item => {
                if (item.paramName === name) {
                    item.relationLabel = key
                    addFlag = false
                }
            })
            if (addFlag) {
                this.currentLabelData.label_option.params.push({
                    paramName: name,
                    relationLabel: key
                })
            }
            this.paramPopover[index] = false
        },
        getParamSetting(name, key) {
            var result = null
            this.currentLabelData.label_option.params.forEach(item => {
                if (item.paramName === name && item.relationLabel === key) {
                    result = item
                }
            })
            return result
        },
        getParamSettingLableName(name) {
            var result = null
            this.currentLabelData.label_option.params.forEach(item => {
                if (item.paramName === name) {
                    if (this.getLableByConstantKey(item.relationLabel)) {
                        result = this.getLableByConstantKey(item.relationLabel).name
                    } else {
                        result = this.getLableByPrimaryKey(item.relationLabel).label_option.name
                    }
                }
            })
            return result
        },
        getLableByConstantKey(key) {
            var result = null
            this.constant.forEach(item => {
                if (item.key === key) {
                    result = item
                }
            })
            return result
        },
        getLableByPrimaryKey(primaryKey) {
            var result = null
            this.setLableList.forEach(item => {
                if (item.label_option.primaryKey === primaryKey) {
                    result = item
                }
            })
            return result
        },
        getLableListNameForParam() {
            var result = []
            this.setLableList.forEach(item => {
                if (item.label_option.primaryKey !== this.currentLabelData.label_option.primaryKey) {
                    result.push({
                        name: item.label_option.name,
                        key: item.label_option.primaryKey
                    })
                }
            })
            result = result.concat(this.constant)
            return result
        },
        setTimeSelectableRange() {
            if (this.timePickerRangeTemp) {
                var _this = this.currentLabelData.label_option.pickerOptions.selectableRange
                var item = this.timePickerRangeTemp[0] + ' - ' + this.timePickerRangeTemp[1]
                if (_this !== '') {
                    if (_this.indexOf(',') !== -1) {
                        _this = _this.replace(']', ',"' + item + '"]')
                    } else {
                        _this = '["' + _this + '","' + item + '"]'
                    }
                } else {
                    _this = item
                }
                this.currentLabelData.label_option.pickerOptions.selectableRange = _this
                this.timePickerRangeTemp = ''
            }
        },
        //获取LabelList
        getLabelList() {
            var param = {
                formId: this.formId
            }
            get('/Form/GetLabelList', param).then(
                res => {
                    console.log(res)
                    this.setLableList=res.Result
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
                    console.log(res)
                }
            )
        },
        setForm() {
            this.$refs.CustomerForm.validate((valid) => {
                if (valid) {
                    var form = JSON.parse(localStorage.getItem(this.formKey))
                    form.formConfig = this.customerForm
                    localStorage.setItem(this.formKey, JSON.stringify(form))
                    this.formSetVisible = false
                }
            })
        },
        saveForm() {
            var form = {
                formConfig: this.customerForm,
                formContent: this.setLableList
            }
            localStorage.setItem(this.formKey, JSON.stringify(form))
        },
        submitPreviewForm() {
            this.$refs.DynamicForm.submitForm()
        },
        previewFormFresh() {
            this.$refs.DynamicFormScrollbar.scrollToY(0)
        },
        formPreviewOpen() {
            if (this.$refs.DynamicForm) {
                setTimeout(() => {
                    this.$refs.DynamicForm.refreshFrom()
                }, 500)
            }
        },
        onSuccess() {
            console.log('加载成功')
        },
        onError(err) {
            console.log(err)
        },
        onEmpty() {
            console.log('空表单')
        },
        onScroll() {
            this.$refs.DynamicForm.mapResize()
        },
        textChange(contents) {
            this.currentLabelData.contents = contents
        },
    },
    mounted() {
        this.GetDataSourceList()
        this.GetDicSourceList()
        this.getForm()
        this.getLabelList()
    }
})

