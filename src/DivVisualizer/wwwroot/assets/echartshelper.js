function onResizeHandler() {
    if (window.echartsFunctions && window.echartsFunctions.map) {
        for (const [key, value] of window.echartsFunctions.map.entries()) {
            window.echartsFunctions.getChart(key).resize();
        }
    }
}

var doit;
window.onresize = function () {
    clearTimeout(doit);
    doit = setTimeout(onResizeHandler, 100);
};