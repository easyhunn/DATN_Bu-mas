<template>
  <div class="allocation">
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
    <div class="allocation-container">
      <TabAllocationSuperiorChild
        v-if="activeNav == 1"
      ></TabAllocationSuperiorChild>
      <TabAllocationImplementation v-if="activeNav == 2">
      </TabAllocationImplementation>
      <TabAllocationDecision v-if="activeNav == 3"></TabAllocationDecision>
    </div>
  </div>
</template>

<script>
import TabAllocationSuperiorChild from "./TabAllocationSuperiorChild.vue";
import TabAllocationImplementation from "./TabAllocationImplementation.vue";
import TabAllocationDecision from "./TabAllocationDecision.vue";

export default {
  name: "Allocation",
  components: {
    TabAllocationSuperiorChild: TabAllocationSuperiorChild,
    TabAllocationImplementation: TabAllocationImplementation,
    TabAllocationDecision: TabAllocationDecision,
  },
  data: function () {
    return {
      navItems: [
        {
          id: 1,
          name: "Nhận phương án từ cấp trên",
        },
        {
          id: 2,
          name: "Thực hiện phân bổ",
        },
        {
          id: 3,
          name: "Quyết định giao",
        },
      ],
      activeNav: 1,
    };
  },
};
</script>
<style lang="scss">
.allocation {
  width: 100%;
  height: 100%;
  .allocation-container {
    padding: 15px;
  }
}
</style>
