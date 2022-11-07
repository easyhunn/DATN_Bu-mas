<template>
  <div class="allocation-container">
    <div class="allocation-decision-title">
      <div class="row">
        <div class="item name col-4">TÊN LẦN NỘP</div>
        <div class="item decision-date col-2">NGÀY GỬI</div>
        <div class="item created-by col-2">NGƯỜI GỬI</div>
        <div class="item status col-2">TRẠNG THÁI</div>
        <div class="item item-tools col-2">
          <div>CHỨC NĂNG</div>
        </div>
      </div>
    </div>
    <div class="content">
      <div class="allocation-decision-item">
        <div class="item add-allocation-decision">
          <div class="wrap-content" id="btnAddSubmit" @click="addSubmit()">
            <div class="ic-add-1"></div>
            <div class="item-name">Tạo lần nộp</div>
          </div>
        </div>
        <div class="list-item">
          <div class="wrap-item">
            <div class="item mt-2" v-for="item in submitList">
              <div class="content-row row" >
                <div class="item-content name col-4">
                  <div class="main-info">
                    <div class="ic-edit"></div>
                    <div class="item-name text-item">
                      {{ item.name }}
                    </div>
                  </div>
                </div>
                <div class="item-content item-date decision-date col-2">
                  <div class="text-date text-item">{{ item.date }}</div>
                </div>
                <div class="item-content item-created-by created-by col-2">
                  <div class="text-item text-item">
                    <span v-if="item.status == 1">chưa nộp</span>
                    <span v-if="item.status == 2">chờ duyệt</span>
                    <span v-if="item.status == 3">hoàn thành</span>
                    <span v-if="item.status == 4">gửi trả</span>
                  </div>
                </div>
                <div class="item-content status status-decision col-2">
                  <div class="text-item-long doing text-item">
                    {{ item.userName }}
                  </div>
                </div>
                <div class="item-content item-tools col-2">
                  <div class="tools">
                    <div class="btn-group-1 more-tools-group">
                      <div class="text-item-long doing text-item">
                        <span  @click="viewSubmitDetail(item)" class="link-primary">Xem</span> 
                        <span v-if="auditSubmitEstimate == null || auditSubmitEstimate.status == 4" v-on:click="submitAuditEstimate(item)" class="link-primary"> | nộp</span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "TabSummarySubmitAndPreview",
  components: {},
  data() {
    return {
      submitList: [],
      auditSubmitEstimate: null
    };
  },
  methods: {
    addSubmit() {
      let me = this;
      let submitCount = this.submitList.length + 1;
      let newSubmit = {
        id: me.uuid(),
        name: "Dự toán thu - chi năm 2022 lần " + submitCount,
        date: "24/01/2022",
        userName: "Vũ Mạnh Hùng",
        status: 1,
        sortOrder: submitCount,
      };
      return axios
          .post("https://localhost:44370/api/Estimate/AddSubmitEstimate", newSubmit)
          .then((res) => {
            me.getSubmitStatusData();
          });
      //  this.submitList.unshift(newSubmit);
    },
    viewSubmitDetail(item) {
      if (item.submit_estimate_list_id) {
        this.$router.push({
        name: "ViewSubmitSummary",
        query: { submitSummaryListId: item.submit_estimate_list_id },
      });
      }
      
    },
    async getSubmitStatusData() {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Estimate/getSubmitEstimateStatus")
        .then(async (res) => {
          me.submitList = res.data;
        });
    },
    async getAuditSubmitStatusData() {
      let me = this;
      await axios
        .get("https://localhost:44370/api/Estimate/submitEstimate")
        .then(async (res) => {
          if (res && res.data) {
            me.auditSubmitEstimate = res.data[0];
          }
        });
    },
    submitAuditEstimate(item) {
      let me = this, mode = 1;
      if (me.auditSubmitEstimate) {
        me.auditSubmitEstimate.submit_estimate_list_id = item.submit_estimate_list_id;
        mode = 2;
      }
      let param = {
        Mode: mode,
        auditEstimateStatus: me.auditSubmitEstimate ?? item
      }
      return axios
          .post("https://localhost:44370/api/Estimate/submitEstimate", param)
          .then((res) => {
            me.getAuditSubmitStatusData();
          });
    },
  },
  async created() {
    let me = this;
    await this.getSubmitStatusData();
    await this.getAuditSubmitStatusData();
  },
};
</script>

<style lang="scss">
.allocation-container {
  width: 100%;
  height: 100%;
  .allocation-decision-title {
    width: 100%;
    padding: 20px 0px;
    background-color: rgb(245, 245, 245);
    border-radius: 5px;
    margin-top: 20px;
    margin-bottom: 20px;
    .item {
      white-space: nowrap;
      cursor: pointer;
      padding: 0 10px;
    }
  }
  .content {
    overflow: auto;
    padding-bottom: 20px;
    height: calc(100% - 100px);
    position: unset !important;
    padding-top: 0px !important;
    .add-allocation-decision {
      display: flex;
      flex-direction: row;
      justify-content: flex-start;
      align-items: center;
      height: 55px;
      border-radius: 5px;
      border: 1px solid rgb(222, 226, 230);
      margin-bottom: 10px;
      .wrap-content {
        display: flex;
        align-items: center;
        width: 180px;
        cursor: pointer;
        .item-name {
          font-style: italic;
          color: rgb(68, 138, 255);
          margin-left: 1px;
          font-weight: normal !important;
        }
      }
    }
    .list-item {
      .wrap-item {
        margin-bottom: 10px;
        transition: box-shadow 0.2s;
        .item {
          cursor: pointer;
          height: 55px;
          border: 1px solid #dee2e6;
          display: flex;
          flex-direction: column;
          justify-content: center;
          border-radius: 5px;
          .item-content {
            padding: 0 10px;
            .text-item {
              white-space: nowrap;
              overflow: hidden;
              text-overflow: ellipsis;
            }
            &.name {
              .main-info {
                display: flex;
                align-items: center;
                .item-name {
                  margin-left: 5px;
                }
              }
            }

            &.item-tools {
              div {
                float: right;
                padding-right: 25px;
              }
            }
          }
        }
      }
    }
  }
}
</style>
