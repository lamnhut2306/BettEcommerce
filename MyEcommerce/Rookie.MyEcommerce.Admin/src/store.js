import {
  applyMiddleware,
  combineReducers,
  compose,
  createStore,
} from "@reduxjs/toolkit";
import {
  categoryListReducer,
  categorySaveReducer,
  categoryDeleteReducer,
  categoryDetailReducer,
} from "./reducers/CategoryReducers";
import thunk from "redux-thunk";
import {
  productDeleteReducer,
  productDetailReducer,
  productListReducer,
  productSaveReducer,
} from "./reducers/ProductReducers";
import { orderListReducer } from "./reducers/OrderReducers";
import createOidcMiddleware from "redux-oidc";
import { routerMiddleware, routerReducer } from "react-router-redux";
import userManager from "./utils/UserManager";
import { createBrowserHistory } from "history";
import { reducer as oidcReducer } from "redux-oidc";
import { loadUser } from "redux-oidc";

const history = createBrowserHistory({ basename: 'http://localhost:3000' });

const oidcMiddleware = createOidcMiddleware(userManager);
const middleware = [thunk, routerMiddleware(history), oidcMiddleware]

const reducers = combineReducers({
  categoryList: categoryListReducer,
  categorySave: categorySaveReducer,
  categoryDelete: categoryDeleteReducer,
  categoryDetail: categoryDetailReducer,
  productList: productListReducer,
  productSave: productSaveReducer,
  productDelete: productDeleteReducer,
  productDetail: productDetailReducer,
  orderList: orderListReducer,
  oidc: oidcReducer,
  routing: routerReducer
});

const store = createStore(reducers, window.initialReduxState ,compose(applyMiddleware(...middleware)));
loadUser(store, userManager);


export {
  store,
  history
};