<template>
  <div class="symmetrical-estimate">
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
    <div class="symmetrical-estimate-container">
      <TabEstimateBudgetCollection
        v-if="activeNav == 1"
      ></TabEstimateBudgetCollection>
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
import TabEstimateBudgetCollection from "./TabEstimateBudgetCollection.vue";
import TabSummaryAnalyticalReview from "./TabSummaryAnalyticalReview.vue";
import TabSummarySubmitAndPreview from "./TabSummarySubmitAndPreview.vue";

export default {
  name: "SymmetricalEstimate",
  components: {
    TabEstimateBudgetCollection: TabEstimateBudgetCollection,
    TabSummaryAnalyticalReview: TabSummaryAnalyticalReview,
    TabSummarySubmitAndPreview: TabSummarySubmitAndPreview,
  },
  data: function () {
    return {
      navItems: [
        {
          id: 1,
          name: "Lập dự toán thu",
        },
        {
          id: 2,
          name: "Lập dự toán chi",
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
.symmetrical-estimate {
  width: 100%;
  height: 100%;
  .symmetrical-estimate-container {
    padding: 15px;
    height: calc(100% - 43px);
    .container {
    }
  }
}
</style>
