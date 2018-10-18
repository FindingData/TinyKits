
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
                form_desc: ''
            },
            customerFormRules: {
                form_name: [{ required: true, message: '请输入表单名称', trigger: 'blur' }]
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
            var param = {
                name: ''
            }
            get('/Form/Index', param).then(
                res => {
                    console.log('表单列表',res)
                    this.formList = res.Result
                }
            )
        },
        addForm() {
            this.$refs.CustomerForm.validate((valid) => {
                if (valid) {
                    var param = {
                        form: this.customerForm
                    }
                    post('/Form/Add', param).then(
                        res => {
                            console.log(res)
                            this.getFormList()
                            this.formAddVisible = false
                        }
                    )
                }
            })
        },
        formAddClose() {
            this.$refs.CustomerForm.resetFields()
        },
        handleEdit(formId) {
            var url = '/Home/FormEdit?formId=' + formId
            window.open(url, "_blank")
        },
        handlePreview(formId) {
            var formKeyList = localStorage.getItem('formList').split(',')
            this.currentFormKey = formKeyList[index]
            setTimeout(() => {
                this.formPreviewVisible = true
            },0)
            //var formKeyList = localStorage.getItem('formList').split(',')
            //var url = '/DynamicForm/FormPreview?formKey=' + formKeyList[index]
            //window.open(url, "_blank")
        },
        handleDelete(formId) {
            this.$confirm('此操作将删除该表单, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                this.$message({
                    type: 'info',
                    message: '待开发'
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

