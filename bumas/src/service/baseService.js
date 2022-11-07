import axios from "axios";

const CORE = "core",
  AUTH = "auth";

export let baseService = {
  async get(type, controller, url = "", param = null) {
    let domain = "https://localhost:44370";
    if (type.toLowerCase() == CORE) {
      // domain = "https://localhost:44370";
    }
    return axios.get(`${domain}/api/${controller}/${url}`, {
      params: param
    });
  },
  async post(type, controller, url = "", params) {
    let domain = "https://localhost:44370";
    if (type.toLowerCase() == CORE) {
      // domain = "https://localhost:44370";
    }
    return axios.post(`${domain}/api/${controller}/${url}`, params);
  },
};
