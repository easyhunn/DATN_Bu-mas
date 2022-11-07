<template>
  <div class="container">
    <div class="m-header">Dự án thu</div>
    <div class="content">
      <MDialogVue v-show="isShowModal" @dialogRes="dialogRes"> </MDialogVue>
      <div class="action-container"></div>
      <EditableTable
        v-model="items"
        :fields="fields"
        :editMode="editMode"
        :isTreeView="false"
        searchPlaceHolder="Tìm kiếm theo tên mã/tên chỉ tiêu"
        :displayFilter="false"
        ref="table"
        :key="tableKey"
        @delete-row="onDeleteRow"
      >
      </EditableTable>
    </div>
    <div class="footer">
      <b-button
        variant="light"
        size="md"
        class="float-left mr-2"
        v-if="editMode == 1"
        @click="editMode = 0"
      >
        Huỷ
      </b-button>
      <b-button
        v-if="editMode == 0"
        variant="success"
        size="md"
        class="float-right"
        @click="editMode = 1"
      >
        sửa
      </b-button>
      <b-button
        v-if="editMode == 1"
        variant="success"
        size="md"
        class="float-right"
        @click="saveData()"
      >
        lưu
      </b-button>
    </div>
  </div>
</template>

<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { fields } from "./dataTableField";
import axios from "axios";
export default {
  name: "TabEstimateBudgetCollection",
  components: {
    EditableTable,
    MDialogVue,
  },
  data() {
    return {
      fields: fields,
      items: [],
      editMode: 0,
      isShowModal: false,
      tableKey: 0,
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
    saveData() {
      let data = this.$refs.table.getData();
      let me = this;
      if (data) {
        let newData = data.filter((x) => x.isNew);
        let updateData = data.filter((x) => x.isUpdate);
        let dataParam = {};
        dataParam.lstUpdate = updateData;
        dataParam.lstInsert = newData;
        return axios
          .post("https://localhost:44370/api/Estimate/saveData", dataParam)
          .then((res) => {
            me.getData();
          });
      }
    },
    async getData() {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Estimate/getall")
        .then(async (res) => {
          me.items = res.data;
          me.tableKey++;
        });
    },
    async onDeleteRow(row) {
      var lstDelete = [];
      lstDelete.push(row);
      await axios
        .delete(`https://localhost:44370/api/Estimate/${row.id}`)
        .then(async (res) => {});
    },
  },
  async created() {
    let me = this;
    await this.getData();
  },
  mounted() {},
};
</script>

<style lang="scss">
.container {
  height: 100%;
  display: flex;
  flex-direction: column;
  .content {
    display: flex;
    flex-direction: column;
    flex: 1;
  }
  .footer {
    .btn {
      width: 120px;
      height: 30px;
    }
  }
}
</style>
