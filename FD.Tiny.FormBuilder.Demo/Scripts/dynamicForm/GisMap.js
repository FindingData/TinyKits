var gisMap = {
    props: ['baseMapUrl', 'centerX', 'centerY', 'pcaCode','purpose'],
    data() {
        return {
            mapId:'',
            map: null,
            ClickGeo: null,
            BuildGraphs: null,
            ConstructionCoord: '',
            contructionMapUrl: '',
            buildingMapUrl: '',
            NetURL: '',
            curConstruction_code: '',


        }
    },
    beforeCreate() {
        dojo.require("esri.map");
        dojo.require("esri.toolbars.draw");
        dojo.require("esri.graphic");
        dojo.require("esri.layers.FeatureLayer");
        dojo.require("esri.layers.graphics");
        dojo.require("esri.tasks.query");
        dojo.require("esri.tasks.geometry");
        dojo.require("esri.tasks.GeometryService");
        dojo.require("esri.tasks.BufferParameters");
    },
    created() {
        this.mapId = 'map' + new Date().getTime()
    },
    methods: {
        //初始化地图
        loadMap() {
            this.map = new esri.Map(this.mapId, {
                logo: false
            })
            dojo.connect(this.map, "onClick", (evt) => {
                this.ClickGeo = evt.mapPoint
                this.GetMapConstruction(evt.mapPoint)  //用于地图定位楼盘
            });
            //this.BuildGraphs = new esri.layers.GraphicsLayer()
            //this.map.removeAllLayers()
            var tiledMapServiceLayer = new esri.layers.ArcGISTiledMapServiceLayer(this.baseMapUrl)
            this.map.addLayer(tiledMapServiceLayer)
            //this.map.addLayer(this.BuildGraphs)
            dojo.connect(this.map, "onLoad", (evt) => {
                if (this.ConstructionCoord == "") {
                    var cPoint = new esri.geometry.Point();
                    cPoint.spatialReference = tiledMapServiceLayer.spatialReference;
                    cPoint.x = this.centerX;
                    cPoint.y = this.centerY;
                    this.map.centerAt(cPoint);
                } else {
                    this.zoomToPoint(this.ConstructionCoord, '');
                }
            });
        },
        //
        LocationConstruction(iConstructionCode, purpose, pcaCode) {
            //debugger;   
            curConstruction_code = iConstructionCode;
            var pquery = new esri.tasks.Query();
            pquery.where = "新楼盘编码 = '" + iConstructionCode.toString() + "'";
            console.log("map", map);
            pquery.outSpatialReference = map.spatialReference; // { wkid: 4326 }  天津2384;
            pquery.returnGeometry = true;
            pquery.outFields = ["楼盘名称"];
            var queryTask = new esri.tasks.QueryTask(contructionMapUrl);
            queryTask.execute(pquery, addGeometryToMap);
        },
        //
        LocationBuilding(iBuildingCode) {
            //setBussMapUrl("40002001", 430100);
            var pquery = new esri.tasks.Query();
            pquery.where = "新楼栋编码 = '" + iBuildingCode.toString() + "'";
            pquery.outSpatialReference = map.spatialReference; // { wkid: 4326 }  天津2384;
            pquery.returnGeometry = true;
            pquery.outFields = ["楼栋名称"];
            var queryTask = new esri.tasks.QueryTask(buildingMapUrl);
            queryTask.execute(pquery, addBuildingGeometryToMap);
        },
        //
        addBuildingGeometryToMap(results) {
            //debugger;
            if (results.features.length > 0) {
                var sName = results.features[0].attributes["楼栋名称"];
                var sGeometry = results.features[0].geometry;
                var sExtent = sGeometry.getExtent();
                //当点击的行对应的Geometry为点类型时进行地图中心定位显示
                if (sGeometry.type == "point") {
                    var cPoint = new esri.geometry.Point();
                    cPoint.spatialReference = map.spatialReference;
                    cPoint.x = sGeometry.x;
                    cPoint.y = sGeometry.y;
                    //map.centerAt(cPoint);
                    zoomToBuildLocation(cPoint, sGeometry, sName);
                    LocationNetCode(cPoint);
                }
                //当点击的行对应的Geometry为线或面类型时获取Geometry的Extent进行中心定位显示
                else {
                    var sExtent = sGeometry.getExtent();
                    var cPoint = new esri.geometry.Point();
                    cPoint.spatialReference = map.spatialReference;// new esri.SpatialReference({ wkid: 4326 });
                    cPoint.x = (sExtent.xmax + sExtent.xmin) / 2;
                    cPoint.y = (sExtent.ymax + sExtent.ymin) / 2;
                    zoomToBuildLocation(cPoint, sGeometry, sName);
                    LocationNetCode(cPoint);
                }
            }
        },
        //定位网格
        LocationNet(geometry) {
            //debugger
            ConstructionCoord = geometry.x.toString() + "," + geometry.y.toString();

            //map.graphics.clear();
            //var red = new esri.symbol.PictureMarkerSymbol("../Content/image/map7.png", 64, 64).setOffset(0, 32); //tp:/ / static.arcgis.com / images / Symbols / Shapes / RedPin1LargeB.png
            //map.graphics.add(new esri.Graphic(geometry, red));

            var pquery = new esri.tasks.Query();
            pquery.geometry = geometry;
            pquery.outFields = ["code"];
            pquery.outSpatialReference = map.spatialReference; // { wkid: 4326 };
            pquery.spatialRelationship = esri.tasks.Query.SPATIAL_REL_INTERSECTS;
            pquery.returnGeometry = true;
            var queryTask = new esri.tasks.QueryTask(NetURL);
            queryTask.execute(pquery, ClickPointSelect);

        },
        //获取网格编码
        LocationNetCode(geometry) {
            ConstructionCoord = geometry.x.toString() + "," + geometry.y.toString();
            var pquery = new esri.tasks.Query();
            pquery.geometry = geometry;
            pquery.outFields = ["code"];
            pquery.outSpatialReference = map.spatialReference; // { wkid: 4326 };
            pquery.spatialRelationship = esri.tasks.Query.SPATIAL_REL_INTERSECTS;
            pquery.returnGeometry = true;
            var queryTask = new esri.tasks.QueryTask(NetURL);
            //debugger
            queryTask.execute(pquery, ClickPointSelect);
        },
        //返回网格编码
        ClickPointSelect(results) {
            //debugger;
            if (results.features.length == 0) {
                return;
            }
            var graphic = results.features[0];
            //debugger;
            GridCode = graphic.attributes["code"];

        },
        //获取楼盘编码
        GetMapConstruction(geometry) {
            this.map.graphics.clear();
            //this.BuildGraphs.clear();
            var red = new esri.symbol.PictureMarkerSymbol("../Content/image/map7.png", 64, 64).setOffset(0, 32); //tp:/ / static.arcgis.com / images / Symbols / Shapes / RedPin1LargeB.png
            this.map.graphics.add(new esri.Graphic(geometry, red));

            var query = new esri.tasks.Query();
            query.geometry = geometry;
            query.outFields = ["新楼盘编码"];
            query.outSpatialReference = this.map.spatialReference; // { wkid: 4326 };
            query.spatialRelationship = esri.tasks.Query.SPATIAL_REL_INTERSECTS;
            query.returnGeometry = true;
            var queryTask = new esri.tasks.QueryTask(this.contructionMapUrl);
            queryTask.execute(query, this.ClickConstructionSelect);
        },
        //返回楼盘编码
        ClickConstructionSelect(results) {
            if (results.features.length == 0) {
                this.LocationNet(this.ClickGeo);
                return;
            } else {
                var graphic = results.features[0];
                //返回楼盘编码，处理楼盘控件
                var code = graphic.attributes["新楼盘编码"];
                //传入参数
                var parms = [
                    { name: "CONSTRUCTION_CODE", val: code },//后台取客户          
                ];
                //dForm.fillInParms(parms);
                //dForm.fetchFormData();
            }
        },
        //添加几何图形
        addGeometryToMap(results) {
            if (results.features.length > 0) {
                this.curConstruction_code = results.features[0];
                var sName = this.curConstruction_code.attributes["楼盘名称"];
                var sGeometry = this.curConstruction_code.geometry;
                var sExtent = sGeometry.getExtent();
                //当点击的行对应的Geometry为点类型时进行地图中心定位显示
                if (sGeometry.type == "point") {
                    var cPoint = new esri.geometry.Point();
                    cPoint.spatialReference = this.map.spatialReference;
                    cPoint.x = sGeometry.x;
                    cPoint.y = sGeometry.y;
                    this.map.centerAt(cPoint);
                    this.zoomToLocation(cPoint, sGeometry, sName);
                    this.LocationNetCode(cPoint);
                }
                //当点击的行对应的Geometry为线或面类型时获取Geometry的Extent进行中心定位显示
                else {
                    var sExtent = sGeometry.getExtent();
                    var cPoint = new esri.geometry.Point();
                    cPoint.spatialReference = this.map.spatialReference;// new esri.SpatialReference({ wkid: 4326 });
                    cPoint.x = (sExtent.xmax + sExtent.xmin) / 2;
                    cPoint.y = (sExtent.ymax + sExtent.ymin) / 2;
                    this.zoomToLocation(cPoint, sGeometry, sName);
                    this.LocationNetCode(cPoint);
                }
            }
        },
        //坐标定位
        zoomToPoint(coord, sName) {
            if (this.map.graphics != null) {
                this.map.graphics.clear();
            }
            var coordarray = coord.split(",");
            var cPoint = new esri.geometry.Point();
            cPoint.spatialReference = map.spatialReference;// new esri.SpatialReference({ wkid: 4326 });
            cPoint.x = parseFloat(coordarray[0]);
            cPoint.y = parseFloat(coordarray[1]);
            this.map.centerAndZoom(cPoint, 4);

            var red = new esri.symbol.PictureMarkerSymbol("/Content/image/map2.png", 64, 64).setOffset(0, 32); //tp:/ / static.arcgis.com / images / Symbols / Shapes / RedPin1LargeB.png
            this.map.graphics.add(new esri.Graphic(cPoint, red));

            var font = new esri.symbol.Font("14px", esri.symbol.Font.STYLE_NORMAL, esri.symbol.Font.VARIANT_NORMAL, esri.symbol.Font.WEIGHT_BOLDER);
            var textSymbol = new esri.symbol.TextSymbol(sName, font, new dojo.Color([255, 0, 0])).setOffset(0, -2);
            var labelPointGraphic = new esri.Graphic(cPoint, textSymbol);
            this.map.graphics.add(labelPointGraphic);
        },
        //位置定位
        zoomToLocation(cPoint, sGeometry, sName) {
            map.centerAndZoom(cPoint, 4);
            map.graphics.clear();
            BuildGraphs.clear();
            var polySym = new esri.symbol.SimpleFillSymbol().setColor(new dojo.Color([56, 102, 164, 0.4])).setOutline(new esri.symbol.SimpleLineSymbol().setColor(new dojo.Color([56, 102, 164, 0.8])));
            var bufferGraphic = new esri.Graphic(sGeometry, polySym);
            map.graphics.add(bufferGraphic);

            var red = new esri.symbol.PictureMarkerSymbol("../Content/image/map2.png", 64, 64).setOffset(0, 32); //tp:/ / static.arcgis.com / images / Symbols / Shapes / RedPin1LargeB.png
            map.graphics.add(new esri.Graphic(cPoint, red));

            var font = new esri.symbol.Font("14px", esri.symbol.Font.STYLE_NORMAL, esri.symbol.Font.VARIANT_NORMAL, esri.symbol.Font.WEIGHT_BOLDER);
            var textSymbol = new esri.symbol.TextSymbol(sName, font, new dojo.Color([255, 0, 0])).setOffset(0, -2);
            var labelPointGraphic = new esri.Graphic(cPoint, textSymbol);
            map.graphics.add(labelPointGraphic);
        },
        //楼栋定位
        zoomToBuildLocation(cPoint, sGeometry, sName) {
            this.map.centerAndZoom(cPoint, 5);
            this.BuildGraphs.clear();
            var polySym = new esri.symbol.SimpleFillSymbol().setColor(new dojo.Color([56, 102, 164, 0.4])).setOutline(new esri.symbol.SimpleLineSymbol().setColor(new dojo.Color([56, 102, 164, 0.8])));
            var bufferGraphic = new esri.Graphic(sGeometry, polySym);
            this.BuildGraphs.add(bufferGraphic);

            var red = new esri.symbol.PictureMarkerSymbol("../Content/image/map3.png", 48, 48).setOffset(0, 24); //tp:/ / static.arcgis.com / images / Symbols / Shapes / RedPin1LargeB.png
            this.BuildGraphs.add(new esri.Graphic(cPoint, red));

            var font = new esri.symbol.Font("14px", esri.symbol.Font.STYLE_NORMAL, esri.symbol.Font.VARIANT_NORMAL, esri.symbol.Font.WEIGHT_BOLDER);
            var textSymbol = new esri.symbol.TextSymbol(sName, font, new dojo.Color([255, 0, 0])).setOffset(0, -2);
            var labelPointGraphic = new esri.Graphic(cPoint, textSymbol);
            this.BuildGraphs.add(labelPointGraphic);
        },
        //获取地图服务地址
        getMapUrl() {
            var requests = [
                axios.post(host+'/DynamicForm/GetCurrentMap', { pcaCode: this.pcaCode, purpose: this.purpose, mapServerType: MapServerType.楼盘地图 }),
                axios.post(host+'/DynamicForm/GetCurrentMap', { pcaCode: this.pcaCode, purpose: this.purpose, mapServerType: MapServerType.楼栋地图 }),
                axios.post(host+'/DynamicForm/GetCurrentMap', { pcaCode: this.pcaCode, purpose: this.purpose, mapServerType: MapServerType.网格地图 })
            ]
            axios.all(requests).then(
                axios.spread((contruction, building,net) => {
                    this.contructionMapUrl = contruction.data
                    this.buildingMapUrl = contruction.data
                    this.NetURL = contruction.data
                    console.log(this.contructionMapUrl, this.buildingMapUrl, this.NetURL)
                })
            )
        },
        //重载地图
        resize() {
            if (this.map)
                this.map.resize()
        },
    },
    mounted() {
        this.loadMap()
        //this.getMapUrl()
    },
    template: `

        <div class="f-map-gis">
            <div v-if="mapId" :id="mapId"></div>
        </div>

    `
}