"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;
var SignUp = function SignUp(_ref) {
  var setShowSignUpForm = _ref.setShowSignUpForm;
  return /*#__PURE__*/React.createElement("div", {
    className: "container"
  }, /*#__PURE__*/React.createElement("h1", null, "Sign Up"), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "First name"
  }), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Middle name"
  }), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Last name"
  }), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Email"
  }), /*#__PURE__*/React.createElement("input", {
    type: "text",
    placeholder: "Password"
  }), /*#__PURE__*/React.createElement("div", {
    className: "signInButton"
  }, /*#__PURE__*/React.createElement("button", null, "Sign in")), /*#__PURE__*/React.createElement("div", {
    className: "forButtonSwitch"
  }, /*#__PURE__*/React.createElement("button", {
    onClick: function onClick() {
      return setShowSignUpForm(false);
    },
    className: "buttonSwitch"
  }, "Or sign up?")));
};
var _default = exports.default = SignUp;