
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
        $.getJSON("api/NutritionApi/?name=" + self.parent.foodSelectionInput() + '&group=' + self.parent.foodGroupSelection().code + '&pageNo=' + (page.number + 1) + '&pageLength=' + '20', function (data) {
            self.parent.foods.removeAll();
            data.forEach(function (item) { self.parent.foods.push(item); });
        });
    }
}



function Meal(name) {
    var self = this;
    self.name = name;
    self.foods = ko.observableArray([]);

    self.Calories = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(self.foods(), function (item) {
            total += item.nutrval("ENERC_KCAL");
        });
        return total;
    });
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

    self.trackDate = ko.observable(new Date());
    self.calendar = ko.observable();
    self.dateChange = function (event, date) {
        self.trackDate(event.sender._value);

        self.loadMeals();
    }

    self.Calories = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(self.meals(), function (item) {
            total += item.Calories();
        });
        return total;
    }).extend({throttle: 500});

    self.TotalNutr = function (n) {
        return ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(self.meals(), function (item) {
                ko.utils.arrayForEach(item.foods(), function (food) {
                    total += food.nutrval(n);
                });
            });
            return total.toFixed(2);
        }).extend({throttle: 500});
    };


    self.PercentNutr = function (n) {
        return ko.computed(function () {
            return (self.TotalNutr(n)() / self.Limits[n].val) * 100;
        });
    };

    self.TotalFPED = function (fg) {
        return ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(self.meals(), function (item) {
                ko.utils.arrayForEach(item.foods(), function (food) {
                    total += parseFloat(food.fped(fg)).toFixed(1) - 0;
                });
            });
            return total.toFixed(2);
        }).extend({throttle: 500});
    };

    self.PercentFPED = function (fg) {
        return ko.computed(function () {
            return (self.TotalFPED(fg)() / self.Limits[fg].val) * 100;
        });
    };

    self.TotalFPEDForArray = function (array) {
        var total = 0;
        array.forEach(function (item) {
            total += self.TotalFPED(item)() - 0;
        });
        return total;
    }

    self.FoodGroups = [
        {
            tagname: 'G_TOTAL', val: 9, unit: 'oz', color: '#ffffaa', name: 'Grains', subgroups: [
                { tagname: ['G_WHOLE'], name: 'Whole Grains' },
                { tagname: ['G_REFINED'], name: 'Refined Grains' }
            ]
        },
        {
            tagname: 'V_TOTAL', val: 3.5, unit: 'cups', color: '#aaffaa', name: 'Vegetables', subgroups: [
            ]
        },
        { tagname: 'F_TOTAL', val: 2, unit: 'cups', color: '#ffaaaa', name: 'Fruits', subgroups: [
                        { tagname: ['F_JUICE'], name: 'Fruit Juice'},
                        { tagname: ['F_OTHER', 'F_CITMLB'], name: 'Whole Fruit' },
        ]
        },
        { tagname: 'D_TOTAL', val: 3, unit: 'cups', color: '#aaaaff', name: 'Dairy', subgroups: [
                        { tagname: ['D_CHEESE'], name: 'Cheese' },
                        { tagname: ['D_YOGURT', 'D_MILK'], name: 'Milk & Yogurt' }
        ]        },
        { tagname: 'PF_TOTAL', val: 6.5, unit: 'oz', color: '#ffaaff', name: 'Protein Foods', subgroups: [] }
    ];

    self.Limits = {
        OILS: { val: 8, unit: 'tsp', color: '#ffffee' },
        SOLID_FATS: { val: 29, unit: 'g', color:'#ffffcc' },
        NA: { val: 2300, unit: 'mg', color:'#cccccc' },
        ENERC_KCAL: { val: 2600, unit: 'kcal', color: '#ffffaa' },
    };




    self.loadMeals = function () {

        ko.utils.arrayForEach(self.meals(), function (meal) {
            meal.foods().splice(0, meal.foods().length);
        });

        var query_obj = {
            date: moment(self.trackDate()).format('l'),
            userID: 1,
            populated: 1
        };

        $.getJSON("api/FoodTracker", query_obj, function (data) {
                if (data.$values)
                    data = data.$values;
                async.each(data, function (tracker, callback) {
                    $.getJSON("api/NutritionApi4" + "?foodCode=" + tracker.MainFood.FoodCode, function (fpeds) {

                        var meals = tracker.SelectedMeals.split(';');
                        async.each(meals, function (meal, callback2) {
                            var mealidx = self.mealTimes.indexOf(meal);
                            if (mealidx == -1) { callback2(); return; }
                            var meal = self.meals()[mealidx];

                            var food = new Food(tracker);
                            food.nutrients = tracker.NutVals;

                            food.fpeds = fpeds;
                            food.parentmeal = meal;
                            food.selectedamount(tracker.Amount);
                            food.selectedamountFAST = tracker.Amount;

                            var portion2 = food.portiondescs.filter(function (item) {
                                return item.$id == tracker.Portion.$ref;
                            })[0];
               
                            food.selectedunit(portion2);
                            food.selectedunitFAST = portion2;
                            food.portionweightFAST = food.portionweight();

                            meal.foods().push(food);

                            callback2(null);
                        }, function (err) {

                            
                        });

                        callback(null);
                    });
                }, function (err) {
                    self.meals().forEach(function (meal) {
                        meal.foods.valueHasMutated();
                    });

                });

            

        });

            //$.getJSON("api/FoodTracker", query_obj, function (data) {
            //    data.$values.forEach(function (tracker) {
            //        console.log(tracker);
            //        meals = tracker.SelectedMeals.split(';');
            //        meals.forEach(function (item) {
            //            var mealidx = self.mealTimes.indexOf(item);
            //            if (mealidx != -1) {
            //                var meal = self.meals()[mealidx];

            //                $.getJSON("api/NutritionApi" + "?foodCode=" + tracker.FoodCode, function (foodResponse) {
            //                    $.getJSON("api/NutritionApi2/?foodCode=" + tracker.FoodCode, function (nutvals) {
            //                        $.getJSON("api/NutritionApi4/?foodCode=" + tracker.FoodCode, function (fpeds) {
            //                            var food = new Food(foodResponse);
            //                            food.nutrients = nutvals.$values;
            //                            food.fpeds = fpeds;

            //                            food.parentmeal = meal;

            //                            food.selectedamount(tracker.Amount);

            //                            var portion = food.portiondescs.filter(function (item) {
            //                                return item.PortionCode == tracker.PortionCode;
            //                            })[0];

            //                            food.selectedunit(portion);

            //                                     //     meal.foods().push(food);
            //                            meal.foods().push(food);
            //                        });
            //                    });
            //                });
            //            }
            //        });
            //    });
            //});
    };

    self.loadMeals();
}

