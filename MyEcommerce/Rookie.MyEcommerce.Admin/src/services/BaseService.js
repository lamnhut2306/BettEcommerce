import axios from "axios";
import { Common } from "../constants/Common";
import userManager from "../utils/UserManager";

axios.defaults.baseURL = `${Common.ApiHost}/api`;

axios.interceptors.request.use((config) => {
    let token = localStorage.getItem("access_token");
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
});

export const responseBody = (response) => response.data;

export const BaseService = {
  get: (url) => axios.get(url).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
  del: (url) => axios.delete(url).then(responseBody),
  postForm: async (url, files) => {
    let formData = new FormData();
    files.map((file) => formData.append(`formFiles`, file, file.name));
    return axios
      .post(url, formData, {
        headers: { "Content-type": "multipart/form-data" },
      })
      .then(responseBody);
  },
};
