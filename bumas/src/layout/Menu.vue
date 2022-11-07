<template>
  <div
    class="menu-side-bar"
    v-bind:class="[isMinimize ? 'mini-sidebar' : 'large-sidebar']"
  >
    <div class="logo-site d-flex" style="border-bottom: 1px solid #f3f4f6">
      <a class="logo" v-on:click="resizeMenu()" href="#" style=""></a>
      <a class="logo logo-text" href="/examine"></a>
      <div class="menu-toggle" v-on:click="resizeMenu()" style="opacity: unset">
        <div class="bar"></div>
        <div class="bar"></div>
        <div class="bar"></div>
      </div>
    </div>
    <!--các tính năng trong menu-->
    <div class="nav-content">
      <router-link
        v-for="item in menuList"
        :key="item.id"
        class="nav-item"
        :to="item.route"
        v-bind:class="{ 'menu-active': item.id == selectedMenu }"
      >
        <div class="menu-item">
          <div class="d-icon menu-icon" :class="item.icon"></div>
          <div class="nav-item-text item-content" v-show="!isMinimize">
            {{ item.name }}
          </div>
          <div v-if="item.subLinks" v-on:click.prevent="toggleSubmenu(item.id)">
            <div class="d-icon icon-arrow-down p-3 ml-2"></div>
          </div>
        </div>
        <div class="sub-menu menu-icon d-none" :id="'subMenu' + item.id">
          <router-link
            v-for="submenu in item.subLinks"
            :key="submenu.id"
            :to="submenu.route"
            v-on:click.native="selectMenu(submenu)"
            v-bind:class="{ 'menu-active': submenu.id == selectedMenu }"
            class="menu-item sub-menu-item"
          >
            <div class="d-icon" :class="submenu.icon"></div>
            <div class="nav-item-text item-content" v-if="!isMinimize">
              {{ submenu.name }}
            </div>
          </router-link>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Menu",
  data: function () {
    return {
      drawer: true,
      menuList: [
        {
          name: "Kiểm tra",
          route: "/examine",
          id: 0,
          icon: "examine",
        },
        {
          name: "Tổng hợp",
          route: "/estimatesummary",
          id: 1,
          icon: "estimate-summary",
        },

        {
          name: "Lập và cân đối",
          route: "/symmetricalestimate",
          id: 2,
          icon: "symetrical",
        },
        // {
        //   name: "Phân bổ, giao dự toán",
        //   route: "/allocation",
        //   id: 3,
        //   icon: "allocation ",
        // },
        // {
        //   name: "Theo dõi thực hiện",
        //   route: "/movie",
        //   id: 7,
        //   icon: "trackprogress",
        // },
        {
          name: "Báo cáo",
          route: "/report",
          id: 8,
          icon: "report",
        },
        // {
        //   name: "Danh mục",
        //   route: "/dictionary",
        //   id: 9,
        //   icon: "dictionary",
        // },
        {
          name: "Khác",
          route: "/other",
          id: 10,
          icon: "icon-back",
        },
      ],
      menuListTree: [
        {
          name: "Kiểm tra",
          route: "/examine",
          id: 0,
        },
        {
          name: "Tổng hợp",
          route: "/estimatesummary",
          id: 1,
        },

        {
          name: "Lập và cân đối",
          route: "/symmetricalestimate",
          id: 2,
        },
        {
          name: "Phân bổ, giao dự toán",
          route: "/allocation",
          id: 3,
        },
        // {
        //   name: "Theo dõi thực hiện",
        //   route: "/movie",
        //   id: 7,
        // },
        {
          name: "Báo cáo",
          route: "/report",
          id: 8,
        },
        {
          name: "Báo cáo",
          route: "/report-viewer",
          id: 8,
        },
        // {
        //   name: "Danh mục",
        //   route: "/dictionary",
        //   id: 9,
        // },
        {
          name: "Khác",
          route: "/other",
          id: 10,
        },
      ],
      selectedMenu: 1,
      isMinimize: false,
    };
  },
  methods: {
    selectMenu(item) {
      this.selectedMenu = item.id;
      // if (item.subLinks) {
      //   this.toggleSubmenu(item.id);
      // }
    },
    resizeMenu() {
      this.isMinimize = !this.isMinimize;
    },
    toggleSubmenu(id) {
      let ele = document.getElementById("subMenu" + id);
      if (ele) {
        let isHide = ele.classList?.contains("d-none");
        if (isHide) {
          ele.classList.remove("d-none");
        } else {
          ele.classList.add("d-none");
        }
      }
    },
  },
  mounted() {
    let me = this;
    let selectItem = this.menuListTree.find((item) => {
      return item.route.toLowerCase() == me.$route.path.toLowerCase();
    });
    if (selectItem && selectItem.id) {
      this.selectedMenu = selectItem.id;
    } else {
      this.selectedMenu = 0;
    }

    //thiếu check đã login
    if (this.selectedMenu < 0) {
      this.selectedMenu = 0;
    }
    // console.log(this.selectedMenu);
  },
  computed: {
    currentRoute() {
      return this.$route.path;
    },
  },
  watch: {
    currentRoute() {
      let me = this;
      let selectedItem = this.menuListTree.find((item) => {
        return item.route.toLowerCase() == me.$route.path.toLowerCase();
      });
      this.selectedMenu = selectedItem?.id;
    },
  },
};
</script>
<style scoped lang="scss">
.d-icon {
  background-size: unset;
  width: 25px;
  height: 25px;
  background: url("../assets/image/misa-icon.svg") no-repeat;
  &.menu-icon {
  }
}
/*thanh menu*/
.menu-side-bar {
  float: left;
  //   width: 220px;
  //   min-width: 220px;
  //   max-width: 220px;
  height: 100%;
  background-color: #011239;
  &.mini-sidebar {
    width: 60px;
    .logo-text {
      display: none;
    }

    .menu-toggle {
      display: none;
    }
    .logo-site {
      justify-content: center;
    }
    .nav-content {
      .nav-item {
        align-items: center;
      }
    }
  }
  &.large-sidebar {
    width: 220px;
  }
  .menu-item {
    height: 55px;
    display: flex;
    align-items: center;
    padding: 10px 15px;
  }
  .sub-menu {
    display: flex;
    flex-direction: column;
    .sub-menu-item {
      padding-left: 25px;
    }
    .menu-item:hover {
      background-color: #273557;
      //   padding-left: 15px;
    }
  }
}
.minimize {
  width: 50px !important;
  min-width: 50px !important;
  max-width: 50px !important;
  .item-content {
    display: none;
  }
  .nav-item {
    padding: 0 !important;
    display: flex;
    align-items: center;
    justify-content: center;
  }
}
.nav-item-text {
  font-size: 13px;
  color: #f5f5f5;
  font-weight: 500;
  padding-left: 10px;
}