function FoodStats(p) {
    var self = this;

    self.parent = p;

    self.targetIdx = function (gender, age) {
        offset = 0;
        if (gender == "male") offset = 1;
        if (age < 3) return 0;
        else if (age < 9) return 1 + offset;
        else if (age < 14) return 3 + offset;
        else if (age < 19) return 5 + offset;
        else if (age < 31) return 7 + offset;
        else if (age < 51) return 9 + offset;
        else return 11 + offset;
    }

    self.TargetPercent = function (code) {
        return (self.parent.selectedFoodNutrValue(self.parent.selectedFood().nutrient(code)) / self.Target(code) * 100).toFixed(0);
    };

    self.Target = function (code, age, gender) {
        if (!age) {
            age = self.parent.Profile.Age;
            gender = self.parent.Profile.Gender;
        }

        var allnutrients = self.NutritionGroups.mineral;
        allnutrients = allnutrients.concat(self.NutritionGroups.vitamin);
        allnutrients = allnutrients.concat(self.NutritionGroups.basic);

        var nutrientgroup = allnutrients.filter(function (item) {
            return item.val == code;
        })[0];

        return nutrientgroup.targets[self.targetIdx(gender, age)];
    };

    self.NutritionGroups = {
        mineral: [
        { val: 301, targets: [700, 1000, 1000, 1300, 1300, 1300, 1300, 1000, 1000, 1000, 1000, 1200, 1200] }, // Calcium
        { val: 306, targets: [3000, 3800, 3800, 4500, 4500, 4700, 4700, 4700, 4700, 4700, 4700, 4700, 4700] },// Potassium
        { val: 307, targets: [1500, 1900, 1900, 2200, 2200, 2300, 2300, 2300, 2300, 2300, 2300, 2300, 2300] }, // Sodium
        { val: 312, targets: [340, 440, 440, 700, 700, 890, 890, 900, 900, 900, 900, 900, 900] }, // Copper
        { val: 303, targets: [7, 10, 10, 8, 8, 15, 11, 18, 8, 18, 8, 8, 8] }, // Iron
        { val: 304, targets: [80, 130, 130, 240, 240, 360, 410, 310, 400, 320, 420, 320, 420] }, // Magnesium
        { val: 305, targets: [460, 500, 500, 1250, 1250, 1250, 1250, 700, 700, 700, 700, 700, 700] }, // Phosphorus
        { val: 317, targets: [20, 30, 30, 40, 40, 55, 55, 55, 55, 55, 55, 55, 55] }, // Selenium
        { val: 309, targets: [3, 5, 5, 8, 8, 9, 11, 8, 11, 8, 11, 8, 11] }, // Zinc
        ],
        vitamin: [
            { val: 320, targets: [300, 400, 400, 600, 600, 700, 900, 700, 900, 700, 900, 700, 900] }, // VitaminA
            { val: 415, targets: [0.5, 0.6, 0.6, 1.0, 1.0, 1.2, 1.3, 1.3, 1.3, 1.3, 1.3, 1.5, 1.7] }, // VitaminB6
            { val: 418, targets: [0.9, 1.2, 1.2, 1.8, 1.8, 2.4, 2.4, 2.4, 2.4, 2.4, 2.4, 2.4, 2.4] }, // VitaminB12
            { val: 401, targets: [15, 25, 25, 45, 45, 65, 75, 75, 90, 75, 90, 75, 90] }, // VitaminC
            { val: 328, targets: [15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15] }, // VitaminD
            { val: 323,  targets: [6, 7, 7, 11, 11, 15, 15, 15, 15, 15, 15, 15, 15] },// VitaminE
            { val: 430,  targets: [30, 55, 55, 60, 60, 75, 75, 90, 120, 90, 120, 90, 120] },// VitaminK
            { val: 435,  targets: [150, 200, 200, 300, 300, 400, 400, 400, 400, 400, 400, 400, 400] },// Folate
            { val: 404,  targets: [0.5, 0.6, 0.6, 0.9, 0.9, 1.0, 1.2, 1.1, 1.2, 1.1, 1.2, 1.1, 1.2] },// Thiamin
            { val: 405,  targets: [0.5, 0.6, 0.6, 0.9, 0.9, 1.0, 1.3, 1.1, 1.3, 1.1, 1.3, 1.1, 1.3] },// Riboflavin
            { val: 406,  targets: [6, 8, 8, 12, 12, 14, 16, 14, 16, 14, 16, 14, 16] },// Niacin
            { val: 421,  targets: [200, 250, 250, 375, 375, 400, 550, 425, 550, 425, 550, 425, 550] },// Choline
        ],
        basic: [
            { val: 208, targets: [] }, // Calories
            { val: 203,  targets: [13, 19, 19, 34, 34, 46, 52, 46, 56, 46, 56, 46, 56] },// Protein
            { val: 205, targets: [130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130] }, // Carbohydrate
            { val: 291, targets: [14, 17, 20, 22, 25, 25, 31, 28, 34, 25, 31, 22, 28] }, // Dietary Fiber
            { val: 204, targets: [] }, // Fat
            { val: 606, targets: [] }, // Saturated Fat
            { val: 645, targets: [] }, // Monounsaturated
            { val: 646, targets: [] },// Polyunsa
        ]
    };
}


