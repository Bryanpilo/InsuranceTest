import axios from "axios";
import { toast } from 'react-toastify';
import httpHelper from "../Helper/HttpHelper";
import 'react-toastify/dist/ReactToastify.css';

const instance = axios.create();

const url = "http://localhost:18588/api/"; 

const handleError = (error) => {

  if (axios.isCancel(error)) {
    return Promise.reject({ response: { data: "Canceled by user" } });
  }

  if (httpHelper.isNotFound(error)) {
    toast.error("An unexpected error occurred, please try again");
  }

  if (httpHelper.badCombination(error)) {
    toast.error("Al seleccionar un tipo de riesgo alto, la cobertura no puede exceder el 50%");
  }

  if (httpHelper.isUnautorized(error)) {
    toast.error("Usuario o contraseña incorrectas");
  }

  // if (!httpHelper.isUnautorized(error)) {
  //   sessionStorage.clear();
  //   propsAxios.history.push('/ErrorAuth');
  // }
  if (httpHelper.isServerError(error)) {
    toast.error("An error occurred in the connection to the server, please contact the support team");
  }

  // if (httpHelper.isExpected(error)) {
  //   toast.error("An unexpected error occurred, please try again");
  // }

  return Promise.reject(error);
};

instance.interceptors.request.use(
  request => request,
  error => handleError(error)
);

instance.interceptors.response.use(
  response => response,
  error => handleError(error)
);

const toQueryString = (obj) => {
  const parts = [];
  for (const property in obj) {
    if (
      obj.hasOwnProperty(property) &&
      (property !== null && property !== undefined)
    ) {
      const value = obj[property];

      if (value !== null && value !== undefined && value !== "")
        parts.push(
          `${encodeURIComponent(property)}=${encodeURIComponent(value)}`
        );
    }
  }
  return parts.join("&");
};

const setJWT = (token) => {
  instance.defaults.headers.common["Authorization"] = `bearer ${token}`;
};

export default {
  delete: instance.delete,
  get: instance.get,
  isCancel: axios.isCancel,
  post: instance.post,
  put: instance.put,
  toQuery: toQueryString,
  setJWT,
  url: url
};