/*
    View for the vehicle. Used to keep the viewmodel clear of UI related logic
*/
define("vehicle/vehicle.view",
    ["jquery", "vehicle/vehicle.viewModel"], function ($, vehicleViewModel) {

        var ist = window.ist || {};

        // View 
        ist.vehicle.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#vehicleBinding")[0],
                initializeForm = function () {
                    // Initialize Forms - For File Upload
                    $("#fileUploadForm").ajaxForm({
                        success: function () {
                            //status("Uploading completed");
                            //progressPercentage(uploadCompletedPercentage + "%");
                            //processingId = data.DocumentFileKey;
                            //requestProcessingStatus();
                            toastr.success("Uploading completed");
                            // viewModel.addVehicleItem().logo(undefined);
                        },
                        dataType: "json",
                        error: function () {
                            //status("Uploading failed. Try again. (Error: " + xhr.statusText + " [" + xhr.status + "])");
                            //showInputArea(true);
                            //showProgressArea(false);
                            //progressPercentage("0%");
                            //alert(status());
                            toastr.error("Uploading failed. Try again.");
                        }
                    });
                },

                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("vehicleTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getVehicles);

                };



            initialize();
            return {
                bindingRoot: bindingRoot,
                initializeForm: initializeForm,
                viewModel: viewModel
            };
        })(vehicleViewModel);

        // Initialize the view model
        if (ist.vehicle.view.bindingRoot) {
            vehicleViewModel.initialize(ist.vehicle.view);
        }
        return ist.vehicle.view;
    });


// Reads File - Print Out Section
function readURL(input) {
    if (input.files && input.files[0]) {
        // ReSharper disable UseOfImplicitGlobalInFunctionScope
        var reader = new FileReader();
        // ReSharper restore UseOfImplicitGlobalInFunctionScope
        reader.onload = function (e) {
            $('#vehicleImage')
                .attr('src', e.target.result)
                .width(120)
                .height(120);
        };

        reader.readAsDataURL(input.files[0]);
    }
}