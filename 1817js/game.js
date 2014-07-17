function newgame(count) {
 /*
  * Private functions
  */
  
  function initializePrivates() {
    var privates = [];
    privates.push({id: 0, name: "Union Bridge Co.", price: 80, abilities: ["bridgeDiscount"], swag: {"bridge":2}});
    privates.push({id: 0, name: "Ohio Bridge Co.", price: 40, abilities: ["bridgeDiscount"], swag: {"bridge":1}});
    privates.push({id: 0, name: "Minor Coal Mine", price: 30, abilities: [], swag: {"coal":1}});
    privates.push({id: 0, name: "Coal Mine", price: 60, abilities: [], swag: {"coal":2}});
    privates.push({id: 0, name: "Major Coal Mine", price: 90, abilities: [], swag: {"coal":3}});
    privates.push({id: 0, name: "Minor Mail Contract", price: 60, abilities: ["mailContract"], swag: {"mailContract":10}});
    privates.push({id: 0, name: "Mail Contract", price: 90, abilities: ["mailContract"], swag: {"mailContract":15}});
    privates.push({id: 0, name: "Major Mail Contract", price: 120, abilities: ["mailContract"], swag: {"mailContract":20}});
    privates.push({id: 0, name: "Mountain Engineers", price: 40, abilities: ["mountainBonus"], swag: {}});
    privates.push({id: 0, name: "Pittsburgh Steel Mill", price: 40, abilities: ["Pittsburgh"], swag: {}});
    privates.push({id: 0, name: "Train Station", price: 80, abilities: ["extraToken"], swag: {}});
    if(richUncle)
      privates.push({id: 0, name: "Loan from a Rich Uncle", price: 100, abilities: [], swag: {}});
    return privates;
  }
  
  function initializeCompanies() {
    var companies = [];
    companies.push({id: 00, name: "Alton & Southern", media: "Alton"});
    companies.push({id: 01, name: "Arcade & Attica", media: "Arcade"});
    companies.push({id: 02, name: "Bessemer", media: "Bessemer"});
    companies.push({id: 03, name: "Boston & Albany", media: "BA"});
    companies.push({id: 04, name: "Chocago Belt", media: "Belt"});
    companies.push({id: 05, name: "Delaware & Lackawanna", media: "Lackawanna"});
    companies.push({id: 06, name: "Elgin, Joliet, and Fugumagoo", media: "Joliet"});
    companies.push({id: 07, name: "Grand Trunk", media: "Trunk"});
    companies.push({id: 08, name: "Housatonic", media: "Housatonic"});
    companies.push({id: 09, name: "Morristown and Erie", media: "ME"});
    companies.push({id: 10, name: "Pittsburgh & Lake Erie", media: "PLE"});
    companies.push({id: 11, name: "Pittsburgh & Shawmut", media: "Shawmut"});
    companies.push({id: 12, name: "Providence and Worcester", media: "PW"});
    companies.push({id: 13, name: "Rutland", media: "Rutland"});
    companies.push({id: 14, name: "Southern", media: "TheS"});
    companies.push({id: 15, name: "Strasburg", media: "Strasburg"});
    companies.push({id: 16, name: "Union", media: "Union"});
    companies.push({id: 17, name: "Warren & Trumble", media: "WandT"});
    companies.push({id: 18, name: "West Chester", media: "WC"});
    companies.push({id: 19, name: "Western", media: "TheW"});
    return companies;
  }
  
 /*
  * Initialize the game
  */
  var playerCount = count;
  var players = [];
  var moneyPerPlayer = ceil(1260/playerCount); // Has factors 1-10. But who am I to stop you playing an 11 player game.
  for(var i=1; i<=playerCount;i++) {
    players.push({name: arguments[i], id: i-1, shares:{}, shareCount:0, privates: []});
  }
  var kitty = 200;
  var availablePrivates = initializePrivates();
  var availableCompanies = initializeCompanies();
});