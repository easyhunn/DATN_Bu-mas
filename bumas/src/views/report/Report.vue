<template>
  <div class="report">
    <div class="action-container"></div>
    <EditableTable
      v-model="items"
      :fields="fields"
      :editMode="editMode"
      :isTreeView="false"
      searchPlaceHolder="Tìm kiếm"
      :displayFilter="true"
      :striped="false"
      headerVariants="none"
      @on-click-row="onClickRow"
    >
    </EditableTable>
  </div>
</template>
<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { items, fields } from "./datafake";
export default {
  name: "Report",
  components: {
    EditableTable,
    MDialogVue,
  },
  data() {
    return {
      fields: fields,
      items: items,
      editMode: 0,
      isShowModal: false,
    };
  },
  methods: {
    onClickRow(item, index, event) {
      let reportCode = item.reportCode,
        params = { ReportName: item.name };
      this.$emit("show-report-view", reportCode, params);
    },
  },
};
</script>

<style lang="scss">
.report {
  .table {
    border: 0 !important;
  }
  .custom-td,
  .custom-th {
    border-top: 0 !important;
  }
}
</style>
