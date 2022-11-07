<template>
  <div id="reportViewer">
    <div>
      <div id="viewer"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ReportViewer",
  data() {
    return {};
  },
  mounted: function () {
    if (this.$route.query) {
      let reportCode = this.$route.query.reportCode,
        reportParams = this.$route.params;
      console.log(this.$route);
      var viewer = new this.Stimulsoft.Viewer.StiViewer(
        null,
        "StiViewer",
        false
      );

      var report = new this.Stimulsoft.Report.StiReport();

      var dataParam = new this.Stimulsoft.System.Data.DataSet("DataParam");
      var dataSource = new this.Stimulsoft.System.Data.DataSet("dataSource");

      var fakeData = {
        DataParam: [
          {
            OrgName: "Huyện Phú Mỹ",
            ReportName: "Mẫu biểu 05",
            Unit: "Triệu Đồng",
          },
        ],
      };
      var fakeDataSource = {
        DataSource: [
          {
            STT: "1",
            Content: "Chi thường xuyên",
            Amount1: 10000000,
            Amount2: 20000000,
            Amount3: 30000000,
          },
          {
            STT: "2",
            Content: "Chi chương trình mục tiêu",
            Amount1: 50000000,
            Amount2: 70000000,
            Amount3: 120000000,
          },
          {
            STT: "3",
            Content: "Chi đầu tư",
            Amount1: 60000000,
            Amount2: 90000000,
            Amount3: 150000000,
          },
        ],
      };

      dataParam.readJson(fakeData);
      dataSource.readJson(fakeDataSource);

      report.loadFile(`/reports/${reportCode}.mrt`);

      report.regData(dataParam.dataSetName, "", dataParam);
      report.regData(dataSource.dataSetName, "", dataSource);
      report.reportName = reportParams.ReportName;
      report.reportAlias = reportParams.ReportName;

      viewer.report = report;

      viewer.renderHtml("viewer");
    }
  },
};
</script>

<style lang="scss">
#reportViewer {
  height: calc(100vh - 55px);
  overflow: auto;
  #viewer {
  }
}
</style>
