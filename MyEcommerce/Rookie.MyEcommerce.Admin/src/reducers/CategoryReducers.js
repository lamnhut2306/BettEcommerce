import {
  CategoryListFail,
  CategoryListRequest,
  CategoryListSuccess,
  CategorySaveFail,
  CategorySaveRequest,
  CategorySaveSuccess,
  CategoryDeleteRequest,
  CategoryDeleteSuccess,
  CategoryDeleteFail,
  CategoryDetailRequest,
  CategoryDetailFail,
  CategoryDetailSuccess
} from "../constants/CategoryConstants";

function categoryListReducer(
  state = { categories: [] },
  action
) {
  switch (action.type) {
    case CategoryListRequest:
      return { loading: true, categories: [] };
    case CategoryListSuccess:
      return { loading: false, categories: action.payload };
    case CategoryListFail:
      return { loading: false, categories: action.payload };
    default:
      return state;
  }
}

function categorySaveReducer(state = {categories: {}}, action) {
  switch (action.type) {
    case CategorySaveRequest:
      return { loading: true };
    case CategorySaveSuccess:
      return { loading: false, category: action.payload, success: true };
    case CategorySaveFail:
      return { loading: false, category: action.payload };
    default:
      return state;
  }
}

function categoryDetailReducer(state = {categories: {}}, action) {
  switch (action.type) {
    case CategoryDetailRequest:
      return { loading: true };
    case CategoryDetailSuccess:
      return { loading: false, category: action.payload };
    case CategoryDetailFail:
      return { loading: false, category: action.payload };
    default:
      return state;
  }
}

function categoryDeleteReducer(state = {categories: {}}, action) {
  switch (action.type) {
    case CategoryDeleteRequest:
      return { loading: true };
    case CategoryDeleteSuccess:
      return { loading: false, category: action.payload, success: true };
    case CategoryDeleteFail:
      return { loading: false, category: action.payload };
    default:
      return state;
  }
}


export {
  categoryListReducer,
  categorySaveReducer,
  categoryDeleteReducer,
  categoryDetailReducer
};
