var labelTemplate = {
    props: {
        lableType:''
    },
    template:
        `
        <div class="f-label-template">
            <div v-if="lableType==='input_base'||lableType==='input_suggest'||lableType==='input_autocomplete'" class="el-input is-disabled">
                <input type="text" disabled="disabled" autocomplete="off" placeholder="请输入内容" class="el-input__inner">
            </div>
            <div v-else-if="lableType==='input_textarea'" class="el-textarea is-disabled">
                <textarea disabled="disabled" rows="2" placeholder="请输入内容" class="el-textarea__inner" style="resize: none;min-height: 33px;"></textarea>
            </div>

            <div v-else-if="lableType==='select'" class="el-select">
                <div class="el-input is-disabled el-input--suffix">
                    <input type="text" disabled="disabled" readonly="readonly" autocomplete="off" placeholder="请选择" class="el-input__inner">
                    <span class="el-input__suffix">
                        <span class="el-input__suffix-inner">
                            <i class="el-select__caret el-input__icon el-icon-arrow-up"></i>
                        </span>
                    </span>
                </div>
            </div>
            
            <div v-else-if="lableType==='radio'" class="el-radio-group">
                <label role="radio" aria-checked="true" tabindex="0" class="el-radio is-checked">
                    <span class="el-radio__input is-checked">
                        <span class="el-radio__inner"></span>
                        <input type="radio" aria-hidden="true" tabindex="-1" class="el-radio__original" value="3">
                    </span>
                    <span class="el-radio__label">备选项1</span>
                </label>
                <label role="radio" tabindex="-1" class="el-radio">
                    <span class="el-radio__input">
                        <span class="el-radio__inner"></span>
                        <input type="radio" aria-hidden="true" tabindex="-1" class="el-radio__original" value="6">
                    </span>
                    <span class="el-radio__label">备选项2</span>
                </label>
                <label role="radio" tabindex="-1" class="el-radio">
                    <span class="el-radio__input">
                        <span class="el-radio__inner"></span>
                        <input type="radio" aria-hidden="true" tabindex="-1" class="el-radio__original" value="6">
                    </span>
                    <span class="el-radio__label">备选项3</span>
                </label>
            </div>


            <div v-else-if="lableType==='checkbox'" role="group" aria-label="checkbox-group" class="el-checkbox-group">
                <label role="checkbox" aria-checked="true" class="el-checkbox is-checked">
                    <span aria-checked="mixed" class="el-checkbox__input is-checked">
                        <span class="el-checkbox__inner"></span>
                        <input type="checkbox" aria-hidden="true" class="el-checkbox__original" value="复选框 A">
                    </span>
                    <span class="el-checkbox__label">复选框 A</span>
                </label>
                <label role="checkbox" class="el-checkbox">
                    <span aria-checked="mixed" class="el-checkbox__input">
                        <span class="el-checkbox__inner"></span>
                        <input type="checkbox" aria-hidden="true" class="el-checkbox__original" value="复选框 B">
                    </span>
                    <span class="el-checkbox__label">复选框 B</span>
                </label>
                <label role="checkbox" class="el-checkbox">
                    <span aria-checked="mixed" class="el-checkbox__input">
                        <span class="el-checkbox__inner"></span>
                        <input type="checkbox" aria-hidden="true" class="el-checkbox__original" value="复选框 C">
                    </span>
                    <span class="el-checkbox__label">复选框 C</span>
                </label>
            </div>

            <div v-else-if="lableType==='time'" class="el-date-editor el-input is-disabled el-input--prefix el-input--suffix el-date-editor--time-select">
                <input type="text" disabled="disabled" autocomplete="off" name="" placeholder="选择时间" class="el-input__inner">
                <span class="el-input__prefix"><i class="el-input__icon el-icon-time"></i></span>
                <span class="el-input__suffix">
                    <span class="el-input__suffix-inner"><i class="el-input__icon"></i></span>
                </span>
            </div>
            
            <div v-else-if="lableType==='date'" class="el-date-editor el-input is-disabled el-input--prefix el-input--suffix el-date-editor--date">
                <input type="text" disabled="disabled" autocomplete="off" name="" placeholder="选择日期" class="el-input__inner">
                <span class="el-input__prefix"><i class="el-input__icon el-icon-date"></i></span>
                <span class="el-input__suffix">
                    <span class="el-input__suffix-inner"><i class="el-input__icon"></i></span>
                </span>
            </div>

            <div v-else-if="lableType==='date_time'" class="el-date-editor el-input is-disabled el-input--prefix el-input--suffix el-date-editor--datetime">
                <input type="text" disabled="disabled" autocomplete="off" name="" placeholder="选择日期时间" class="el-input__inner">
                <span class="el-input__prefix"><i class="el-input__icon el-icon-time"></i></span>
                <span class="el-input__suffix">
                    <span class="el-input__suffix-inner"><i class="el-input__icon"></i></span>
                </span>
            </div>

            <div v-else-if="lableType==='switch'" role="switch" aria-checked="true" aria-disabled="true" class="el-switch is-disabled is-checked">
                <input type="checkbox" name="" true-value="true" disabled="disabled" class="el-switch__input">
                <span class="el-switch__core" style="width: 40px;"></span>
            </div>

            <div v-else-if="lableType==='input_number'" class="el-input-number is-disabled">
                <span role="button" class="el-input-number__decrease"><i class="el-icon-minus"></i></span>
                <span role="button" class="el-input-number__increase"><i class="el-icon-plus"></i></span>
                <div class="el-input is-disabled">
                    <input type="text" disabled="disabled" autocomplete="off" max="Infinity" min="-Infinity" class="el-input__inner" role="spinbutton" aria-valuemax="Infinity" aria-valuemin="-Infinity" aria-valuenow="1" aria-disabled="true">
                </div>
            </div>

            <div v-else-if="lableType==='slider'" role="slider" aria-valuemin="0" aria-valuemax="100" aria-orientation="horizontal" aria-disabled="true" class="el-slider" aria-valuetext="50" aria-label="slider between 0 and 100">
                <div class="el-slider__runway disabled">
                    <div class="el-slider__bar" style="width: 50%; left: 0%;"></div>
                    <div tabindex="0" class="el-slider__button-wrapper" style="left: 50%;">
                        <div class="el-slider__button el-tooltip" aria-describedby="el-tooltip-5373" tabindex="0"></div>
                    </div>
                </div>
            </div>

            <div v-else-if="lableType==='rate'" role="slider" aria-valuenow="3.7" aria-valuetext="3.7" aria-valuemin="0" aria-valuemax="5" tabindex="0" class="el-rate">
                <span class="el-rate__item" style="cursor: auto;">
                    <i class="el-rate__icon el-icon-star-on" style="color: rgb(247, 186, 42);"></i>
                </span>
                <span class="el-rate__item" style="cursor: auto;">
                    <i class="el-rate__icon el-icon-star-on" style="color: rgb(247, 186, 42);"></i>
                </span>
                <span class="el-rate__item" style="cursor: auto;">
                    <i class="el-rate__icon el-icon-star-on" style="color: rgb(247, 186, 42);"></i>
                </span>
                <span class="el-rate__item" style="cursor: auto;">
                    <i class="el-rate__icon el-icon-star-on" style="color: rgb(239, 242, 247);">
                        <i class="el-rate__decimal el-icon-star-on" style="color: rgb(247, 186, 42); width: 50%;"></i>
                    </i>
                </span>
                <span class="el-rate__item" style="cursor: auto;">
                    <i class="el-rate__icon el-icon-star-on" style="color: rgb(239, 242, 247);"></i>
                </span>
                <span class="el-rate__text" style="color: rgb(255, 153, 0);">3.7</span>
            </div>

            <div v-else-if="lableType==='map_gis'" class="label-map-gis">
                
            </div>

        </div>
        
        `
}