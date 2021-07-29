import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import "bootstrap/dist/css/bootstrap.min.css";
import { Provider } from "react-redux";
import { OidcProvider } from "redux-oidc";
import { store } from "./store";
import userManager from "./utils/UserManager";

ReactDOM.render(
  <Provider store={store}>
    <OidcProvider userManager={userManager} store={store}>
        <React.StrictMode store={store}>
          <App />
        </React.StrictMode>
    </OidcProvider>
  </Provider>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
