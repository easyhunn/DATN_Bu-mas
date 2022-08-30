import axios from "axios";

const CORE = "core",
  AUTH = "auth";

export let baseService = {
  get(type, controller, url = "") {
    let domain = "https://localhost:44370";
    if (type.toLowerCase() == CORE) {
      // domain = "https://localhost:44370";
    }
    return axios.get(`${domain}/api/${controller}/${url}`);
  },
};
