<template>
  <div class="allocation-container">
    <div class="allocation-decision-title">
      <div class="d-flex justify-content-between">
        <div class="item-title name">TÊN LẦN NỘP</div>
        <div class="item-title decision-date">NGÀY GỬI</div>
        <div class="item-title created-by">NGƯỜI GỬI</div>
        <div class="item-title status">TRẠNG THÁI</div>
        <div class="item-title item-tools">
          <div>CHỨC NĂNG</div>
        </div>
      </div>
    </div>
    <div class="content">
      <div class="allocation-decision-item">
        <div class="item add-allocation-decision">
          <div class="wrap-content" id="btnAddSubmit">
            <div class="ic-add-1"></div>
            <div class="item-name">Tạo lần nộp</div>
          </div>
        </div>
        <div class="list-item">
          <div class="wrap-item">
            <div class="item">
              <div class="d-flex content-row justify-content-between">
                <div class="item-content name">
                  <div class="main-info">
                    <div class="ic-edit"></div>
                    <div class="item-name">
                      Dự toán thu - chi năm 2022 lần 2
                    </div>
                  </div>
                </div>
                <div class="item-content item-date decision-date">
                  <div class="text-date">24/01/2022</div>
                </div>
                <div class="item-content item-created-by created-by">
                  <div class="text-item">Nguyễn Hồng Sơn</div>
                </div>
                <div class="item-content status status-decision">
                  <div class="text-item-long doing">Chờ duyệt</div>
                </div>
                <div class="item-content item-tools">
                  <div class="tools">
                    <div class="btn-group-1 more-tools-group">
                      <div class="text-item-long doing">Xem dự toán</div>
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
export default {
  name: "TabSummarySubmitAndPreview",
  components: {},
  data() {
    return {};
  },
  methods: {},
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
    .item-title {
      white-space: nowrap;
      cursor: pointer;
      &.name {
        max-width: calc(30% - 50px);
        width: 20%;
        padding-left: 15px;
      }
      &.decision-date {
        width: 125px;
      }
      &.created-by {
        width: 15%;
      }
      &.status {
        width: 10%;
        margin-left: 15px;
      }
      &.item-tools {
        margin-left: 15px;
        div {
          float: right;
          padding-right: 25px;
        }
      }
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
  }
}
</style>
