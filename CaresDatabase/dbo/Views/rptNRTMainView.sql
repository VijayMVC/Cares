
CREATE VIEW [dbo].[rptNRTMainView]
AS
-- Created : MAR, Dated:27-Dec-09
select 
NM.NRTMainID, NM.NRTTypeID, NM.NRTMainDecsription, NM.OpenLocationID, NM.CloseLocationID, NM.NRTStatusID, NM.StartDtTime, NM.EndDtTime, 
NM.RowVersion, NM.IsActive, 
NM.IsPrivate, NM.IsDeleted, NM.IsReadOnly, NM.RecCreatedBy, NM.RecCreatedDt, NM.RecLastUpdatedBy, NM.RecLastUpdatedDt,
NT.NRTTypeCode, NT.NRTTypeName,

OW.OperationID, OP.OperationCode, OP.OperationName, OW.LocationCode as OpenLocationCode, OC.LocationCode as CloseLocationCode


from NRTMain NM

inner join operationsworkplace OW on OW.OperationsWorkPlaceID = NM.OpenLocationID
inner join operationsworkplace OC on OC.OperationsWorkPlaceID = NM.CloseLocationID
INNER JOIN Operation OP on OW.OperationID = OP.OperationID
inner join NRTType NT on NM.NrtTypeID = NT.NRTTypeID