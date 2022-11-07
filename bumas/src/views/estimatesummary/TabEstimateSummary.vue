<template>
  <div id="container">
    <div class="m-header">Tổng hợp dự toán năm 2023</div>
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
      >
      </EditableTable>
    </div>
  </div>
</template>

<script>
import EditableTable from "@/components/EditableTable.vue";
import MDialogVue from "@/components/MDialog.vue";
import { fields } from "./dataField";
import axios from "axios";
export default {
  name: "TabEstimateSummary",
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
      tableKey: 1
    };
  },
  methods: {
    
    openModal() {
      this.isShowModal = true;
    },
    dialogRes(res) {
      if (res == 2) {
        this.isShowModal = false;
      }
    },
    async getData() {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Estimate/getSummaryData")
        .then(async (res) => {
          me.items = res.data;
          me.tableKey++;
      })
    },
  },
  async created() {
    let me = this;
    await this.getData();
  },
};
</script>

<style lang="scss">
.content {
  display: flex;
  flex-direction: column;
}
</style>
