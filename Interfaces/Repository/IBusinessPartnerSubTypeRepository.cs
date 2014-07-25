﻿using Models.DomainModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Business Partner SubType Repository Interface
    /// </summary>
    public interface IBusinessPartnerSubTypeRepository : IBaseRepository<BusinessPartnerSubType, int>
    {
        ///// <summary>
        ///// Get Busienss partner Individual by Name and Id
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //BusinessPartnerIndividual GetBusinessPartnerIndividualByName(string name, int id);
        ///// <summary>
        ///// Get business partner individual by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //BusinessPartnerIndividual GetById(long id);
    }
}