function Food(data) {
    if (data == null) {
        data = { MainFood: '', Portions: '', Weights: '' }
    }
    var self = this;

    self.parentmeal = null;
    self.data = data;

    self.selectedamount = ko.observable(1);
    self.selectedunit = ko.observable();
    self.selectedamountFAST;
    self.selectedunitFAST;
    self.portionweightFAST;

    self.selectedmeals = ko.observableArray();

    self.food = data.MainFood;
    self.portiondescs = data.Portions;//.$values;
    self.foodweights = data.Weights;;//.$values;
    self.nutrients = [];
    self.foodgroups = [];
    self.fpeds = [];
    
    self.nutrientsMap = {};

    self.fped = function (fg) {
        var amount = (self.selectedamountFAST == undefined) ? self.selectedamount() : self.selectedamountFAST;
        var weight = (self.portionweightFAST == undefined) ? self.portionweight() : self.portionweightFAST;

        return parseFloat(self.fpeds[fg]).toFixed(2) / 100 * amount * weight;
    };

    self.nutrval = function (tag) {
        code = globalNutrDefs.nutrient(tag);
        if (!code) return 0;

        var amount = (self.selectedamountFAST == undefined) ? self.selectedamount() : self.selectedamountFAST;
        var weight = (self.portionweightFAST == undefined) ? self.portionweight() : self.portionweightFAST;


        return globalNutrDefs.nutritionAmount(self.nutrient(code.NutrientCode).NutrientValue, weight, amount);
    };

    self.nutrient = function (code) {
        if (self.nutrientsMap[code]) return self.nutrientsMap[code];
        value = self.nutrients.filter(function (item) {
            return item.NutrientCode == code;
        })[0];
        self.nutrientsMap[code] = value;
        return value;
    };

    self.portionweight = ko.computed(function () {
        if (self.foodweights == null || self.selectedunit() == null) return 0;
        return self.foodweights.filter(function (item) {
            return item.PortionCode == self.selectedunit().PortionCode;
        })[0].PortionWeight;
    });

    self.clone = function () {
        var food = new Food(self.data);

        food.parentmeal = self.parentmeal;
        
        food.selectedamount(self.selectedamount());
        food.selectedunit(self.selectedunit());

        food.selectedamountFAST = self.selectedamountFAST;
        food.selectedunitFAST = self.selectedunitFAST;

        food.food = self.food;
        food.portiondescs = self.portiondescs;
        food.foodweights = self.foodweights;
        food.nutrients = self.nutrients;
        food.foodgroups = self.foodgroups;
        food.fpeds = self.fpeds;
        return food;
    }
}



