"use strict";

function _typeof(o) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && "function" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? "symbol" : typeof o; }, _typeof(o); }
var _react = _interopRequireDefault(require("react"));
var ReactDOM = _interopRequireWildcard(require("react-dom/client"));
var _App = _interopRequireDefault(require("./App.tsx"));
require("./index.css");
var _reactRouterDom = require("react-router-dom");
var _ErrorPage = _interopRequireDefault(require("./Components/ErrorPage.tsx"));
var _WorkZone = _interopRequireDefault(require("./Components/WorkZone"));
function _getRequireWildcardCache(e) { if ("function" != typeof WeakMap) return null; var r = new WeakMap(), t = new WeakMap(); return (_getRequireWildcardCache = function _getRequireWildcardCache(e) { return e ? t : r; })(e); }
function _interopRequireWildcard(e, r) { if (!r && e && e.__esModule) return e; if (null === e || "object" != _typeof(e) && "function" != typeof e) return { default: e }; var t = _getRequireWildcardCache(r); if (t && t.has(e)) return t.get(e); var n = { __proto__: null }, a = Object.defineProperty && Object.getOwnPropertyDescriptor; for (var u in e) if ("default" !== u && Object.prototype.hasOwnProperty.call(e, u)) { var i = a ? Object.getOwnPropertyDescriptor(e, u) : null; i && (i.get || i.set) ? Object.defineProperty(n, u, i) : n[u] = e[u]; } return n.default = e, t && t.set(e, n), n; }
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
var router = (0, _reactRouterDom.createBrowserRouter)([{
  path: "*",
  element: /*#__PURE__*/_react.default.createElement(_App.default, null),
  errorElement: /*#__PURE__*/_react.default.createElement(_ErrorPage.default, null)
}, {
  path: "/workzone/:id",
  element: /*#__PURE__*/_react.default.createElement(_WorkZone.default, null)
}]);
ReactDOM.createRoot(document.getElementById('root')).render( /*#__PURE__*/_react.default.createElement(_react.default.StrictMode, null, /*#__PURE__*/_react.default.createElement(_reactRouterDom.RouterProvider, {
  router: router
})));