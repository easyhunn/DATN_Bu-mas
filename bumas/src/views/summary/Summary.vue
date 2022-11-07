<template>
  <div class="summary">
    <nav class="nav-container">
      <div class="nav">
        <div
          class="nav-item nav-link"
          v-for="(decision, index) in orgDecision"
          @click="onSelectView(index)"
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
      <ExamineOrg :itemData="items" :orgType="activeDec"> </ExamineOrg>
    </div>
  </div>
</template>

<script>
import { orgDecision } from "../../commonData.js";
import ExamineOrgVue from "./ExamineOrg.vue";
import axios from "axios";

export default {
  name: "Summary",
  components: { ExamineOrg: ExamineOrgVue },
  data: function () {
    return {
      orgDecision: orgDecision,
      activeDec: 0,
      items: [],
      defaultItems: [],
    };
  },
  methods: {
    onSelectView(index) {
      this.activeDec = index;
      switch (index) {
        case 0:
          this.items = this.defaultItems;
          break;
        case 1:
          this.items = this.defaultItems.filter((x) => x.status == 1 || x.status == 4 ||  !x.status);
          break;
        default:
          this.items = this.defaultItems.filter((x) => x.status == index);
          break;
      }
    },
    async getData() {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Organization/getSubOrgByStatus")
        .then(async (res) => {
          let data = res.data
          if (data) {
            me.items = data;
            me.defaultItems = data;
            me.orgDecision[0].count = data.length;
            me.orgDecision[1].count = data.filter(x => x.status == 1 || x.status == 4 || !x.status).length;
            me.orgDecision[2].count = data.filter(x => x.status == 2).length;
            me.orgDecision[3].count = data.filter(x => x.status == 3).length;
          }
          
        });
    },
  },
  async created() {
    let me = this;
    await this.getData();
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
