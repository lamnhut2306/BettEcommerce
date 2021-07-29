export const CategoryListRequest = "CategoryListRequest";
export const CategoryListSuccess = "CategoryListSuccess";
export const CategoryListFail = "CategoryListFail";

export const CategoryDetailRequest = "CategoryDetailRequest";
export const CategoryDetailSuccess = "CategoryDetailSuccess";
export const CategoryDetailFail = "CategoryDetailFail";

export const CategorySaveRequest = "CategorySaveRequest";
export const CategorySaveSuccess = "CategorySaveSuccess";
export const CategorySaveFail = "CategorySaveFail";

export const CategoryDeleteRequest = "CategoryDeleteRequest";
export const CategoryDeleteSuccess = "CategoryDeleteSuccess";
export const CategoryDeleteFail = "CategoryDeleteFail";

export const CategoryRules = {
    nameRegex: /^.{1,100}$/,
    descriptionRegex: /^.{1,255}$/
}

export const CategoryInvalidMessage = {
    description: `Description is required, maximum 255 characters.`,
    name: `Name is required, maximum 100 characters.`
}