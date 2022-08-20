<template>
  <div class="estimate-summary">
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
    <div class="summary-container">
      <TabEstimateSummary v-if="activeNav == 1"></TabEstimateSummary>
      <TabSummaryAnalyticalReview
        v-if="activeNav == 2"
      ></TabSummaryAnalyticalReview>
      <TabSummarySubmitAndPreview
        v-if="activeNav == 3"
      ></TabSummarySubmitAndPreview>
    </div>
  </div>
</template>

<script>
import TabEstimateSummary from "./TabEstimateSummary.vue";
import TabSummaryAnalyticalReview from "./TabSummaryAnalyticalReview.vue";
import TabSummarySubmitAndPreview from "./TabSummarySubmitAndPreview.vue";

export default {
  name: "EstimateSummary",
  components: {
    TabEstimateSummary: TabEstimateSummary,
    TabSummaryAnalyticalReview: TabSummaryAnalyticalReview,
    TabSummarySubmitAndPreview: TabSummarySubmitAndPreview,
  },
  data: function () {
    return {
      navItems: [
        {
          id: 1,
          name: "Tổng hợp",
        },
        {
          id: 2,
          name: "Phân tích tổng quan",
        },
        {
          id: 3,
          name: "Nộp và xem kết quả",
        },
      ],
      activeNav: 1,
    };
  },
};
</script>
<style lang="scss">
.estimate-summary {
  width: 100%;
  height: 100%;
  .summary-container {
    padding: 15px;
  }
}
</style>