.menu-side-bar .logo-site {
  height: 55px;
  width: 100%;
  display: flex;
  align-items: center;
  cursor: pointer;
  /* background-color: #1e235a; */
  /* color: #ffffff; */
  color: white;
  padding: 10px;
  font-weight: 600;
  .menu-toggle {
    .bar {
      background-color: #f5f5f5;
      width: 20px;
      height: 2px;
      margin: 6px 1px;
    }
  }
}

.menu-side-bar .logo-site .logo-icon {
  //   background-image: url("../../assets/Icon/Logo_Full_White.png");
  width: 100%;
  height: 100%;
  background-size: contain;
  background-repeat: no-repeat;
}

/*thanh menu dưới logo*/
.menu-side-bar .nav-content {
  width: 100%;
  height: 100%;
  /* background-color: #2b3173; */
  display: flex;
  flex-direction: column;
  align-items: center;
}

.menu-side-bar .nav-content .nav-item {
  width: 100%;
  font-weight: 300;
  // height: 55px;
  flex-direction: column;
  display: flex;
  // align-items: center;
  justify-content: center;
  color: #aaacc7;
  cursor: pointer;
  line-height: 17px;
  text-decoration: none;
}

.menu-side-bar .nav-content .nav-item .menu-item:hover {
  background-color: #273557;
  padding-left: 10px;
}

.menu-side-bar .nav-content .nav-item:active {
  // background-color: #019160;
  font-family: GoogleSans-Medium;
}

.nav-item .nav-item-icon {
  background-repeat: no-repeat;
  height: 38px;
  width: 22px;
  margin-left: 8px;
  margin-right: 10px;
}
.last-nav-item {
  border-top: 1px solid #1e235a;
}
.menu-active {
  background-color: #273557;
}

/// icon
.examine {
  background-position: -3px -47px;
}
.estimate-summary {
  background-position: -3px -72px;
}
.symetrical {
  background-position: -4px -96px;
}
.allocation {
  background-position: -338px -1px;
}
.trackprogress {
  background-position: 0 -119px;
}
.report {
  background-position: -2px -144px;
}
.dictionary {
  background-position: -2px -167px;
}
</style>
