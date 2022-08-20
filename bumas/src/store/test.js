import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    data: string,
  },
  getters: {},
  mutations: {},
  actions: {
    getData() {
      this.data = "got it";
    },
  },
  modules: {},
});
