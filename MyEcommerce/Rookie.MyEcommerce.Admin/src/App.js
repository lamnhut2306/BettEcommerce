import { BrowserRouter, Route, Switch } from "react-router-dom";
import "./App.css";
import CallbackPage from "./pages/CallbackPage";
import CategoryPage from "./pages/CategoryPage";
import OrderPage from "./pages/OrderPage";
import ProductPage from "./pages/ProductPage";
import { connect } from "react-redux";
import LoginPage from "./pages/LoginPage";

function App(props) {
  return (
    <BrowserRouter>
      <Switch>
        {props.isAuthenticated && <Route exact={true} path="/Product" component={ProductPage}></Route>}
        {props.isAuthenticated && <Route exact={true} path="/Order" component={OrderPage}></Route>}
        {props.isAuthenticated && <Route exact={true} path="" component={CategoryPage}></Route>}
        <Route exact={false} path="/callback" component={CallbackPage}></Route>
        {!props.isAuthenticated && <Route exact={true} path="" component={LoginPage}></Route>}
      </Switch>
    </BrowserRouter>
  );
}

function mapStateToProps(state) {
  return {
    user: state.oidc.user,
    isAuthenticated: state.oidc.user && !state.oidc.user.expired,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    dispatch,
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(App);
