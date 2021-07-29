import React from "react";
import { CallbackComponent } from "redux-oidc";
import userManager from "../utils/UserManager";
import { useHistory } from "react-router";
import { connect } from "react-redux";

function CallbackPage(props) {
  const history = useHistory();
  return (
    <CallbackComponent
      userManager={userManager}
      successCallback={(res) => {
        localStorage.setItem("access_token", res.access_token);
        userManager.signinRedirectCallback({response_mode:"query"}).then(history.push(""));
      }}
      errorCallback={(error) => history.push("")}
    >
      <div>Redirecting...</div>
    </CallbackComponent>
  );
}

export default connect()(CallbackPage);
