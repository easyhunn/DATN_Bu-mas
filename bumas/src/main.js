import Vue from "vue";
import App from "./App.vue";
import router from "./router/menuRoute";
import store from "./store";
import axios from "axios";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

// Import Bootstrap and BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.scss"; // đang ảnh hưởng đến workbook
import "bootstrap-vue/dist/bootstrap-vue.css";
// import "./app.scss";
import "./assets/css/tailwind.css";
import "./scss/main-layout.scss";
import "./scss/icon.scss";
import "./scss/common.scss";

import commonMixin from "./assets/mixin/common.js";
import { Stimulsoft } from "stimulsoft-reports-js/Scripts/stimulsoft.blockly.editor";

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue);
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin);
Vue.mixin({
  ...commonMixin,
});
Vue.prototype.Stimulsoft = Stimulsoft;
Vue.config.productionTip = false;
axios.defaults.withCredentials = true;
axios.defaults.baseURL = "http://localhost:44370";
axios.interceptors.request.use((request) => {
  if (store.state.authen.jwtToken)
    request.headers["Authorization"] = "Bearer " + store.state.authen.jwtToken;
  return request;
});

new Vue({
  store,
  router,
  render: function (h) {
    return h(App);
  },
}).$mount("#app");
