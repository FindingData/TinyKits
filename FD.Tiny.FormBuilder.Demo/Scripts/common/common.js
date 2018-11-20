/**
 * 获取homeIndexVm
 */
function getVm() {
    if (typeof (dfIndexVm) !== 'undefined') {
        return dfIndexVm
    } else {
        return dfFormEditVm
    }
}

//==================================message=================================

/**
 * 错误消息提示
    msg:消息内容
 * @param {string} msg
 */
function ErrorMsg(msg) {
    if (getVm() !== null) {
        getVm().$message({
            message: msg,
            type: 'error',
        })
    }
}
/**
 * 普通消息提示
    msg:消息内容
 * @param {string} msg
 */
function InfoMsg(msg) {
    if (getVm() !== null) {
        getVm().$message({
            message: msg,
            type: 'info'
        })
    }
}
/**
 * 警示消息提示
    msg:消息内容
 * @param {string} msg
 */
function WarningMsg(msg) {
    if (getVm() !== null) {
        getVm().$message({
            message: msg,
            type: 'warning'
        })
    }
}
/**
 * 成功消息提示
    msg:消息内容
 * @param {string} msg
 */
function SuccessMsg(msg) {
    if (getVm() !== null) {
        getVm().$message({
            message: msg,
            type: 'success'
        })
    }
}
//批量错误处理弹框
function batchErrorDialogHandle(msg, title) {
    /* msg: 消息内容, title:弹框标题
     * @param { string } msg
     * @param { string } title
    */
    let len = arguments.length;
    if (len === 1) {
        batchErrorDialogHandle_1(getVm(), msg);
    } else if (len === 2) {
        batchErrorDialogHandle(getVm(), msg, title);
    }
}

function batchErrorDialogHandle_1(vm, msg) {
    vm.exportErrorDialog = true;
    setTimeout(() => {
        $('.f-export-error-body', window.parent.document).html(msg);
    }, 0);
}
function batchErrorDialogHandle_2(vm, msg,title) {
    vm.exportErrorDialog = true;
    vm.exportErrorDialogTitle = title;
    setTimeout(() => {
        $('.f-export-error-body', window.parent.document).html(msg);
    },0);
}
//==================================alert=====================================
/**
 * alert弹框
    msg:消息内容,title:弹框标题,confirmFunc:确认回调方法
 * @param {string} msg
 * @param {string} title
 * @param {function} confirmFunc
 */
function alertHandle(msg, title, confirmFunc) {
    let len = arguments.length;
    if (len === 1) {
        alertHandle_1(getVm(), msg)
    } else if (len === 2) {
        alertHandle_2(getVm(), msg, title)
    } else if (len === 3) {
        alertHandle_3(getVm(), msg, title, confirmFunc)
    }
}

function alertHandle_1(vm, msg) {
    vm.$alert(msg, '提示', {
        showConfirmButton: false,
        customClass: 'f-alert-dialog'
    })
    
}

function alertHandle_2(vm, msg,title) {
    vm.$alert(msg, title, {
        showConfirmButton: false,
    })
}

function alertHandle_3(vm, msg, title,confirmFunc) {
    vm.$alert(msg, title, {
        confirmButtonText: '确定',
    }).then(
        confirm => {
            confirmFunc()
        }
        )
}



//==================================confirm=================================
/**
 * confirm弹框
    msg:消息内容,confirmFunc:确认回调方法,title:弹框标题,config:确定、取消按钮文字我类型配置,cancelFunc:取消回调方法
 * @param {string} msg
 * @param {function} confirmFunc
 * @param {string} title
 * @param {object} config
 * @param {function} cancelFunc
 */
var confirmType={info:'icon-info',warn:'icon-warning',help:'icon-yiwen'}
function confirmHandle( msg, confirmFunc, title, config, cancelFunc) {
    let len = arguments.length
    if (len === 2) {
        confirmHandle_1(getVm(), msg, confirmFunc)
    } else if (len === 3) {
        confirmHandle_2(getVm(), msg, confirmFunc, title)
    } else if (len === 4) {
        confirmHandle_3(getVm(), msg, confirmFunc, title, config)
    } else if (len === 5) {
        confirmHandle_4(getVm(), msg, confirmFunc, title, config, cancelFunc)
    }

}

