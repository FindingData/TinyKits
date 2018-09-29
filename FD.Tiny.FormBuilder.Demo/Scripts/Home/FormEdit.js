var dfFormEditVm = new Vue({
    el: '.df-form-edit',
    components: {
        'label-template': labelTemplate,
        'dynamic-form': dynamicForm,
        'vue-scrollbar': Vue2Scrollbar
    },
    data() {
        return {
            formComponents: [],
            setLableList: [],
            currentLabelData: {},
            currentLabelindex:-1,
            formPreviewVisible: false,
            formSetVisible: false,
            formKey: getParam('formKey'),
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
            dicSource:[],
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
            dateType: ['year', 'month', 'date','dates','week','datetime','datetimerange','daterange'],
            timePickerRangeTemp:'',
        }
    },
    methods: {
        GetFormComponents() {
            get('/DataSource/GetFormComponents').then(
                res => {
                    this.formComponents = res
                }
            )
        },
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
            var result=[]
            this.dataSource.forEach(item => {
                if (item.type === type) {
                    result.push(item)
                }
            })
            return result
        },
        updateData(evt) {
            console.log(this.setLableList)
        },
        addData(evt) {
            this.setLableList = clone(this.setLableList)
            console.log(this.setLableList)
        },
        settingData(index) {
            this.currentLabelindex=index
            this.currentLabelData = this.setLableList[index]
        },
        removeData() {
            this.$confirm('此操作将移除该组件, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                this.setLableList.splice(this.currentLabelindex, 1)
                this.currentLabelindex = -1
                this.currentLabelData = {}
                }).catch(() => {
                })
            
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
            result=result.concat(this.constant)
            return result
        },
        setTimeSelectableRange() {
            if (this.timePickerRangeTemp) {
                var _this = this.currentLabelData.label_option.pickerOptions.selectableRange
                var item = this.timePickerRangeTemp[0] + ' - ' + this.timePickerRangeTemp[1]
                if (_this !== '') {
                    if (_this.indexOf(',') !== -1) {
                        _this = _this.replace(']',',"'+item+'"]')
                    } else {
                        _this = '["' + _this+'","'+item+'"]'
                    }
                } else {
                    _this=item
                }
                this.currentLabelData.label_option.pickerOptions.selectableRange = _this
                this.timePickerRangeTemp=''
            }
        },
        getForm() {
            var form = JSON.parse(localStorage.getItem(this.formKey))
            this.setLableList = form.formContent
            this.customerForm = form.formConfig
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

        },
        previewFormFresh() {
            this.$refs.DynamicFormScrollbar.scrollToY(0)
        },
        formPreviewOpen() {
            if (this.$refs.DynamicForm) {
                setTimeout(() => {
                    this.$refs.DynamicForm.refreshFrom()
                },500)
            }
        },
        onScroll() {
            this.$refs.DynamicForm.mapResize()
        },
    },
    mounted() {
        this.GetFormComponents()
        this.GetDataSourceList()
        this.GetDicSourceList()
        this.getForm()
    }
})

