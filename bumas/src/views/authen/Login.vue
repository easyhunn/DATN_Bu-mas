<template>
  <div
    class="w-full h-full flex items-center justify-center bg-gray-50 login-container"
  >
    <div class="login-content">
      <div class="border-teal p-8 border-t-12 rounded-lg shadow-lg bg-white">
        <div class="mb-5 flex flex-column items-center justify-center">
          <div class="logo mb-3"></div>
          <div
            class="font-size-28 font-bold text-grey-darker block mb-2 text-lg"
          >
            Quản lý ngân sách
          </div>
        </div>
        <div class="mb-3">
          <input
            type="text"
            class="block appearance-none d-height w-full bg-white border border-grey-light hover:border-grey px-2"
            placeholder="Số điện thoại/Email"
            v-model="email"
          />
        </div>
        <div class="mb-3">
          <input
            type="password"
            class="block d-height appearance-none w-full bg-white border border-grey-light hover:border-grey px-2"
            placeholder="Mật khẩu"
            v-model="password"
          />
          <span v-show="isAuthFalse" class="text-red-500 mt-1"
            >username or password is incorrect</span
          >
        </div>
        <div class="flex flex-col gap-2">
          <a
            @click="handleLogin()"
            href="#"
            class="btn btn-primary-outline d-height btn-green"
          >
            <span class="text-white">Đăng nhập</span>
          </a>
          <a
            @click="handleSignup()"
            href="#"
            class="btn-black d-height"
            tabindex="0"
          >
            <span class="text-white">Sign up</span>
          </a>
        </div>

        <div class="mt-2 text-sm leading-5">
          <router-link
            to="/forgot-password"
            class="font-medium text-indigo-600 hover:text-indigo-500 focus:outline-none focus:underline transition ease-in-out duration-150"
          >
            Quên mật khẩu?
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
  name: "Login",
  components: {},
  data() {
    return {
      email: "",
      password: "",
      show: false,
      isVerify: false,
      isLogin: false,
      isAuthFalse: false,
    };
  },
  methods: {
    async handleLogin() {
      this.$store
        .dispatch("authen/loginToken", {
          Email: this.email,
          Password: this.password,
        })
        .then((res) => {
          console.log(this.authenEmail);
          if (this.authenEmail && this.jwtToken) {
            this.$router.push("/");
            this.isAuthFalse = false;
          } else {
            console.log("sai mk");
            this.isAuthFalse = true;
          }
        });
    },
    handleSignup() {},
    recoverPassword() {},
  },
  computed: {
    ...mapState({
      authenEmail: (state) => state.authen.email,
      jwtToken: (state) => state.authen.jwtToken,
    }),
  },
  mounted() {},
};
</script>

<style scoped lang="scss">
.login-container {
  overflow: hidden;
  background-image: url("../../assets/image/background-login.svg");
  background-repeat: no-repeat;
  background-size: cover;
  .login-content {
    width: 400px;
    min-height: 500px;
  }
}
input {
  border: none !important;
  outline: none !important;
  &.focus {
    --tw-bg-opacity: 1;
    background-color: red;
  }
}
.btn-black {
  &:hover {
    span {
      color: black;
    }
  }
}
.btn-green {
  background-color: #43a047;
  display: flex;
  align-items: center;
  justify-content: center;
}
.d-height {
  height: 30px !important;
}
.text-white {
  color: white;
}
.font-size-28 {
  font-size: 28px;
}
.logo {
  width: 55px;
  height: 62px;
}
</style>
