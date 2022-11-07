<template>
  <div class="report-setting-viewer worksheet">
    <gc-spread-sheets
      class="sample-spreadsheets"
      @workbookInitialized="initSpread"
    >
      <gc-worksheet> </gc-worksheet>
    </gc-spread-sheets>
    <div class="options-container">
      <div class="option-row">
        <div class="inputContainer template-header">
          <div class="input-content">
            <label for="templateName">Tên mẫu biểu</label>
            <input id="templateName" type="text" v-model="templateName" />
          </div>
          <div class="input-content">
            <label for="TemplateCode">Mã biểu mẫu</label>
            <input id="TemplateCode" type="text" v-model="TemplateCode" />
          </div>
        </div>
        <div class="inputContainer">
          <input type="file" id="fileDemo" class="input" @change="loadExcel" />
          <br />
          <div class="d-flex justify-content-between align-items-end">
            <div class="preview" @click="preview(1)">File ban hành</div>
          </div>
        </div>
        <div class="inputContainer">
          <input
            type="file"
            id="summaryFile"
            class="input"
            @change="loadSummaryExcel"
          />
          <br />
          <div class="d-flex justify-content-between align-items-end mt-2">
            <div class="preview" v-on:click="preview(2)">File tổng hợp</div>
          </div>
        </div>
        <fieldset class="inputContainer">
          <legend>Số dòng</legend>
          <div class="input-content">
            <label for="headerLevel">Tiêu đề</label>
            <input id="headerLevel" type="number" v-model="headerLevel" />
          </div>
          <div class="input-content">
            <label for="rowCount">Dòng</label>
            <input id="rowCount" type="number" v-model="rowCount" />
          </div>
          <div class="input-content">
            <label for="columnCount">Cột</label>
            <input id="columnCount" type="number" v-model="columnCount" />
          </div>
          <button class="button" @click="applyConfig">Thiết lập</button>
        </fieldset>
      </div>
      <div class="footer">
        <button class="button btn btn-light mr-2" @click="backTab">Huỷ</button>
        <button class="button btn btn-success" @click="uploadFile">Lưu</button>
      </div>
    </div>
  </div>
</template>

<script>
import "@grapecity/spread-sheets-vue";
import GC from "@grapecity/spread-sheets";
import "@grapecity/spread-sheets-charts";
import { IO } from "@grapecity/spread-excelio";
import "./ReportSettingViewer.scss";

//filesaver to export
import { saveAs } from "file-saver";

import { baseService } from "../../service/baseService";

window.GC = GC;

export default {
  name: "ReportSettingViewer",
  data: function () {
    return {
      spread: null,
      summaryTemplateJson: null,
      templateJson: null,
      importExcelFile: null,
      headerLevel: null,
      rowCount: null,
      columnCount: null,
      templateName: "",
      TemplateCode: "",
    };
  },
  methods: {
    initSpread: function (spread) {
      this.spread = spread;
      spread.options.calcOnDemand = true;
      let activeSheet = spread.getActiveSheet();
      activeSheet.autoGenerateColumns = true;
    },
    changeFileDemo(e) {
      this.importExcelFile = e.target.files[0];
    },
    changeExportFileName(e) {
      this.exportFileName = e.target.value;
    },
    loadExcel(e) {
      let exportFileName = e.target.files[0];
      let spread = this.spread;
      let excelIo = new IO();
      let excelFile = exportFileName,
        me = this;

      // here is excel IO API
      excelIo.open(
        excelFile,
        function (json) {
          let workbookObj = json;
          me.templateJson = json;
          spread.fromJSON(workbookObj);
          me.clearLicense();
        },
        function (e) {
          // process error
          alert(e.errorMessage);
        }
      );
    },
    loadSummaryExcel(e) {
      let exportFileName = e.target.files[0];
      let spread = this.spread;
      let excelIo = new IO();
      let excelFile = exportFileName;
      let me = this;

      // here is excel IO API
      excelIo.open(
        excelFile,
        function (json) {
          let workbookObj = json;
          me.summaryTemplateJson = json;
          spread.fromJSON(workbookObj);
          me.clearLicense();
        },
        function (e) {
          // process error
          alert(e.errorMessage);
        }
      );
    },
    saveExcel(e) {
      let spread = this.spread;
      let excelIo = new IO();

      let fileName = this.exportFileName;
      if (fileName.substr(-5, 5) !== ".xlsx") {
        fileName += ".xlsx";
      }

      let json = spread.toJSON({ includeBindingSource: true });

      // here is excel IO API
      excelIo.save(
        json,
        function (blob) {
          saveAs(blob, fileName);
        },
        function (e) {
          console.log(e);
        }
      );
    },
    /**
     * Get default colums name
     * @param {*} sheet
     * @param {*} colIndex
     */
    getColumnLetterFromIndex(sheet, colIndex) {
      return GC.Spread.Sheets.CalcEngine.evaluateFormula(
        sheet,
        "=SUBSTITUTE(ADDRESS(1," + colIndex + ',4),"1","")',
        0,
        0
      );
    },
    /**
     *
     * @param {*} sheet
     */
    getDataSource(sheet) {
      let columnCount = sheet.getColumnCount(),
        rowCount = sheet.getRowCount();

      let dataSource = [],
        startRow = this.headerLevel ?? 0;

      for (let i = startRow; i < rowCount; ++i) {
        let dynamicRow = {};
        for (let j = 0; j < columnCount; ++j) {
          var columnName = this.getColumnLetterFromIndex(sheet, j + 1);
          dynamicRow[columnName] = sheet.getValue(i, j);
        }
        dataSource.push(dynamicRow);
      }
      return dataSource;
    },
    /**
     * lưu file client
     * @param {*} e
     */
    async uploadFile(e) {
      let spread = this.spread,
        activeSheet = spread.getActiveSheet();

      let json = spread.toJSON();
      let dataSource = this.getDataSource(activeSheet);
      let param = {
        JsonData: JSON.stringify(json),
        template_code: "MB05",
        template_name: "mẫu vmhung",
        organization_code: "0410",
        template_data: JSON.stringify(dataSource),
      };
      // baseService.post("core", "ReportSetting", "saveTemplate", param);
      localStorage.setItem("templateJson", JSON.stringify(json));
    },
    /**
     * lưu file client
     * @param {*} e
     */
    async getTemplate(e) {
      let spread = this.spread;

      let param = {
        fileName: "test.json",
      };
      var jsonData = await baseService.get(
        "core",
        "ReportSetting",
        "getStorageFile",
        param
      );
      spread.fromJSON(jsonData.data);
      me.clearLicense();
    },
    /**
     * áp dụng config
     */
    applyConfig() {
      let workbook = this.spread,
        activeSheet = workbook.getActiveSheet();
      if (this.rowCount) {
        activeSheet.setRowCount(this.rowCount);
      }
      if (this.columnCount) {
        activeSheet.setColumnCount(this.columnCount);
      }
    },
    backTab() {
      this.$router.go(-1);
    },
    preview(type) {
      let workbook = this.spread;
      let templateJson = null;
      switch (type) {
        case 1:
          templateJson = this.templateJson;
          break;
        case 2:
          templateJson = this.summaryTemplateJson;
          break;
      }
      if (templateJson) {
        workbook.fromJSON(templateJson);
        me.clearLicense();
      }
    },
    clearLicense() {
      let workbook = this.spread;
      let licenseIndex = workbook.getSheetIndex("Evaluation Version");
      if (licenseIndex >= 0) {
        workbook.removeSheet(licenseIndex);
      }
    },
  },
};
</script>
