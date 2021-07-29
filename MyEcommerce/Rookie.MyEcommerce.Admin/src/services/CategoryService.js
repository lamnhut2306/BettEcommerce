import { BaseService } from "./BaseService";

export const CategoryService = {
    getAll: () => BaseService.get('/Category'),
    getById: (id) => BaseService.get(`/Category/${id}`),
    put: (id, category) => BaseService.put(`/Category/${id}`, category),
    post: (category) => BaseService.post('/Category', category),
    delete: (id) => BaseService.del(`/Category/${id}`)
}