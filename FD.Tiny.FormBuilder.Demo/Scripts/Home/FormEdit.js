


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
            RelateType: RelateType,
            ValidatorType: ValidatorType,
            Operation: Operation,
            activeComponentsName: '表单标签',
            setLableList: [],
            currentLabelData: {},
            currentLabelindex: -1,
            oldLabelData: {},
            oldIndex: -1,
            labelActiveName: 'control',
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
                relate_type: RelateType.combine,
                condition: {
                    condition_expr: '',
                    condition_item: {
                        value_method: '',
                        inner_value:''
                    }
                }
            },
            //添加验证dialog
            validatorAddDialog: false,
            //添加验证form
            validatorAddForm: {
                validatorName: '',
                validatorType: '',
                numberMin: '',
                numberMax: '',
                lengthMin: '',
                lengthMax: '',
                compareTarget: '',
                compareType: '',
                regular: '',
                errorMessage:''
            },
            //临时的数据源设置
            tempDataSourceConfig: {
                data_source_type: '',
                dic_type_id: '',
                dic_par_ids: '',
                separtor: '',
                value: '',
                api_id: '',
                api_name: '',
                request_parameter_map: []
            },
            tempApiIdBak:'',
            dictIndeterminate: false,
            dictIndeterminateCheckAll: false,
            dictChecked: [],
            //Dict数据源
            dictList: [],
            dictPars:[],
            //Api数据源
            dataApis: [],
            //临时的数据源api参数设置
            tempDataApiParam: [],
            formulaExampleData: FormulaExampleData,
            formulaExampleDataVisible: false,
            formulaDataVisible: false,
            formulaDataBak: [],

        }
    },
    computed: {
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
                    post('/Api/Form/AddLabel', this.setLableList[i], () => {
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
            debugger
            post('/Api/Form/SaveLabel', label).then(
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
            this.initDataSourceConfig()
        },
        //初始化DataSourceConfig
        initDataSourceConfig() {
            this.dictPars.splice(0, this.dictPars.length)
            if (this.currentLabelData.label_config.data_source) {
                for (var pro in this.currentLabelData.label_config.data_source) {
                    if (pro === 'dic_par_ids') {
                        this.dictChecked = this.currentLabelData.label_config.data_source[pro].split(',').map(Number)
                        this.dictIndeterminateCheckAll = this.dictChecked.length === this.dictPars.length
                    } else {
                        this.tempDataSourceConfig[pro] = this.currentLabelData.label_config.data_source[pro]
                    }
                }
                if (this.tempDataSourceConfig.api_id) {
                    this.handledDataApiChange(this.tempDataSourceConfig.api_id)
                }
                if (this.tempDataSourceConfig.dic_type_id) {
                    this.getDictPars()
                }
            } else {
                this.tempDataSourceConfig = {
                    data_source_type: '',
                    dic_type_id: '',
                    dic_par_ids: '',
                    separtor: '',
                    value: '',
                    api_id: '',
                    api_name: '',
                    parameter_list: []
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
                api_id: '',
                api_name: '',
                request_parameter_map: []
            }
            this.tempDataApiParam.splice(0, this.tempDataApiParam.length)
        },
        //数据源类型-字典类型更改回调
        handledDictTypeChange(val) {
            this.getDictPars(() => {
                this.dictChecked.splice(0, this.dictChecked.length)
                if (this.currentLabelData.label_config.data_source.dic_type_id === val) {
                    this.dictChecked = this.currentLabelData.label_config.data_source.dic_par_ids.split(',').map(Number)
                }
                this.dictIndeterminateCheckAll = this.dictChecked.length === this.dictPars.length
            })
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
                    if (this.currentLabelData.label_config.data_source &&
                        this.currentLabelData.label_config.data_source.api_id &&
                        this.currentLabelData.label_config.data_source.api_id === val) {
                        item.request_parameter_list.forEach(_item => {
                            this.tempDataApiParam.push({
                                parameter_name: _item.parameter_name,
                                parameter_name_chs: _item.parameter_name_chs,
                                is_required: _item.is_required,
                                parameter_value: this.currentLabelData.label_config.data_source.request_parameter_map[_item.parameter_name]
                            })
                        })
                    } else {
                        item.request_parameter_list.forEach(_item => {
                            this.tempDataApiParam.push({
                                parameter_name: _item.parameter_name,
                                parameter_name_chs: _item.parameter_name_chs,
                                is_required: _item.is_required,
                                parameter_value: ''
                            })
                        })
                    }
                }
            })
        },
        getApiName(api_id) {
            var result=''
            this.dataApis.forEach(item => {
                if (item.api_id === api_id) {
                    result=item.api_name
                }
            })
            return result
        },
        //获取标签项
        getLableConfigItem(attr) {
            var option = null
            this.currentLabelData.label_config.control_config.control_options.forEach(item => {
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
                    this.currentLabelData.label_config.data_source = null
                    var errMessage=''
                    if (this.tempDataSourceConfig.data_source_type === DataSourceType.Custom) {
                        this.$refs.dynamicValidateForm.validate(valid => {
                            if (valid) {
                                this.currentLabelData.label_config.data_source = {
                                    data_source_type: this.tempDataSourceConfig.data_source_type,
                                    separtor: this.tempDataSourceConfig.separtor,
                                    value: this.tempDataSourceConfig.value
                                }
                            } else {
                                errMessage='自定义数据源配置错误！'
                            }
                        })
                        
                    } else if (this.tempDataSourceConfig.data_source_type === DataSourceType.Dict) {
                        if (this.tempDataSourceConfig.dic_type_id !== '' && this.dictChecked.length > 0) {
                            this.currentLabelData.label_config.data_source = {
                                data_source_type: this.tempDataSourceConfig.data_source_type,
                                dic_type_id: this.tempDataSourceConfig.dic_type_id,
                                dic_par_ids: this.dictChecked.join(',')
                            }
                        } else {
                            errMessage = '字典数据源配置错误！'
                        }
                    } else if (this.tempDataSourceConfig.data_source_type === DataSourceType.DataApi) {
                        if (this.tempDataSourceConfig.api_id !== '') {
                            var flag = true
                            var parameter_list = {}
                            this.tempDataApiParam.forEach(item => {
                                if (item.is_required && item.parameter_value === '') {
                                    flag = false
                                }
                                parameter_list[item.parameter_name] = item.parameter_value
                            })
                            if (!flag) {
                                errMessage = 'Api数据源配置错误！'
                            } else {
                                this.currentLabelData.label_config.data_source = {
                                    data_source_type: this.tempDataSourceConfig.data_source_type,
                                    api_id: this.tempDataSourceConfig.api_id,
                                    api_name: this.getApiName(this.tempDataSourceConfig.api_id),
                                    request_parameter_map: parameter_list
                                }
                            }
                        } else {
                            errMessage = 'Api数据源配置错误！'
                        }
                    }
                    if (errMessage !== '') {
                        WarningMsg(errMessage)
                    } else {
                        this.saveLabel(this.currentLabelData)
                    }
                }
            })
        },
        //删除标签
        removeLabel() {
            this.$confirm('此操作将移除该组件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                var param = {
                    labelId: this.currentLabelData.label_id
                }
                get('/Api/Form/DelLabel', param).then(
                    res => {
                        console.log('删除标签', res)
                        SuccessMsg('操作成功')
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
                storeId: 161
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
        //添加验证dialog关闭回调
        validatorAddDialogClose() {
            this.$refs.ValidatorAddForm.resetFields()
        },
        //新增验证关联
        validatorAdd() {
            this.$refs.ValidatorAddForm.validate(valid => {
                if (valid) {

                }
            })
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
        //获取数据源
        getDataApi() {
            var param = { name: '' }
            get('/Api/DataApi/Index', param).then(
                res => {
                    this.dataApis = res
                    console.log('DataApi',res)
                }
            )
        },
        //变量公式取值-公式撤回
        formulaDataReturnBack() {
            this.currentLabelData.default_value = ''
            if (this.formulaDataBak.length > 0) {
                this.formulaDataBak.splice(this.formulaDataBak.length - 1, 1)
            }
            if (this.formulaDataBak.length > 0) {
                this.currentLabelData.default_value = this.formulaDataBak[this.formulaDataBak.length - 1]
            }
                
        },
        //变量公式取值-公式按钮
        formulaDataOperation(operation) {
            var str=''
            switch (operation) {
                case Operation.Plus:
                    str = '+'
                    break;
                case Operation.Minus:
                    str = '-'
                    break;
                case Operation.Multiply:
                    str = '*'
                    break;
                case Operation.Divide:
                    str = '/'
                    break;
                case Operation.LeftParentheses:
                    str = '('
                    break;
                case Operation.RightParentheses:
                    str = ')'
                    break;
            }
            if (this.currentLabelData.default_value) {
                this.currentLabelData.default_value += str
            } else {
                this.currentLabelData.default_value = str
            }
            this.formulaDataBak.push(this.currentLabelData.default_value)
        },
        //变量公式取值-变量
        formulaDataLabelClick(item) {
            if (this.currentLabelData.default_value) {
                this.currentLabelData.default_value += ' @' + item.label_name_chs + ' '
            } else {
                this.currentLabelData.default_value = ' @' + item.label_name_chs + ' '
            }
            this.formulaDataBak.push(this.currentLabelData.default_value)
        },
        //变量公式取值-清除
        formulaDataClear() {
            this.currentLabelData.default_value = ''
            this.formulaDataBak.splice(0,this.formulaDataBak.length)
        },
        //变量公式取值-更新
        formulaDataChange(value) {
            this.formulaDataBak.push(this.currentLabelData.default_value)
        },
        //获取字典
        getDictList() {
            get('/Api/Data/GetDictTypeList').then(
                res => {
                    this.dictList=res
                    console.log('dictList', res)
                }
            )
        },
        getDictPars(callBack) {
            var param = {
                dicTypeId: this.tempDataSourceConfig.dic_type_id
            }
            get('/Api/Data/GetDictList',param).then(
                res => {
                    this.dictPars = res
                    console.log('dictPars', res)
                    if (callBack)
                        callBack()
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
        onScroll() {
            this.$refs.DynamicForm.dropMenuClose()
        },
    },
    mounted() {
        this.getForm()
        this.getLabelList()
        //this.getRetrieve()
        this.initStyle()
        this.getDataApi()
        this.getDictList()
    }
})

