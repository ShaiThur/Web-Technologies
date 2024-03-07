"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var SignIn = function SignIn(_ref) {
  var setShowSignUpForm = _ref.setShowSignUpForm,
    setShowWorkZone = _ref.setShowWorkZone;
  return /*#__PURE__*/React.createElement("div", {
    className: "container"
  }, /*#__PURE__*/React.createElement("h1", null, "Sign In"), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Email"
  }), /*#__PURE__*/React.createElement("input", {
    type: "password",
    placeholder: "Password"
  }), /*#__PURE__*/React.createElement("div", {
    className: "remindPass"
  }, /*#__PURE__*/React.createElement("a", {
    href: ""
  }, "Forgot password?")), /*#__PURE__*/React.createElement("div", {
    className: "signInButton signInButton1"
  }, /*#__PURE__*/React.createElement("button", {
    onClick: function onClick() {
      return setShowWorkZone(true);
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