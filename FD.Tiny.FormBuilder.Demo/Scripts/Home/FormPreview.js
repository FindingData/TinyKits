var dfFormPreviewVm = new Vue({
    el: '.df-form-preview',
    data() {
        return {
            dataSource: [],
            setLableList: [],
            formKey: getParam('formKey'),
            column: 1,
            align:'right'
        }
    },
    methods: {
        getFormItemWidth() {
            return parseInt(100/this.column)-1
        },
        getFormItemInputWidth() {
            if (this.column === 3) {
                return this.align==='top'?'360px':'240px'
            } else if (this.column === 2) {
                return this.align === 'top' ? '420px' : '330px'
            } else {
                return this.align === 'top' ? '530px' : '500px'
            }
        },
        GetDataSourceList() {
            get('/DataSource/GetDataSourceList').then(
                res => {
                    this.dataSource = res
                }
            )
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
        getLableByPrimaryKey(primaryKey) {
            var result = null
            this.setLableList.forEach(item => {
                if (item.label_option.primaryKey === primaryKey) {
                    result = item
                }
            })
            return result
        },
        suggestSearch(index) {
            return (queryString, callback) => {
                var suggestions = this.setLableList[index].label_option.suggestions.split(',')
                var data = []
                suggestions.forEach(item => {
                    data.push({
                        value: item
                    })
                })
                var results = queryString ? data.filter((item) => { return item.value.indexOf(queryString) !== -1 }) : data
                callback(results)
            }
        },
        autocompleteSearch(index) {
            return (queryString, callback) => {
                var dataSource = this.getDataSource(this.setLableList[index].label_option.dataSource)
                var param = {
                    q: queryString
                }
                this.setLableList[index].label_option.params.forEach(item => {
                    param[item.paramName] = this.getLableByPrimaryKey(item.relationLabel).label_option.defaultValue
                })
                post(dataSource.url, param).then(
                    res => {
                        console.log(res, this.setLableList[index].label_option.filterRule)
                        var result = []
                        res.forEach((re) => {
                            var str = ''
                            this.setLableList[index].label_option.filterRule.forEach(item => {
                                if (str === '') {
                                    str = re[item]
                                } else {
                                    str += '||' + re[item]
                                }
                            })
                            result.push({
                                value: str
                            })
                        })
                        callback(result)
                    }
                )
            }
        },
        getForm() {
            var form = JSON.parse(localStorage.getItem(this.formKey))
            this.setLableList = form.formContent
        },
    },
    mounted() {
        this.getForm()
    }
})

