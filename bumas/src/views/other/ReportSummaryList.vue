<template>
  <div class="report-setting-list">
    <EditableTable
      v-model="items"
      :fields="fields"
      :editMode="editMode"
      :isTreeView="false"
      searchPlaceHolder="Tìm kiếm"
      :displayFilter="false"
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
import { items, fields } from "./data";
export default {
  name: "ReportSummaryList",
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
      let params = {},
          reportCode = "";
      if (true) {
        this.$router.push({
          name: "ReportSummaryViewer",
          params: params,
          query: { reportCode: reportCode },
        });
      }
      
    },
    
  },
};
</script>

<style lang="scss">
.report-setting-list {
  .table {
    border: 0 !important;
  }
  .custom-td,
  .custom-th {
    border-top: 0 !important;
  }
}
</style>
