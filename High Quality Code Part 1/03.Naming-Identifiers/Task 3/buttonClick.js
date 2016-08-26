function _ClickON_TheButton( THE_event, argumenti) {
  var moqProzorec= window,
      brauzyra = moqProzorec.navigator.appCodeName,
      ism=brauzyra=="Mozilla";
  if(ism) {
    alert("Yes");
  } else {
    alert("No");
  }
}