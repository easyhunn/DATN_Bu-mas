<template>
  <div class="container">
    <div class="d-flex align-items-center">
      <div v-on:click="backTab" class="mr-2 link-primary">&larr;</div>
      <div class="m-header">Dự án thu</div>
    </div>

    <div class="content">
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
import { summaryFields } from "./dataTableField";
import axios from "axios";
export default {
  name: "ViewSubmitSummary",
  components: {
    EditableTable,
    MDialogVue,
  },
  data() {
    return {
      fields: summaryFields,
      items: [],
      editMode: 0,
      isShowModal: false,
      tableKey: 0,
    };
  },
  methods: {
    async getData(submitSummaryListId) {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Estimate/getEstimateById", {
          params: {
            submitSummaryListId: submitSummaryListId
          },
        })
        .then(async (res) => {
          me.items = res.data;
          me.tableKey++;
        });
    },
    backTab() {
      this.$router.go(-1);
    },
  },
  async created() {
    let me = this;
    if (this.$route.query) {
      let submitSummaryListId = this.$route.query.submitSummaryListId;
      await this.getData(submitSummaryListId);
    }
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
