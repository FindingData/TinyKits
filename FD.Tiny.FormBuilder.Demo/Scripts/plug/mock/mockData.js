// 设置1秒至4秒间响应
Mock.setup({ timeout: '300-800' });

var FormType = {
    查勘表单: '4005001',
    立项表单: '4005002',
    询价表单: '4005003',
    其他表单: '4005004'
}
function getFormTypeAttr(type) {
    for (var pro in FormType) {
        if (FormType[pro] === type) {
            return pro
        }
    }
}


var formComponents = [
    {
        component_group: '表单组件',
        component_list: [
            {
                label_type: 'input_base',
                label_des: '普通文本',
                label_option: {
                    name: '普通文本',
                    primaryKey: '',
                    defaultValue: '',
                    maxlength: 100,
                    placeholder: '请输入内容',
                    clearable: false,
                    readonly: false,
                    hidden: false
                }
            },
            {
                label_type: 'input_autocomplete',
                label_des: '远程文本',
                label_option: {
                    name: '远程文本',
                    primaryKey: '',
                    defaultValue: '',
                    maxlength: 100,
                    placeholder: '请输入内容',
                    clearable: false,
                    readonly: false,
                    hidden: false,
                    trigger_focus: false,
                    dataSourceType: 'api',
                    customDataSource:'',
                    apiDataSource: '',
                    params: [],
                    dataShowModel:'item-normal',
                    filterRule: []
                }
            },
            {
                label_type: 'input_textarea',
                label_des: '多行文本',
                label_option: {
                    name: '多行文本',
                    primaryKey: '',
                    defaultValue: '',
                    maxlength: 100,
                    minlength: 0,
                    placeholder: '请输入内容',
                    autosize: [2, 4],
                    resize:'none',
                    readonly: false,
                    hidden: false
                }
            },
            {
                label_type: 'select',
                label_des: '下拉选择',
                label_option: {
                    name: '下拉选择',
                    primaryKey: '',
                    defaultValue: '',
                    maxlength: 100,
                    minlength: 0,
                    placeholder: '请输入内容',
                    filterable:false,
                    clearable: false,
                    readonly: false,
                    hidden: false,
                    dataSourceType: 'api',
                    customDataSource: '',
                    dicDataSource: '',
                    apiDataSource: '',
                    params: [],
                }
            },
            {
                label_type: 'radio',
                label_des: '单选框',
                label_option: {
                    name: '单选框',
                    primaryKey: '',
                    defaultValue: '',
                    readonly: false,
                    hidden: false,
                    dataSourceType: 'api',
                    customDataSource: '',
                    dicDataSource: '',
                    apiDataSource: '',
                    params: [],
                }
            },
            {
                label_type: 'checkbox',
                label_des: '复选框',
                label_option: {
                    name: '单选框',
                    primaryKey: '',
                    defaultValue: [],
                    readonly: false,
                    hidden: false,
                    dataSourceType: 'api',
                    customDataSource: '',
                    dicDataSource: '',
                    apiDataSource: '',
                    params: [],
                }
            },
            {
                label_type: 'time',
                label_des: '时间选择',
                label_option: {
                    name: '时间选择',
                    primaryKey: '',
                    defaultValue: '',
                    placeholder: '请输入内容',
                    clearable: true,
                    readonly: false,
                    hidden: false,
                    arrowControl: false,
                    valueFormat: '',
                    format: '',
                    pickerOptions: {
                        selectableRange:''
                    },
                    editable: false,
                    isRange: false,
                    rangeSeparator: '-',
                    startPlaceholder: '开始时间',
                    endPlaceholder: '结束时间'
                }
            },
            {
                label_type: 'date',
                label_des: '日期选择',
                label_option: {
                    name: '日期选择',
                    primaryKey: '',
                    defaultValue: '',
                    placeholder: '请输入内容',
                    clearable: true,
                    readonly: false,
                    hidden: false,
                    valueFormat: '',
                    format: '',
                    editable: false,
                    align:'left',
                    type:'date',
                    rangeSeparator: '-',
                    startPlaceholder: '开始时间',
                    endPlaceholder: '结束时间'
                }
            },
            {
                label_type: 'switch',
                label_des: '是非选项',
                label_option: {
                    name: '是非选项',
                    primaryKey: '',
                    defaultValue: false,
                    readonly: false,
                    hidden: false,
                    activeText: '',
                    inactiveText: '',
                    activeColor: null,
                    inactiveColor: null
                }
            },
            {
                label_type: 'input_number',
                label_des: '数字框',
                label_option: {
                    name: '数字框',
                    primaryKey: '',
                    defaultValue: 0,
                    min: 0,
                    max: 10,
                    step: 1,
                    precision:0,
                    disabled: false,
                    hidden: false,
                    controls: true,
                    controlsPosition: 'normal'
                }
            },
            {
                label_type: 'slider',
                label_des: '滑块',
                label_option: {
                    name: '滑块',
                    primaryKey: '',
                    defaultValue: 3,
                    min: 0,
                    max: 10,
                    step: 1,
                    disabled: false,
                    hidden: false,
                    range: false,
                    showStops: false,
                    showTooltip: true,
                    formatTooltip: ''
                }
            },
            {
                label_type: 'rate',
                label_des: '评分',
                label_option: {
                    name: '评分',
                    primaryKey: '',
                    defaultValue: 3,
                    max: 5,
                    disabled: false,
                    hidden: false,
                    iconClasses: 'star',
                    allowHalf: false,
                    showModel: 'text',
                    texts: '["极差", "失望", "一般", "满意", "惊喜"]'
                }
            }
        ]
    },
    {
        component_group: '展示组件',
        component_list: [
            {
                label_type: 'html',
                label_des: 'HTML'
            },
            {
                label_type: 'rtf',
                label_des: '富文本',
                contents:[]
            },
        ]
    },
    {
        component_group: '扩展组件',
        component_list: [
            {
                label_type: 'map_gis',
                label_des: 'GIS地图',
                label_option: {
                    name: 'GIS地图',
                    primaryKey: '',
                    defaultValue: '',
                    maxlength: 100,
                    minlength: 0,
                    placeholder: '请输入内容',
                    clearable: false,
                    readonly: false,
                    hidden: false
                }
            },
            {
                label_type: 'map_baidu',
                label_des: '百度地图',
                label_option: {
                    name: '百度地图',
                    primaryKey: '',
                    scaleLevel: [6,18],
                    enableScrollWheel: true,
                    enableDragging: true,
                    enableMapClick: false,
                    enableSearch: true,
                    enableLocation: true
                }
            }
        ]
    }
]
var dataSource = [
    {
        id: '4001001',
        name: '基础楼盘信息',
        url: '/DataSource/Construction',
        type: 'auto',
        params: [
            {
                name: 'cons_type',
                require: true
            },
            {
                name: 'pcaCode',
                require: false
            }
        ],
        resultFeild: ['cons_id','cons_type', 'consName', 'address', 'pcaCode', 'busseness_range', 'middle_school', 'primary_school', 'park','subway']
    },
    {
        id: '4001002',
        name: '基础楼栋信息',
        url: '/DataSource/Build',
        type: 'auto',
        params: [
            {
                name: 'cons_id',
                require: true
            }
        ],
        resultFeild: ['build_id', 'buildName', 'floor', 'year', 'area',]
    },
    {
        id: '4001003',
        name: '基础房号信息',
        url: '/DataSource/House',
        type: 'auto',
        params: [
            {
                name: 'build_id',
                require: true
            }
        ],
        resultFeild: ['house_id', 'houseName', 'orientation', 'area',]
    },
    {
        id: '5001001',
        name: '城市区域',
        url: '/DataSource/pca',
        type:'dic',
        params: [
            {
                name: 'pca_code',
                require: true
            }
        ],
        resultFeild: []
    },
    {
        id: '5001002',
        name: '业务来源',
        url: '/DataSource/business',
        type: 'dic',
        params: [
            {
                name: 'customer_id',
                require: true
            }
        ],
        resultFeild: []
    }
]
var dicSource = [
    {
        id: '4002001',
        name: '标的物类型',
        items: [
            {
                value: '4301001',
                label:'住宅'
            },
            {
                value: '4301002',
                label: '商业'
            },
            {
                value: '4301003',
                label: '办公'
            },
            {
                value: '4301004',
                label: '土地'
            },
            {
                value: '4301005',
                label: '工业'
            },
            {
                value: '4301006',
                label: '其他'
            }
        ]
    },
    {
        id: '4002002',
        name: '估价目的',
        items: [
            {
                value: '4302001',
                label: '抵押'
            },
            {
                value: '4302002',
                label: '司法'
            },
            {
                value: '4302003',
                label: '征收'
            },
            {
                value: '4302004',
                label: '课税'
            },
            {
                value: '4302005',
                label: '转让'
            },
            {
                value: '4302006',
                label: '其他'
            }
        ]
    },
    {
        id: '4002003',
        name: '项目等级',
        items: [
            {
                value: '4303001',
                label: '普通项目'
            },
            {
                value: '4303002',
                label: '简易项目'
            },
            {
                value: '4303003',
                label: '综合项目'
            },
            {
                value: '4303004',
                label: '特殊项目'
            },
            {
                value: '4303005',
                label: '其他项目'
            }
        ]
    }
]
var construction = [
    {
        cons_id: '1001001',
        cons_type:'4001001',
        consName: '新开福建材大市场',
        address: '开福区福元西路与双河路交汇处西南角新开福建材大市场',
        pcaCode: '430105',
        busseness_range: '属伍家岭商业中心商圈，距离2.8公里',
        middle_school: '一中',
        primary_school: '长郡双语',
        park: '月湖公园',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001002',
        cons_type: '4001001',
        consName: '卧琥城',
        address: '长沙市万家丽北路2段368号',
        pcaCode: '430105',
        busseness_range: '属马王堆商业中心商圈，距离3.1公里',
        middle_school: '一中',
        primary_school: '广益',
        park: '月湖公园',
        subway: '地铁2号线'
    },
    {
        cons_id: '1001003',
        cons_type: '4001001',
        consName: '星城雅郡',
        address: '邻湘楚家园',
        pcaCode: '430105',
        busseness_range: '属马王堆商业中心商圈，距离3.9公里',
        middle_school: '一中',
        primary_school: '广益',
        park: '世界之窗',
        subway: '地铁2号线'
    },
    {
        cons_id: '1001004',
        cons_type: '4001001',
        consName: '北正街商住楼',
        address: '北正街41号',
        pcaCode: '430105',
        busseness_range: '属金满地商业中心商圈，距离0.1公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '湘江风光带',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001002',
        cons_type: '4001001',
        consName: '五一大道202（中环.壹世界)',
        address: '长沙市开福区五一西路202号',
        pcaCode: '430105',
        busseness_range: '属五一广场商业中心商圈，距离0.1公里',
        middle_school: '长郡',
        primary_school: '麓山国际',
        park: '湘江风光带',
        subway: '地铁1、2号线'
    },
    {
        cons_id: '1001006',
        cons_type: '4001001',
        consName: '兴汉大厦',
        address: '开福区蔡锷北路东兴园巷2号',
        pcaCode: '430105',
        busseness_range: '属金满地商业中心商圈，距离0.9公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '烈士公园',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001007',
        cons_type: '4001002',
        consName: '上胡家花园巷10号',
        address: '上胡家花园巷10号',
        pcaCode: '430105',
        busseness_range: '属金满地商业中心商圈，距离0.5公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '烈士公园',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001008',
        cons_type: '4001002',
        consName: '兴通园公寓',
        address: '东风路东侧',
        pcaCode: '430105',
        busseness_range: '属伍家岭商业中心商圈，距离0.6公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '月湖公园',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001009',
        cons_type: '4001003',
        consName: '紫荆花园',
        address: '国庆巷85号',
        pcaCode: '430105',
        busseness_range: '属伍家岭商业中心商圈，距离0.4公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '烈士公园',
        subway: '地铁1号线'
    },
    {
        cons_id: '1001010',
        cons_type: '4001003',
        consName: '才子佳苑1期',
        address: '开福区德雅路',
        pcaCode: '430105',
        busseness_range: '属伍家岭商业中心商圈，距离2.2公里',
        middle_school: '一中',
        primary_school: '麓山国际',
        park: '烈士公园',
        subway: '地铁1号线'
    }
]
var pca = [
    {
        pca_code:'430101',
        pca_name: '开福区'
    },
    {
        pca_code: '430102',
        pca_name: '天心区'
    },
    {
        pca_code: '430103',
        pca_name: '芙蓉区'
    },
    {
        pca_code: '430104',
        pca_name: '雨花区'
    },
    {
        pca_code: '430105',
        pca_name: '岳麓区'
    },
    {
        pca_code: '430701',
        pca_name: '武陵区'
    },
    {
        pca_code: '430702',
        pca_name: '鼎城区'
    },
    {
        pca_code: '430703',
        pca_name: '安乡县'
    },
    {
        pca_code: '430704',
        pca_name: '汉寿县'
    },
    {
        pca_code: '430705',
        pca_name: '澧县'
    }
]

