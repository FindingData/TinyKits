var baiduMap = {
    props: ['point','searchShow'],
    data() {
        return {
            mapId: '',
            map: null,
            nearbyArea:0,
            searchInput: '',
            mPoint: null,
        }
    },
    created() {
        this.mapId = 'map' + new Date().getTime()
    },
    methods: {
        //初始化地图
        loadMap() {
            debugger
            // 创建地图实例  
            this.map = new BMap.Map(this.mapId)
            //启用滚轮
            this.map.enableScrollWheelZoom(true)
            // 创建点坐标  
            var point = new BMap.Point(112.99535, 28.20176)
            // 初始化中心点和缩放级别
            this.map.centerAndZoom(point, 14)
            if (this.point) {
                this.mPoint = new BMap.Point(this.point.lng, this.point.lat)
                this.map.centerAndZoom(this.mPoint, 14)
            } else {
                //定位到当前城市
                var myCity = new BMap.LocalCity()
                myCity.get(result => {
                    this.map.setCenter(result.name)
                    this.mPoint = result.center
                })
            }
        },
        doSearach() {
            if (this.searchInput !== '') {
                if (this.nearbyArea !== 0) {
                    var local = new BMap.LocalSearch(this.map, { renderOptions: { map: this.map, autoViewport: false } })
                    local.searchNearby(this.searchInput, this.mPoint, this.nearbyArea, { forceLocal: true});
                } else {
                    var local = new BMap.LocalSearch(this.map, {
                        renderOptions: { map: this.map }
                    })
                    local.search(this.searchInput, { forceLocal: true })
                }
            }
        },
    },
    mounted() {
        this.loadMap()
    },
    template: `

        <div class="f-map-baidu">
            <div :id="mapId" onselectstart="return false;" style="height:365px;-webkit-user-select:none;"></div>
        </div>

    `
}