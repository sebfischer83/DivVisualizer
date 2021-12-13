var jsInteropClass = {
    dotnetReferences: new Map(),
    setReference: function (id, dotnetReference) {
        this.dotnetReferences.set(id, dotnetReference);
        console.log(dotnetReference);
    },
    callFunction: function (id, name, params) {
        let ref = this.dotnetReferences.get(id);
        let res = undefined;
        res = ref.invokeMethodAsync("Execute", name, params).then(x => res = x);
        return res;
    },
    setProperty: function (name, json) {
        window[name] = JSON.parse(json);
    }
};

window.divInterop = window.divInterop || jsInteropClass;