Mock.mock('/DataSource/GetFormComponents', 'get', function () {
    return Mock.mock(formComponents);
});

Mock.mock('/DataSource/GetDataSourceList', 'get', function () {
    return Mock.mock(dataSource);
});

Mock.mock('/DataSource/GetDicSourceList', 'get', function () {
    return Mock.mock(dicSource);
});

Mock.mock('/DataSource/Construction', 'post', function (options) {
    var param = JSON.parse(options.body)
    var result = construction.filter((item) => {
        var flag = true
        for (var pro in param) {
            if (pro !== 'q') {
                if (param[pro] !== item[pro]) {
                    flag = false
                }
            } else {
                if (item.consName.indexOf(param['q']) === -1) {
                    flag = false
                }
            }
        }
        return flag
    })
    return Mock.mock(result);
});
Mock.mock('/DataSource/pca', 'post', function (options) {
    var param = JSON.parse(options.body)
    var filter = pca.filter((item) => {
        var flag = true
        for (var pro in param) {
            if (item.pca_code.indexOf(param[pro]) === -1) {
                flag = false
            }
        }
        return flag
    })
    var result = []
    filter.forEach(item => {
        result.push({
            value: item.pca_code,
            label: item.pca_name
        })
    })
    return Mock.mock(result);
});
