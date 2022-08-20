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
      <Report v-if="activeNav == 1"></Report>
    </div>
  </div>
</template>

<script>
import Report from "./Report.vue";

export default {
  name: "ReportContainer",
  components: {
    Report: Report,
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
    };
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
