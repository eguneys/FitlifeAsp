
function Page(number, p) {
    var self = this;

    self.parent = p;
    self.number = number;
    self.array = ko.observableArray([]);

    self.isCurrentPage = ko.computed(function () {
        return (self.number == p.currentPage()) ? "active" : "";
    }, self);
}

function Pagination(nvm) {
    var self = this;



    self.parent = nvm;

    self.items = ko.observableArray([]);
    self.currentPage = ko.observable(0);
    self.pageLength = ko.observable(20);

    self.leftWatch = ko.observable(0);

    self.pageCount = ko.computed(function () {
        return self.items().length / self.pageLength();
    }, self);

    self.hasPrevious = ko.computed(function () {
        return (self.leftWatch() > 1) ? "" : "disabled";
    }, self);

    self.hasNext = ko.computed(function () {
        return (self.leftWatch() < self.pageCount()) ? "" : "disabled";
    }, self);

    self.itemsWatch = ko.computed(function () {
        return self.items.slice(self.leftWatch(), self.leftWatch() + 5);
    }, self);

    self.pageLeft = function () {
        if (self.hasPrevious() == "disabled") return;
        self.leftWatch(self.leftWatch() - 4);
    }

    self.pageRight = function () {
        if (self.hasNext() == "disabled") return;
        self.leftWatch(self.leftWatch() + 4);
    }

    self.goPage = function (page) {
        self.currentPage(page.number);
        $.getJSON("api/NutritionApi/?name=" + self.parent.foodSelectionInput() + '&pageNo=' + (page.number + 1) + '&pageLength=' + '20', function (data) {
            self.parent.foods.removeAll();
            data.$values.forEach(function (item) { self.parent.foods.push(item); });
        });
    }
}



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
        data = { MainFood: '', Portions: '', Weights: '' }
    }
    var self = this;

    self.parentmeal = null;

    self.selectedamount = ko.observable(1);
    self.selectedunit = ko.observable();
    self.selectedmeals = ko.observableArray();

    self.food = data.MainFood;
    self.portiondescs = data.Portions.$values;
    self.foodweights = data.Weights.$values;
    self.nutrients = [];
    self.foodgroups = [];

    self.portionweight = ko.computed(function () {
        if (self.foodweights == null || self.selectedunit() == null) return 0;
        return self.foodweights.filter(function (item) {
            return item.PortionCode == self.selectedunit().PortionCode;
        })[0].PortionWeight;
    });
}



function FoodGroup(name) {
    var self = this;
    self.name = name;
    self.amount = ko.observable();
}

function NutrDefs(defs) {
    var self = this;
    self.by_tag = {};
    self.by_id = {};

    defs.forEach(function (item) {
        self.by_tag[item.Tagname] = item;
        self.by_id[item.NutrientCode] = item;
    });
}

function NutritionViewModel() {

    var self = this;

    $.getJSON("api/NutritionApi2", function (nutdefs) {
        self.nutrdefs = new NutrDefs(nutdefs.$values);
        console.log(self.nutrdefs);
    });

    self.foodSelectionInput = ko.observable();
    self.foods = ko.observableArray();
    self.foodGroups = [
    new FoodGroup("All Foods"),
    new FoodGroup("Dairy")
    ];
    self.foodGroupSelection = ko.observable(self.foodGroups[0]);

    self.selectedFood = ko.observable(new Food());

    self.foodTracker = ko.observable(new FoodTracker());

    self.foodPagination = ko.observable(new Pagination(self));


    self.nutr = function (nutr_no) {
        return self.nutrdefs.by_id[nutr_no];
    }

    self.nutrient = function (name) {
        return self.nutrdefs.by_tag[name];
    }

    self.nutritionAmount = function (nutr_val) {
        if (nutr_val == null) return 0;
        var nutrdef = self.nutr(nutr_val.NutrientCode);
        return Math.round((nutr_val.NutrientValue / 100) * self.selectedFood().portionweight() * self.selectedFood().selectedamount());
    };


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
        
        $.getJSON("api/NutritionApi/?name=" + newval + '&pageNo=' + '1' + '&pageLength=' + '20', function (data) {
            self.foods.removeAll();
            data.$values.forEach(function (item) { self.foods.push(item); });


            $.getJSON("api/NutritionApi/?name=" + newval + '&getpageno=1', function (data) {
                self.foodPagination().items.removeAll();
                datalength = data;
                for (var i = 0; i < (datalength / self.foodPagination().pageLength()); i++) {
                    self.foodPagination().items.push(new Page(i, self.foodPagination()));
                }
            });
        });



    }, 1000);
}

self.selectFood = function (food) {
    $.getJSON("api/NutritionApi/?foodCode=" + food.FoodCode, function (data) {
        $.getJSON("api/NutritionApi2/?foodCode=" + food.FoodCode, function (nutvals) {
            var food = new Food(data);
            food.nutrients = nutvals.$values;
            self.selectedFood(food);
        });

    });
}


self.addFood = function () {
    ko.utils.arrayForEach(self.selectedFood().selectedmeals(), function (item) {
        var meal = self.foodTracker().meals()[self.foodTracker().mealTimes.indexOf(item)];
        self.selectedFood().parentmeal = meal;
        // deep copy selected food into meals
        meal.foods.push(jQuery.extend(true, {}, self.selectedFood()));
    });
}

self.removeFood = function (food) {
    food.parentmeal.foods.remove(food);
}
self.editFood = function (food) {
    food.parentmeal.foods.remove(food);
    self.selectedFood(food);
}
};

if (document.getElementById('NutritionViewContent') != null)
    ko.applyBindings(new NutritionViewModel(), document.getElementById('NutritionViewContent'));