function confirmHandle_1(vm, msg, confirmFunc) {
    console.log('confirmvm',vm)
    const h = vm.$createElement
    vm.$confirm(
        h('div', { class: ['f-confirm-dialog'] }, [
            h('i', { class: ['iconfont', confirmType[msg.type]] }, ''),
            h('span', {class:['f-confirm-dialog-message']}, msg.message)
        ]),
        '提示',
        {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            closeOnClickModal:false
        }
    ).then(
        confirm => {
            confirmFunc()
        }
    ).catch(
        cancel => {
        }
        )
}

function confirmHandle_2(vm, msg, confirmFunc, title) {
    const h = vm.$createElement
    vm.$confirm(
        h('div', { class: ['f-confirm-dialog'] }, [
            h('i', { class: ['iconfont', confirmType[msg.type]] }, ''),
            h('span', { class: ['f-confirm-dialog-message'] }, msg.message)
        ]),
        title,
        {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            closeOnClickModal: false
        }
    ).then(
        confirm => {
            confirmFunc()
        }
    ).catch(
        cancel => {
        }
        )
}

function confirmHandle_3(vm, msg, confirmFunc, title, config) {
    const h = vm.$createElement
    vm.$confirm(
        h('div', {class:['f-confirm-dialog']}, [
            h('i', { class: ['iconfont', confirmType[msg.type]] }, ''),
            h('span', { class: ['f-confirm-dialog-message'] }, msg.message)
        ]),
        title,
        config
    ).then(
        confirm => {
            confirmFunc()
        }
    ).catch(
        cancel => {
        }
        )
}

function confirmHandle_4(vm, msg, confirmFunc, title, config, cancelFunc) {
    const h = vm.$createElement
    vm.$confirm(
        h('div', { class: ['f-confirm-dialog'] }, [
            h('i', { class: ['iconfont', confirmType[msg.type]] }, ''),
            h('span', { class: ['f-confirm-dialog-message'] }, msg.message)
        ]),
        title,
        config
    ).then(
        confirm => {
            confirmFunc()
        }
    ).catch(
        cancel => {
            cancelFunc()
        }
        )
}


/** 
 * 获取当前时间 格式：yyyy-MM-dd HH:MM:SS 
 */
function getCurrentTime() {
    var date = new Date();//当前时间  
    var month = zeroFill(date.getMonth() + 1);//月  
    var day = zeroFill(date.getDate());//日  
    var hour = zeroFill(date.getHours());//时  
    var minute = zeroFill(date.getMinutes());//分  
    var second = zeroFill(date.getSeconds());//秒  

    //当前时间  
    var curTime = date.getFullYear() + "-" + month + "-" + day
        + " " + hour + ":" + minute + ":" + second;

    return curTime;
}
/** 
 * 补零 
 */
function zeroFill(i) {
    if (i >= 0 && i <= 9) {
        return "0" + i;
    } else {
        return i;
    }
}

//深度克隆对象
function clone(Obj) {
    var buf;
    if (Obj instanceof Array) {
        buf = [];  // 创建一个空的数组
        var i = Obj.length;
        while (i--) {
            buf[i] = clone(Obj[i]);
        }
        return buf;
    } else if (Obj instanceof Object) {
        buf = {};  // 创建一个空对象
        for (var k in Obj) {  // 为这个对象添加新的属性
            buf[k] = clone(Obj[k]);
        }
        return buf;
    } else {
        return Obj;
    }
}
/**
 * 获取url参数
 * @param {any} paramName
 */
function getParam(paramName) {
    paramValue = "", isFound = !1;
    if (location.search.indexOf("?") == 0 && location.search.indexOf("=") > 1) {
        arrSource = unescape(location.search).substring(1, location.search.length).split("&"), i = 0;
        while (i < arrSource.length && !isFound) arrSource[i].indexOf("=") > 0 && arrSource[i].split("=")[0].toLowerCase() == paramName.toLowerCase() && (paramValue = arrSource[i].split("=")[1], isFound = !0), i++
    }
    return paramValue == "" && (paramValue = null), paramValue
}
/**
 * 获取浏览器高度
*/
function getClientHeight() {
    return document.documentElement.clientHeight
}

/**
 * 获取dialog内容scroll高度
 * */
function getDialogScrollHeight() {
    return (1 - 0.15) * getClientHeight() - 50 - 54 - 60
}