<template>
  <div class="Content">
    <MDialogVue v-show="isShowModal" @dialogRes="dialogRes"> </MDialogVue>
    <div class="action-container"></div>
    <EditableTable
      v-model="items"
      :fields="fields"
      :editMode="editMode"
      :isTreeView="false"
      searchPlaceHolder="Nhập tên đơn vị, mã QHNS để tìm kiếm"
      :displayFilter="true"
    >
    </EditableTable>
  </div>
</template>

<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { items, fields } from "./datafake";
export default {
  name: "ExamineOrg",
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
  mounted() {
    this.testFn();
  },
};
</script>

<style lang="scss"></style>
