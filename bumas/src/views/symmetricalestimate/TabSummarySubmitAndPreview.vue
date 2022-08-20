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
          <div class="wrap-content" id="btnAddSubmit">
            <div class="ic-add-1"></div>
            <div class="item-name">Tạo lần nộp</div>
          </div>
        </div>
        <div class="list-item">
          <div class="wrap-item">
            <div class="item">
              <div class="content-row row">
                <div class="item-content name col-4">
                  <div class="main-info">
                    <div class="ic-edit"></div>
                    <div class="item-name text-item">
                      Dự toán thu - chi năm 2022 lần 2
                    </div>
                  </div>
                </div>
                <div class="item-content item-date decision-date col-2">
                  <div class="text-date text-item">24/01/2022</div>
                </div>
                <div class="item-content item-created-by created-by col-2">
                  <div class="text-item text-item">Nguyễn Hồng Sơn</div>
                </div>
                <div class="item-content status status-decision col-2">
                  <div class="text-item-long doing text-item">Chờ duyệt</div>
                </div>
                <div class="item-content item-tools col-2">
                  <div class="tools">
                    <div class="btn-group-1 more-tools-group">
                      <div class="text-item-long doing text-item">
                        Xem dự toán
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
