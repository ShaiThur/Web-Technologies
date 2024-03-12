"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireDefault(require("react"));
var _freeSolidSvgIcons = require("@fortawesome/free-solid-svg-icons");
var _reactFontawesome = require("@fortawesome/react-fontawesome");
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var Post = function Post(props) {
  var stars = [];
  for (var i = 0; i < props.post.countStars; i++) stars.push([/*#__PURE__*/_react.default.createElement(_reactFontawesome.FontAwesomeIcon, {
    icon: _freeSolidSvgIcons.faStar,
    className: "starIcon"
  })]);
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, /*#__PURE__*/_react.default.createElement("div", {
    className: "post"
  }, /*#__PURE__*/_react.default.createElement("div", {
    className: "postContent"
  }, /*#__PURE__*/_react.default.createElement("strong", null, props.post.title), /*#__PURE__*/_react.default.createElement("div", null, "\u0421\u0440\u043E\u043A \u0441\u0434\u0430\u0447\u0438: ", props.post.deadLine)), /*#__PURE__*/_react.default.createElement("div", {
    className: "postHelper"
  }, /*#__PURE__*/_react.default.createElement("div", {
    className: "difficulty"
  }, stars), /*#__PURE__*/_react.default.createElement("button", null, "\u0412\u0437\u044F\u0442\u044C"))));
};
var _default = exports.default = Post;