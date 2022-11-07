<template>
  <div class="report-setting-list">
    <div class="action-container">
      <b-button
        class="btn btn-success"
        variant="success"
        @click="onClickRow"
        >Thêm biểu mẫu</b-button
      >
    </div>
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
  name: "ReportList",
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
      this.$router.push({
        name: "ReportSettingViewer",
        params: params,
        query: { reportCode: reportCode },
      });
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
  .btn {
    height: 35px;
    width: 150px;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    border: 1px solid transparent;
    padding: 0.375rem 0.75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: 0.25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
  }
}
</style>
