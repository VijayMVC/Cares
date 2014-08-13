﻿using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Payment Term Mapper
    /// </summary>
    public static class PaymentTermMapper
    {
        #region Public
        /// <summary>
        ///  Create web api model from domail model
        /// </summary>
        public static PaymentTermDropDown CreateFrom(this DomainModels.PaymentTerm source)
        {
            return new PaymentTermDropDown
            {
                PaymentTermId = source.PaymentTermId,
                PaymentTermName = source.PaymentTermName,
                PaymentTermCode = source.PaymentTermCode
            };
        }
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static DomainModels.PaymentTerm CreateFrom(this PaymentTermDropDown source)
        {
            if (source != null)
            {
                return new DomainModels.PaymentTerm
                {
                    PaymentTermId = source.PaymentTermId,
                    PaymentTermName = source.PaymentTermName,
                    PaymentTermCode = source.PaymentTermCode
                };
            }
            return new DomainModels.PaymentTerm();
        }
        #endregion
    }
}