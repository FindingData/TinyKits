﻿
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
            labelData:[],
        }
    },
    methods: {
        //获取Form
        getForm() {
            var param = {
                formId: this.formId
            }
            get('/Form/Get', param).then(
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
            get('/Form/GetLabelList', param).then(
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
            })
            if (this.labelData.length > 0) {
                this.onSuccess()
            } else {
                this.onEmpty()
            }
        },
        //获取LabelDataList
        getLabelDataList() {
            return this.labelData
        },
        //获取控件选项
        getLabelControlOptions(index,key) {
            var value = null
            var options = this.labelData[index].label.label_config.control_options
            options.forEach(item => {
                if (item.key === key) {
                    value=item.value
                }
            })
            return value
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
        validate() {
            return true
        },
        //提交表单
        submitForm(fn) {
            if (this.validate()) {
                var param = {
                    store: {
                        form_id: this.formId,
                        label_data_list: this.labelData
                    }
                }
                post('/Form/Submit', param).then(
                    res => {
                        console.log('提交表单',res)
                        if (typeof (fn) === 'function') {
                            fn()
                        }
                    }
                )
            }
        },
    },
    mounted() {
        this.getForm()
        this.formWith = this.$refs.ElForm.$el.getBoundingClientRect().width
    },
    template: `
    
        <el-form ref="ElForm" :label-width="labelWidth+'px'" :label-position="labelAlign" :inline="true">
                <gis-map v-for="(item,index) in labelData" :key="index" v-if="item.label.control_type==='map_gis'"
                        ref="GisMap"
                        :base-map-url="baseMapUrl" 
                        :center-x="CenterX" 
                        :center-y="CenterY" 
                        :pca-code="pcaCode">
                </gis-map>
                <baidu-map v-else-if="item.label.control_type==='map_baidu'"
                        ref="BaiduMap"
                        :scale-level="item.label.label_option.scaleLevel"
                        :enable-scroll-wheel="item.label.label_option.enableScrollWheel"
                        :enable-dragging="item.label.label_option.enableDragging"
                        :enable-map-click="item.label.label_option.enableMapClick"
                        :enable-search="item.label.label_option.enableSearch"
                        :enable-location="item.label.label_option.enableLocation"
                        :default-point="item.label.label_option.defaultPoint">
                </baidu-map>
                <quill-rtf v-else-if="item.label.control_type==='rtf'"
                           :eidt-enabled="false"
                           :contents="item.label.contents" >
                </quill-rtf>
                <el-form-item v-else
                              :label="item.label.label_name_chs"
                              :style="{width:getFormItemWidth()+'px'}">
                    <el-input v-if="item.label.control_type==='input_base'"
                              v-model="item.label_value"
                              :placeholder="getLabelControlOptions(index,'placeholder')"
                              :clearable="getLabelControlOptions(index,'clearable')"
                              :readonly="getLabelControlOptions(index,'readonly')"
                              :style="{width:getFormItemInputWidth()+'px'}">
                    </el-input>
                    <el-autocomplete v-if="item.label.control_type==='input_autocomplete'"
                                     v-model="item.label_value"
                                     :placeholder="item.label.label_option.placeholder"
                                     :maxlength="item.label.label_option.maxlength"
                                     :clearable="item.label.label_option.clearable"
                                     :readonly="item.label.label_option.readonly"
                                     :fetch-suggestions="autocompleteSearch(index)"
                                     :trigger-on-focus="item.label.label_option.trigger_focus"
                                     :style="{width:getFormItemInputWidth()+'px'}">
                            <template slot-scope="{ item }">
                                <div v-if="item.label.label_option.dataShowModel==='item-title-des'">
                                    <div class="title">{{item.title}}</div>
                                    <span style="font-size: 12px;color: #b4b4b4;">{{item.des}}</span>
                                </div>
                                <div v-else-if="item.label.label_option.dataShowModel==='item-key-value'">
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
                    <el-input v-if="item.label.control_type==='input_textarea'"
                              type="textarea"
                              v-model="item.label_value"
                              :placeholder="item.label.label_option.placeholder"
                              :maxlength="item.label.label_option.maxlength"
                              :autosize="{ minRows: item.label.label_option.autosize[0], maxRows: item.label.label_option.autosize[1] }"
                              :resize="item.label.label_option.resize"
                              :readonly="item.label.label_option.readonly"
                              :style="{width:getFormItemInputWidth()+'px'}">
                    </el-input>
                    <el-select v-if="item.label.control_type==='select'"
                              v-model="item.label_value"
                              :placeholder="item.label.label_option.placeholder"
                              :filterable="item.label.label_option.filterable"
                              :clearable="item.label.label_option.clearable"
                              :readonly="item.label.label_option.readonly"
                              :style="{width:getFormItemInputWidth()+'px'}">
                            <el-option v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.label"
                                      :value="item.value">
                            </el-option>
                    </el-select>
                    <el-radio-group v-if="item.label.control_type==='radio'"
                                    v-model="item.label_value"
                                    :readonly="item.label.label_option.readonly"
                                    :style="{width:getFormItemInputWidth()+'px'}">
                        <el-radio v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.value">
                            {{item.label}}
                        </el-radio>
                    </el-radio-group>
                   <el-checkbox-group v-if="item.label.control_type==='checkbox'"
                                    v-model="item.label_value"
                                    :readonly="item.label.label_option.readonly"
                                    :style="{width:getFormItemInputWidth()+'px'}">
                        <el-checkbox v-for="item in getLabelValueOption(index)"
                                      :key="item.value"
                                      :label="item.value">
                            {{item.label}}
                        </el-checkbox>
                   </el-checkbox-group>
                    <el-switch v-if="item.label.control_type==='switch'"
                               v-model="item.label_value"
                               :readonly="item.label.label_option.readonly"
                               :active-color="item.label.label_option.activeColor"
                               :inactive-color="item.label.label_option.inactiveColor"
                               :active-text="item.label.label_option.activeText"
                               :inactive-text="item.label.label_option.inactiveText"
                               :style="{width:getFormItemInputWidth()+'px'}">
                    </el-switch>
                    <el-rate v-if="item.label.control_type==='rate'"
                               v-model="item.label_value"
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
                    <el-slider v-if="item.label.control_type==='slider'"
                               v-model="item.label_value"
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
                    <el-input-number v-if="item.label.control_type==='input_number'"
                                    v-model="item.label_value"
                                    :disabled="item.label.label_option.disabled"
                                    :min="item.label.label_option.min"
                                    :max="item.label.label_option.max"
                                    :step="item.label.label_option.step"
                                    :precision="item.label.label_option.precision"
                                    :controls="item.label.label_option.controls"
                                    :controls-position="item.label.label_option.controlsPosition"
                                    :style="{width:getFormItemInputWidth()>300?300:getFormItemInputWidth()+'px'}">
                    </el-input-number>
                    <el-time-picker v-if="item.label.control_type==='time'"
                                    v-on:change="timeChange"
                                    v-model="item.label_value"
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
                    <el-date-picker v-if="item.label.control_type==='date'"
                                    v-on:change="timeChange"
                                    v-model="item.label_value"
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
            
        </el-form>
    
    `
}