<template>
  <div class="sample-tutorial">
    <gc-spread-sheets
      class="sample-spreadsheets"
      @workbookInitialized="initSpread"
    >
      <gc-worksheet> </gc-worksheet>
    </gc-spread-sheets>
    <div class="options-container">
      <div class="option-row">
        <div class="inputContainer">
          <input
            type="checkbox"
            id="incremental"
            @change="changeIncremental"
            checked
          />
          <label for="incremental">Incremental Loading</label>

          <p class="summary" id="loading-container">
            Loading progress:
            <input
              style="width: 231px"
              id="loadingStatus"
              type="range"
              name="points"
              min="0"
              max="100"
              value="0"
              step="0.01"
            />
          </p>
          <input
            type="file"
            id="fileDemo"
            class="input"
            @change="changeFileDemo"
          />
          <br />
          <input
            type="button"
            id="loadExcel"
            value="import"
            class="button"
            @click="loadExcel"
          />
        </div>
        <div class="inputContainer">
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
      <div class="option-row">
        <div class="group">
          <label
            >Password:
            <input type="password" id="password" @change="changePassword" />
          </label>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import "@grapecity/spread-sheets-vue";
import GC from "@grapecity/spread-sheets";
import "@grapecity/spread-sheets-charts";
import { IO } from "@grapecity/spread-excelio";
import { jsonData } from "./data";
import "./ExportStyle.scss";
//filesaver to export
import { saveAs } from "file-saver";
window.GC = GC;

export default {
  name: "Export",
  data: function () {
    return {
      spread: null,
      importExcelFile: null,
      exportFileName: "export.xlsx",
      password: "",
    };
  },
  methods: {
    initSpread: function (spread) {
      this.spread = spread;
      spread.options.calcOnDemand = true;
      spread.fromJSON(jsonData);
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
    changeIncremental(e) {
      document.getElementById("loading-container").style.display = e.target
        .checked
        ? "block"
        : "none";
    },
    loadExcel(e) {
      let spread = this.spread;
      let excelIo = new IO();
      let excelFile = this.importExcelFile;
      let password = this.password;

      let incrementalEle = document.getElementById("incremental");
      let loadingStatus = document.getElementById("loadingStatus");
      // here is excel IO API
      excelIo.open(
        excelFile,
        function (json) {
          let workbookObj = json;
          if (incrementalEle.checked) {
            spread.fromJSON(workbookObj, {
              incrementalLoading: {
                loading: function (progress, args) {
                  progress = progress * 100;
                  loadingStatus.value = progress;
                  console.log(
                    "current loading sheet",
                    args.sheet && args.sheet.name()
                  );
                },
                loaded: function () {},
              },
            });
          } else {
            spread.fromJSON(workbookObj);
          }
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
};
</script>
