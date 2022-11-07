<template>
  <div class="report-summary-viewer worksheet">
    <gc-spread-sheets
      :key="spreadKey"
      class="sample-spreadsheets"
      @workbookInitialized="initSpread"
    >
      <gc-worksheet> </gc-worksheet>
    </gc-spread-sheets>
    <div class="options-container" v-if="showMenu">
      <div class="option-row">
        <div class="inputContainer export-group">
          <div>
            <input
            id="exportFileName"
            value="export.xlsx"
            class="input"
            @change="changeExportFileName"
          />
          <input
            type="button"
            id="saveExcel"
            value="Xuất khẩu"
            class="button"
            @click="saveExcel"
          />
          </div>
          <!-- <div class="icon-toggle-menu" v-if="showMenu" v-on:click="toggleMenu(false)">
            &#62;
          </div>
          <div class="icon-toggle-menu" v-if="!showMenu" v-on:click="showMenu=true">
            &#60;
          </div> -->
        </div>
        <div class="inputContainer list-org">
          <h3>Danh sách đơn vị</h3>
          <ul class="list-group">
            <li class="list-group-item" v-for="org in lstOrg" 
              @click="chooseOrg(org)"
              :class="{'active-org': org.id == selectedOrg}"
              key="org.Id">
              {{org.name}}
             </li>
            <!-- <li class="list-group-item">Tổng hợp</li>
            <li class="list-group-item">Đơn vị 1</li>
            <li class="list-group-item">Đơn vị 2</li> -->
          </ul>
        </div>
      </div>
      <div class="footer">
        <button class="button btn btn-success" @click="backTab">Đóng</button>
        <!-- <button class="button btn btn-success" @click="uploadFile">Lưu</button> -->

      </div>
    </div>
  </div>
</template>

<script>
import "@grapecity/spread-sheets-vue";
import GC from "@grapecity/spread-sheets";
import "@grapecity/spread-sheets-charts";
import { IO } from "@grapecity/spread-excelio";
import "./ReportSummaryViewer.scss";

//filesaver to export
import { saveAs } from "file-saver";

import { baseService } from "../../service/baseService";

window.GC = GC;

export default {
  name: "ReportSummaryViewer",
  data: function () {
    return {
      spread: null,
      importExcelFile: null,
      exportFileName: "export.xlsx",
      password: "",
      headerLevel: null,
      rowCount: null,
      columnCount: null,
      templateName: "",
      TemplateCode: "",
      showMenu: true,
      spreadKey: 0,
      lstOrg: [
        {
          id: 1,
          name: "Tổng hợp",
        },
        {
          id: 2,
          name: "Đơn vị 1",
        },
        {
          id: 3,
          name: "Đơn vị 2",
        }
      ],
      selectedOrg: 1
    };
  },
  methods: {
    toggleMenu(isShow) {
      let me = this;
      me.showMenu = isShow;
      this.spreadKey++; 
    },
    initSpread: function (spread) {
      this.spread = spread;
      spread.options.calcOnDemand = true;
      let activeSheet = spread.getActiveSheet();
      activeSheet.autoGenerateColumns = true;
      var templateJson = JSON.parse(localStorage.getItem("templateJson"));
      spread.fromJSON(templateJson);
      this.clearLicense();
    },
    changeFileDemo(e) {
      this.importExcelFile = e.target.files[0];
    },
    changePassword(e) {
      this.password = e.target.value;
    },
    changeExportFileName(e) {
      this.exportFileName = e.target.value;
    },
    loadExcel(e) {
      let spread = this.spread;
      let excelIo = new IO();
      let excelFile = this.importExcelFile;
      let password = this.password;
      let me = this;

      // here is excel IO API
      excelIo.open(
        excelFile,
        function (json) {
          let workbookObj = json;
          spread.fromJSON(workbookObj);
          me.clearLicense();
        },
        function (e) {
          // process error
          alert(e.errorMessage);
        },
        {
          password: password,
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
      this.clearLicense();
    },
    /**
     * áp dụng config
     */
    applyConfig () {
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
    chooseOrg(org) {
      if (org && org.id) this.selectedOrg = org.id;
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
