using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FD.Tiny.UI.Controls;
using FD.Tiny.Common.Utility.Json;
using Newtonsoft.Json.Converters;

namespace FD.Tiny.UI.Controls.Demo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            var ctls = new List<BaseControl>();

            var radio = new Radio()
            {
                name = "radio",                
            };

            ctls.Add(radio);
             
            var checkexbox = new CheckBox()
            {
                name = "checkbox",
                is_checked = true,
            };

            ctls.Add(checkexbox);

            var uncheckedbox = new CheckBox() {
                name = "chexkbox",                
            };

            ctls.Add(uncheckedbox);

            var datePicker = new DatePicker()
            {
                 name="datepicker"
            };
            ctls.Add(datePicker);


            
            return Json(ctls, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Radio()
        {
            var container = new Dictionary<string, List<BaseControl>>();

            var basic = new List<BaseControl>();
            var b1 = new Radio()
            {
                name = "radio",
                value = "1",
                text = "备选项",
                is_checked = false,
            };
            basic.Add(b1);
            var b2 = new Radio()
            {
                name = "radio",
                label = "2",
                text = "备选项",
                is_checked = true
            };
            basic.Add(b2);
            container.Add("basic", basic);
            var disabled = new List<BaseControl>();
            var b3 = new Radio()
            {
                name = "radio1",
                disabled = true,
                text = "备选项",
                value = "禁用",
            };
            disabled.Add(b3);
            var b4 = new Radio()
            {
                name = "radio1",
                disabled = true,
                text = "备选项",
                value = "选中且禁用",
            };
            disabled.Add(b4);
            container.Add("disabled", disabled);



            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Check()
        {
            var container = new Dictionary<string, List<BaseControl>>();

            var basic = new List<BaseControl>();
            var chk1 = new CheckBox()
            {
                name = "check",
                is_checked = true,    
                text = "备选项",
            };
            basic.Add(chk1);

            container.Add("basic", basic);

            var disabled = new List<BaseControl>();
            var chk2 = new CheckBox()
            {
                name = "check1",
                is_checked = false,
                text = "备选项1",
                disabled = true,
            };
            disabled.Add(chk2);
            var chk3 = new CheckBox()
            {
                name = "check2",
                is_checked = false,
                text = "备选项",
                disabled = true,
            };
            disabled.Add(chk3);

            var group = new List<BaseControl>();
            var chk4 = new CheckBox()
            {
                name = "checkList",
                label = "复选框 A",
                text= "复选框 A",
                is_checked = true,
            };
            group.Add(chk4);
            var chk5 = new CheckBox()
            {
                name = "checkList",
                label = "复选框 B",
                text = "复选框 B",                
            };
            group.Add(chk5);
            var chk6 = new CheckBox()
            {
                name = "checkList",
                label = "复选框 C",
                text = "复选框 C",
            };
            group.Add(chk6);
            var chk7 = new CheckBox()
            {
                name = "checkList",
                label = "禁用",
                text = "禁用",
                disabled = true,
            };
            group.Add(chk7);
            var chk8 = new CheckBox()
            {
                name = "checkList",
                label = "选中禁用",
                text = "选中禁用",
                is_checked = true,
                disabled = true,
            };
            group.Add(chk8);

            container.Add("disabled", disabled);

            return Json(container, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Input()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new Input()
            {
                name = "input",
                type = InputMode.text,
                placeholder = "文本"
            };
            container.Add("basic", basic);
            var disabled = new Input()
            {
                name = "input1",
                disabled = true,
            };
            container.Add("disabled", disabled);
            var textarea = new Input()
            {
                name = "textarea",
                placeholder = "文本域",
                type = InputMode.textarea,
            };
            container.Add("textarea", textarea);
            var search = new Input()
            {
                name = "search",
                type = InputMode.autocomplete,                
            };
            var autocomplete = new Autocomplete()
            {
                data = MockData()
            };
            search.autocomplete = autocomplete;

            var search2 = new Input()
            {
                name = "search2",
                placeholder = "请输入内容", 
                type = InputMode.autocomplete
            };
            var autocomplete2 = new Autocomplete()
            {
                data = MockData(),
                response_formatter = new ResultFormatter()
                {
                    label = new string[]{ "name" },
                    value = "user_name",
                }
            };
            search2.autocomplete = autocomplete2;

            var search3 = new Input()
            {
                name = "search3",
                placeholder = "请输入内容",                
                type = InputMode.autocomplete
            };
            var autocomplete3 = new Autocomplete()
            {
                url = "/home/api/getuser",
                remote = true,
                param_list = new List<QueryParam>()
                {
                     new QueryParam(){ name="customer_id",value="1" },
                     new QueryParam(){ name="user_id",value="2"},
                },
                response_formatter = new ResultFormatter()
                {
                    label = new string[] { "user_name" },
                    value = "user_id"
                }
            };
            search3.autocomplete = autocomplete3;

            container.Add("search1", search3);
            container.Add("search2", search3);
            container.Add("search3", search3);

            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InputNumber()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new InputNumber()
            {
                name = "basic",
                min = 1,
                max = 10,
            };
            container.Add("basic", basic);

            var disabled = new InputNumber()
            {
                name = "disabled",
                disabled = true,
            };
            container.Add("disabled", disabled);

            var step = new InputNumber()
            {
                name = "step",
                step = 5,
                value = "1",
            };
            container.Add("step", step);

            var precision = new InputNumber()
            {
                name = "precision",
                step = 0.1f,
                max = 10,
                precision = 2,
            };

            return Json(container, JsonRequestBehavior.AllowGet);
        }
    
        [HttpGet]
        public ActionResult Select()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new Select()
            {
                name = "basic",
                placeholder = "请选择",
                options = MockSelectData()
            };
            container.Add("basic,", basic);

            var diabled = new Select()
            {
                name = "diabled",
                placeholder = "请选择",
                disabled =true,
                options = MockSelectData()
            };
            container.Add("diabled,", diabled);

            var clearable = new Select()
            {
                name = "clearable",
                placeholder = "请选择",
                clearable = true,
                options = MockSelectData()
            };
            container.Add("clearable,", clearable);

            var multiple = new Select()
            {
                 name = "multiple",
                 multiple = true,
                 placeholder ="请选择",
            };
            container.Add("multiple,", multiple);

            var filterable = new Select()
            {
                name = "filterable",
                filterable = true,
                placeholder = "请选择",
            };
            container.Add("filterable,", filterable);

            var search = new Select()
            {
                name = "search",
                remote = true,
            };
            var autocomplete = new Autocomplete()
            {
                url = "/home/api/getuser",
                remote = true,
                param_list = new List<QueryParam>()
                {
                     new QueryParam(){ name="customer_id",value="1" },
                     new QueryParam(){ name="user_id",value="2"},
                },
                response_formatter = new ResultFormatter()
                {
                    label = new string[] { "user_name" },
                    value = "user_id"
                }
            };
            search.autocomplete = autocomplete;
            container.Add("search,", search);

            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Switch()
        {
            var container = new Dictionary<string, BaseControl>();
            var basic = new Switch()
            {
                name = "value",
                is_checked = true,
            };
            container.Add("basic", basic);

            var desc = new Switch()
            {
                name = "desc",
                active_text = "按月付费",
                inactive_text = "按月付费"
            };
            container.Add("desc", desc);

            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Slider()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new Slider()
            {
                name = "basic",
            };
            container.Add("basic", basic);

            var step = new Slider()
            {
                name = "step",
                step = 10,
                show_stops = true,
            };

            container.Add("step", step);


            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TimePicker()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new DatePicker()
            {
                name = "basic",
                options = new TimeSelect()
                {
                    start = "08:30",
                    step = "00:15",
                    end = "18:30"
                },
                placeholder = "选择时间"
            };
            container.Add("basic", basic);

            var anytime = new DatePicker()
            {
                name = "anytime",
                options = new TimeSelect()
                {
                    selectableRange=new string[] { "18:30:00 - 20:30:00"},                                        
                },
                placeholder ="任意时间点",
            };
            container.Add("anytime", anytime);

            var starttime = new DatePicker()
            {
                name = "starttime",
                options = new TimeSelect()
                {
                    start = "08:30",
                    step = "00:15",
                    end = "18:30",
                },

            };
            container.Add("starttime", starttime);
            var endtime = new DatePicker()
            {
                name = "endtime",
                options = new TimeSelect()
                {
                    start = "08:30",
                    step = "00:15",
                    end = "18:30",
                    minTime = "startTime"
                },
            };
            container.Add("endtime", endtime);

            var range = new DatePicker()
            {
                is_range = true,
                range_separator="至",
                start_placeholder = "开始时间",
                end_placeholder ="结束时间",
                placeholder = "选择时间范围"
            };
            container.Add("range", range);



            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DatePicker()
        {
            var container = new Dictionary<string, BaseControl>();
            var day = new DatePicker()
            {
                name = "day",
                type = DateMode.date,
                placeholder = "选择日期",
            };
            container.Add("day", day);

            var week = new DatePicker()
            {
                name= "week",
                type = DateMode.week,
                format = "yyyy 第 WW 周",
                placeholder = "选择周",
            };
            container.Add("week", week);

            var month = new DatePicker()
            {
                name= "month",
                type = DateMode.month,
                placeholder = "选择月"
            };
            container.Add("month", month);

            var year = new DatePicker()
            {
                type = DateMode.year,
                placeholder = "选择年",
            };
            container.Add("year", year);

            var multiple = new DatePicker()
            {
                name= "multiple",
                type = DateMode.dates,
            };
            container.Add("multiple", multiple);

            var range = new DatePicker()
            {
                name = "range",
                type = DateMode.daterange,
                start_placeholder = "开始日期",
                end_placeholder = "结束日期"
            };
            container.Add("range", range);

            var vauleFormat = new DatePicker()
            {
                name = "vauleFormat",
                type = DateMode.date,
                format = "yyyy 年 MM 月 dd 日",
                value_format = "yyyy-MM-dd"
            };

            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DateTime()
        {
            var container = new Dictionary<string, BaseControl>();

            var basic = new DatePicker()
            {
                name = "basic",
                type = DateMode.datetime,
                placeholder="选择日期时间",
            };
            container.Add("basic", basic);

            var range = new DatePicker()
            {
                name = "range",
                type = DateMode.datetimerange,
                range_separator = "至",
                start_placeholder = "开始日期",
                end_placeholder = "结束日期"
            };
            container.Add("range", range);

            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(IList<BaseControl> controls)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Api(string method)
        {
            if (method == "getuser")
            {
                var list = MockData();
                return Json(list);
            }
            return Json(null);
        }

        private dynamic MockData()
        {
            var user1 = new
            {
                user_name = "abc",
                value = 1,
                user_id = "123",
            };
            var list = Enumerable.Repeat(user1, 5).ToList();
            return user1;
        }

        private List<Option> MockSelectData()
        {
            var data1 = new Option() { value = "选项1", label = "黄金糕" };
            var data2 = new Option() { value = "选项2", label = "双皮奶" };
            var data3 = new Option() { value = "选项3", label = "龙须面" };
            var data4 = new Option() { value = "选项4", label = "北京烤鸭" };
            var data5 = new Option() { value = "选项5", label = "绿豆糕" };
            var list = new List<Option>
            {
                data1,
                data2,
                data3,
                data4,
                data5,
            };
            return list;
        }



    }
}