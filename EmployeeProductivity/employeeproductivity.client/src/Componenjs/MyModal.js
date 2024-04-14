"use strict";

function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _process = require("process");
var _react = _interopRequireWildcard(require("react"));
var _uuid = require("uuid");
function _getRequireWildcardCache(e) { if ("function" != typeof WeakMap) return null; var r = new WeakMap(), t = new WeakMap(); return (_getRequireWildcardCache = function _getRequireWildcardCache(e) { return e ? t : r; })(e); }
function _interopRequireWildcard(e, r) { if (!r && e && e.__esModule) return e; if (null === e || "object" != _typeof(e) && "function" != typeof e) return { default: e }; var t = _getRequireWildcardCache(r); if (t && t.has(e)) return t.get(e); var n = { __proto__: null }, a = Object.defineProperty && Object.getOwnPropertyDescriptor; for (var u in e) if ("default" !== u && {}.hasOwnProperty.call(e, u)) { var i = a ? Object.getOwnPropertyDescriptor(e, u) : null; i && (i.get || i.set) ? Object.defineProperty(n, u, i) : n[u] = e[u]; } return n.default = e, t && t.set(e, n), n; }
function _toConsumableArray(arr) { return _arrayWithoutHoles(arr) || _iterableToArray(arr) || _unsupportedIterableToArray(arr) || _nonIterableSpread(); }
function _nonIterableSpread() { throw new TypeError("Invalid attempt to spread non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }
function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }
function _iterableToArray(iter) { if (typeof Symbol !== "undefined" && iter[Symbol.iterator] != null || iter["@@iterator"] != null) return Array.from(iter); }
function _arrayWithoutHoles(arr) { if (Array.isArray(arr)) return _arrayLikeToArray(arr); }
function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) arr2[i] = arr[i]; return arr2; }
var MyModal = function MyModal(_ref) {
  var posts = _ref.posts,
    setNewPost = _ref.setNewPost;
  var title = (0, _react.useRef)(null);
  var date = (0, _react.useRef)(null);
  var difficult = (0, _react.useRef)(null);
  var description = (0, _react.useRef)(null);
  var AddPost = function AddPost() {
    if (title.current.value != "" && date.current.value != "" && difficult.current.value != "" && difficult.current.value <= 3 && difficult.current.value > 0 && description.current.value != "") {
      var newPost = {
        id: Date.now(),
        title: title.current.value.toString(),
        deadLine: date.current.value.toString(),
        countStars: difficult.current.value.toString(),
        description: description.current.value.toString()
      };
      setNewPost([].concat(_toConsumableArray(posts), [newPost]));
      title.current.value = "";
      date.current.value = "";
      difficult.current.value = "";
      description.current.value = "";
    } else {
      window.alert('Fill all in form!');
    }
  };
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, /*#__PURE__*/_react.default.createElement("div", {
    className: "modalContent"
  }, /*#__PURE__*/_react.default.createElement("form", {
    action: "",
    className: "modalForm"
  }, /*#__PURE__*/_react.default.createElement("input", {
    type: "text",
    placeholder: "Enter title",
    ref: title
  }), /*#__PURE__*/_react.default.createElement("textarea", {
    name: "description",
    cols: "30",
    rows: "10",
    placeholder: "Enter description",
    ref: description
  }), /*#__PURE__*/_react.default.createElement("input", {
    type: "number",
    max: "3",
    min: "1",
    ref: difficult,
    placeholder: "Enter difficult"
  }), /*#__PURE__*/_react.default.createElement("input", {
    type: "date",
    ref: date
  })), /*#__PURE__*/_react.default.createElement("div", {
    className: "addTaskButton",
    onClick: function onClick() {
      return AddPost();
    }
  }, /*#__PURE__*/_react.default.createElement("button", null, "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C"))));
};
var _default = exports.default = MyModal;