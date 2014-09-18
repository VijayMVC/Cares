/*
    View for the Design Grade Used to keep the viewmodel clear of UI related logic
*/
define("designGrade/designGrade.view",
    ["jquery", "designGrade/designGrade.viewModel"], function ($, designGradeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.DesignGrade.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#DesignGradeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDesignGrades);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(designGradeViewModel);
        // Initialize the view model
        if (ist.DesignGrade.view.bindingRoot) {
            designGradeViewModel.initialize(ist.DesignGrade.view);
        }
        return ist.DesignGrade.view;
    });