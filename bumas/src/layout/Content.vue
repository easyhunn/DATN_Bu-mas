<template>
  <div id="Content">
    <b-button @click="openModal"> open modal </b-button>
    <MDialogVue v-show="isShowModal" @dialogRes="dialogRes"> </MDialogVue>
    <div class="action-container">
      <b-button
        v-if="editMode == 0"
        class="edit-button"
        variant="success"
        @click="changeEditMode(1)"
        >Sửa</b-button
      >
      <b-button
        v-if="editMode == 1"
        class="edit-button"
        variant="success"
        @click="changeEditMode(0)"
        >Huỷ</b-button
      >
    </div>
    <EditableTable
      v-model="items"
      :fields="fields"
      :editMode="editMode"
      :isTreeView="true"
    >
    </EditableTable>
  </div>
</template>

<script>
import EditableTable from "./components/EditableTable.vue";
import MDialogVue from "./components/MDialog.vue";
export default {
  name: "Content",
  components: {
    EditableTable,
    MDialogVue,
  },
  data() {
    return {
      fields: [
        { key: "checkBox", label: "", type: "checkBox", tdClass: "w-35px" },
        {
          key: "_tree",
          label: "",
          type: "_tree",
          tdClass: "w-35px tree-field",
        },
        { key: "name", label: "Name", type: "text", tdClass: "w-200px" },
        {
          key: "department",
          label: "Department",
          type: "select",
          options: ["Development", "Marketing", "HR", "Accounting"],
          tdClass: "w-200px",
        },
        { key: "age", label: "Age", type: "number", tdClass: "w-100px" },
        {
          key: "dateOfBirth",
          label: "Date Of Birth",
          type: "date",
          tdClass: "w-250px",
        },
        {
          key: "delete",
          label: "Action",
          type: "_action",
          tdClass: "w-100px",
        },
      ],
      items: [
        {
          id: 1,
          age: 40,
          name: "Dickerson",
          department: "Development",
          dateOfBirth: "1984-05-20",
          isParent: true,
        },
        {
          id: 2,
          age: 21,
          name: "Larsen",
          department: "Marketing",
          dateOfBirth: "1984-05-20",
          parentId: 1,
        },
        {
          id: 3,
          age: 89,
          name: "Geneva",
          department: "HR",
          dateOfBirth: "1984-05-20",
          parentId: 1,
          isParent: true,
        },
        {
          id: 4,
          age: 38,
          name: "Jami",
          department: "Accounting",
          dateOfBirth: "1984-05-20",
          parentId: 3,
        },
        {
          id: 5,
          age: 39,
          name: "Hung",
          department: "Accounting",
          dateOfBirth: "1984-05-20",
        },
      ],
      editMode: 0,
      isShowModal: true,
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

<style lang="scss"></style>
