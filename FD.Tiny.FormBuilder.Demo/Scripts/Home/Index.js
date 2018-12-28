
var dfIndexVm = new Vue({
    components: {
        'dynamic-form': dynamicForm,
        'vue-scrollbar': Vue2Scrollbar
    },
    el: '.df-index',
    data() {
        return {
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
            currentFormId: '',
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
        //获取表单列表
        getFormList() {
            var param = {
                name: ''
            }
            get('/Api/Form/Index', param).then(
                res => {
                    console.log('表单列表',res)
                    this.formList = res
                }
            )
        },
        //新增表单
        addForm() {
            this.$refs.CustomerForm.validate((valid) => {
                if (valid) {
                    var param = {
                        form: this.customerForm
                    }
                    post('/Api/Form/Add', param).then(
                        res => {
                            console.log('新增表单',res)
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
        //编辑表单
        handleEdit(formId) {
            var url = '/Home/FormEdit?formId=' + formId
            window.open(url, "_blank")
        },
        //表单预览
        handlePreview(formId) {
            this.currentFormId = formId
            this.formPreviewVisible = true
        },
        //删除表单
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
        //提交表单
        submitPreviewForm() {
            this.$refs.DynamicForm.submitForm(() => {
                InfoMsg('表单提交完成')
            })
        },
        //刷新表单
        previewFormFresh() {
            this.$refs.DynamicFormScrollbar.scrollToY(0)
        },
        //表单dialog打开回调
        formPreviewOpen() {
            document.getElementById('DynamicFormScrollbar').style.maxHeight = getDialogScrollHeight() + 'px'
            if (this.$refs.DynamicForm) {
                this.$refs.DynamicFormScrollbar.scrollToY(0)
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
        }

    },
    mounted() {
        this.getFormList()
    }
})

