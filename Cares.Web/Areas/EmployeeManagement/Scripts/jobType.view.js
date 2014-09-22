/*
    View for the Job Type Used to keep the viewmodel clear of UI related logic
*/
define("jobType/jobType.view",
    ["jquery", "jobType/jobType.viewModel"], function ($, jobTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.JobType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#JobTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getJobTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(jobTypeViewModel);
        // Initialize the view model
        if (ist.JobType.view.bindingRoot) {
            jobTypeViewModel.initialize(ist.JobType.view);
        }
        return ist.JobType.view;
    });