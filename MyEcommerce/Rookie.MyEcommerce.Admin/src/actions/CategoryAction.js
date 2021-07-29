import {
  CategoryListFail,
  CategoryListRequest,
  CategoryListSuccess,
  CategorySaveFail,
  CategorySaveRequest,
  CategorySaveSuccess,
  CategoryDetailFail,
  CategoryDetailSuccess,
  CategoryDetailRequest,
  CategoryDeleteRequest,
  CategoryDeleteSuccess,
  CategoryDeleteFail
} from "../constants/CategoryConstants";
import { CategoryService } from "../services/CategoryService";

export const ListCategories = () => async (dispatch) => {
  try {
    dispatch({ type: CategoryListRequest });
    const data = await CategoryService.getAll();
    dispatch({ type: CategoryListSuccess, payload: data });
  } catch (error) {
    dispatch({ type: CategoryListFail, payload: error.message });
  }
};

export const detailCategory = (categoryId) => async (dispatch) => {
    try {
      dispatch({ type: CategoryDetailRequest });
      const data = await CategoryService.getById(categoryId);
      dispatch({ type: CategoryDetailSuccess, payload: data });
    } catch (error) {
      dispatch({ type: CategoryDetailFail, payload: error.message });
    }
  };

export const SaveCategory = (category) => async (dispatch) => {
  try {
    dispatch({ type: CategorySaveRequest, payload: category });
    if (category.id) {
      const data = await CategoryService.put(category.id, category);
      dispatch({ type: CategorySaveSuccess, payload: data });
    } else {
      const data = await CategoryService.post(category);
      dispatch({ type: CategorySaveSuccess, payload: data });
    }
  } catch (error) {
    dispatch({ type: CategorySaveFail, payload: error.message });
  }
};

export const DeleteCategory = (categoryId) => async (dispatch) => {
  try {
    dispatch({ type: CategoryDeleteRequest, payload: categoryId });
    const data = await CategoryService.delete(categoryId);
    dispatch({ type: CategoryDeleteSuccess, payload: data, success: true });
  } catch (error) {
    dispatch({ type: CategoryDeleteFail, payload: error.message });
  }
};
