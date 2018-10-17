
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
        'gis-map': gisMap,
        'baidu-map': baiduMap,
        'quill-rtf': quillRtf
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
            LabelValueOptions: [],
            formatTooltipFns:[],
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
        getLabelValueOption(index) {
            var result=[]
            this.LabelValueOptions.forEach(item => {
                if (index === item.index) {
                    result=item.data
                }
            })
            return result
        },
        getFormatTooltipFn(index) {
            var fn = null
            this.formatTooltipFns.forEach(item => {
                if (index === item.index) {
                    fn = item.fn
                }
            })
            return fn
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
        getRateIconClasses(index) {
            var arr=[]
            this.setLableList.forEach((item, _index) => {
                if (_index === index) {
                    if (item.label_option.iconClasses === 'star') {
                        arr = ['el-icon-star-on', 'el-icon-star-on', 'el-icon-star-on']
                    } else {
                        arr = ['iconfont icon-kulian', 'iconfont icon-lian-s', 'iconfont icon-icon_xiaolian-mian']
                    }
                }
            })
            return arr
        },
        getRateVoidIconClasses(index) {
            var icon = ''
            this.setLableList.forEach((item, _index) => {
                if (_index === index) {
                    if (item.label_option.iconClasses === 'star') {
                        icon = 'el-icon-star-off'
                    } else {
                        icon = 'iconfont icon-icon_xiaolian-xian'
                    }
                }
            })
            return icon
        },
        getRateShowModel(index) {
            var flag = false
            this.setLableList.forEach((item, _index) => {
                if (_index === index) {
                    if (item.label_option.showModel === 'text') {
                        flag = true
                    }
                }
            })
            return flag
        },
        getRateTexts(index) {
            var arr = []
            this.setLableList.forEach((item, _index) => {
                if (_index === index) {
                    arr = JSON.parse(item.label_option.texts)
                }
            })
            return arr
        },
        getTimePickerOptions(index) {
            var option = {}
            this.setLableList.forEach((item, _index) => {
                if (_index === index) {
                    if (item.label_option.pickerOptions.selectableRange !== '') {
                        console.log('{ "value":' + item.label_option.pickerOptions.selectableRange + '}')
                        option = {
                            selectableRange: JSON.parse('{ "value":' + item.label_option.pickerOptions.selectableRange+'}').value
                        }
                    }
                }
            })
            return option
        },
        getForm() {
            if (localStorage ) {
                var form = JSON.parse(localStorage.getItem(this.formKey))
                this.setLableList = form.formContent
                this.initLabelValueOptions()
                this.initFormatTooltipFns()
            } else {
                this.$message({
                    message: '获取表单出错',
                    type: 'error'
                })
            }
        },
        initLabelValueOptions() {
            this.setLableList.forEach((item,index) => {
                if (item.label_type === 'select' || item.label_type === 'radio' || item.label_type === 'checkbox') {
                    if (item.label_option.dataSourceType === 'custom') {
                        var data = []
                        var dataSource = item.label_option.customDataSource.split(',')
                        dataSource.forEach(item => {
                            data.push({
                                value: item,
                                label: item
                            })
                        })
                        this.LabelValueOptions.push({
                            index: index,
                            data: data
                        })
                    } else if (item.label_option.dataSourceType === 'dic') {
                        var dataSource = this.getDicSource(item.label_option.dicDataSource)
                        if (dataSource) {
                            this.LabelValueOptions.push({
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
                                    this.LabelValueOptions.push({
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
        initFormatTooltipFns() {
            this.setLableList.forEach((item, index) => {
                if (item.label_type === 'slider') {
                    if (item.label_option.formatTooltip !== '') {
                        var obj = JSON.parse(item.label_option.formatTooltip)
                        this.formatTooltipFns.push({
                            index: index,
                            fn: (val) => {
                                try {
                                    return eval(obj.expression) + obj.unit
                                }
                                catch (exception) {
                                    return val + obj.unit
                                }
                            }
                        })
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
        timeChange(val) {
            console.log(val)
        }
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
                <baidu-map v-else-if="label.label_type==='map_baidu'"
                        ref="BaiduMap"
                        :scale-level="label.label_option.scaleLevel"
                        :enable-scroll-wheel="label.label_option.enableScrollWheel"
                        :enable-dragging="label.label_option.enableDragging"
                        :enable-map-click="label.label_option.enableMapClick"
                        :enable-search="label.label_option.enableSearch"
                        :enable-location="label.label_option.enableLocation"
                        :default-point="label.label_option.defaultPoint">
                </baidu-map>
                <quill-rtf v-else-if="label.label_type==='rtf'"
                           :eidt-enabled="false"
                           :contents="label.contents" >
                </quill-rtf>
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
                            <el-option v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.label"
                                      :value="item.value">
                            </el-option>
                    </el-select>
                    <el-radio-group v-if="label.label_type==='radio'"
                                    v-model="label.label_option.defaultValue"
                                    :readonly="label.label_option.readonly"
                                    :style="{width:getFormItemInputWidth()+'px'}">
                        <el-radio v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.value">
                            {{item.label}}
                        </el-radio>
                    </el-radio-group>
                   <el-checkbox-group v-if="label.label_type==='checkbox'"
                                    v-model="label.label_option.defaultValue"
                                    :readonly="label.label_option.readonly"
                                    :style="{width:getFormItemInputWidth()+'px'}">
                        <el-checkbox v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.value">
                            {{item.label}}
                        </el-checkbox>
                   </el-checkbox-group>
                    <el-switch v-if="label.label_type==='switch'"
                               v-model="label.label_option.defaultValue"
                               :readonly="label.label_option.readonly"
                               :active-color="label.label_option.activeColor"
                               :inactive-color="label.label_option.inactiveColor"
                               :active-text="label.label_option.activeText"
                               :inactive-text="label.label_option.inactiveText"
                               :style="{width:getFormItemInputWidth()+'px'}">
                    </el-switch>
                    <el-rate v-if="label.label_type==='rate'"
                               v-model="label.label_option.defaultValue"
                               :disabled="label.label_option.disabled"
                               :max="label.label_option.max"
                               :allow-half="label.label_option.allowHalf"
                               :iconClasses="getRateIconClasses(index)"
                               :void-icon-class="getRateVoidIconClasses(index)"
                               :show-text="getRateShowModel(index)"
                               :show-score="!getRateShowModel(index)"
                               :texts="getRateTexts(index)"
                               :style="{width:getFormItemInputWidth()+'px'}">
                    </el-rate>
                    <el-slider v-if="label.label_type==='slider'"
                               v-model="label.label_option.defaultValue"
                               :disabled="label.label_option.disabled"
                               :min="label.label_option.min"
                               :max="label.label_option.max"
                               :step="label.label_option.step"
                               :show-stops="label.label_option.showStops"
                               :show-tooltip="label.label_option.showTooltip"
                               :range="label.label_option.range"
                               :format-tooltip="getFormatTooltipFn(index)"
                               :style="{width:getFormItemInputWidth()+'px'}">
                    </el-slider>
                    <el-input-number v-if="label.label_type==='input_number'"
                                    v-model="label.label_option.defaultValue"
                                    :disabled="label.label_option.disabled"
                                    :min="label.label_option.min"
                                    :max="label.label_option.max"
                                    :step="label.label_option.step"
                                    :precision="label.label_option.precision"
                                    :controls="label.label_option.controls"
                                    :controls-position="label.label_option.controlsPosition"
                                    :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                    </el-input-number>
                    <el-time-picker v-if="label.label_type==='time'"
                                    v-on:change="timeChange"
                                    v-model="label.label_option.defaultValue"
                                    :placeholder="label.label_option.placeholder"
                                    :readonly="label.label_option.readonly"
                                    :clearable="label.label_option.clearable"
                                    :arrow-control="label.label_option.arrowControl"
                                    :editable="label.label_option.editable"
                                    :value-format="label.label_option.valueFormat"
                                    :format='label.label_option.format'
                                    :picker-options="getTimePickerOptions(index)"                                
                                    :is-range="label.label_option.isRange"
                                    :range-separator="label.label_option.rangeSeparator"
                                    :start-placeholder="label.label_option.startPlaceholder"
                                    :end-placeholder="label.label_option.endPlaceholder"
                                    :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                    </el-time-picker>
                    <el-date-picker v-if="label.label_type==='date'"
                                    v-on:change="timeChange"
                                    v-model="label.label_option.defaultValue"
                                    :placeholder="label.label_option.placeholder"
                                    :readonly="label.label_option.readonly"
                                    :clearable="label.label_option.clearable"
                                    :type="label.label_option.type"
                                    :editable="label.label_option.editable"
                                    :value-format="label.label_option.valueFormat"
                                    :format='label.label_option.format'
                                    :align="label.label_option.align"
                                    :range-separator="label.label_option.rangeSeparator"
                                    :start-placeholder="label.label_option.startPlaceholder"
                                    :end-placeholder="label.label_option.endPlaceholder"
                                    :default-time="label.label_option.type==='daterange'?['00:00:00', '23:59:59']:''"
                                    :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                    </el-date-picker>
            </el-form-item>
            
        </el-form>
    
    `
}