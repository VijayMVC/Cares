using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.Common;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    public static class TariffTypeHelper
    {
        public static TariffType GetTariffType(DateTime recCreatedDate, DateTime startDate, DateTime endDate, Int64 operationId, List<TariffType> oTariffTypeList)
        {
            TariffType obj = null;
            TimeSpan dtSpan = endDate - startDate;
            
            //converting duration to minutes for standard scale
            var duration = dtSpan.Days * 24 * 60 + dtSpan.Hours * 60 + dtSpan.Minutes;
            //filtering TariffType list on Operation and Record Created Date
            List<TariffType> oReturnedList = oTariffTypeList.FindAll(delegate(TariffType item)
            {
                return (item.OperationId == operationId && item.EffectiveDate <= recCreatedDate);
            });
            //
            Boolean found = false;
            //now get the tarifftype by matching time
            TariffType oReturnedTariffType = oReturnedList.Find(delegate(TariffType item) //changed it to oReturnedList from TariffTypeList
            {
                float newDuration = 0;
                if (item.MeasurementUnitId == (int)(MeasurementUnitEnum.Day))
                    newDuration = item.DurationFrom * (24 * 60);
                else if (item.MeasurementUnitId == (int)(MeasurementUnitEnum.Hour))
                    newDuration = item.DurationFrom * 60;
                else if (item.MeasurementUnitId == (int)(MeasurementUnitEnum.Minute))
                    newDuration = item.DurationFrom;

                if (!found)
                {
                    if (newDuration <= duration)
                    {
                        obj = item;
                        found = true;
                    }
                    return false;
                }
                else
                {
                    float oldDuration = 0;
                    if (obj.MeasurementUnitId == (int)(MeasurementUnitEnum.Day))
                        oldDuration = obj.DurationFrom * (24 * 60);
                    else if (obj.MeasurementUnitId == (int)(MeasurementUnitEnum.Hour))
                        oldDuration = obj.DurationFrom * 60;
                    else if (obj.MeasurementUnitId == (int)(MeasurementUnitEnum.Minute))
                        oldDuration = obj.DurationFrom;

                    if (newDuration >= oldDuration && newDuration <= duration)
                    {
                        if (item.MeasurementUnitId == obj.MeasurementUnitId && item.EffectiveDate >= obj.EffectiveDate)
                        {
                            obj = item;
                        }
                        else if (item.MeasurementUnitId > obj.MeasurementUnitId)
                        {
                            obj = item;
                        }


                    }
                    return false;
                }
            });

            return obj;
        }
    }
}
