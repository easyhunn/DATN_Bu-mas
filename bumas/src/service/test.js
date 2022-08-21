import { baseService } from "./baseService";

let testService = {
  async getData() {
    return baseService.get("core", "WeatherForecast");
  },
};
export default testService;
