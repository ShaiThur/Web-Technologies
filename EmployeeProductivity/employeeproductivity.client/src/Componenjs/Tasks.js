"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireDefault(require("react"));
var _Post = _interopRequireDefault(require("./Post"));
var _PostList = _interopRequireDefault(require("./PostList"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var Tasks = function Tasks(_ref) {
  var posts = _ref.posts;
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, /*#__PURE__*/_react.default.createElement(_PostList.default, {
    posts: posts
  }));
};
var _default = exports.default = Tasks;