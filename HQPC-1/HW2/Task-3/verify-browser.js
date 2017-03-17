function verifyBrowser(event, arguments) {
  var myWindow = window;
  var browser = window.navigator.appCodeName;
  var isMozilla;
  if(browser === 'Mozilla') {
      isMozilla = true;
  }
  else {
      isMozilla = false;
  }
  
  if(isMozilla) {
      alert("Yes");
  }
  else {
      alert("No");
  }
}