"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireDefault(require("react"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var MyModalView = function MyModalView(_ref) {
  var title = _ref.title,
    description = _ref.description,
    date = _ref.date;
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, /*#__PURE__*/_react.default.createElement("div", {
    className: "modalContent"
  }, /*#__PURE__*/_react.default.createElement("form", {
    action: "",
    className: "modalForm"
  }, /*#__PURE__*/_react.default.createElement("input", {
    type: "text",
    placeholder: "Enter title",
    value: title
  }), /*#__PURE__*/_react.default.createElement("textarea", {
    name: "description",
    cols: "30",
    rows: "10",
    placeholder: "Enter description",
    value: description
  }), /*#__PURE__*/_react.default.createElement("input", {
    type: "date",
    value: date
  }))));
};
var _default = exports.default = MyModalView;