import commonFn from "@/js/commonFn";
import { mapGetters } from "vuex";
const commonMixin = {
  methods: {
    ...commonFn,
  },
  computed: {
    ...mapGetters({
      authUtil: "authen/userInfo",
    }),
  },
};
export default commonMixin;
