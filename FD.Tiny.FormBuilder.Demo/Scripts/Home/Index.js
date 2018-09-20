
var dfIndexVm = new Vue({
    components: {
        'dynamic-form': dynamicForm,
        'vue-scrollbar': Vue2Scrollbar
    },
    el: '.df-index',
    data() {
        return {
            FormType: FormType,
            formAddVisible:false,
            formList: [],
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
            formPreviewVisible: false,
            currentFormKey: '',
            labelWidth:120,
            column: 1,
            align: 'right',
            previewFormSetVisible: false,
        }
    },
    methods: {
        getFormTypeAttr(type) {
            return getFormTypeAttr(type)
        },
        getFormList() {
            this.formList.splice(0, this.formList.length)
            var formKeyListStr = localStorage.getItem('formList')
            if (formKeyListStr !== null) {
                var formKeyList = formKeyListStr.split(',')
                formKeyList.forEach(item => {
                    var form = JSON.parse(localStorage.getItem(item)).formConfig
                    form.formKey = item
                    this.formList.push(form)
                    console.log(form)
                })
            }
        },
        addForm() {
            this.$refs.CustomerForm.validate((valid) => {
                if (valid) {
                    var formKey = 'F' + new Date().getTime()
                    var form = {
                        formConfig: this.customerForm,
                        formContent:[]
                    }
                    localStorage.setItem(formKey, JSON.stringify(form))
                    var formKeyList=[]
                    var formKeyListStr = localStorage.getItem('formList')
                    if (formKeyListStr !== null) {
                        formKeyList = formKeyListStr.split(',')
                    }
                    formKeyList.push(formKey)
                    localStorage.setItem('formList', formKeyList.join(','))
                    this.getFormList()
                    this.formAddVisible = false
                }
            })
        },
        formAddClose() {
            this.$refs.CustomerForm.resetFields()
        },
        handleEdit(index) {
            var formKeyList = localStorage.getItem('formList').split(',')
            var url = '/Home/FormEdit?formKey=' + formKeyList[index]
            window.open(url, "_blank")
        },
        handlePreview(index) {
            var formKeyList = localStorage.getItem('formList').split(',')
            this.currentFormKey = formKeyList[index]
            setTimeout(() => {
                this.formPreviewVisible = true
            },0)
            //var formKeyList = localStorage.getItem('formList').split(',')
            //var url = '/DynamicForm/FormPreview?formKey=' + formKeyList[index]
            //window.open(url, "_blank")
        },
        handleDelete(index) {
            this.$confirm('此操作将删除该表单, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                var formKeyList = localStorage.getItem('formList').split(',')
                localStorage.removeItem(formKeyList[index])
                formKeyList.splice(index, 1)
                localStorage.setItem('formList', formKeyList.join(','))
                this.getFormList()
                this.$message({
                    type: 'success',
                    message: '删除成功!'
                })
            })
        },
        submitPreviewForm() {

        },
        previewFormFresh() {
            this.$refs.DynamicFormScrollbar.scrollToY(0)
        },
        formPreviewOpen() {
            if (this.$refs.DynamicForm) {
                this.$refs.DynamicForm.refreshFrom()
            }
        },
        onScroll() {
            this.$refs.DynamicForm.mapResize()
        },
    },
    mounted() {
        this.getFormList()
    }
})

