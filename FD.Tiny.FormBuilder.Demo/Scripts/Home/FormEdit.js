


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
                    post('/Api/Form/AddLabel', param, () => {
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
            var sort=0
            this.setLableList.forEach(item => {
                if (item.label_type === LabelType.control) {
                    if (item.label_config.label_sort !== sort) {
                        item.label_sort = sort
                        this.saveLabel(item)
                    }
                    sort++
                }
                
            })
        },
        //保存Label
        saveLabel(label) {
            var param = {
                label: label
            }
            post('/Api/Form/SaveLabel', param).then(
                res => {
                    console.log('保存Label', res)
                    SuccessMsg('操作成功')
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
                debugger
                var param = {
                    labelId: this.currentLabelData.label_id
                }
                post('/Api/Form/DelLabel', param).then(
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
            get('/Api/Form/GetLabelList', param).then(
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
            get('/Api/Form/Get', param).then(
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
            get('/Api/Form/Retrieve', param).then(
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
       
        getDataApi() {
            var param = { name: '' }
            get('/Api/DataApi/Index', param).then(
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

