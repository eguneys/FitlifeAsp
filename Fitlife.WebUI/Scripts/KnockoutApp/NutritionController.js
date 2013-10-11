function Meal(name) {
    var self = this;
    self.name = name;
    self.foods = ko.observableArray();
}

function FoodTracker() {
    var self = this;

    self.mealTimes = [
    "breakfast",
    "lunch",
    "dinner",
    "snacks"];

    self.mealAmounts = [
    1,2,3,4,5
    ];

    self.meals = ko.observableArray([
    new Meal(self.mealTimes[0]),
    new Meal(self.mealTimes[1]),
    new Meal(self.mealTimes[2]),
    new Meal(self.mealTimes[3])
    ]);
}


function Food(data) {
    if (data == null) {
        data = { MainFood: '', Portions: '', Weights: ''}
    }
    var self = this;
    self.selectedamount = 1;
    self.selectedunit = null;
    self.selectedmeals = ko.observableArray();

    self.food = data.MainFood;
    self.portiondescs = data.Portions;
    self.foodweights = data.Weights;
    self.nutrients = [];
    self.foodgroups = [];
}



function FoodGroup(name) {
    var self = this;
    self.name = name;
    self.amount = ko.observable();
}

function NutritionViewModel() {

    var self = this;

    self.foodSelectionInput = ko.observable();
    self.foods = ko.observableArray();
    self.foodGroups = [
    new FoodGroup("All Foods"),
    new FoodGroup("Dairy")
    ];
    self.foodGroupSelection = ko.observable(self.foodGroups[0]);

    self.selectedFood = ko.observable(new Food());

    self.foodTracker = ko.observable(new FoodTracker());

self.selectFoodGroup = function (fg) {
    self.foodGroupSelection(fg);
    console.log(self.foodGroupSelection);
}

var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();

self.foodSelectionInputChanged = function () {
    delay(function () {
        var newval = $('#inputfoodselection').val();
        if (!newval || newval === '') return;

        self.foodSelectionInput(newval);


        $.getJSON("api/NutritionApi/?name=" + newval, function (data) {
            self.foods.removeAll();
            data.$values.forEach(function (item) { self.foods.push(item); });
        });


    }, 1000);
}

self.selectFood = function (food) {
    $.getJSON("api/NutritionApi/?foodCode=" + food.FoodCode, function (data) {
        $.getJSON("api/NutritionApi2/?foodCode=" + food.FoodCode, function (nutvals) {
            var food = new Food(data);
            food.nutrients = nutvals;
            console.log(food);
            self.selectedFood(food);
        });

    });
}


self.addFood = function () {
    ko.utils.arrayForEach(self.selectedFood().selectedmeals(), function (item) {
        self.foodTracker().meals()[self.foodTracker().mealTimes.indexOf(item)].foods.push(self.selectedFood());
    });
}

self.removeFood = function (food) {

}
};


ko.applyBindings(new NutritionViewModel());