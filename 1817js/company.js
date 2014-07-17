function player() {
  var money = 0;
  var shares = [];
  return {
    shares : shares,
    money : money
  };
}

function company(ID, VALUE, SIZE) {
  var id = ID;
  var stockvalue = VALUE;
  var size = SIZE; // 2,5,10
  var shares = 0;
  var tokens = [];
  var loosetokens = 0;
  return { };
}

var state = {
  bank_pool = { },
  companies = [],
  
}