

ko.bindingHandlers.googleChart = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        google.load("visualization", "1", { packages: ["corechart"] });

        var value = valueAccessor();

        var valueUnwrapped = ko.unwrap(value);

        var FoodTracker = allBindingsAccessor()['foodTracker'];
        var FoodGroups = FoodTracker.FoodGroups;
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        var value = valueAccessor();

        var valueUnwrapped = ko.unwrap(value);

        var FoodTracker = allBindingsAccessor()['foodTracker'];
        var FoodGroups = FoodTracker.FoodGroups;


        google.setOnLoadCallback(drawChart);
        if (google.visualization) drawChart();
        function drawChart() {


            var data = {
                cols: [
            { id: 'fgroup', label: 'Food Groups', type: 'string' }
                ],
                rows: [
                    {
                        c: [
                            { v: "Food Groups" }
                        ]
                    }
                ]
            };
            
            var options = {
                title: 'Daily Intake',
                colors: [],
                flll: 100,
                vAxis: {
                    gridlines: {
                        count: 10
                    }
                },
                hAxis: {
                    title: 'Total Percentage of Target'
                }
            };


            for (var i in [0, 1, 2, 3, 4]) {
                var j = i;
                j++;
                var value = FoodGroups[i];

                data['cols'][j] = { id: value.name, label: value.name, type: 'number' };
                options.colors[i] = value.color;
                console.log(value.tagname);
                data['rows'][0].c[j] = { v:( (FoodTracker.TotalFPED(value.tagname)() / value.val) * 100).toFixed(2)};
            }
            console.log(data);

            var chart = new google.visualization.ColumnChart(element);
            var datatable = new google.visualization.DataTable(
                data
                );

            chart.draw(datatable, options);
        };
    }
};

ko.bindingHandlers.kendoDatePicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        // handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($(element).datepicker("getDate"));
        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });
    }
}