function FoodGroup(name, code) {
    var self = this;
    self.name = name;
    self.code = code;
}

function NutrDefs() {
    var self = this;
    
    $.getJSON("api/NutritionApi2", function (nutdefs) {
        if (nutdefs.$values)
            nutdefs = nutdefs.$values;
        nutdefs.forEach(function (item) {
            self.by_tag[item.Tagname] = item;
            self.by_id[item.NutrientCode] = item;
        });
    });

    self.by_tag = {};
    self.by_id = {};


    self.nutrient = function (name) {
        var result = self.by_id[name];
        if (result == undefined) result = self.by_tag[name];
        return result;
    }

    self.nutritionAmount = function (nutr_val, weight, amount) {
        if (nutr_val == null) return 0;
//        var nutrdef = self.nutrient(nutr_val.NutrientCode);
        return Math.round((nutr_val / 100) * weight * amount);
    };
}

function UserProfile(p) {
    var self = this;
    self.parent = p;

    self.Age = 0;
    self.Gender = "male";
    self.Name = "";

    self.fill = function () {
        userid = $.cookie('userid');
        $.getJSON('api/UserApi/?userID=' + userid, function (data) {
            self.Age = data.Age;
            self.Gender = data.Gender;
            self.Name = data.Name;
        });
    };

    self.fill();
}

