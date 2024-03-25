"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var _react = require("react");
var _reactRouterDom = require("react-router-dom");
var SignIn = function SignIn(_ref) {
  var setShowSignUpForm = _ref.setShowSignUpForm;
  var inputEmail = (0, _react.useRef)(null);
  var inputPassword = (0, _react.useRef)(null);
  var navigate = (0, _reactRouterDom.useNavigate)();
  var OpenWorkZone = function OpenWorkZone(id) {
    if (inputEmail.current.value != "" && inputPassword.current.value != "") {
      navigate("/workzone/".concat(id));
    } else {
      window.alert('Enter email and password');
    }
  };
  return /*#__PURE__*/React.createElement("div", {
    className: "container"
  }, /*#__PURE__*/React.createElement("h1", null, "Sign In"), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Email",
    ref: inputEmail
  }), /*#__PURE__*/React.createElement("input", {
    type: "password",
    placeholder: "Password",
    ref: inputPassword
  }), /*#__PURE__*/React.createElement("div", {
    className: "remindPass"
  }, /*#__PURE__*/React.createElement("a", {
    href: ""
  }, "Forgot password?")), /*#__PURE__*/React.createElement("div", {
    className: "signInButton signInButton1"
  }, /*#__PURE__*/React.createElement("button", {
    onClick: function onClick() {
      return OpenWorkZone(inputEmail.current.value);
    }
  }, "Sign in")), /*#__PURE__*/React.createElement("div", {
    className: "forButtonSwitch"
  }, /*#__PURE__*/React.createElement("button", {
    onClick: function onClick() {
      return setShowSignUpForm(true);
    },
    className: "buttonSwitch"
  }, "Or sign up?")));
};
var _default = exports.default = SignIn;