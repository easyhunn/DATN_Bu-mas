<template>
  <div class="report-container">
    <nav class="nav-container m-nav">
      <div class="nav">
        <div
          class="nav-item nav-link"
          v-for="navItem in navItems"
          @click="activeNav = navItem.id"
          v-bind:class="{ active: activeNav == navItem.id }"
        >
          <div class="item-content">
            <span class="upper-case">{{ navItem.name }}</span>
          </div>
        </div>
      </div>
    </nav>
    <div class="report-content">
      <Report v-if="activeNav == 1" @show-report-view="showReportViewer">
      </Report>
      <!-- <ReportViewer v-if="isShowReportViewer"></ReportViewer> -->
    </div>
  </div>
</template>

<script>
import Report from "./Report.vue";
import ReportViewer from "./ReportViewer.vue";

export default {
  name: "ReportContainer",
  components: {
    Report: Report,
    ReportViewer: ReportViewer,
  },
  data: function () {
    return {
      navItems: [
        {
          id: 1,
          name: "Báo cáo theo mẫu",
        },
      ],
      activeNav: 1,
      isShowReportViewer: false,
    };
  },
  methods: {
    showReportViewer(reportCode, params) {
      // let route = this.$router.resolve({
      //   name: "ReportViewer",
      //   params: { orgId: "123455" },
      //   query: { reportCode: reportCode },
      // });
      // window.open(route.href, "_blank"); => k mang params theo được

      this.$router.push({
        name: "ReportViewer",
        params: params,
        query: { reportCode: reportCode },
      });
    },
  },
};
</script>
<style lang="scss">
.report-container {
  width: 100%;
  height: 100%;
  .report-content {
    padding: 15px;
  }
}
</style>
