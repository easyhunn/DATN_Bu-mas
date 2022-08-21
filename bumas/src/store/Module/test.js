import testService from "../../service/test";

let testStore = {
  namespaced: true,
  state: {
    message: "from test",
  },
  getters: {},
  mutations: {
    changeMessage: function (state, message) {
      state.message = message;
    },
  },
  actions: {
    changeMessage({ state, commit, rootState }) {
      testService.getData().then((data) => {
        commit("changeMessage", data.data[0].Date);
      });
    },
  },
  modules: {},
};
export default testStore;