function NutritionViewModel() {

    var self = this;
    
    self.foodSelectionInput = ko.observable();
    self.foods = ko.observableArray();
    self.foodGroups = [
    new FoodGroup("All Foods", 0),
    new FoodGroup("Milk and milk products", 1),
    new FoodGroup("Meat, poultry, fish, and mixtues", 2),
    new FoodGroup("Eggs", 3),
    new FoodGroup("Legumes, nuts, and seeds", 4),
    new FoodGroup("Grain Products", 5),
    new FoodGroup("Fruits", 6),
    new FoodGroup("Vegetables", 7),
    new FoodGroup("Fats, Oils, and salad dressings", 8),
    new FoodGroup("Sugars, sweets, and beverages", 9)
    ];
    self.foodGroupSelection = ko.observable(self.foodGroups[0]);

    self.selectedFood = ko.observable(new Food());

    self.foodTracker = ko.observable(new FoodTracker());

    self.foodStats = new FoodStats(self);

    self.Profile = new UserProfile(self);

    self.foodPagination = ko.observable(new Pagination(self));

    self.selectedFoodNutr = function (nutrient) {
        if (!nutrient) return {};
        return globalNutrDefs.nutrient(nutrient.NutrientCode);
    }

    self.selectedFoodNutrValue = function (nutrient) {
        if (!nutrient) return 0;
        value = globalNutrDefs.nutritionAmount(nutrient.NutrientValue, self.selectedFood().portionweight(), self.selectedFood().selectedamount());
        return value;
    };

    self.selectedFoodNutrVal = function (nutrient) {
        if (!nutrient) return 0;
        value = self.selectedFoodNutrValue(nutrient);
        unit = globalNutrDefs.nutrient(nutrient.NutrientCode).Unit;
        return value + " " + unit;
    };

self.selectFoodGroup = function (fg) {
    self.foodGroupSelection(fg);
    self.foodSelectionInputChanged();
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
        
        $.getJSON("api/NutritionApi/?name=" + newval + '&group=' + self.foodGroupSelection().code + '&pageNo=' + '1' + '&pageLength=' + '20', function (data) {
            self.foods.removeAll();
            if (data.$values)
                data = data.$values;
            data.forEach(function (item) { self.foods.push(item); });


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
            $.getJSON("api/NutritionApi4/?foodCode=" + food.FoodCode, function (fpeds) {
                var food = new Food(data);
                food.nutrients = nutvals.$values?nutvals.$values:nutvals;
                food.fpeds = fpeds;

                self.selectedFood(food);
            });
        });

    });
}


self.addFood = function () {
    var selectedMeals = "";
    ko.utils.arrayForEach(self.selectedFood().selectedmeals(), function (item) {
        var meal = self.foodTracker().meals()[self.foodTracker().mealTimes.indexOf(item)];
        self.selectedFood().parentmeal = meal;
        // deep copy selected food into meals
        var clonefood = self.selectedFood().clone();
        clonefood.selectedamountFAST = clonefood.selectedamount();
        clonefood.selectedunitFAST = clonefood.selectedunit();
        clonefood.portionweightFAST = clonefood.portionweight();
        meal.foods.push(clonefood);

        selectedMeals += item + ";";
    });

    var tracker_obj = {
        FoodCode: self.selectedFood().food.FoodCode,
        Amount: self.selectedFood().selectedamount(),
        PortionCode: self.selectedFood().selectedunit().PortionCode,
        SelectedMeals: selectedMeals,
        UserID: 1,
        TrackDate: moment(self.foodTracker().trackDate()).format('l')
    };

    $.post("api/FoodTracker", tracker_obj, function (data) {
        console.log(data);
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

var globalNutrDefs = new NutrDefs();

if (document.getElementById('NutritionViewContent') != null)
    ko.applyBindings(new NutritionViewModel(), document.getElementById('NutritionViewContent'));
