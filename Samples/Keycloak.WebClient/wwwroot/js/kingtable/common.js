(function () {
    /*
    var a = document.getElementById("theme");
    a.addEventListener("change", function (e) {
        var v = a.value;
        document.body.className = v;
    }, true);
    */
    
    var b = document.getElementById("plain-controls");
    if (b) {
        var events = {
            "click next": function () {
                table.pagination.next();
            },
            "click prev": function () {
                table.pagination.prev();
            },
            "click first": function () {
                table.pagination.first();
            },
            "click last": function () {
                table.pagination.last();
            },
            "click refresh": function () {
            	alert("refresh'e tıklandı. (common.js'e bak ;))");
                table.refresh();
            }
        };
        var x, c;
        for (x in events) {
            var c = x.split(/\s/);
            document.getElementById(c[1]).addEventListener(c[0], events[x], true);
        }
    }
})();