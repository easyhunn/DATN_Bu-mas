<template>
  <div class="other-container">
    <nav class="nav-container m-nav">
      <div class="nav">
        <div
          class="nav-item nav-link"
          v-for="navItem in navItems"
          @click="onClickNav(navItem.id)"
          v-bind:class="{ active: activeNav == navItem.id }"
        >
          <div class="item-content">
            <span class="upper-case">{{ navItem.name }}</span>
          </div>
        </div>
      </div>
    </nav>
    <div class="other-content">
      <ReportSettingList v-if="activeNav == 1" >
      </ReportSettingList>
      <ReportSummaryList v-if="activeNav == 2" >
      </ReportSummaryList>
    </div>
  </div>
</template>

<script>
import ReportSettingList from "./ReportSettingList.vue";
import ReportSummaryList from "./ReportSummaryList.vue";


export default {
  name: "OtherContainer",
  components: {
    ReportSettingList: ReportSettingList,
    ReportSummaryList: ReportSummaryList
  },
  data: function () {
    return {
      navItems: [
        {
          id: 1,
          name: "Thiết lập",
        },
        {
          id: 2,
          name: "Tổng hợp",
        },
      ],
      isShowReportViewer: false,
      activeNav: 1
    };
  },
  methods: {
   onClickNav(navId) {
    sessionStorage.setItem("summaryActiveNavId", navId);
    this.activeNav = navId;
   }
  },
  mounted() {
    let activeNavId = sessionStorage.getItem("summaryActiveNavId");
    if(activeNavId) {
      this.activeNav = activeNavId;
    }
  }
};
</script>
<style lang="scss">
.other-container {
  width: 100%;
  height: 100%;
  .other-content {
    padding: 15px;
  }
}
</style>
