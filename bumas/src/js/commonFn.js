var commonFn = {
  //cache
  setCookie: function (name, value, exp_days) {
    const d = new Date();
    d.setTime(d.getTime() + exp_days * 24 * 60 * 60 * 1000);
    document.cookie =
      name + "=" + value + ";" + "expires=" + d.toUTCString() + ";path=/";
  },
  getCookie: function (name) {
    const cname = name + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(";");
    for (let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) == " ") {
        c = c.substring(1);
      }
      if (c.indexOf(cname) == 0) {
        return c.substring(cname.length, c.length);
      }
    }
    return "";
  },
  deleteCookie: function (name) {
    const d = new Date();
    d.setTime(d.getTime() - 60 * 60 * 1000);
    document.cookie = name + "=;" + "expires=" + d.toUTCString() + ";path=/";
  },
  testFn: function () {
    console.log("success");
  },
};
export default commonFn;
