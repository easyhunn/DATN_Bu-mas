import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import Summary from "../views/summary/Summary.vue";
import EstimateSummary from "../views/estimatesummary/EstimateSummary.vue";
import SymmetricalEstimate from "../views/symmetricalestimate/SymmetricalEstimate.vue";
import Allocation from "../views/allocation/Allocation.vue";
import ReportContainer from "../views/report/ReportContainer.vue";
import Other from "../views/other/Other.vue";
import Dictionary from "../views/dictionary/Dictionary.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/examine",
    name: "Summary",
    component: Summary,
  },
  {
    path: "/estimatesummary",
    name: "EstimateSummary",
    component: EstimateSummary,
  },
  {
    path: "/symmetricalestimate",
    name: "SymmetricalEstimate",
    component: SymmetricalEstimate,
  },
  {
    path: "/report",
    name: "Report",
    component: ReportContainer,
  },
  {
    path: "/allocation",
    name: "Allocation",
    component: Allocation,
  },
  {
    path: "/dictionary",
    name: "Dictionary",
    component: Dictionary,
  },
  {
    path: "/other",
    name: "Other",
    component: Other,
  },
  {
    path: "/about",
    name: "about",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: function () {
      return import(/* webpackChunkName: "about" */ "../views/AboutView.vue");
    },
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
