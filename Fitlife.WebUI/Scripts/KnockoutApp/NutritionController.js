function FoodTracker() {
    var self = this;
    var mealTimes = [
    "breakfast",
    "lunch",
    "dinner",
    "snacks"];

    var meals = ko.observableArray([
    ]);
}


function Food(description, amount, unit, time) {
    var self = this;
    self.description = ko.observable(description);
    self.amount = ko.observable(amount);
    self.unit = ko.observable(unit);
    self.time = ko.observable(time);

    self.nutrients = ko.observableArray();
    self.foodGroups = ko.observableArray();
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
    self.foodGroups = ko.observableArray();
    self.foodGroupSelection = ko.observable(self.foodGroups()[0]);

    self.selectedFood = ko.observable(new Food());

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
            console.log(self.foods());
        });


    }, 1000);
}

};


ko.applyBindings(new NutritionViewModel());