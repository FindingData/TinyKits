
var dynamicForm = {
    props: {
        labelWidth: {
            type: Number,
            default: 120
        },
        labelAlign: {
            type: String,
            default: 'right'
        },
        formColumn: {
            type: Number,
            default: 1
        },
        formKey: {
            type: String,
            require:true
        },
        baseConfig: {
            type: Object,
            require: true
        },
    },
    components: {
        'gis-map': gisMap
    },
    data() {
        return {
            formWith:0,
            setLableList: [],
            dataSource: [],
            dicSource: [],
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
            selectOptions: [],
            baseMapUrl:'http://www.findingdata.cn:6080/arcgis/rest/services/湖南/cs_dt_map/MapServer',
            CenterX:112.98,
            CenterY:28.28,
            pcaCode:430100
        }
    },
    methods: {
        GetDataSourceList() {
            var requests = [get('/DataSource/GetDataSourceList'), get('/DataSource/GetDicSourceList')]
            axios.all(requests).then(
                axios.spread((dataSource, dicSource) => {
                    this.dataSource = dataSource
                    this.dicSource = dicSource
                    this.getForm()
                })
            )
        },
        getDicSource(id) {
            var obj = null
            this.dicSource.forEach(item => {
                if (id === item.id) {
                    obj = item
                }
            })
            return obj
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
        getLableByConstantKey(key) {
            var result = null
            this.constant.forEach(item => {
                if (item.key === key) {
                    result = item
                }
            })
            return result
        },
        getSelectOption(index) {
            var result=[]
            this.selectOptions.forEach(item => {
                if (index === item.index) {
                    result=item.data
                }
            })
            return result
        },
        autocompleteSearch(index) {
            return (queryString, callback) => {
                if (this.setLableList[index].label_option.dataSourceType === 'custom') {
                    var dataSource = this.setLableList[index].label_option.customDataSource.split(',')
                    var data = []
                    dataSource.forEach(item => {
                        data.push({
                            value: item
                        })
                    })
                    var results = queryString ? data.filter((item) => { return item.value.indexOf(queryString) !== -1 }) : data
                    callback(results)
                } else {
                    var dataSource = this.getDataSource(this.setLableList[index].label_option.apiDataSource)
                    if (dataSource) {
                        var param = {
                            q: queryString
                        }
                        this.setLableList[index].label_option.params.forEach(item => {
                            if (this.getLableByConstantKey(item.relationLabel)) {
                                param[item.paramName] = this.constant[this.getLableByConstantKey(item.relationLabel).name]
                            } else {
                                param[item.paramName] = this.getLableByPrimaryKey(item.relationLabel).label_option.defaultValue
                            }
                        })
                        post(dataSource.url, param).then(
                            res => {
                                var result = []
                                res.forEach((re) => {
                                    if (this.setLableList[index].label_option.dataShowModel === 'item-title-des') {
                                        result.push({
                                            title: re[this.setLableList[index].label_option.filterRule[0]],
                                            des: re[this.setLableList[index].label_option.filterRule[1]]
                                        })
                                    } else if (this.setLableList[index].label_option.dataShowModel === 'item-key-value') {
                                        result.push({
                                            key: re[this.setLableList[index].label_option.filterRule[0]],
                                            value: re[this.setLableList[index].label_option.filterRule[1]]
                                        })
                                    } else {
                                        result.push({
                                            item: re[this.setLableList[index].label_option.filterRule[0]]
                                        })
                                    }
                                })
                                callback(result)
                            }
                        )
                    } else {
                        callback([])
                    }
                }
            }
        },
        getForm() {
            if (localStorage.getItem(this.formKey)) {
                var form = JSON.parse(localStorage.getItem(this.formKey))
                this.setLableList = form.formContent
                this.initSelectOptions()
            } else {
                this.$message({
                    message: '获取表单出错',
                    type: 'error'
                })
            }
        },
        initSelectOptions() {
            this.setLableList.forEach((item,index) => {
                if (item.label_type === 'select') {
                    if (item.label_option.dataSourceType === 'custom') {
                        var data = []
                        var dataSource = item.label_option.customDataSource.split(',')
                        dataSource.forEach(item => {
                            data.push({
                                value: item,
                                label: item
                            })
                        })
                        this.selectOptions.push({
                            index: index,
                            data: data
                        })
                    } else if (item.label_option.dataSourceType === 'dic') {
                        var dataSource = this.getDicSource(item.label_option.dicDataSource)
                        if (dataSource) {
                            this.selectOptions.push({
                                index: index,
                                data: dataSource.items
                            })
                        }
                    } else {
                        var dataSource = this.getDataSource(item.label_option.apiDataSource)
                        if (dataSource) {
                            var param = {}
                            item.label_option.params.forEach(item => {
                                if (this.getLableByConstantKey(item.relationLabel)) {
                                    param[item.paramName] = this.baseConfig[this.getLableByConstantKey(item.relationLabel).name]
                                } else {
                                    param[item.paramName] = this.getLableByPrimaryKey(item.relationLabel).label_option.defaultValue
                                }
                            })
                            post(dataSource.url, param).then(
                                res => {
                                    this.selectOptions.push({
                                        index: index,
                                        data: res
                                    })
                                }
                            )
                        }
                    }
                }
            })
        },
        getFormItemInputWidth() {
            return this.labelAlign === 'top' ? this.getFormItemWidth() : this.getFormItemWidth() - this.labelWidth
        },
        getFormItemWidth() {
            return this.formWith / this.formColumn - 10
        },
        refreshFrom() {
            this.getForm()
        },
        mapResize() {
            if (this.$refs.GisMap&&this.$refs.GisMap.length > 0) {
                this.$refs.GisMap[0].resize()
            }
        },
    },
    mounted() {
        this.GetDataSourceList()
        this.formWith = this.$refs.ElForm.$el.getBoundingClientRect().width
    },
    template: `
    
        <el-form ref="ElForm" :label-width="labelWidth+'px'" :label-position="labelAlign" :inline="true">
                <gis-map v-for="(label,index) in setLableList" :key="index" v-if="label.label_type==='map_gis'"
                        ref="GisMap"
                        :base-map-url="baseMapUrl" 
                        :center-x="CenterX" 
                        :center-y="CenterY" 
                        :pca-code="pcaCode">
                </gis-map>
                <el-form-item v-else
                          :label="label.label_option.name"
                          v-show="!label.label_option.hidden"
                          :style="{width:getFormItemWidth()+'px'}">
                <el-input v-if="label.label_type==='input_base'"
                          v-model="label.label_option.defaultValue"
                          :placeholder="label.label_option.placeholder"
                          :maxlength="label.label_option.maxlength"
                          :clearable="label.label_option.clearable"
                          :readonly="label.label_option.readonly"
                          :style="{width:getFormItemInputWidth()+'px'}">
                </el-input>
                <el-autocomplete v-if="label.label_type==='input_autocomplete'"
                                 v-model="label.label_option.defaultValue"
                                 :placeholder="label.label_option.placeholder"
                                 :maxlength="label.label_option.maxlength"
                                 :clearable="label.label_option.clearable"
                                 :readonly="label.label_option.readonly"
                                 :fetch-suggestions="autocompleteSearch(index)"
                                 :trigger-on-focus="label.label_option.trigger_focus"
                                 :style="{width:getFormItemInputWidth()+'px'}">
                        <template slot-scope="{ item }">
                            <div v-if="label.label_option.dataShowModel==='item-title-des'">
                                <div class="title">{{item.title}}</div>
                                <span style="font-size: 12px;color: #b4b4b4;">{{item.des}}</span>
                            </div>
                            <div v-else-if="label.label_option.dataShowModel==='item-key-value'">
                                <el-row>
                                    <el-col :span="12">{{item.key}}</el-col>
                                    <el-col :span="12">{{item.value}}</el-col>
                                </el-row>    
                            </div>
                            <div v-else>
                                {{item.item}}
                            </div>
                        </template>
                </el-autocomplete>
                <el-input v-if="label.label_type==='input_textarea'"
                          type="textarea"
                          v-model="label.label_option.defaultValue"
                          :placeholder="label.label_option.placeholder"
                          :maxlength="label.label_option.maxlength"
                          :autosize="{ minRows: label.label_option.autosize[0], maxRows: label.label_option.autosize[1] }"
                          :resize="label.label_option.resize"
                          :readonly="label.label_option.readonly"
                          :style="{width:getFormItemInputWidth()+'px'}">
                </el-input>
                <el-select v-if="label.label_type==='select'"
                          v-model="label.label_option.defaultValue"
                          :placeholder="label.label_option.placeholder"
                          :filterable="label.label_option.filterable"
                          :clearable="label.label_option.clearable"
                          :readonly="label.label_option.readonly"
                          :style="{width:getFormItemInputWidth()+'px'}">
                        <el-option v-for="item in getSelectOption(index)"
                                  :key="item.value"
                                  :label="item.label"
                                  :value="item.value">
                        </el-option>
                </el-select>
            </el-form-item>
            
        </el-form>
    
    `
}