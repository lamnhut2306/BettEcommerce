import {
  OrderListFail,
  OrderListRequest,
  OrderListSuccess,
} from "../constants/OrderConstants";
import { OrderService } from "../services/OrderService";

export const ListOrders = () => async (dispatch) => {
  try {
    dispatch({ type: OrderListRequest });
    const data = await OrderService.getAll();
    dispatch({ type: OrderListSuccess, payload: data });
  } catch (error) {
    dispatch({ type: OrderListFail, payload: error.message });
  }
};
