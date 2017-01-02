"use strict";
var Product = (function () {
    function Product() {
    }
    return Product;
}());
exports.Product = Product;
var Discriminator;
(function (Discriminator) {
    Discriminator[Discriminator["unKnown"] = 0] = "unKnown";
    Discriminator[Discriminator["Laptop"] = 1] = "Laptop";
    Discriminator[Discriminator["Phone"] = 2] = "Phone";
})(Discriminator || (Discriminator = {}));
var ConditionType;
(function (ConditionType) {
    ConditionType[ConditionType["unKnown"] = 0] = "unKnown";
    ConditionType[ConditionType["New"] = 1] = "New";
    ConditionType[ConditionType["Used"] = 2] = "Used";
    ConditionType[ConditionType["Refurbished"] = 3] = "Refurbished";
})(ConditionType || (ConditionType = {}));
var ProcessorType;
(function (ProcessorType) {
    ProcessorType[ProcessorType["unKnown"] = 0] = "unKnown";
    ProcessorType[ProcessorType["IntelI5"] = 1] = "IntelI5";
    ProcessorType[ProcessorType["IntelI3"] = 2] = "IntelI3";
    ProcessorType[ProcessorType["IntelI7"] = 3] = "IntelI7";
    ProcessorType[ProcessorType["AMD"] = 4] = "AMD";
})(ProcessorType || (ProcessorType = {}));
var HardDriveType;
(function (HardDriveType) {
    HardDriveType[HardDriveType["unKnown"] = 0] = "unKnown";
    HardDriveType[HardDriveType["HHD"] = 1] = "HHD";
    HardDriveType[HardDriveType["SSD"] = 2] = "SSD";
    HardDriveType[HardDriveType["Hybrid"] = 3] = "Hybrid";
})(HardDriveType || (HardDriveType = {}));
//# sourceMappingURL=Product.model.js.map