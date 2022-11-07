<template>
  <div id="app">
    <div class="app-container">
      <div class="layout-menu" v-if="isLogin">
        <Menu></Menu>
      </div>
      <div class="layout-content">
        <div class="content-header" v-if="isLogin">
          <Header></Header>
        </div>
        <div class="content-container">
          <router-view />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Menu from "./layout/Menu.vue";
import Header from "./layout/Header.vue";
import "@grapecity/spread-sheets-vue";
import "@grapecity/spread-sheets/styles/gc.spread.sheets.excel2013white.css";
import { mapState, mapGetters } from "vuex";

export default {
  name: "App",
  components: {
    Menu: Menu,
    Header: Header,
  },
  data() {
    return {};
  },
  methods: {},
  computed: {
    ...mapState({}),
    ...mapGetters({
      isLogin: "authen/loginStatus",
    }),
  },
};
</script>

<style lang="scss">
@import "~ag-grid-community/styles/ag-grid.css";
@import "~ag-grid-community/styles/ag-theme-alpine.css";
html {
  overflow: hidden;
}
.app-container {
  width: 100vw;
  height: 100vh;
  display: flex;
  .layout-menu {
    height: 100vh;
    max-height: 100vh;
    min-height: 100vh;
    &.mini-sidebar {
      width: 60px;
    }
    &.large-sidebar {
      width: 220px;
    }
  }
  .layout-content {
    flex: 1;
    display: flex;
    flex-direction: column;
    .content-header {
      width: 100%;
      height: 55px;
      user-select: none;
      background-color: #fff;
      display: flex;
      border-bottom: 1px solid #e0e0e0;
      justify-content: space-between;
    }
    .content-container {
      flex: 1;
    }
  }
}
</style>
