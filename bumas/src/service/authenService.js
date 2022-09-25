import { baseService } from "./baseService.js";

let authenService = {
  async getData() {
    return baseService.get("core", "Test");
  },
};
export default authenService;
