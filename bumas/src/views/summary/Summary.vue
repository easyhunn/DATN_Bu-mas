<template>
  <div class="summary">
    <nav class="nav-container">
      <div class="nav">
        <div
          class="nav-item nav-link"
          v-for="(decision, index) in orgDecision"
          @click="activeDec = index"
          v-bind:class="{ active: activeDec == index }"
        >
          <div class="item-content">
            <div class="item-header">{{ decision.count }}</div>
            <div class="item-text">{{ decision.text }}</div>
          </div>
        </div>
      </div>
    </nav>
    <div class="summary-container">
      <ExamineOrg></ExamineOrg>
    </div>
  </div>
</template>

<script>
import { orgDecision } from "../../testdata.js";
import ExamineOrgVue from "./ExamineOrg.vue";
export default {
  name: "Summary",
  components: { ExamineOrg: ExamineOrgVue },
  data: function () {
    return {
      orgDecision: orgDecision,
      activeDec: 0,
    };
  },
};
</script>
<style lang="scss">
.summary {
  width: 100%;
  height: 100%;
  padding: 15px;
  .nav-container {
    height: 82px;
    min-height: 82px;
    max-height: 82px;
    .nav {
      display: flex;
      .nav-item {
        &.active {
          color: #fff !important;
          background-color: #27ae60 !important;
          border-color: #27ae60 !important;
        }
        .item-header {
          font-size: 34px;
          font-weight: 500;
          line-height: 44px;
        }
        .item-text {
          font-size: 11px;
          display: block;
          white-space: nowrap;
          text-overflow: ellipsis;
          overflow: hidden;
          text-transform: uppercase;
          display: flex;
          height: 25px;
          align-items: center;
        }
        flex: 1;
        height: 82px;
        background-color: #fff;
        border: 1px solid #e0e0e0;
        color: #011239;
        padding: 8px 10px !important;
        margin-right: 30px;
        flex: 1;
        cursor: pointer;
        border-radius: 0;
      }
    }
  }
  .summary-container {
    margin-top: 15px;
  }
}
</style>
