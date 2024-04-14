"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = require("react");
var _SelectCompany = _interopRequireDefault(require("./SelectCompany"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
function _slicedToArray(arr, i) { return _arrayWithHoles(arr) || _iterableToArrayLimit(arr, i) || _unsupportedIterableToArray(arr, i) || _nonIterableRest(); }
function _nonIterableRest() { throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }
function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }
function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) arr2[i] = arr[i]; return arr2; }
function _iterableToArrayLimit(r, l) { var t = null == r ? null : "undefined" != typeof Symbol && r[Symbol.iterator] || r["@@iterator"]; if (null != t) { var e, n, i, u, a = [], f = !0, o = !1; try { if (i = (t = t.call(r)).next, 0 === l) { if (Object(t) !== t) return; f = !1; } else for (; !(f = (e = i.call(t)).done) && (a.push(e.value), a.length !== l); f = !0); } catch (r) { o = !0, n = r; } finally { try { if (!f && null != t.return && (u = t.return(), Object(u) !== u)) return; } finally { if (o) throw n; } } return a; } }
function _arrayWithHoles(arr) { if (Array.isArray(arr)) return arr; }
var SignUp = function SignUp(_ref) {
  var setShowSignUpForm = _ref.setShowSignUpForm;
  var checkDirector = (0, _react.useRef)(null);
  var _useState = (0, _react.useState)(false),
    _useState2 = _slicedToArray(_useState, 2),
    showCompanyInput = _useState2[0],
    setShowCompanyInput = _useState2[1];
  var handleCheckboxChange = function handleCheckboxChange() {
    setShowCompanyInput(checkDirector.current.checked);
  };
  return /*#__PURE__*/React.createElement("div", {
    className: "container"
  }, /*#__PURE__*/React.createElement("h1", null, "Sign Up"), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "First name"
  }), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Last name"
  }), showCompanyInput ? /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Enter company(name, city)"
  }) : /*#__PURE__*/React.createElement(_SelectCompany.default, null), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Email"
  }), /*#__PURE__*/React.createElement("input", {
    type: "password",
    placeholder: "Password"
  }), /*#__PURE__*/React.createElement("div", {
    className: "checkbox"
  }, /*#__PURE__*/React.createElement("input", {
    type: "checkbox",
    ref: checkDirector,
    onChange: handleCheckboxChange
  }), /*#__PURE__*/React.createElement("p", null, "I'm director")), /*#__PURE__*/React.createElement("div", {
    className: "signButton"
  }, /*#__PURE__*/React.createElement("button", null, "Sign up")), /*#__PURE__*/React.createElement("div", {
    className: "forButtonSwitch"
  }, /*#__PURE__*/React.createElement("button", {
    onClick: function onClick() {
      return setShowSignUpForm(false);
    },
    className: "buttonSwitch"
  }, "Or sign in?")));
};
var _default = exports.default = SignUp;