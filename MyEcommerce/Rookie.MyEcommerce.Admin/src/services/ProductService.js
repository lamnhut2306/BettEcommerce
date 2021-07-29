import { BaseService } from "./BaseService";

export const ProductService = {
  getAll: () => BaseService.get("/product"),
  getById: (id) => BaseService.get(`/product/${id}`),
  put: (id, product) => BaseService.put(`/product/${id}`, product),
  post: (product) => {
    let data = {
      name: product.name,
      description: product.description,
      unitPrice: product.unitPrice,
      discount: product.discount,
      categoryId: product.categoryId,
    };
    BaseService.post(`/product`, data).then((res) => {
      data.id = res.id;
      return BaseService.postForm(`/productImage/${data.id}`, product.images).then(
        (res) => {
          data.images = res;
          return new Promise(() => data);
        }
      );
    });
  },
  delete: (id) => BaseService.del(`/product/${id}`),
};
