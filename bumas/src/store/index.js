import Vue from "vue";
import Vuex from "vuex";
import testStore from "./Module/test";
import authenStore from "./Module/authen";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    message: "from main store",
  },
  getters: {},
  mutations: {},
  actions: {
    changeMessage() {
      console.log("from main message");
    },
  },
  modules: {
    test: testStore,
    authen: authenStore,
  },
});
