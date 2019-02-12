
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
        formId: {
            type: Number,
            require:true
        },
        baseConfig: {
            type: Object,
            require: true
        },
        onSuccess: Function,
        onError: Function,
        onEmpty: Function
    },
    components: {
        'gis-map': gisMap,
        'baidu-map': baiduMap,
        'quill-rtf': quillRtf
    },
    data() {
        return {
            formWith:0,
            labelData: [],
            LabelValueOptions: [],
            formModel: {},
            rules: [],
            validator_list: [
                [],
                [{
                    validatorName: '',
                    validatorType: 'required',
                    numberMin: '',
                    numberMax: '',
                    lengthMin: '',
                    lengthMax: '',
                    compareTarget: '',
                    compareType: '',
                    regular: '',
                    errorMessage: '楼盘地址必填'
                }, {
                        validatorName: '',
                        validatorType: 'lengthSize',
                        numberMin: '',
                        numberMax: '',
                        lengthMin: 10,
                        lengthMax: 20,
                        compareTarget: '',
                        compareType: '',
                        regular: '',
                        errorMessage: '字符长度错误'
                    }],
                [{
                    validatorName: '',
                    validatorType: 'required',
                    numberMin: '',
                    numberMax: '',
                    lengthMin: '',
                    lengthMax: '',
                    compareTarget: '',
                    compareType: '',
                    regular: '',
                    errorMessage: '我是必选'
                }],
                [],
                [],
                [],
                [],
                []
            ],
        }
    },
    methods: {
        //获取Form
        getForm() {
            var param = {
                formId: this.formId
            }
            get('/Api/Form/Get', param).then(
                res => {
                    console.log('获取Form',res)
                    this.getLabelList()
                }
            )
        },
        //获取LabelList
        getLabelList() {
            var param = {
                formId: this.formId
            }
            get('/Api/Form/GetLabelList', param).then(
                res => {
                    console.log('获取LabelList',res)
                    this.initLabelData(res)
                }
            )
        },
        //初始化LabelData
        initLabelData(lableList) {
            this.labelData.splice(0, this.labelData.length)
            lableList.forEach(item => {
                var data = {
                    label_id: item.label_id,
                    label_name_chs: item.label_name_chs,
                    label_value: item.default_value,
                    label: item
                }
                this.labelData.push(data)
                this.formModel[item.label_id] = item.label_value
            })
            if (this.labelData.length > 0) {
                this.initLabelValueOptions()
                this.initValidatorRules()
                this.onSuccess()
            } else {
                this.onEmpty()
            }
        },
        //初始化LableValueOptions
        initLabelValueOptions() {
            this.LabelValueOptions.splice(0, this.LabelValueOptions.length)
            this.labelData.forEach((item, index) => {
                var _label=item.label
                if (_label.label_type === 0) {
                    if (_label.label_config.control_config.control_type === 'select' || _label.label_config.control_config.control_type === 'radio' || _label.label_config.control_config.control_type === 'checkbox') {
                        if (_label.label_config.data_source.data_source_type === 0) {
                            this.getDicSource(_label.label_config.data_source.dic_type_id, (res) => {
                                var _data = []
                                var _ids = _label.label_config.data_source.dic_par_ids.split(',')
                                _ids.forEach(item => {
                                    for (var i = 0; i < res.length; i++) {
                                        if (item === res[i].dic_par_id + '') {
                                            _data.push({
                                                label: res[i].dic_par_name,
                                                value: item
                                            })
                                            break
                                        }
                                    }
                                })
                                this.LabelValueOptions.push({
                                    index: index,
                                    data: _data
                                })
                            })
                        } else if (_label.label_config.data_source.data_source_type === 1) {
                            var _data = []
                            var dataSource = _label.label_config.data_source.value.split(_label.label_config.data_source.separtor)
                            dataSource.forEach(_item => {
                                _data.push({
                                    value: _item,
                                    label: _item
                                })
                            })
                            this.LabelValueOptions.push({
                                index: index,
                                data: _data
                            })
                        } else {
                            var param = []
                            for (pro in _label.label_config.data_source.request_parameter_map) {
                                param.push({
                                    parameter_name: pro,
                                    value: this.getParamValue(_label.label_config.data_source.request_parameter_map[pro])
                                })
                            }
                            this.getDataSource(_label.label_config.data_source.api_id, param, (res) => {
                                this.getDataApi(_label.label_config.data_source.api_name, (_res) => {
                                    var _data = []
                                    res.forEach(r_item => {
                                        var data = {}
                                        _res[0].response_parameter_list.forEach(_r_p => {
                                            data[_r_p.parameter_name_chs] = r_item[_r_p.parameter_name.toUpperCase()]
                                        })
                                        _data.push(data)
                                    })
                                    this.LabelValueOptions.push({
                                        index: index,
                                        data: _data
                                    })
                                    
                                })
                            })
                        }
                    }
                }
            })
        },
        //初始化验证规则
        initValidatorRules() {
            this.rules.splice(0, this.rules.length)
            this.labelData.forEach((item, index) => {
                var _label = item.label
                var _rules = []
                if (_label.label_type === 0) {
                    this.validator_list[index].forEach(valid => {
                        var rule = {
                            trigger: _label.label_config.control_config.control_type === 'select' ? 'change' : 'blur',
                            validator: this.getValidator(valid),
                            message: valid.errorMessage
                        }
                        _rules.push(rule)
                    })
                    //_label.label_config.validator_list.forEach(valid => {
                    //    var rule = {
                    //        trigger: _label.label_config.control_config.control_type === 'select' ? 'change' : 'blur',
                    //        validator: this.getValidator(valid),
                    //        message: valid.message
                    //    }
                    //    _rules.push(rule)
                    //})
                }
                this.rules.push(_rules)
            })
            console.log(this.rules)
        },
        //获取验证函数
        getValidator(valid) {
            return (rule, value, callback, source, options) => {
                debugger
                var _value = ''
                this.labelData.forEach(item => {
                    if (item.label_id === parseInt(rule.field)) {
                        _value = item.label.default_value
                    }
                })
                if (valid.validatorType === 'required') {
                    if (_value && _value !== '') {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'number') {
                    if (_value && !isNaN(_value)) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'email') {
                    var reg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                    if (_value && reg.test(_value)) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'tel') {
                    var reg1 = /^1\d{10}$/;
                    var reg2 = /^0\d{2,3}-?\d{7,8}$/;
                    if (_value && (reg1.test(_value) || reg2.test(_value))) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'url') {
                    var reg = /^(?:([A-Za-z]+):)?(\/{0,3})([0-9.\-A-Za-z]+)(?::(\d+))?(?:\/([^?#]*))?(?:\?([^#]*))?(?:#(.*))?$/
                    if (_value && reg.test(_value)) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'ID') {
                    var reg = /^\d{15}|\d{}18$/
                    if (_value && reg.test(_value)) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'numberSize') {
                    if (_value >= valid.numberMin && _value <= valid.numberMax) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'lengthSize') {
                    if (_value.length >= valid.lengthMin && _value.length <= valid.lengthMax) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                } else if (valid.validatorType === 'compare') {
                    var _valueTarget = ''
                    this.labelData.forEach(item => {
                        if (item.label_id === valid.compareTarget) {
                            _valueTarget = item.label.default_value
                        }
                    })
                    if (valid.compareType === 0) {
                        if (_value > _valueTarget) {
                            callback()
                        } else {
                            callback(new Error())
                        }
                    } else if (valid.compareType === 1) {
                        if (_value = _valueTarget) {
                            callback()
                        } else {
                            callback(new Error())
                        }
                    } else if (valid.compareType === 2) {
                        if (_value < _valueTarget) {
                            callback()
                        } else {
                            callback(new Error())
                        }
                    }
                } else if (valid.validatorType === 'regular') {
                    var reg = valid.regular
                    if (_value && reg.test(_value)) {
                        callback()
                    } else {
                        callback(new Error())
                    }
                }
            }
        },
        //获取字典数据
        getDicSource(dic_type_id,callBack) {
            var param = {
                dicTypeId: dic_type_id
            }
            get('/Api/Data/GetDictList', param).then(
                res => {
                    callBack(res)
                }
            )
        },
        //获取Api
        getDataApi(api_name, callBack) {
            var param = {
                name: api_name
            }
            get('/Api/DataApi/Index', param).then(
                res => {
                    callBack(res)
                }
            )
        },
        //获取Api数据
        getDataSource(api_id, param, callBack) {
            var param = {
                apiId: api_id,
                request: param
            }
            post('/Api/Data/ListData', param).then(
                res => {
                    callBack(res)
                }
            )
        },
        //获取参数值
        getParamValue(label_id) {
            var result=''
            this.labelData.forEach(item => {
                var _label = item.label
                if (_label.label_id === parseInt(label_id)) {
                    result = _label.default_value
                }
            })
            return result
        },
        //获取LabelDataList
        getLabelDataList() {
            return this.labelData
        },
        //获取控件配置
        getLabelControlOptions(index,key) {
            var value = null
            var options = this.labelData[index].label.label_config.control_config.control_options
            options.forEach(item => {
                if (item.key === key) {
                    value=item.value
                }
            })
            return value
        },
        //获取下拉控件选项
        getLabelValueOption(index) {
            var result = []
            this.LabelValueOptions.forEach(item => {
                if (index === item.index) {
                    result = item.data
                }
            })
            return result
        },
        //自动完成控件条件筛选
        autocompleteSearch(index) {
            return (queryString, callback) => {
                var _label = this.labelData[index].label
                var param = []
                for (pro in _label.label_config.data_source.request_parameter_map) {
                    param.push({
                        parameter_name: pro,
                        value: this.getParamValue(_label.label_config.data_source.request_parameter_map[pro])
                    })
                }
                this.getDataSource(_label.label_config.data_source.api_id, param, (res) => {
                    console.log('res', res)
                    this.getDataApi(_label.label_config.data_source.api_name, (_res) => {
                        var _data = []
                        res.forEach(r_item => {
                            var data = {}
                            _res[0].response_parameter_list.forEach(_r_p => {
                                data[_r_p.parameter_name_chs] = r_item[_r_p.parameter_name.toUpperCase()]
                            })
                            _data.push(data)
                        })
                        callback(_data)
                    })
                })

            }
        },
        //获取表单控件宽度
        getFormItemInputWidth() {
            return this.labelAlign === 'top' ? this.getFormItemWidth() : this.getFormItemWidth() - this.labelWidth
        },
        //获取表单项宽度
        getFormItemWidth() {
            return this.formWith / this.formColumn - 10
        },
        //关闭所有下拉
        dropMenuClose() {
            for (ref in this.$refs) {
                if (ref.indexOf('Select') !== -1 || ref.indexOf('Time') !== -1 || ref.indexOf('Date') !== -1) {
                    this.$refs[ref][0].handleClose()
                }
                if (ref.indexOf('Auto') !== -1) {
                    this.$refs[ref][0].close()
                }
                if (ref.indexOf('Cascader') !== -1) {
                    this.$refs[ref][0].handleClickoutside()
                }
            }
        },
        //刷新
        refreshFrom() {
            this.getForm()
        },
        //提交表单
        submitForm(fn) {
            this.$refs.ElForm.validate(valid => {
                if (valid) {
                    var param = {
                        form_id: this.formId,
                        label_data_list: this.labelData
                    }
                    post('/Api/Form/Submit', param).then(
                        res => {
                            SuccessMsg('提交成功')
                            console.log('提交表单', res)
                            if (typeof (fn) === 'function') {
                                fn()
                            }
                        }
                    )
                    
                }
            })
        },
    },
    mounted() {
        this.getForm()
        this.formWith = this.$refs.ElForm.$el.getBoundingClientRect().width
    },
    template: `
    
        <el-form ref="ElForm" :model="formModel" :label-width="labelWidth+'px'" :label-position="labelAlign" :inline="true">
                <div v-for="(item,index) in labelData" :key="index" v-if="item.label.label_type === 0">
                        <gis-map :ref="'GisMap'+index" v-if="item.label.label_config.control_config.control_type==='map_gis'"
                            ref="GisMap"
                            :base-map-url="baseMapUrl" 
                            :center-x="CenterX" 
                            :center-y="CenterY" 
                            :pca-code="pcaCode">
                        </gis-map>
                        <baidu-map :ref="'BaiDuMap'+index" v-else-if="item.label.label_config.control_config.control_type==='map_baidu'"
                                ref="BaiduMap"
                                :scale-level="item.label.label_option.scaleLevel"
                                :enable-scroll-wheel="item.label.label_option.enableScrollWheel"
                                :enable-dragging="item.label.label_option.enableDragging"
                                :enable-map-click="item.label.label_option.enableMapClick"
                                :enable-search="item.label.label_option.enableSearch"
                                :enable-location="item.label.label_option.enableLocation"
                                :default-point="item.label.label_option.defaultPoint">
                        </baidu-map>
                        <quill-rtf :ref="'Rtf'+index" v-else-if="item.label.label_config.control_config.control_type==='rtf'"
                                   :eidt-enabled="false"
                                   :contents="item.label.contents" >
                        </quill-rtf>
                        <el-form-item v-else
                                      :label="item.label.label_name_chs"
                                      :style="{width:getFormItemWidth()+'px'}"
                                      :prop="item.label_id+''"
                                      :rules="rules[index]">
                            <el-input :ref="'Input'+index" v-if="item.label.label_config.control_config.control_type==='input_base'"
                                      v-model="item.label.default_value"
                                      :placeholder="getLabelControlOptions(index,'placeholder')"
                                      :clearable="getLabelControlOptions(index,'clearable')"
                                      :readonly="getLabelControlOptions(index,'readonly')"
                                      :style="{width:getFormItemInputWidth()+'px'}">
                            </el-input>
                            <el-autocomplete :ref="'Auto'+index" v-if="item.label.label_config.control_config.control_type==='input_autocomplete'"
                                             v-model="item.label.default_value"
                                             :placeholder="getLabelControlOptions(index,'placeholder')"
                                             :clearable="getLabelControlOptions(index,'clearable')"
                                             :readonly="getLabelControlOptions(index,'readonly')"
                                             :trigger-on-focus="getLabelControlOptions(index,'trigger-on-focus')"
                                             :fetch-suggestions="autocompleteSearch(index)"
                                             :style="{width:getFormItemInputWidth()+'px'}"> 
                            </el-autocomplete>
                            <el-input :ref="'TextArea'+index" v-if="item.label.label_config.control_config.control_type==='input_textarea'"
                                      type="textarea"
                                      v-model="item.label.default_value"
                                      :placeholder="getLabelControlOptions(index,'placeholder')"
                                      :autosize="{ minRows: getLabelControlOptions(index,'autosize')[0], maxRows: getLabelControlOptions(index,'autosize')[1] }"
                                      :resize="getLabelControlOptions(index,'resize')"
                                      :readonly="getLabelControlOptions(index,'readonly')"
                                      :style="{width:getFormItemInputWidth()+'px'}">
                            </el-input>
                            <el-select :ref="'Select'+index" v-if="item.label.label_config.control_config.control_type==='select'"
                                      v-model="item.label.default_value"
                                      :placeholder="getLabelControlOptions(index,'placeholder')"
                                      :filterable="getLabelControlOptions(index,'filterable')"
                                      :clearable="getLabelControlOptions(index,'clearable')"
                                      :readonly="getLabelControlOptions(index,'readonly')"
                                      :style="{width:getFormItemInputWidth()+'px'}">
                                    <el-option v-for="item in getLabelValueOption(index)"
                                              :key="item.value"
                                              :label="item.label"
                                              :value="item.value">
                                    </el-option>
                            </el-select>
                            <el-radio-group :ref="'Radio'+index" v-if="item.label.label_config.control_config.control_type==='radio'"
                                            v-model="item.label.default_value"
                                            :readonly="item.label.label_option.readonly"
                                            :style="{width:getFormItemInputWidth()+'px'}">
                                <el-radio v-for="item in getLabelValueOption(index)"
                                              :key="item.value"
                                              :label="item.value">
                                    {{item.label}}
                                </el-radio>
                            </el-radio-group>
                           <el-checkbox-group :ref="'CheckBox'+index" v-if="item.label.label_config.control_config.control_type==='checkbox'"
                                            v-model="item.label.default_value"
                                            :readonly="item.label.label_option.readonly"
                                            :style="{width:getFormItemInputWidth()+'px'}">
                                <el-checkbox v-for="item in getLabelValueOption(index)"
                                              :key="item.value"
                                              :label="item.value">
                                    {{item.label}}
                                </el-checkbox>
                           </el-checkbox-group>
                            <el-switch :ref="'Switch'+index" v-if="item.label.label_config.control_config.control_type==='switch'"
                                       v-model="item.label.default_value"
                                       :readonly="item.label.label_option.readonly"
                                       :active-color="item.label.label_option.activeColor"
                                       :inactive-color="item.label.label_option.inactiveColor"
                                       :active-text="item.label.label_option.activeText"
                                       :inactive-text="item.label.label_option.inactiveText"
                                       :style="{width:getFormItemInputWidth()+'px'}">
                            </el-switch>
                            <el-rate :ref="'Rate'+index" v-if="item.label.label_config.control_config.control_type==='rate'"
                                       v-model="item.label.default_value"
                                       :disabled="item.label.label_option.disabled"
                                       :max="item.label.label_option.max"
                                       :allow-half="item.label.label_option.allowHalf"
                                       :iconClasses="getRateIconClasses(index)"
                                       :void-icon-class="getRateVoidIconClasses(index)"
                                       :show-text="getRateShowModel(index)"
                                       :show-score="!getRateShowModel(index)"
                                       :texts="getRateTexts(index)"
                                       :style="{width:getFormItemInputWidth()+'px'}">
                            </el-rate>
                            <el-slider :ref="'Slider'+index" v-if="item.label.label_config.control_config.control_type==='slider'"
                                       v-model="item.label.default_value"
                                       :disabled="item.label.label_option.disabled"
                                       :min="item.label.label_option.min"
                                       :max="item.label.label_option.max"
                                       :step="item.label.label_option.step"
                                       :show-stops="item.label.label_option.showStops"
                                       :show-tooltip="item.label.label_option.showTooltip"
                                       :range="item.label.label_option.range"
                                       :format-tooltip="getFormatTooltipFn(index)"
                                       :style="{width:getFormItemInputWidth()+'px'}">
                            </el-slider>
                            <el-input-number :ref="'Number'+index" v-if="item.label.label_config.control_config.control_type==='input_number'"
                                            v-model="item.label.default_value"
                                            :disabled="item.label.label_option.disabled"
                                            :min="item.label.label_option.min"
                                            :max="item.label.label_option.max"
                                            :step="item.label.label_option.step"
                                            :precision="item.label.label_option.precision"
                                            :controls="item.label.label_option.controls"
                                            :controls-position="item.label.label_option.controlsPosition"
                                            :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                            </el-input-number>
                            <el-time-picker :ref="'Time'+index" v-if="item.label.label_config.control_config.control_type==='time'"
                                            v-on:change="timeChange"
                                            v-model="item.label.default_value"
                                            :placeholder="item.label.label_option.placeholder"
                                            :readonly="item.label.label_option.readonly"
                                            :clearable="item.label.label_option.clearable"
                                            :arrow-control="item.label.label_option.arrowControl"
                                            :editable="item.label.label_option.editable"
                                            :value-format="item.label.label_option.valueFormat"
                                            :format='item.label.label_option.format'
                                            :picker-options="getTimePickerOptions(index)"                                
                                            :is-range="item.label.label_option.isRange"
                                            :range-separator="item.label.label_option.rangeSeparator"
                                            :start-placeholder="item.label.label_option.startPlaceholder"
                                            :end-placeholder="item.label.label_option.endPlaceholder"
                                            :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                            </el-time-picker>
                            <el-date-picker :ref="'Date'+index" v-if="item.label.label_config.control_config.control_type==='date'"
                                            v-on:change="timeChange"
                                            v-model="item.label.default_value"
                                            :placeholder="item.label.label_option.placeholder"
                                            :readonly="item.label.label_option.readonly"
                                            :clearable="item.label.label_option.clearable"
                                            :type="item.label.label_option.type"
                                            :editable="item.label.label_option.editable"
                                            :value-format="item.label.label_option.valueFormat"
                                            :format='item.label.label_option.format'
                                            :align="item.label.label_option.align"
                                            :range-separator="item.label.label_option.rangeSeparator"
                                            :start-placeholder="item.label.label_option.startPlaceholder"
                                            :end-placeholder="item.label.label_option.endPlaceholder"
                                            :default-time="item.label.label_option.type==='daterange'?['00:00:00', '23:59:59']:''"
                                            :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                            </el-date-picker>
                    </el-form-item>
             </div>
        </el-form>
    
    `
}