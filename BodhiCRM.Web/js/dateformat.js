// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2016-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2016-7-2 8:9:4.18 
// 版权所有：卢森科技
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, // 月份  
        "d+": this.getDate(), // 日  
        "h+": this.getHours(), // 小时  
        "m+": this.getMinutes(), // 分  
        "s+": this.getSeconds(), // 秒  
        "q+": Math.floor((this.getMonth() + 3) / 3), // 季度  
        "S": this.getMilliseconds()
        // 毫秒  
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4
                - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1)
                    ? (o[k])
                    : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

Date.prototype.addDays = function (d) {
    this.setDate(this.getDate() + d);
};

Date.prototype.addWeeks = function (w) {
    this.addDays(w * 7);
};

Date.prototype.addMonths = function (m) {
    var d = this.getDate();
    this.setMonth(this.getMonth() + m);

    if (this.getDate() < d)
        this.setDate(0);
};

Date.prototype.addYears = function (y) {
    var m = this.getMonth();
    this.setFullYear(this.getFullYear() + y);

    if (m < this.getMonth()) {
        this.setDate(0);
    }
};

//js格式化时间  
Date.prototype.toDateString = function (formatStr) {
    var date = this;
    var timeValues = function () {
    };
    timeValues.prototype = {
        year: function () {
            if (formatStr.indexOf("yyyy") >= 0) {
                return date.getYear();
            } else {
                return date.getYear().toString().substr(2);
            }
        },
        elseTime: function (val, formatVal) {
            return formatVal >= 0 ? (val < 10 ? "0" + val : val) : (val);
        },
        month: function () {
            return this.elseTime(date.getMonth() + 1, formatStr.indexOf("MM"));
        },
        day: function () {
            return this.elseTime(date.getDate(), formatStr.indexOf("dd"));
        },
        hour: function () {
            return this.elseTime(date.getHours(), formatStr.indexOf("hh"));
        },
        minute: function () {
            return this.elseTime(date.getMinutes(), formatStr.indexOf("mm"));
        },
        second: function () {
            return this.elseTime(date.getSeconds(), formatStr.indexOf("ss"));
        }
    }
    var tV = new timeValues();
    var replaceStr = {
        year: ["yyyy", "yy"],
        month: ["MM", "M"],
        day: ["dd", "d"],
        hour: ["hh", "h"],
        minute: ["mm", "m"],
        second: ["ss", "s"]
    };
    for (var key in replaceStr) {
        formatStr = formatStr.replace(replaceStr[key][0], eval("tV." + key
                + "()"));
        formatStr = formatStr.replace(replaceStr[key][1], eval("tV." + key
                + "()"));
    }
    return formatStr;
}

function formatStrDate(date) {
    var str = date.toDateString("yyyy-MM-dd hh:mm:ss");
    if (str.indexOf("00:00:00") != -1) {
        return str.replace("00:00:00", "10:00:00");
    }
    return str;
}