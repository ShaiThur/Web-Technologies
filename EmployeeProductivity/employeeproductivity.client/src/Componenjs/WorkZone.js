"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _freeSolidSvgIcons = require("@fortawesome/free-solid-svg-icons");
var _reactFontawesome = require("@fortawesome/react-fontawesome");
require("../Css/workZone.css");
var _react = require("react");
var _Post = _interopRequireDefault(require("./Post"));
var _Tasks = _interopRequireDefault(require("./Tasks"));
var _OffersTask = _interopRequireDefault(require("./OffersTask"));
var _StatisticForOne = _interopRequireDefault(require("./StatisticForOne"));
var _reactRouterDom = require("react-router-dom");
var _Employees = _interopRequireDefault(require("./Employees"));
var _AllStatistic = _interopRequireDefault(require("./AllStatistic"));
function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
function _slicedToArray(arr, i) { return _arrayWithHoles(arr) || _iterableToArrayLimit(arr, i) || _unsupportedIterableToArray(arr, i) || _nonIterableRest(); }
function _nonIterableRest() { throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }
function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }
function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) arr2[i] = arr[i]; return arr2; }
function _iterableToArrayLimit(r, l) { var t = null == r ? null : "undefined" != typeof Symbol && r[Symbol.iterator] || r["@@iterator"]; if (null != t) { var e, n, i, u, a = [], f = !0, o = !1; try { if (i = (t = t.call(r)).next, 0 === l) { if (Object(t) !== t) return; f = !1; } else for (; !(f = (e = i.call(t)).done) && (a.push(e.value), a.length !== l); f = !0); } catch (r) { o = !0, n = r; } finally { try { if (!f && null != t.return && (u = t.return(), Object(u) !== u)) return; } finally { if (o) throw n; } } return a; } }
function _arrayWithHoles(arr) { if (Array.isArray(arr)) return arr; }
var WorkZone = function WorkZone() {
  var _useState = (0, _react.useState)('Задачи'),
    _useState2 = _slicedToArray(_useState, 2),
    nameLabel = _useState2[0],
    setNameLabel = _useState2[1];
  var _useState3 = (0, _react.useState)('button1'),
    _useState4 = _slicedToArray(_useState3, 2),
    activeButton = _useState4[0],
    setActiveButton = _useState4[1];
  var navigate = (0, _reactRouterDom.useNavigate)();
  var id = (0, _reactRouterDom.useParams)();
  var _id$id$split = id.id.split(";"),
    _id$id$split2 = _slicedToArray(_id$id$split, 2),
    name = _id$id$split2[0],
    typeOfUser = _id$id$split2[1];
  var ChangePage = function ChangePage(nameLabel, buttonName) {
    setActiveButton(buttonName);
    setNameLabel(nameLabel);
  };
  var Exit = function Exit() {
    navigate("/");
  };
  return /*#__PURE__*/React.createElement("div", {
    className: "mainViewWork"
  }, typeOfUser == "director" ? /*#__PURE__*/React.createElement("div", {
    className: "workzone"
  }, /*#__PURE__*/React.createElement("div", {
    className: "header"
  }, /*#__PURE__*/React.createElement("div", {
    className: "headerContents"
  }, /*#__PURE__*/React.createElement("label", {
    htmlFor: ""
  }, name), /*#__PURE__*/React.createElement("button", {
    className: 'exitIcon',
    onClick: function onClick() {
      return Exit();
    }
  }, /*#__PURE__*/React.createElement(_reactFontawesome.FontAwesomeIcon, {
    icon: _freeSolidSvgIcons.faRightToBracket
  }))), /*#__PURE__*/React.createElement("label", {
    id: 'tasks'
  }, nameLabel), /*#__PURE__*/React.createElement("div", {
    className: 'tabs'
  }, /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button1' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Задачи', 'button1');
    }
  }, "\u0417\u0430\u0434\u0430\u0447\u0438"), /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button2' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Работники', 'button2');
    }
  }, "\u0420\u0430\u0431\u043E\u0442\u043D\u0438\u043A\u0438"), /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button3' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Статистика', 'button3');
    }
  }, "\u0421\u0442\u0430\u0442\u0438\u0441\u0442\u0438\u043A\u0430"))), /*#__PURE__*/React.createElement("div", {
    className: "body"
  }, nameLabel == 'Задачи' ? /*#__PURE__*/React.createElement(_Tasks.default, null) : nameLabel == 'Работники' ? /*#__PURE__*/React.createElement(_Employees.default, null) : /*#__PURE__*/React.createElement(_AllStatistic.default, null))) : /*#__PURE__*/React.createElement("div", {
    className: "workzone"
  }, /*#__PURE__*/React.createElement("div", {
    className: "header"
  }, /*#__PURE__*/React.createElement("div", {
    className: "headerContents"
  }, /*#__PURE__*/React.createElement("label", {
    htmlFor: ""
  }, name), /*#__PURE__*/React.createElement("button", {
    className: 'exitIcon',
    onClick: function onClick() {
      return Exit();
    }
  }, /*#__PURE__*/React.createElement(_reactFontawesome.FontAwesomeIcon, {
    icon: _freeSolidSvgIcons.faRightToBracket
  }))), /*#__PURE__*/React.createElement("label", {
    id: 'tasks'
  }, nameLabel), /*#__PURE__*/React.createElement("div", {
    className: 'tabs'
  }, /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button1' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Задачи', 'button1');
    }
  }, "\u0417\u0430\u0434\u0430\u0447\u0438"), /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button2' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Предложенные задания', 'button2');
    }
  }, "\u041F\u0440\u0435\u0434\u043B\u043E\u0436\u0435\u043D\u043D\u044B\u0435"), /*#__PURE__*/React.createElement("button", {
    className: 'tabsButtons',
    id: activeButton == 'button3' ? 'activeButton' : '',
    onClick: function onClick() {
      return ChangePage('Статистика', 'button3');
    }
  }, "\u0421\u0442\u0430\u0442\u0438\u0441\u0442\u0438\u043A\u0430"))), /*#__PURE__*/React.createElement("div", {
    className: "body"
  }, nameLabel == 'Задачи' ? /*#__PURE__*/React.createElement(_Tasks.default, null) : nameLabel == 'Предложенные задания' ? /*#__PURE__*/React.createElement(_OffersTask.default, null) : /*#__PURE__*/React.createElement(_StatisticForOne.default, null))));
};
var _default = exports.default = WorkZone;