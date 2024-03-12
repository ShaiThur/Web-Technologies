"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireDefault(require("react"));
var _Post = _interopRequireDefault(require("./Post"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var PostList = function PostList(_ref) {
  var posts = _ref.posts;
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, posts.map(function (post) {
    return /*#__PURE__*/_react.default.createElement(_Post.default, {
      post: post
    });
  }));
};
var _default = exports.default = PostList;