create VIEW [dbo].[rptNRTDriverView]
AS
--	Created : MAR, Dated:27-Dec-09

SELECT     ND.NRTDriverID, ND.ChaufferID, ND.DesigGradeID, ND.LicenseExpDt, ND.LicenseNo, 
                      ND.StartDtTime, ND.EndDtTime, 
                      ND.NRTVehicleID, NV.NRTMainID, E.EmpCode AS DriverCode, 
                      E.EmpFName + '-' + E.EmpMName + '-' + E.EmpLName AS DriverName
FROM       NRTDriver ND 
INNER JOIN NRTVehicle NV ON ND.NRTVehicleID = NV.NRTVehicleID AND NV.NRTVehicleID = ND.NRTVehicleID 
INNER JOIN Employee E ON ND.ChaufferID = E.EmployeeID