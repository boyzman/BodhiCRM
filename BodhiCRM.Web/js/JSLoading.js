// 显示读取屏蔽  
function ShowProgressBar() {
    displayProgress();
    displayMaskFrame();
}

// 隐藏读取屏蔽
function HideProgressBar() {
    var progress = $('#divProgress');
    var maskFrame = $("#divMaskFrame");
    progress.hide();
    maskFrame.hide();
}
// 显示读取画面
function displayProgress() {
    var w = $(document).width();
    var h = $(window).height();
    var progress = $('#divProgress');
    progress.css({ "z-index": 999999, "top": (h / 2) - (progress.height() / 2), "left": (w / 2) - (progress.width() / 2) });
    progress.show();
}
// 显示屏蔽画面
function displayMaskFrame() {
    var w = $(window).width();
    var h = $(document).height();
    var maskFrame = $("#divMaskFrame");
    maskFrame.css({ "z-index": 999998, "opacity": 0.7, "width": w, "height": h });
    maskFrame.show();
}
