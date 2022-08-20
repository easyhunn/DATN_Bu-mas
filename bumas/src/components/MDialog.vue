<template>
  <div class="m-dialog">
    <div class="dialog-background"></div>
    <div class="dialog-container">
      <div class="dialog-header">
        <div class="left-header">
          <div class="header-title"></div>
        </div>
        <div class="right-header">
          <button type="button" class="icon-close"></button>
        </div>
      </div>
      <div class="dialog-content">
        <div class="icon-warning"></div>
        <div class="d-text">bạn có chắc chắn muốn xoá bản ghi không?</div>
      </div>
      <div class="dialog-footer">
        <div class="dialog-footer-left">
          <button type="button" @click="dialogRes(2)" class="btn btn-light">
            <div class="d-text">Không</div>
          </button>
        </div>
        <div class="dialog-footer-right">
          <button @click="dialogRes(1)" class="btn btn-success">
            <div class="">Có</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MDialog",
  props: {},
  methods: {
    dialogRes(resStatus) {
      this.$emit("dialogRes", resStatus);
    },
  },
};
</script>

<style scoped lang="scss">
.m-dialog {
  .dialog-background {
    width: 100vw;
    height: 100vh;
    background: black;
    opacity: 0.5;
    position: fixed;
    top: 0px;
    left: 0px;
    z-index: 4;
  }
  .dialog-container {
    z-index: 5;
    width: 420px;
    height: 171px;
    background-color: white;
    position: fixed;
    top: calc((100vh - 171px) / 2);
    left: calc((100vw - 420px) / 2);
    z-index: 5;
    border-radius: 3px;
    display: flex;
    flex-direction: column;
  }
  .dialog-container .dialog-header {
    display: flex;
    justify-content: space-between;
    padding: 15px 10px 5px 10px;
    height: 36px;
    min-height: 36px;
    max-height: 36px;
    background-color: #f0f0f0;
    border-radius: 3px 3px 0 0;
    align-items: center;
  }
  .dialog-header .header-title {
    font-size: 16px;
    font-weight: 700;
  }
  .dialog-container .dialog-content {
    height: auto;
    display: flex;
    flex: 1;
    padding: 5px 32px 20px 40px;
    border: 1px solid #e1e1e1;
    align-items: center;
  }

  .dialog-footer {
    display: flex;
    align-items: center;
    height: 61px;
    min-height: 61px;
    max-height: 61px;
    padding: 0 10px;
    justify-content: space-between;
  }
  .dialog-footer .dialog-footer-left {
    display: flex;
    padding: 7px;
  }
  .dialog-footer-left .btn-3:hover {
    background-color: #e5e6eb;
    border-color: #e5e6eb !important;
  }
  .dialog-footer .d-text {
    color: #2b3173;
    font-weight: 600;
    padding: 0 5px;
  }
  .dialog-footer .dialog-footer-right {
    display: flex;
  }
}
</style>
