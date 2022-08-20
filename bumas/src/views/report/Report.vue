<template>
  <div class="report">
    <MDialogVue v-show="isShowModal" @dialogRes="dialogRes"> </MDialogVue>
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
    /**
     * Thay đổi mode xem/ sửa
     */
    changeEditMode(mode) {
      this.editMode = mode;
    },
    openModal() {
      this.isShowModal = true;
    },
    dialogRes(res) {
      if (res == 2) {
        this.isShowModal = false;
      }
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
