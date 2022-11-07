<template>
  <div id="container">
    <div class="m-header">Dự toán chi 2022</div>
    <div class="content">
      <MDialogVue v-show="isShowModal" @dialogRes="dialogRes"> </MDialogVue>
      <div class="action-container"></div>
      <EditableTable
        v-model="items"
        :fields="fields"
        :editMode="editMode"
        :isTreeView="false"
        searchPlaceHolder="Tìm kiếm theo tên mã/tên chỉ tiêu"
        :displayFilter="true"
      >
      </EditableTable>
    </div>
  </div>
</template>

<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { items, fields } from "./dataTableField";
export default {
  name: "TabSummaryAnalyticalReview",
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
.content {
  display: flex;
  flex-direction: column;
}
</style>
