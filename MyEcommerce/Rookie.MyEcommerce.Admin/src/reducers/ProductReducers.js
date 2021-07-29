import {
  ProductListFail,
  ProductListRequest,
  ProductListSuccess,
  ProductSaveFail,
  ProductSaveRequest,
  ProductSaveSuccess,
  ProductDeleteRequest,
  ProductDeleteSuccess,
  ProductDeleteFail,
  ProductDetailRequest,
  ProductDetailFail,
  ProductDetailSuccess,
} from "../constants/ProductConstants";

function productListReducer(state = { products: [] }, action) {
  switch (action.type) {
    case ProductListRequest:
      return { loading: true, products: [] };
    case ProductListSuccess:
      return { loading: false, products: action.payload };
    case ProductListFail:
      return { loading: false, products: action.payload };
    default:
      return state;
  }
}

function productSaveReducer(state = { products: {} }, action) {
  switch (action.type) {
    case ProductSaveRequest:
      return { loading: true };
    case ProductSaveSuccess:
      return { loading: false, product: action.payload, success: true };
    case ProductSaveFail:
      return { loading: false, product: action.payload };
    default:
      return state;
  }
}

function productDetailReducer(state = { products: {} }, action) {
  switch (action.type) {
    case ProductDetailRequest:
      return { loading: true };
    case ProductDetailSuccess:
      return { loading: false, product: action.payload };
    case ProductDetailFail:
      return { loading: false, product: action.payload };
    default:
      return state;
  }
}

function productDeleteReducer(state = { products: {} }, action) {
  switch (action.type) {
    case ProductDeleteRequest:
      return { loading: true };
    case ProductDeleteSuccess:
      return { loading: false, product: action.payload, success: true };
    case ProductDeleteFail:
      return { loading: false, product: action.payload };
    default:
      return state;
  }
}

export {
  productListReducer,
  productSaveReducer,
  productDeleteReducer,
  productDetailReducer,
};
