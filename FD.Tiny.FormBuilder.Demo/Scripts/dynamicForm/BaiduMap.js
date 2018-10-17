var baiduMap = {
    props: [ 'scaleLevel', 'enableScrollWheel', 'enableDragging', 'enableMapClick', 'enableSearch', 'enableLocation'],
    data() {
        return {
            mapId: '',
            map: null,
            nearbyArea:0,
            searchInput: '',
            mPoint: null,
            searchInput:'',
            searchSelect: 0,

        }
    },
    created() {
        this.mapId = 'map' + new Date().getTime()
    },
    methods: {
        //初始化地图
        loadMap() {
            // 创建地图实例  
            this.map = new BMap.Map(this.mapId, { minZoom: this.scaleLevel[0], maxZoom: this.scaleLevel[1], enableMapClick: this.enableMapClick })
            //启用滚轮
            this.map.enableScrollWheelZoom(this.enableScrollWheel)
            //启用拖拽
            if (this.enableDragging) {
                this.map.enableDragging()
            } else {
                this.map.disableDragging()
            }
            // 创建点坐标  
            var point = new BMap.Point(112.99535, 28.20176)
            // 初始化中心点和缩放级别
            this.map.centerAndZoom(point, 14)
            //定位到当前城市
            var myCity = new BMap.LocalCity()
            myCity.get(result => {
                this.map.setCenter(result.name)
                this.mPoint = result.center
            })
        },
        searchSubmit() {
            if (this.searchInput !== '') {
                this.map.clearOverlays()
                if (this.searchSelect !== 0) {
                    var local = new BMap.LocalSearch(this.map, { renderOptions: { map: this.map, autoViewport: false } })
                    local.searchNearby(this.searchInput, this.mPoint, this.searchSelect, { forceLocal: true})
                } else {
                    var local = new BMap.LocalSearch(this.map, {
                        renderOptions: { map: this.map }
                    })
                    local.search(this.searchInput, { forceLocal: true })
                }
            }
        },
        location() {
            navigator.geolocation.getCurrentPosition(function (position) {
                console.log('location',position)
                //得到html5定位结果
                var x = position.coords.longitude;
                var y = position.coords.latitude;
                var ggPoint = new BMap.Point(x, y);
                var convertor = new BMap.Convertor();
                var pointArr = [];
                pointArr.push(ggPoint);
                convertor.translate(pointArr, 1, 5, function (data) {
                    if (data.status === 0) {
                        var marker = new BMap.Marker(data.points[0]);
                        bm.addOverlay(marker);
                        bm.setCenter(data.points[0]);
                    }
                })
                

            })
        },
    },
    mounted() {
        this.loadMap()
    },
    template: `

        <div class="f-map-baidu" style="position:relative;">
            <div v-if="enableSearch" style="position:absolute;top:20px;left:20px;z-index:99;">
                <el-input placeholder="请输入内容" v-model="searchInput">
                    <el-select v-model="searchSelect" slot="prepend" style="width:100px;">
                      <el-option label="500M" :value="500"></el-option>
                      <el-option label="1000M" :value="1000"></el-option>
                      <el-option label="3000M" :value="3000"></el-option>
                      <el-option label="不限" :value="0"></el-option>
                    </el-select>
                    <el-button slot="append" icon="el-icon-search" v-on:click="searchSubmit" title="检索"></el-button>
                </el-input>
            </div>
            <div v-if="enableLocation" style="position:absolute;bottom:20px;left:20px;z-index:99;">
                <el-button type="text" v-on:click="location" title="定位">
                    <i class="iconfont icon-Location" style="font-size:32px;"></i>
                </el-button>
            </div>
            <div :id="mapId" onselectstart="return false;" style="height:365px;-webkit-user-select:none;"></div>
        </div>

    `
}