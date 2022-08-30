import { baseService } from "./baseService";

let testService = {
  async getData() {
    return baseService.get("core", "Test");
  },
};
export default testService;
