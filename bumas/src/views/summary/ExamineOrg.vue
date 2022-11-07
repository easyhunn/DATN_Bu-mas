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
      :key="tableKey"
    >
    </EditableTable>
  </div>
</template>

<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { fields } from "./dataFields";
export default {
  name: "ExamineOrg",
  props: {
    orgType: Number,
    itemData: Array
  },
  components: {
    EditableTable,
    MDialogVue,
  },
  data() {
    return {
      fields: fields,
      items: this.itemData,
      editMode: 0,
      isShowModal: false,
      tableKey: 0
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
  },
  watch: {
    itemData() {
      this.items = this.itemData
      this.tableKey++;
    }
  },
};
</script>

<style lang="scss"></style>
