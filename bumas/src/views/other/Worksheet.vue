<template>
  <div class="sample-tutorial workbook">
    <div class="tool-bar">
      <div class="export-group d-flex">
        <input
          id="exportFileName"
          value="export.xlsx"
          class="input"
          @change="changeExportFileName"
        />
        <input
          type="button"
          id="saveExcel"
          value="export"
          class="button"
          @click="saveExcel"
        />
      </div>
    </div>
    <div class="sample-container">
      <gc-spread-sheets
        class="sample-spreadsheets"
        @workbookInitialized="initSpread"
      >
        <gc-worksheet> </gc-worksheet>
      </gc-spread-sheets>
      <div id="statusBar"></div>
    </div>
  </div>
</template>
<script>
import "@grapecity/spread-sheets-vue";
import GC from "@grapecity/spread-sheets";
import { IO } from "@grapecity/spread-excelio";
//filesaver to export
import { saveAs } from "file-saver";
export default {
  data() {
    return {
      autoGenerateColumns: false,
      spread: null,
      activeSheetIndex: 0,
      activeSheetName: "Sheet1",
      targetIndex: 2,
      exportFileName: "export.xlsx",
    };
  },
  methods: {
    initSpread: function (spread) {
      this.spread = spread;
      spread.suspendPaint();
      //init Worksheet
      var sheet = spread.getSheet(0);

      // init Status Bar
      var statusBar = new GC.Spread.Sheets.StatusBar.StatusBar(
        document.getElementById("statusBar")
      );
      statusBar.bind(spread);
      spread.resumePaint();
    },

    addSheet: function (e) {
      var spread = this.spread;
      var activeIndex = spread.getActiveSheetIndex();
      if (activeIndex >= 0) {
        spread.addSheet(activeIndex + 1);
        spread.setActiveSheetIndex(activeIndex + 1);
      } else {
        spread.addSheet(0);
        spread.setActiveSheetIndex(0);
      }
    },
    removeSheet: function (e) {
      var spread = this.spread;
      var activeIndex = spread.getActiveSheetIndex();
      if (activeIndex >= 0) {
        spread.removeSheet(activeIndex);
      }
    },
    clearSheets: function (e) {
      var spread = this.spread;
      spread.clearSheets();
    },
    setActiveSheetIndex: function (e) {
      var spread = this.spread;
      var index = this.activeSheetIndex;
      if (!isNaN(index)) {
        index = parseInt(index);
        if (0 <= index && index < spread.getSheetCount()) {
          spread.setActiveSheetIndex(index);
        }
      }
    },
    changeSheetIndex: function (e) {
      var spread = this.spread;
      var sheetName = this.activeSheetName;
      var targetIndex = this.targetIndex;
      if (!isNaN(targetIndex)) {
        targetIndex = parseInt(targetIndex);
        if (0 <= targetIndex && targetIndex <= spread.getSheetCount()) {
          spread.changeSheetIndex(sheetName, targetIndex);
        }
      }
    },
    /**
     * đổi file xuất khẩu
     * @param {*} e
     */
    changeExportFileName(e) {
      this.exportFileName = e.target.value;
    },
    /**
     * xuất khẩu
     * @param {*} e
     */
    saveExcel(e) {
      let spread = this.spread;
      let excelIo = new IO();

      let fileName = this.exportFileName;
      let password = this.password;
      if (fileName.substr(-5, 5) !== ".xlsx") {
        fileName += ".xlsx";
      }

      let json = spread.toJSON();

      // here is excel IO API
      excelIo.save(
        json,
        function (blob) {
          saveAs(blob, fileName);
        },
        function (e) {
          // process error
          console.log(e);
        },
        {
          password: password,
        }
      );
    },
  },
  computed: {},
};
</script>
<style scoped lang="scss">
.sample-tutorial {
  position: relative;
  height: 100%;
  overflow: hidden;
  .tool-bar {
    height: 60px;
    padding: 0 16px;
    .export-group {
      width: 100px;
      flex-direction: column;
    }
  }
  .sample-container {
    display: flex;
    flex-direction: column;
    width: 100%;
    height: calc(100% - 60px);

    label {
      display: block;
      margin-bottom: 6px;
    }

    input {
      padding: 4px 6px;
    }

    input[type="button"] {
      margin-top: 6px;
      display: block;
    }
    .sample-spreadsheets {
      width: calc(100%);
      height: 100%;
      overflow: hidden;
      float: left;
    }
    #statusBar {
      bottom: 0;
      height: 25px;
      width: 100%;
      position: relative;
    }
  }
}
</style>
