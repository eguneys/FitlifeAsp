ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepickerOptions || {},
            $el = $(element);

        $el.datepicker(options);

        $el.datepicker("setDate", moment().format("l"));

        // handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($el.datepicker("getDate"));
        });

        // handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $el.datepicker("destroy");
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $el = $(element);
        
        // handle date dat coming via json from Microsoft
        if (String(value).indexOf('/Date(') == 0) {
            value = new Date(parseInt(value.replace(/\/Date\((.*?)\)\//gi, "$1")));
        }

        var current = $el.datepicker("getDate");

        if (value - current != 0) {
            $el.datepicker("setDate", value);
        }
    }
}

function MuscleGroup(name, value) {
    var self = this;

    self.name = name;
    self.value = value;
}

function ProgressViewModel() {
    var self = this;

    self.muscleGroups = [
        new MuscleGroup("Chest", "chest"),
        new MuscleGroup("Back/Biceps", "back"),
        new MuscleGroup("Shoulder/Triceps", "shoulder"),
        new MuscleGroup("Legs", "legs")
    ];

    self.selectedMuscleGroup = ko.observable(self.muscleGroups[0]);

    self.selectedDate = ko.observable();

    self.photoDescription = ko.observable();

    self.uploadStart = function (data, event, param1) {

       // console.log(moment(self.selectedDate()).format());

        var response_obj = {
            UserID: 1,
            Date: moment().format(), // moment(self.selectedDate()).format(),
            PhotoSource: param1.result.data.link,
            PhotoDescription: self.photoDescription(),
            MuscleGroup: self.selectedMuscleGroup().value
        }
   //     $.post("api/ProgressApi", response_obj, function () {
        $.post("Progress/SaveBodyPhoto", response_obj, function () {
        }).done(function () {
            console.log('done');
        });
    }
}

if (document.getElementById('ProgressViewContent') != null)
    ko.applyBindings(new ProgressViewModel(), document.getElementById('ProgressViewContent'));
