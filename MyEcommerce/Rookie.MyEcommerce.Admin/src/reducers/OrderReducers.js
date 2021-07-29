import {
  OrderListFail,
  OrderListRequest,
  OrderListSuccess,
} from "../constants/OrderConstants";

function orderListReducer(state = { orders: [] }, action) {
  switch (action.type) {
    case OrderListRequest:
      return { loading: true, orders: [] };
    case OrderListSuccess:
      return { loading: false, orders: action.payload };
    case OrderListFail:
      return { loading: false, orders: action.payload };
    default:
      return state;
  }
}

export { orderListReducer };
