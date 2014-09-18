
Create VIEW [dbo].[NRTMainView]
AS
select NM.*,OW.OperationID from NRTMain NM
inner join operationsworkplace OW on OW.OperationsWorkPlaceID = NM.OpenLocationID