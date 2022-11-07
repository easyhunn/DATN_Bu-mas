import Vue from "vue";
import VueRouter from "vue-router";
import store from "../store/index";

import Summary from "../views/summary/Summary.vue";
import EstimateSummary from "../views/estimatesummary/EstimateSummary.vue";
import SymmetricalEstimate from "../views/symmetricalestimate/SymmetricalEstimate.vue";
import Allocation from "../views/allocation/Allocation.vue";
import ReportContainer from "../views/report/ReportContainer.vue";
import Other from "../views/other/Other.vue";
import Dictionary from "../views/dictionary/Dictionary.vue";
import Login from "../views/authen/Login.vue";
import ReportViewer from "../views/report/ReportViewer.vue";
import ReportSettingViewer from "../views/other/ReportSettingViewer.vue";
import ReportSummaryViewer from "../views/other/ReportSummaryViewer.vue";
import ViewSubmitSummary from "../views/symmetricalestimate/ViewSubmitSummary.vue";

Vue.use(VueRouter);
const routes = [
  {
    path: "/login",
    name: "login",
    component: Login,
  },
  {
    path: "/",
    name: "Summary",
    component: Summary,
    meta: { requiresAuth: true },
  },
  {
    path: "/examine",
    name: "Summary",
    component: Summary,
    meta: { requiresAuth: true },
  },
  {
    path: "/estimatesummary",
    name: "EstimateSummary",
    component: EstimateSummary,
    meta: { requiresAuth: true },
  },
  {
    path: "/symmetricalestimate",
    name: "SymmetricalEstimate",
    component: SymmetricalEstimate,
    meta: { requiresAuth: true },
  },
  {
    path: "/report",
    name: "Report",
    component: ReportContainer,
    meta: { requiresAuth: true },
  },
  {
    path: "/allocation",
    name: "Allocation",
    component: Allocation,
    meta: { requiresAuth: true },
  },
  {
    path: "/dictionary",
    name: "Dictionary",
    component: Dictionary,
    meta: { requiresAuth: true },
  },
  {
    path: "/other",
    name: "Other",
    component: Other,
    meta: { requiresAuth: true },
  },
  {
    path: "/report-viewer",
    name: "ReportViewer",
    component: ReportViewer,
    meta: { requiresAuth: true },
    props: true,
  },
  {
    path: "/report-setting-viewer",
    name: "ReportSettingViewer",
    component: ReportSettingViewer,
    meta: { requiresAuth: true },
    props: true,
  },
  {
    path: "/report-summary-viewer",
    name: "ReportSummaryViewer",
    component: ReportSummaryViewer,
    meta: { requiresAuth: true },
    props: true,
  },
  {
    path: "/view-submit-summary",
    name: "ViewSubmitSummary",
    component: ViewSubmitSummary,
    meta: { requiresAuth: true },
    props: true,
  },
  
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  // get current user info
  // const isLogin = Auth.state.isLogin;
  if (to.name == "login") {
    store.dispatch("authen/signOut");
  }
  let isLogin = store.getters["authen/loginStatus"];
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);
  // isLogin = true;
  if (requiresAuth && !isLogin) next("/login");
  else next();
});
export default router;
