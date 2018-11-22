
var dataApiVm = new Vue({
    components: {
        'vue-scrollbar': Vue2Scrollbar
    },
    el: '.data-api',
    data() {
        return {
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
        }
    },
    methods: {

        //获取表单列表
        getDataApiList() {
            var param = {
                name: ''
            }
            get('/DataApi/Index', param).then(
                res => {
                    console.log('数据源列表', res)
                    this.dataApiList = res
                }
            )
        },
        dataApiAddClose() {

        },
        dataApiAddOpen() {
            document.getElementById('DataApiScrollbar').style.maxHeight = getDialogScrollHeight()+'px'
        },
        sqlContentFromat() {
            if (this.customerForm.sql_content !== '') {
                this.customerForm.sql_content = this.customerForm.sql_content.replace(/\r/g, '').replace(/\n/g, '').replace(/\t/g, '')
                this.customerForm.sql_content = this.customerForm.sql_content.replace(/select/g, 'SELECT\r\n\t')
                    .replace(/from/g, '\r\nFROM\n\t').replace(/where/g, '\r\nWHERE\n\t').replace(/SELECT/g, 'SELECT\r\n\t')
                    .replace(/FROM/g, '\r\nFROM\n\t').replace(/WHERE/g, '\r\nWHERE\n\t')
                
            }
            
        },
        addDataApi() {

        }
    },
    mounted() {
        this.getDataApiList()
    }
})

