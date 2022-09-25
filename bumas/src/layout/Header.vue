<template>
  <header class="layout-header" id="header">
    <div class="left-header">
      <div class="organization-name">
        <span>Huyện Phù Mỹ</span>
      </div>
      <div class="work-year-container">
        <div class="work-year-content">
          <span>Năm ngân sách </span><span id="workYearValue">2022</span>

          <input
            type="text"
            class="yearpicker"
            id="txtWorkYear"
            value=""
            disabled="disabled"
          />
        </div>
      </div>
    </div>
    <div class="right-header">
      <div class="tool-header">
        <div>
          <button
            class="header-icon d-none"
            title=""
            data-toggle="tooltip"
            data-original-title="Tìm kiếm"
          >
            <div class="search"></div>
          </button>
        </div>
        <div v-click-outside="hideSettingDropDown">
          <div class="setting-dropdown">
            <button
              class="header-icon"
              title="Thiết lập"
              @click="showSetting = !showSetting"
              id="setting-management"
            >
              <div class="setting"></div>
            </button>
            <div class="setting-container dropdown-menu" v-if="showSetting">
              <div class="row-group">
                <div class="col-3">
                  <span class="title-header">Thiết lập hệ thống</span>
                </div>
                <div class="col-3">
                  <span class="title-header">&nbsp;</span>
                </div>
                <div class="col-3">
                  <span class="title-header">&nbsp;</span>
                </div>
                <div class="col-3">
                  <span class="title-header">Tiện ích</span>
                </div>
              </div>
              <div class="row-group">
                <div class="col-3">
                  <div
                    class="setting-item"
                    id="InformationUnitManagement"
                    data-detail-page="/systemmanagement/informationunitmanagementpartial"
                    data-command="Setting"
                  >
                    Thông tin đơn vị
                  </div>
                  <div
                    class="setting-item"
                    id="Developping1"
                    data-command="Developping"
                  >
                    Thông tin tài nguyên
                  </div>
                </div>

                <div class="col-3">
                  <div
                    class="setting-item"
                    id="UserManagement"
                    data-sc-subsystem-code="UserManagement"
                    data-command="SettingPage"
                    data-detail-page="/systemmanagement/usermanagement"
                  >
                    Quản lý người dùng
                  </div>

                  <div
                    class="setting-item"
                    id="RoleManagement"
                    data-sc-subsystem-code="RoleManagement"
                    data-command="SettingPage"
                    data-detail-page="/systemmanagement/rolemanagement"
                  >
                    Quản lý vai trò
                  </div>

                  <div
                    class="setting-item"
                    id="ChildOrganizationManagement"
                    data-command="SettingPage"
                    data-detail-page="/systemmanagement/organizationmanagement"
                  >
                    Đơn vị trực thuộc
                  </div>
                </div>
                <div class="col-3">
                  <div
                    class="setting-item"
                    id="ProcessManagement"
                    data-detail-page="/systemmanagement/processmanagementpartial"
                    data-command="Developing"
                  >
                    Thiết lập quy trình
                  </div>

                  <div
                    class="setting-item"
                    id="Developping2"
                    data-command="Developing"
                  >
                    Thiết lập chữ ký số
                  </div>
                </div>
                <div class="col-3">
                  <div
                    class="setting-item"
                    id="Developping3"
                    data-detail-page="/history/historyaccess"
                    data-command="History"
                  >
                    Lịch sử truy cập
                  </div>

                  <div
                    class="setting-item"
                    id="btnViewAgreementHistory"
                    data-command="ShowAgreementHistory"
                  >
                    Tra cứu thỏa thuận sử dụng
                  </div>
                  <div
                    class="setting-item"
                    id="Developping4"
                    data-command="Developing"
                  >
                    Kết nối
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div>
          <button
            class="header-icon ui-dialog-titlebar-help header-help-button"
            title="Trợ giúp (F1)"
            data-toggle="help-popup"
          >
            <div class="help"></div>
          </button>
        </div>

        <div id="pnNotification">
          <button
            class="header-icon"
            title="Thông báo"
            data-toggle="dropdown"
            id="notification"
          >
            <div class="notification"></div>
            <span class="notification-number" style="display: none">0</span>

            <div
              class="noti-container dropdown-menu"
              id="conNotification"
              area-labelledby="notification"
              title=""
            >
              <div class="arrow-up" style="right: 124px"></div>
              <div class="notification-title">
                <div class="title">Thông báo</div>
                <div
                  class="setting"
                  title=""
                  data-toggle="tooltip"
                  data-placement="bottom"
                  data-original-title="Cài đặt thông báo"
                >
                  <div class="ic-setting"></div>
                </div>
              </div>

              <div class="noti-group"></div>

              <div class="notification-bottom">
                <div class="more-noti">
                  <div class="title">Xem tất cả các thông báo</div>
                </div>
              </div>
            </div>
          </button>
        </div>

        <div class="business" style="">
          <button
            class="header-icon toggle-business"
            id="organization-item"
            @click="showBusinessToggle = !showBusinessToggle"
          >
            <div class="home"></div>
          </button>
          <b-popover
            :show.sync="showBusinessToggle"
            target="organization-item"
            custom-class="business-popover-class"
            container="header"
            offset=""
            placement="bottom"
          >
            <template #title>Nghiệp vụ chương trình</template>
            <div class="popover-gr-item">
              <a
                class="dropdown-item business-item summary selected"
                appcode="summary"
                href="#"
                title="Tổng hợp"
                >Tổng hợp</a
              >
              <a
                class="dropdown-item business-item estimate"
                appcode="estimate"
                href="#"
                title="Lập dự toán"
                >Lập dự toán</a
              >
            </div>
          </b-popover>
        </div>
      </div>
      <div class="user-header">
        <div class="sepetator d-none"></div>
        <div
          class="avatar"
          data-toggle="dropdown"
          id="more-setting-avatar"
          style="
            background: url(https://id.misa.vn/image/getavatar?userId=8d1489f7-55ba-4f6c-a29b-bc992300e83d&amp;width=100&amp;height=100)
              center no-repeat;
          "
        ></div>

        <div class="more" data-toggle="dropdown" id="more-setting"></div>

        <div
          class="dropdown-menu dropdown-menu-right"
          area-labelledby="more-setting"
          id="userSetting"
        ></div>
        <b-popover
          show.sync="true"
          target="more-setting"
          container="header"
          offset=""
          placement="bottom"
        >
          <div class="popover-gr-item">
            <a
              class="dropdown-item business-item summary selected"
              href="#"
              title="Tổng hợp"
              >Đăng xuất</a
            >
          </div>
        </b-popover>
      </div>
    </div>
  </header>
</template>

<script>
import ClickOutside from "vue-click-outside";

export default {
  name: "Header",
  props: {},
  data: function () {
    return {
      showSetting: false,
      showBusinessToggle: false,
      showSettingToggle: true,
    };
  },
  methods: {
    hideSettingDropDown() {
      this.showSetting = false;
    },
  },
  directives: {
    ClickOutside,
  },
};
</script>

<style scoped lang="scss">
header {
  position: relative;
  width: 100%;
  height: 55px;
  user-select: none;
  background-color: #fff;
  display: flex;
  border-bottom: 1px solid #e0e0e0;
  justify-content: space-between;
  .left-header {
    display: flex;
    align-items: center;
    .organization-name {
      white-space: nowrap;
      color: #454f63;
      margin-left: 20px;
      font-size: 15px;
      font-family: Roboto-Medium;
      display: block;
      text-overflow: ellipsis;
      text-transform: uppercase;
      font-weight: 600;
    }
    .work-year-container {
      margin-left: 30px;
      border: 1px solid #dedede;
      height: 32px;
      line-height: 30px;
      position: relative;
      width: 160px;
      .work-year-content {
        padding: 0 8px 0 12px;
        display: flex;
        align-items: center;
        position: relative;
        &::before {
          content: "";
          position: absolute;
          top: 12px;
          right: 10px;
          display: inline-block;
          height: 5px;
          width: 5px;
          border-radius: 50%;
          background: #15ab15;
        }
        span {
          white-space: nowrap;
        }
        #workYearValue {
          margin-left: 4px;
        }
        .yearpicker {
          position: absolute;
          top: 0;
          left: 0;
          right: 0;
          bottom: 0;
          opacity: 0;
          width: 100%;
          cursor: pointer;
        }
      }
    }
  }
  .right-header {
    display: flex;
    align-items: center;
    .tool-header {
      z-index: 1;
      display: flex;
      height: 55px;
      .header-icon {
        background: #fff;
        width: 44px;
        height: 100%;
        border: 0;
        outline: 0;
        position: relative;
        display: flex;
        justify-content: center;
        align-items: center;
        border-bottom: 1px solid #e0e0e0;
        .help {
          background: url("../assets/image/misa-icon.svg") -27px -51px no-repeat;
          width: 18px;
          height: 18px;
        }
        .notification {
          background: url("../assets/image/misa-icon.svg") -27px -75px no-repeat;
          width: 18px;
          height: 18px;
        }
        .home {
          background: url("../assets/image/misa-icon.svg") -3px -219px no-repeat;
          width: 18px;
          height: 18px;
        }
      }
      .business {
        .dropdown-menu {
          position: absolute;
          z-index: 1000;
          display: none;
          min-width: 10rem;
          padding: 0.5rem 0;
          margin: 0;
          font-size: 1rem;
          color: #212529;
          text-align: left;
          list-style: none;
          background-color: #fff;
          background-clip: padding-box;
          border: 1px solid rgba(0, 0, 0, 0.15);
          border-radius: 0.25rem;
        }
      }
    }
    .setting-dropdown {
      height: 100%;
      .header-icon {
        background: #fff;
        width: 44px;
        height: 100%;
        border: 0;
        outline: 0;
        position: relative;
        display: flex;
        justify-content: center;
        align-items: center;
        border-bottom: 1px solid #e0e0e0;
        .setting {
          background: url("../assets/image/misa-icon.svg") -27px -26px no-repeat;
          width: 18px;
          height: 20px;
        }
      }
      .setting-container {
        position: fixed !important;
        top: 55px !important;
        right: 0 !important;
        left: unset !important;
        bottom: unset !important;
        transform: inherit !important;
        width: 820px;
        height: 210px;
        transition: ease-in-out 0.2s;
        min-height: 130px;
        max-height: 210px;
        border-radius: 0;
        border: none;
        z-index: 100000000;
        box-shadow: -3px 3px 5px rgb(0 0 0 / 10%);
        font-size: 13px !important;
        padding: 0 !important;
        margin: 0 !important;
        .row-group {
          &:first-child {
            margin-top: 20px;
          }
          margin-top: 10px;
          display: flex;
          .setting-item {
            padding: 6px 12px;
            white-space: nowrap;
            cursor: pointer;
          }
        }
      }
      .dropdown-menu {
        position: absolute;
        display: block;
        top: 100%;
        left: 0;
        z-index: 1000;
        float: left;
        padding: 0.5rem 0;
        margin: 0.125rem 0 0;
        font-size: 1rem;
        color: #212529;
        text-align: left;
        list-style: none;
        background-color: #fff;
        background-clip: padding-box;
        border: 1px solid rgba(0, 0, 0, 0.15);
        border-radius: 0.25rem;
      }
    }
    .user-header {
      z-index: 1;
      color: #fff;
      display: flex;
      justify-content: flex-end;
      justify-self: flex-end;
      align-items: center;
      align-self: center;
      margin: 0 15px;
      font-size: 13px;
      .sepetator {
        border-right: 1px solid #e0e0e0;
        height: 22px;
      }
      .avatar {
        background: url("../assets/image/avatar-profile-default.svg") center
          no-repeat;
        border: 1px solid #e0e0e0;
        margin-right: 14px;
        height: 30px;
        width: 30px;
        background-size: 30px !important;
        border-radius: 50%;
        cursor: pointer;
      }
      .more {
        color: #7b7a8d;
        cursor: pointer;
        content: "";
        border-top: 4.5px solid;
        border-right: 4px solid transparent;
        border-left: 4px solid transparent;
      }
    }
  }
  .business-popover-class {
    // left: -0 !important;
  }
}
</style>
