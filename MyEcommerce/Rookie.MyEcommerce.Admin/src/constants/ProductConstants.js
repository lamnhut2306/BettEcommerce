export const ProductListRequest = "ProductListRequest";
export const ProductListSuccess = "ProductListSuccess";
export const ProductListFail = "ProductListFail";

export const ProductDetailRequest = "ProductDetailRequest";
export const ProductDetailSuccess = "ProductDetailSuccess";
export const ProductDetailFail = "ProductDetailFail";

export const ProductSaveRequest = "ProductSaveRequest";
export const ProductSaveSuccess = "ProductSaveSuccess";
export const ProductSaveFail = "ProductSaveFail";

export const ProductDeleteRequest = "ProductDeleteRequest";
export const ProductDeleteSuccess = "ProductDeleteSuccess";
export const ProductDeleteFail = "ProductDeleteFail";

export const ProductRules = {
  nameRegex: /^.{1,100}$/,
  descriptionRegex: /^.{1,255}$/,
};

export const ProductInvalidMessage = {
  description: `Description is required, maximum 255 characters.`,
  name: `Name is required, maximum 100 characters.`,
};
