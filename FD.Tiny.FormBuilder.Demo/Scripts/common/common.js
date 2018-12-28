/**
 * 获取Vm
 */
function getVm() {
    if (typeof (dfIndexVm) !== 'undefined') {
        return dfIndexVm
    } else {
        return dfFormEditVm
    }
}

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

/**
 * 深度克隆对象
 * @param {any} Obj
 */
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

/**
 * 根据值获取属性名称
 * @param {any} obj
 * @param {any} val
 */
function getPropByValue(obj, val) {
    var result = ''
    for (var pro in obj) {
        if (obj[pro] === val) {
            result = pro
        }
    }
    return result
}