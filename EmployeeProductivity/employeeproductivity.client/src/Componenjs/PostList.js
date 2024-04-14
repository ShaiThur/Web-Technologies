"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = _interopRequireDefault(require("react"));
var _Post = _interopRequireDefault(require("./Post"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var PostList = function PostList(_ref) {
  var posts = _ref.posts,
    nameOfOption = _ref.nameOfOption;
  return /*#__PURE__*/_react.default.createElement(_react.default.Fragment, null, posts.length == 0 ? null : posts.map(function (post) {
    return /*#__PURE__*/_react.default.createElement(_Post.default, {
      nameOfOption: nameOfOption,
      post: post,
      key: post.id
    });
  }));
};
var _default = exports.default = PostList;