
--select * from VehicleOtherDetailView
CREATE VIEW [dbo].[VehicleOtherDetailView]
AS
select VO.* from VehicleOtherDetail VO
--inner join Vehicle V
--on VO.VehicleID=V.VehicleID