import Vue from "vue";
import App from "./App.vue";
import router from "./router/menuRoute";
import store from "./store";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

// Import Bootstrap and BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.scss"; // đang ảnh hưởng đến workbook
import "bootstrap-vue/dist/bootstrap-vue.css";
// import "./app.scss";
import "./assets/css/tailwind.css";
import "./scss/main-layout.scss";
import "./scss/icon.scss";
import "./scss/common.scss";

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue);
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: function (h) {
    return h(App);
  },
}).$mount("#app");
