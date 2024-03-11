"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
require("./App.css");
require("../src/Css/mainStyles.css");
var _Form = _interopRequireDefault(require("./Components/Form"));
var _react = require("react");
var _WorkZone = _interopRequireDefault(require("./Components/WorkZone"));
var _backgrimage = _interopRequireDefault(require("../src/images/backgrimage.jpg"));
var _workzone_backgrimage = _interopRequireDefault(require("../src/images/workzone_backgrimage.jpg"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
function _slicedToArray(arr, i) { return _arrayWithHoles(arr) || _iterableToArrayLimit(arr, i) || _unsupportedIterableToArray(arr, i) || _nonIterableRest(); }
function _nonIterableRest() { throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }
function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }
function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) arr2[i] = arr[i]; return arr2; }
function _iterableToArrayLimit(r, l) { var t = null == r ? null : "undefined" != typeof Symbol && r[Symbol.iterator] || r["@@iterator"]; if (null != t) { var e, n, i, u, a = [], f = !0, o = !1; try { if (i = (t = t.call(r)).next, 0 === l) { if (Object(t) !== t) return; f = !1; } else for (; !(f = (e = i.call(t)).done) && (a.push(e.value), a.length !== l); f = !0); } catch (r) { o = !0, n = r; } finally { try { if (!f && null != t.return && (u = t.return(), Object(u) !== u)) return; } finally { if (o) throw n; } } return a; } }
function _arrayWithHoles(arr) { if (Array.isArray(arr)) return arr; }
function App() {
  var _useState = (0, _react.useState)(false),
    _useState2 = _slicedToArray(_useState, 2),
    showWorkZone = _useState2[0],
    setShowWorkZone = _useState2[1];
  return /*#__PURE__*/React.createElement("div", null, /*#__PURE__*/React.createElement("div", {
    className: "backimage",
    style: showWorkZone ? {
      backgroundImage: "url(".concat(_workzone_backgrimage.default, ")")
    } : {
      backgroundImage: "url(".concat(_backgrimage.default, ")")
    }
  }, /*#__PURE__*/React.createElement("div", {
    style: {
      width: "".concat(100, "%"),
      height: "".concat(100, "%"),
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center'
    }
  }, showWorkZone ? /*#__PURE__*/React.createElement(_WorkZone.default, null) : /*#__PURE__*/React.createElement(_Form.default, {
    setShowWorkZone: setShowWorkZone
  }))));
}
var _default = exports.default = App;