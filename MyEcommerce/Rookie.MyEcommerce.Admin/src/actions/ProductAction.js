import {
    ProductListFail,
    ProductListRequest,
    ProductListSuccess,
    ProductSaveFail,
    ProductSaveRequest,
    ProductSaveSuccess,
    ProductDetailFail,
    ProductDetailSuccess,
    ProductDetailRequest,
    ProductDeleteRequest,
    ProductDeleteSuccess,
    ProductDeleteFail
  } from "../constants/ProductConstants";
  import { ProductService } from "../services/ProductService";
  
  export const ListProducts = () => async (dispatch) => {
    try {
      dispatch({ type: ProductListRequest });
      const data = await ProductService.getAll();

      dispatch({ type: ProductListSuccess, payload: data });
    } catch (error) {
      dispatch({ type: ProductListFail, payload: error.message });
    }
  };
  
  export const detailProduct = (productId) => async (dispatch) => {
      try {
        dispatch({ type: ProductDetailRequest });
        const data = await ProductService.getById(productId);
        dispatch({ type: ProductDetailSuccess, payload: data });
      } catch (error) {
        dispatch({ type: ProductDetailFail, payload: error.message });
      }
    };
  
  export const SaveProduct = (product) => async (dispatch) => {
    try {
      dispatch({ type: ProductSaveRequest, payload: product });
      if (product.id) {
        const data = await ProductService.put(product.id, product);
        dispatch({ type: ProductSaveSuccess, payload: data });
      } else {
        const data = await ProductService.post(product);
        dispatch({ type: ProductSaveSuccess, payload: data });
      }
    } catch (error) {
      dispatch({ type: ProductSaveFail, payload: error.message });
    }
  };
  
  export const DeleteProduct = (productId) => async (dispatch) => {
    try {
      dispatch({ type: ProductDeleteRequest, payload: productId });
      const data = await ProductService.delete(productId);
      dispatch({ type: ProductDeleteSuccess, payload: data, success: true });
    } catch (error) {
      dispatch({ type: ProductDeleteFail, payload: error.message });
    }
  };
  