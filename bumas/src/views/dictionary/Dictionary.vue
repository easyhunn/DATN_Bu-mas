<template>
  <div class="dictionary">
    dic {{ message }}
    <button v-on:click="changeMessageA()">change message</button>
    <h1>{{ info }}</h1>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
import axios from "axios";

export default {
  name: "Dictionary",
  data: function () {
    return {
      info: "",
    };
  },
  methods: {
    ...mapActions("test", {
      changeTestMessage: "changeMessage",
    }),
    changeMessageA() {
      this.changeTestMessage();
    },
  },
  mounted() {
    axios
      .get("https://localhost:44370/api/Test")
      .then((response) => (this.info = response));
  },
  computed: {
    ...mapState({
      message: (state) => state.test.message,
    }),
  },
};
</script>
