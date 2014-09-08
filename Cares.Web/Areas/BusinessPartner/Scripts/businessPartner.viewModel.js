/*
    Module with the view model for the Business Partner
*/
define("businessPartner/businessPartner.viewModel",
    ["jquery", "amplify", "ko", "businessPartner/businessPartner.dataservice", "businessPartner/businessPartnerWithKoMapping.model", "common/confirmation.viewModel", "common/pagination"],
    function ($, amplify, ko, dataservice, model, confirmation, pagination) {
        var ist = window.ist || {};
        ist.businessPartner = {
            viewModel: (function () {
                var// the view 
                    view,
                      // Show Filter Section
                    filterSectionVisilble = ko.observable(false),
                    // Active BusinessPartner
                    selectedBusinessPartner = ko.observable(),
                     // listview selected BusinessPartner
                    listSelectedBusinessPartner = ko.observable(),
                    // #region Arrays
                    // BusinessPartners
                    businessPartners = ko.observableArray([]),
                    // #endregion Arrays
                    // #region Busy Indicators
                    isLoadingBusinessPartners = ko.observable(false),
                    // #endregion Busy Indicators
                    // #region Observables
                    // Companies Array
                    companies = ko.observableArray([]),
                    // Payment Terms Array 
                    paymentTerms = ko.observableArray([]),
                    // Business Partners Rating Types Array
                    bpRatingTypes = ko.observableArray([]),
                    // Business Legal Statuses Array
                    businessLegalStatuses = ko.observableArray([]),
                    // Response Business  Partners Array
                    respBusinessPartners = ko.observableArray([]),
                    // Business Legal Statuses Array
                    dealingEmployees = ko.observableArray([]),
                    // Business Partner Companies Array
                    businessPartnerCompanies = ko.observableArray([]),
                    // Countries Array
                    countries = ko.observableArray([]),
                    // Occupation Types Array
                    occupationTypes = ko.observableArray([]),
                    // Business Segments Array
                    businessSegments = ko.observableArray([]),
                     // Business Partner SubType Array
                    businessPartnerSubTypes = ko.observableArray([]),
                    // Phone Types Array
                    phoneTypes = ko.observableArray([]),
                    // Address Types Array
                    addressTypes = ko.observableArray([]),
                    // Country Regions Array
                    countryRegions = ko.observableArray([]),
                    // filtered Country Regions Array
                    filteredcountryRegions = ko.observableArray([]),
                    // Country Regions Array
                    countryCitites = ko.observableArray([]),
                    // Filtered Country Cities Array
                    filteredCountryCities = ko.observableArray([]),
                    // Sub Regions Array
                    subRegions = ko.observableArray([]),
                    // Filtered Sub Regions Array
                    filteredSubRegions = ko.observableArray([]),
                    // Areas Array
                    areas = ko.observableArray([]),
                    // filtered Areas Array
                    filteredAreas = ko.observableArray([]),
                    // Marketing Channel Array
                    marketingChannels = ko.observableArray([]),
                    // Business Partner Relationship Type Array
                    businessPartnerRelationshipTypes = ko.observableArray([]),
                    // Sort On
                    sortOn = ko.observable(1),
                    // Sort Order -  true means asc, false means desc
                    sortIsAsc = ko.observable(true),
                    // Is Business Partner Editor Visible
                    isBusinessPartnerEditorVisible = ko.observable(false),
                    // Pagination
                    pager = ko.observable(),
                    // search filter
                    searchFilter = ko.observable(),
                    // select Filter
                    selectFilter = ko.observable(),
                    // selected Country from dropdown
                    selectedCountry = ko.observable(),
                    // #region Utility Functions
                    // Select filter option Individual or Company list
                    optionIndividualOrCompany = [{ Id: true, Name: 'Individual' }, { Id: false, Name: 'Company' }],
                    // Select Gender list
                    optionGenderList = [{ Id: 'M', Name: 'Male' }, { Id: 'F', Name: 'Female' }],
                    // Select Martial Status list
                    optionMaritalStatusList = [
                        { Id: 'M', Name: 'Married' },
                        { Id: 'S', Name: 'Single' },
                         { Id: 'C', Name: 'Committed' },
                         { Id: 'D', Name: 'Divorced' },
                         { Id: 'W', Name: 'Widowed' }
                    ],
                    // Select business partner
                    selectBusinessPartner = function (businessPartner) {
                        if (listSelectedBusinessPartner() !== businessPartner) {
                            listSelectedBusinessPartner(businessPartner);
                        }
                    },
                     //For Edit, Tariff Type Id
                    selectedBusinessPartnerId = ko.observable(),
                    // Edit a Business Partner - In a Form
                    onEditBusinessPartner = function (businessPartner, e) {
                        selectedBusinessPartnerId(businessPartner.businessPartnerListId().split('-')[1]);
                        getBusinessPartnerById(selectedBusinessPartnerId());
                        showBusinessPartnerEditor();
                        e.stopImmediatePropagation();
                    },
                    // Collapase filter section
                    collapseFilterSection = function () {
                        filterSectionVisilble(false);
                    },
                    //Show filter section
                    showFilterSection = function () {
                        filterSectionVisilble(true);
                    },
                    //country selection change event
                    onCountrySelectionChange = function (value) {
                        if (selectedBusinessPartner().businessPartnerAddressNew().countryId() !== undefined)
                            getRegionsByCountry(selectedBusinessPartner().businessPartnerAddressNew().countryId().CountryId);
                    },
                    //get regions by country          
                    getRegionsByCountry = function (countryId) {
                        isLoadingBusinessPartners(true);
                        //filter Regions by country
                        filteredcountryRegions.removeAll();
                        _.each(countryRegions(), function (item) {
                            if (item.CountryId === countryId)
                                filteredcountryRegions.push(item);
                        });
                        filteredcountryRegions.valueHasMutated();
                        //filter cities by country
                        filteredCountryCities.removeAll();
                        _.each(countryCitites(), function (item) {
                            if (item.CountryId === countryId)
                                filteredCountryCities.push(item);
                        });
                        filteredCountryCities.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                    //region selection change event
                    onRegionSelectionChange = function (value) {
                        if (selectedBusinessPartner().businessPartnerAddressNew().regionId() !== undefined)
                            getSubRegionsByRegion(selectedBusinessPartner().businessPartnerAddressNew().regionId().RegionId);
                        else {
                            // empty sub regions
                            filteredSubRegions.removeAll();
                            filteredSubRegions.valueHasMutated();
                        }
                    },
                    //get sub regions by region          
                    getSubRegionsByRegion = function (regionId) {
                        isLoadingBusinessPartners(true);
                        // get filtered sub regions
                        filteredSubRegions.removeAll();
                        _.each(subRegions(), function (item) {
                            if (item.RegionId === regionId)
                                filteredSubRegions.push(item);
                        });
                        filteredSubRegions.valueHasMutated();
                        // get filtered cities
                        filteredCountryCities.removeAll();
                        _.each(countryCitites(), function (item) {
                            if (item.RegionId === regionId)
                                filteredCountryCities.push(item);
                        });
                        filteredCountryCities.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                    //sub region selection change event
                    onSubRegionSelectionChange = function (value) {
                        if (selectedBusinessPartner().businessPartnerAddressNew().subRegionId() !== undefined)
                            getCitiesBySubRegion(selectedBusinessPartner().businessPartnerAddressNew().subRegionId().SubRegionId);
                    },
                    //get cities by sub region          
                    getCitiesBySubRegion = function (subRegionId) {
                        isLoadingBusinessPartners(true);
                        // get filtered cities
                        filteredCountryCities.removeAll();
                        _.each(countryCitites(), function (item) {
                            if (item.SubRegionId === subRegionId)
                                filteredCountryCities.push(item);
                        });
                        filteredCountryCities.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                      //city selection change event
                    onCitySelectionChange = function (value) {
                        if (selectedBusinessPartner().businessPartnerAddressNew().cityId() !== undefined)
                            getAreasByCity(selectedBusinessPartner().businessPartnerAddressNew().cityId().CityId);
                        else {
                            // empty area list
                            filteredAreas.removeAll();
                            filteredAreas.valueHasMutated();
                        }
                    },
                    //get Areas by city          
                    getAreasByCity = function (cityId) {
                        isLoadingBusinessPartners(true);
                        // get areas by city
                        filteredAreas.removeAll();
                        _.each(areas(), function (item) {
                            if (item.CityId === cityId)
                                filteredAreas.push(item);
                        });
                        filteredAreas.valueHasMutated();
                        isLoadingBusinessPartners(false);
                    },
                    // get business partner by id
                    getBusinessPartnerById = function (businessPartnerId) {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartnerById({
                            id: businessPartnerId
                        }, {
                            success: function (data) {
                                selectedBusinessPartner(model.BusinessPartnerClientMapper(data));
                                selectedBusinessPartner().reset();
                                isLoadingBusinessPartners(false);
                            },
                            error: function () {
                                isLoadingBusinessPartners(false);
                                toastr.error("Error!");
                            }
                        });
                    },
                    // Show BusinessPartner Editor
                    showBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(true);
                    },
                    // close BusinessPartner Editor
                    onCloseBusinessPartnerEditor = function () {
                        if (selectedBusinessPartner().hasChanges()) {
                            confirmation.messageText("Do you want to save changes?");
                            confirmation.afterProceed(onSaveBusinessPartner);
                            confirmation.afterCancel(function () {
                                selectedBusinessPartner().reset();
                                closeBusinessPartnerEditor();
                            });
                            confirmation.show();
                            return;
                        }
                        closeBusinessPartnerEditor();
                    },
                    // close Business Partner Editor
                    closeBusinessPartnerEditor = function () {
                        isBusinessPartnerEditorVisible(false);
                    },
                    // Delete a BusinessPartner
                    onDeleteBusinessPartner = function (businessPartner) {
                        if (!businessPartner.businessPartnerId()) {
                            businessPartners.remove(businessPartner);
                            return;
                        }
                        // Ask for confirmation
                        confirmation.afterProceed(function () {
                            deleteBusinessPartner(businessPartner);
                        });
                        confirmation.show();
                    },
                     // Delete BusinessPartner
                    deleteBusinessPartner = function (businessPartner) {
                        dataservice.deleteBusinessPartner(businessPartner, {
                            success: function () {
                                businessPartners.remove(businessPartner);
                                toastr.success("Business Partner removed successfully");
                                getBusinessPartners();
                            },
                            error: function () {
                                toastr.error("Failed to remove Business Partner!");
                            }
                        });
                    },
                    // Delete a BusinessPartner In Type
                    onDeleteBusinessPartnerInType = function (businessPartnerInType) {
                        selectedBusinessPartner().businessPartnerInTypes.remove(businessPartnerInType);
                        return;
                    },
                     // Delete a BusinessPartner Relationship Item
                    onDeleteBusinessPartnerRelationshipItem = function (businessPartnerRelationshipItem) {
                        selectedBusinessPartner().businessPartnerRelationshipItemList.remove(businessPartnerRelationshipItem);
                        return;
                    },
                    // Delete a BusinessPartner Phone Item
                    onDeleteBusinessPartnerPhone = function (businessPartnerPhone) {
                        selectedBusinessPartner().businessPartnerPhoneNumbers.remove(businessPartnerPhone);
                        return;
                    },
                    // Delete a BusinessPartner Address Item
                    onDeleteBusinessPartnerAddress = function (businessPartnerAddress) {
                        selectedBusinessPartner().businessPartnerAddressList.remove(businessPartnerAddress);
                        return;

                    },
                    // Delete a BusinessPartner Marketing Channel Item
                    onDeleteBusinessPartnerMarketingChannel = function (businessPartnerMarketingChannel) {
                        selectedBusinessPartner().businessPartnerMarketingChannels.remove(businessPartnerMarketingChannel);
                        return;
                    },
                    // Do Before Add BusinessPartner InType Item
                    doBeforeAddItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerInTypeNew().isValid()) {
                            selectedBusinessPartner().businessPartnerInTypeNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner In Type
                    onAddBusinessPartnerInType = function () {
                        // check validation error before add
                        if (doBeforeAddItem()) {
                            var businessPartnerInType = model.BusinessPartnerInType(
                                undefined,
                                '',
                                selectedBusinessPartner().businessPartnerInTypeNew().fromDate(),
                                selectedBusinessPartner().businessPartnerInTypeNew().toDate(),
                                selectedBusinessPartner().businessPartnerId(),
                                selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId() !== undefined ? selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().BusinessPartnerSubTypeId : undefined,
                                selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId() !== undefined ? selectedBusinessPartner().businessPartnerInTypeNew().businessPartnerSubTypeId().BusinessPartnerSubTypeCodeName : undefined,
                                selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId() !== undefined ? selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().BpRatingTypeId : undefined,
                                selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId() !== undefined ? selectedBusinessPartner().businessPartnerInTypeNew().bpRatingTypeId().BpRatingTypeCodeName : undefined
                            );
                            selectedBusinessPartner().businessPartnerInTypes.push(businessPartnerInType);
                            selectedBusinessPartner().businessPartnerInTypes.valueHasMutated();
                            // emplty input fields
                            selectedBusinessPartner().businessPartnerInTypeNew(model.BusinessPartnerInType(undefined, '', undefined, undefined, undefined, undefined, undefined, undefined, undefined));
                        }
                    },
                    // Do Before Add BusinessPartner Phone Item
                    doBeforeAddPhoneItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerPhoneNumberNew().isValid()) {
                            selectedBusinessPartner().businessPartnerPhoneNumberNew().errors.showAllMessages();
                            flag = false;
                        } else {
                            // check if isdefault true entry already there
                            var isDefaultAlreadyThere = false;
                            _.each(selectedBusinessPartner().businessPartnerPhoneNumbers(), function (item) {
                                if (item.isDefault() == true)
                                    isDefaultAlreadyThere = true;
                            });
                            if (isDefaultAlreadyThere && selectedBusinessPartner().businessPartnerPhoneNumberNew().isDefault()) {
                                toastr.info("Default record already there!");
                                return false;
                            }
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Phone
                    onAddBusinessPartnerPhone = function () {
                        // check validation error before add
                        if (doBeforeAddPhoneItem()) {
                            var businessPartnerPhone = model.BusinessPartnerPhone(
                                undefined,
                                selectedBusinessPartner().businessPartnerPhoneNumberNew().isDefault(),
                                selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneNumber(),
                                selectedBusinessPartner().businessPartnerId(),
                                selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId() !== undefined ? selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().PhoneTypeId : undefined,
                                selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId() !== undefined ? selectedBusinessPartner().businessPartnerPhoneNumberNew().phoneTypeId().PhoneTypeCodeName : undefined
                            );
                            selectedBusinessPartner().businessPartnerPhoneNumbers.push(businessPartnerPhone);
                            selectedBusinessPartner().businessPartnerPhoneNumbers.valueHasMutated();
                            // emplty input fields
                            selectedBusinessPartner().businessPartnerPhoneNumberNew(model.BusinessPartnerPhone(undefined, false, undefined, undefined, undefined));
                        }
                    },
                    // Do Before Add BusinessPartner Address Item
                    doBeforeAddAddressItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerAddressNew().isValid()) {
                            selectedBusinessPartner().businessPartnerAddressNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Address
                    onAddBusinessPartnerAddress = function () {
                        // check validation error before add
                        if (doBeforeAddAddressItem()) {
                            var businessPartnerAddress = model.BusinessPartnerAddress(
                                undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().contactPerson(),
                                selectedBusinessPartner().businessPartnerAddressNew().streetAddress(),
                                selectedBusinessPartner().businessPartnerAddressNew().emailAddress(),
                                selectedBusinessPartner().businessPartnerAddressNew().webPage(),
                                selectedBusinessPartner().businessPartnerAddressNew().zipCode(),
                                selectedBusinessPartner().businessPartnerAddressNew().poBox(),
                                selectedBusinessPartner().businessPartnerAddressNew().countryId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().countryId().CountryId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().countryId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().countryId().CountryCodeName : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().regionId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().regionId().RegionId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().regionId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().regionId().RegionCodeName : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().subRegionId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().subRegionId().SubRegionId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().subRegionId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().subRegionId().SubRegionCodeName : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().cityId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().cityId().CityId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().cityId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().cityId().CityCodeName : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().areaId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().areaId().AreaId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().areaId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().areaId().AreaCodeName : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().addressTypeId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().addressTypeId().AddressTypeId : undefined,
                                selectedBusinessPartner().businessPartnerAddressNew().addressTypeId() !== undefined ? selectedBusinessPartner().businessPartnerAddressNew().addressTypeId().AddressTypeCodeName : undefined,
                                selectedBusinessPartner().businessPartnerId()
                            );
                            selectedBusinessPartner().businessPartnerAddressList.push(businessPartnerAddress);
                            selectedBusinessPartner().businessPartnerAddressList.valueHasMutated();

                            // emplty input fields
                            selectedBusinessPartner().businessPartnerAddressNew(model.BusinessPartnerAddress(undefined, "", "", "", "", "", "", undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined));
                        }
                    },
                     // Do Before Add BusinessPartner Address Item
                    doBeforeAddMarketingChannelItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerMarketingChannelNew().isValid()) {
                            selectedBusinessPartner().businessPartnerMarketingChannelNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Marketing Channel
                    onAddBusinessPartnerMarketingChannel = function () {
                        // check validation error before add
                        if (doBeforeAddMarketingChannelItem()) {
                            var businessPartnerMarketingChannel = model.BusinessPartnerMarketingChannel(
                                selectedBusinessPartner().businessPartnerMarketingChannelNew().marketingChannelId() !== undefined ? selectedBusinessPartner().businessPartnerMarketingChannelNew().marketingChannelId().MarketingChannelId : undefined,
                                selectedBusinessPartner().businessPartnerMarketingChannelNew().marketingChannelId() !== undefined ? selectedBusinessPartner().businessPartnerMarketingChannelNew().marketingChannelId().MarketingChannelCodeName : undefined,
                                selectedBusinessPartner().businessPartnerId()
                            );
                            selectedBusinessPartner().businessPartnerMarketingChannels.push(businessPartnerMarketingChannel);
                            selectedBusinessPartner().businessPartnerMarketingChannels.valueHasMutated();
                            // emplty input fields
                            selectedBusinessPartner().businessPartnerMarketingChannelNew(model.BusinessPartnerMarketingChannel(undefined, undefined, undefined));
                        }
                    },
                     // Do Before Add BusinessPartner Relationship Item
                    doBeforeAddBusinessPartnerRelationshipItem = function () {
                        var flag = true;
                        if (!selectedBusinessPartner().businessPartnerRelationshipItemNew().isValid()) {
                            selectedBusinessPartner().businessPartnerRelationshipItemNew().errors.showAllMessages();
                            flag = false;
                        }
                        return flag;
                    },
                    // Add a BusinessPartner Relationship Item
                    onAddBusinessPartnerRelationshipItem = function () {
                        // check validation error before add
                        if (doBeforeAddBusinessPartnerRelationshipItem()) {
                            var businessPartnerRelationshipItem = model.BusinessPartnerRelationshipItem(
                                undefined,
                                selectedBusinessPartner().businessPartnerId(),
                                selectedBusinessPartner().businessPartnerRelationshipItemNew().businessPartnerRelationshipTypeId().BusinessPartnerRelationshipTypeId,
                                selectedBusinessPartner().businessPartnerRelationshipItemNew().businessPartnerRelationshipTypeId().BusinessPartnerRelationshipTypeCodeName,
                                selectedBusinessPartner().businessPartnerRelationshipItemNew().secondaryBusinessPartnerId().BusinessPartnerId,
                                selectedBusinessPartner().businessPartnerRelationshipItemNew().secondaryBusinessPartnerId().BusinessPartnerCodeName
                            );
                            selectedBusinessPartner().businessPartnerRelationshipItemList.push(businessPartnerRelationshipItem);
                            selectedBusinessPartner().businessPartnerRelationshipItemList.valueHasMutated();
                            // emplty input fields
                            selectedBusinessPartner().businessPartnerRelationshipItemNew(model.BusinessPartnerRelationshipItem(undefined, undefined, undefined, undefined, undefined, undefined));
                        }
                    },
                    // Create Business Partner
                    createBusinessPartner = function () {
                        var businessPartner = model.BusinessPartnerDetail.Create();
                        selectedBusinessPartner(businessPartner);
                    },
                    // Create BusinessPartner - In Form
                    createBusinessPartnerInForm = function () {
                        createBusinessPartner();
                        showBusinessPartnerEditor();
                    },
                    // Save BusinessPartner
                    onSaveBusinessPartner = function (businessPartner) {
                        if (doBeforeSave()) {
                            // Commits and Selects the Row
                            saveBusinessPartner(businessPartner);
                        }
                    },
                    // Do Before Logic
                    doBeforeSave = function () {
                        var flag = true;
                        if (selectedBusinessPartner().isIndividual()) {
                            if (!selectedBusinessPartner().isValid() || !selectedBusinessPartner().businessPartnerIndividual().isValid()) {
                                selectedBusinessPartner().errors.showAllMessages();
                                selectedBusinessPartner().businessPartnerIndividual().errors.showAllMessages();
                                flag = false;
                            }
                        }
                        if (!selectedBusinessPartner().isIndividual()) {
                            if (!selectedBusinessPartner().isValid() || !selectedBusinessPartner().businessPartnerCompany().isValid()) {
                                selectedBusinessPartner().errors.showAllMessages();
                                selectedBusinessPartner().businessPartnerCompany().errors.showAllMessages();
                                flag = false;
                            }
                        }

                        return flag;
                    },
                    // Initialize the view model
                    initialize = function (specifiedView) {
                        view = specifiedView;
                        ko.applyBindings(view.viewModel, view.bindingRoot);
                        getBase();
                        // Set Pager
                        pager(pagination.Pagination({}, businessPartners, getBusinessPartners));
                        getBusinessPartners();
                    },
                    // Map BusinessPartners - Server to Client
                    mapBusinessPartners = function (data) {
                        var businessPartnerList = [];
                        _.each(data.BusinessPartners, function (item) {
                            var businessPartner = new model.BusinessPartner(item);
                            businessPartnerList.push(businessPartner);
                        });
                        ko.utils.arrayPushAll(businessPartners(), businessPartnerList);
                        businessPartners.valueHasMutated();
                    },
                    // Get Base
                    getBase = function () {
                        dataservice.getBusinessPartnerBase({
                            success: function (data) {
                                //Company array
                                companies.removeAll();
                                ko.utils.arrayPushAll(companies(), data.ResponseCompanies);
                                companies.valueHasMutated();
                                // Payment Terms array
                                paymentTerms.removeAll();
                                ko.utils.arrayPushAll(paymentTerms(), data.ResponsePaymentTerms);
                                paymentTerms.valueHasMutated();
                                // Business Partner Rating Types array
                                bpRatingTypes.removeAll();
                                ko.utils.arrayPushAll(bpRatingTypes(), data.ResponseBPRatingTypes);
                                bpRatingTypes.valueHasMutated();
                                // Business Legal Statuses array
                                businessLegalStatuses.removeAll();
                                ko.utils.arrayPushAll(businessLegalStatuses(), data.ResponseBusinessLegalStatuses);
                                businessLegalStatuses.valueHasMutated();
                                // Business Legal Statuses array
                                respBusinessPartners.removeAll();
                                ko.utils.arrayPushAll(respBusinessPartners(), data.ResponseBusinessPartners);
                                respBusinessPartners.valueHasMutated();
                                // Business Legal Statuses array
                                dealingEmployees.removeAll();
                                ko.utils.arrayPushAll(dealingEmployees(), data.ResponseDealingEmployees);
                                dealingEmployees.valueHasMutated();
                                // Business Partner Companies array
                                businessPartnerCompanies.removeAll();
                                ko.utils.arrayPushAll(businessPartnerCompanies(), data.ResponseBusinessPartnerCompanies);
                                businessPartnerCompanies.valueHasMutated();
                                // Countries array
                                countries.removeAll();
                                ko.utils.arrayPushAll(countries(), data.ResponseCountries);
                                countries.valueHasMutated();
                                // Occupation Types array
                                occupationTypes.removeAll();
                                ko.utils.arrayPushAll(occupationTypes(), data.ResponseOccupationTypes);
                                occupationTypes.valueHasMutated();
                                // Business Segments array
                                businessSegments.removeAll();
                                ko.utils.arrayPushAll(businessSegments(), data.ResponseBusinessSegments);
                                businessSegments.valueHasMutated();
                                // Business Partner SubType array
                                businessPartnerSubTypes.removeAll();
                                ko.utils.arrayPushAll(businessPartnerSubTypes(), data.ResponseBusinessPartnerSubTypes);
                                businessPartnerSubTypes.valueHasMutated();
                                // Phone Types array
                                phoneTypes.removeAll();
                                ko.utils.arrayPushAll(phoneTypes(), data.ResponsePhoneTypes);
                                phoneTypes.valueHasMutated();
                                // Address Types array
                                addressTypes.removeAll();
                                ko.utils.arrayPushAll(addressTypes(), data.ResponseAddressTypes);
                                addressTypes.valueHasMutated();
                                // Marketing Channel array
                                marketingChannels.removeAll();
                                ko.utils.arrayPushAll(marketingChannels(), data.ResponseMarketingChannels);
                                marketingChannels.valueHasMutated();
                                // Business Partner Relationship array
                                businessPartnerRelationshipTypes.removeAll();
                                ko.utils.arrayPushAll(businessPartnerRelationshipTypes(), data.ResponseBusinessPartnerRelationshipTypes);
                                businessPartnerRelationshipTypes.valueHasMutated();
                                //country Regions array
                                countryRegions.removeAll();
                                ko.utils.arrayPushAll(countryRegions(), data.ResponseRegions);
                                countryRegions.valueHasMutated();
                                //country Cities array
                                countryCitites.removeAll();
                                ko.utils.arrayPushAll(countryCitites(), data.ResponseCities);
                                countryCitites.valueHasMutated();
                                ////filtered Country Cities
                                //filteredCountryCities.removeAll();
                                //ko.utils.arrayPushAll(filteredCountryCities(), data.ResponseCities);
                                //filteredCountryCities.valueHasMutated();
                                //Sub Regions array
                                subRegions.removeAll();
                                ko.utils.arrayPushAll(subRegions(), data.ResponseSubRegions);
                                subRegions.valueHasMutated();
                                //Area array
                                areas.removeAll();
                                ko.utils.arrayPushAll(areas(), data.ResponseAreas);
                                areas.valueHasMutated();
                            },
                            error: function () {
                                toastr.error("Failed to load base data");
                            }
                        });
                    },
                    // Search 
                    search = function () {
                        pager().reset();
                        getBusinessPartners();
                    },
                    reset = function () {
                        searchFilter(undefined);
                        selectFilter(undefined);
                        pager().reset();
                        getBusinessPartners();
                    },
                    // Get businessPartners
                    getBusinessPartners = function () {
                        isLoadingBusinessPartners(true);
                        dataservice.getBusinessPartners({
                            SearchString: searchFilter(),
                            SelectOption: selectFilter(),
                            PageNo: pager().currentPage(), SortBy: sortOn(), IsAsc: sortIsAsc()
                        }, {
                            success: function (data) {
                                pager().totalCount(data.TotalCount);
                                businessPartners.removeAll();
                                mapBusinessPartners(data);
                                isLoadingBusinessPartners(false);
                            },
                            error: function () {
                                isLoadingBusinessPartners(false);
                                toastr.error("Failed to load businessPartners!");
                            }
                        });
                    },
                    // Save Business Partner
                    saveBusinessPartner = function (businessPartner) {
                        var method = "updateBusinessPartner";
                        if (!selectedBusinessPartner().businessPartnerId()) {
                            method = "createBusinessPartner";
                        }
                        dataservice[method](model.BusinessPartnerServerMapper(selectedBusinessPartner()), {
                            success: function () {
                                // Reset Changes
                                selectedBusinessPartner().reset();
                                // If BusinessPartner is specified then select it
                                if (businessPartner) {
                                    selectBusinessPartner(businessPartner);
                                }
                                if (isBusinessPartnerEditorVisible) {
                                    closeBusinessPartnerEditor();
                                }
                                getBusinessPartners();
                                toastr.success("Business Partner saved successfully");
                            },
                            error: function () {
                                toastr.error('Failed to save business Partner!');
                            }
                        });
                    };
                // #endregion Service Calls
                return {
                    // Observables
                    selectedBusinessPartner: selectedBusinessPartner,
                    isLoadingBusinessPartners: isLoadingBusinessPartners,
                    businessPartners: businessPartners,
                    searchFilter: searchFilter,
                    reset: reset,
                    selectFilter: selectFilter,
                    sortOn: sortOn,
                    sortIsAsc: sortIsAsc,
                    // Observables Arrays
                    companies: companies,
                    paymentTerms: paymentTerms,
                    bpRatingTypes: bpRatingTypes,
                    businessLegalStatuses: businessLegalStatuses,
                    respBusinessPartners: respBusinessPartners,
                    dealingEmployees: dealingEmployees,
                    businessPartnerCompanies: businessPartnerCompanies,
                    countries: countries,
                    occupationTypes: occupationTypes,
                    businessSegments: businessSegments,
                    businessPartnerSubTypes: businessPartnerSubTypes,
                    phoneTypes: phoneTypes,
                    addressTypes: addressTypes,
                    // Utility Methods
                    onSaveBusinessPartner: onSaveBusinessPartner,
                    createBusinessPartner: createBusinessPartner,
                    onDeleteBusinessPartner: onDeleteBusinessPartner,
                    initialize: initialize,
                    selectBusinessPartner: selectBusinessPartner,
                    search: search,
                    getBusinessPartners: getBusinessPartners,
                    pager: pager,
                    onEditBusinessPartner: onEditBusinessPartner,
                    showBusinessPartnerEditor: showBusinessPartnerEditor,
                    onCloseBusinessPartnerEditor: onCloseBusinessPartnerEditor,
                    isBusinessPartnerEditorVisible: isBusinessPartnerEditorVisible,
                    createBusinessPartnerInForm: createBusinessPartnerInForm,
                    optionIndividualOrCompany: optionIndividualOrCompany,
                    listSelectedBusinessPartner: listSelectedBusinessPartner,
                    optionGenderList: optionGenderList,
                    optionMaritalStatusList: optionMaritalStatusList,
                    onDeleteBusinessPartnerInType: onDeleteBusinessPartnerInType,
                    onAddBusinessPartnerInType: onAddBusinessPartnerInType,
                    doBeforeAddPhoneItem: doBeforeAddPhoneItem,
                    onAddBusinessPartnerPhone: onAddBusinessPartnerPhone,
                    onDeleteBusinessPartnerPhone: onDeleteBusinessPartnerPhone,
                    doBeforeAddAddressItem: doBeforeAddAddressItem,
                    onAddBusinessPartnerAddress: onAddBusinessPartnerAddress,
                    onDeleteBusinessPartnerAddress: onDeleteBusinessPartnerAddress,
                    onCountrySelectionChange: onCountrySelectionChange,
                    selectedCountry: selectedCountry,
                    countryRegions: countryRegions,
                    countryCitites: countryCitites,
                    onRegionSelectionChange: onRegionSelectionChange,
                    subRegions: subRegions,
                    areas: areas,
                    filteredSubRegions: filteredSubRegions,
                    filteredCountryCities: filteredCountryCities,
                    filteredcountryRegions: filteredcountryRegions,
                    onSubRegionSelectionChange: onSubRegionSelectionChange,
                    filteredAreas: filteredAreas,
                    onCitySelectionChange: onCitySelectionChange,
                    marketingChannels: marketingChannels,
                    onDeleteBusinessPartnerMarketingChannel: onDeleteBusinessPartnerMarketingChannel,
                    onAddBusinessPartnerMarketingChannel: onAddBusinessPartnerMarketingChannel,
                    businessPartnerRelationshipTypes: businessPartnerRelationshipTypes,
                    onAddBusinessPartnerRelationshipItem: onAddBusinessPartnerRelationshipItem,
                    onDeleteBusinessPartnerRelationshipItem: onDeleteBusinessPartnerRelationshipItem,
                    filterSectionVisilble: filterSectionVisilble,
                    collapseFilterSection: collapseFilterSection,
                    showFilterSection: showFilterSection,
                    // Utility Methods
                };
            })()
        };
        return ist.businessPartner.viewModel;
    });
