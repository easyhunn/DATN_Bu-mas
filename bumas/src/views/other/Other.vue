<template>
  <div class="other">
    <Worksheet></Worksheet>
    <!-- <ExportView></ExportView> -->
  </div>
</template>
<script>
import Worksheet from "./Worksheet.vue";
import ExportView from "./Export.vue";
export default {
  components: {
    Worksheet: Worksheet,
    ExportView: ExportView,
  },
  data() {
    return {};
  },
  methods: {},
  computed: {},
};
</script>
<style scoped>
.other {
  height: calc(100%);
}
</style>
