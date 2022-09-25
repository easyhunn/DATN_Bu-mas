import authenService from "../../service/authenService";
import commonFn from "@/js/commonFn";
import axios from "axios";

let authenStore = {
  namespaced: true,
  state: {
    email: "",
    password: "",
    token: "",
    id: "",
    sessionId: "",
    jwtToken: "",
  },
  mutations: {
    setUser(state, { email, password, token = state.token }) {
      state.email = email;
      state.password = password;
      state.token = token;
    },
    setProfile(state, { email, password }) {
      state.email = email;
      state.password = password;
      commonFn.setCookie("email", email, 1);
    },
    setJwtToken(state, jwtToken) {
      state.jwtToken = jwtToken;
      commonFn.setCookie("jwtToken", jwtToken, 1);
    },
  },
  actions: {
    async signIn(context, { email, password }) {
      commonFn.deleteCookie("email");
      commonFn.deleteCookie("token");
      commonFn.deleteCookie("password");
      var token = Date.now();
      context.commit("setUser", { email, password, token });

      commonFn.setCookie("email", email, 1);
      commonFn.setCookie("token", token, 1);
      // commonFn.setCookie("password", password, 1);
      return true;
    },
    signOut(context) {
      context.commit("setUser", {});
      commonFn.deleteCookie("email");
      commonFn.deleteCookie("token");
      // commonFn.deleteCookie("password");
    },
    loginToken({ commit }, credentials) {
      return axios
        .post("https://localhost:44370/account/token", credentials)
        .then((res) => {
          const profile = res.data;
          const jwtToken = res.data.token;
          delete profile.token;
          commit("setProfile", profile);
          commit("setJwtToken", jwtToken);
        });
    },
  },
  getters: {
    userInfo(state) {
      return {
        email: state.email,
        password: state.password,
      };
    },
    loginStatus(state) {
      if (!state.email) {
        state.email = commonFn.getCookie("email");
        state.token = commonFn.getCookie("token");
        state.jwtToken = commonFn.getCookie("jwtToken");
      }
      return state.email && (state.token || state.jwtToken);
    },
    authToken(state) {
      return state.token;
    },
  },
};
export default authenStore;
