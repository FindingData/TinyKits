var DataType = { Number: 0, String: 1, Date: 2 }
var dataApiVm = new Vue({
    components: {
        'vue-scrollbar': Vue2Scrollbar
    },
    el: '.data-api',
    data() {
        return {
            DataType: DataType,
            dataApiList: [],
            dataApiAddVisible: false,
            customerForm: {
                api_id: '',
                api_name: '',
                api_desc: '',
                api_url: '',
                sql_content: '',
                fsq_db_name: '',
                request_parameter_list: [],
                response_parameter_list:[]
            },
            edit: false,
        }
    },
    methods: {
        //获取表单列表
        getDataApiList() {
            var param = {
                name: ''
            }
            get('/Api/DataApi/Index', param).then(
                res => {
                    console.log('数据源列表', res)
                    this.dataApiList = res
                }
            )
        },
        dataApiAddClose() {
            this.$refs.DataApiScrollbar.scrollToY(0)
            this.customerForm = {
                api_id: '',
                api_name: '',
                api_desc: '',
                api_url: '',
                sql_content: '',
                fsq_db_name: '',
                request_parameter_list: [],
                response_parameter_list: []
            }
        },
        dataApiAddOpen() {
            document.getElementById('DataApiScrollbar').style.maxHeight = getDialogScrollHeight()+'px'
        },
        //格式化SQL
        sqlContentFromat() {
            if (this.customerForm.sql_content !== '') {
                var param = {
                    sql: this.customerForm.sql_content.replace(/\r/g, '').replace(/\n/g, '').replace(/\t/g, '')
                }
                get('/Api/DataApi/ParseSql', param).then(
                    res => {
                        console.log('SQL格式化', res)
                        this.customerForm.request_parameter_list = res.requestList
                        this.customerForm.response_parameter_list = res.respList
                    }
                )
                this.customerForm.sql_content = this.customerForm.sql_content.replace(/\r/g, '').replace(/\n/g, '').replace(/\t/g, '')
                console.log(this.customerForm.sql_content)
                this.customerForm.sql_content = this.customerForm.sql_content
                    .replace(/SELECT/g, 'SELECT\r\n\t')
                    .replace(/FROM/g, '\r\nFROM\n\t')
                    .replace(/WHERE/g, '\r\nWHERE\n\t')
                    .replace(/select/g, 'SELECT\r\n\t')
                    .replace(/where/g, '\r\nWHERE\n\t')
                    .replace(/from/g, '\r\nFROM\n\t')
                
            }
            
        },
        //新增数据源
        addDataApi() {
            this.$refs.CustomerForm.validate(valid => {
                if (valid) {
                    if (this.edit) {
                        post('/Api/DataApi/Save', this.customerForm).then(
                            res => {
                                console.log('更新数据源', res)
                                this.dataApiAddVisible = false
                                this.getDataApiList()
                                this.edit = false
                            }
                        )
                    } else {
                        post('/Api/DataApi/Add', this.customerForm).then(
                            res => {
                                console.log('新增数据源', res)
                                this.dataApiAddVisible = false
                                this.getDataApiList()
                            }
                        )
                    }
                }
            })
        },
        //删除数据源
        handleDelete(id) {
            this.$confirm('此操作将删除该数据源, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                post('/DataApi/Del', { apiId: id }).then(
                    res => {
                        this.getDataApiList()
                    }
                )
            })
            
        },
        //编辑数据源
        handleEdit(index) {
            this.customerForm = clone(this.dataApiList[index])
            this.dataApiAddVisible = true
            this.edit = true
        },
    },
    mounted() {
        this.getDataApiList()
    }
})

