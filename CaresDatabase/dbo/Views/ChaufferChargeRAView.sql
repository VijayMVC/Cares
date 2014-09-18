--select * from ChaufferChargeRAview
CREATE VIEW [dbo].[ChaufferChargeRAView]
AS
SELECT     --dbo.Designation.DesignationID, dbo.Designation.DesignationCode, dbo.Designation.DesignationKey, 
	dbo.DesigGrade.DesigGradeID, 
                      dbo.DesigGrade.DesigGradeCode, dbo.ChaufferChargeMain.ChaufferChargeMainID, dbo.ChaufferChargeMain.TariffTypeCode, dbo.ChaufferCharge.ChaufferChargeID, 
                      dbo.ChaufferCharge.ChaufferChargeRate, dbo.ChaufferCharge.IsDeleted AS ChaufferChargeIsDeleted, dbo.ChaufferCharge.StartDt AS ChaufferChargeStartDt
FROM         dbo.ChaufferChargeMain INNER JOIN
                      dbo.ChaufferCharge ON dbo.ChaufferChargeMain.ChaufferChargeMainID = dbo.ChaufferCharge.ChaufferChargeMainID INNER JOIN
                      dbo.DesigGrade ON dbo.ChaufferCharge.DesigGradeID = dbo.DesigGrade.DesigGradeID 
--		INNER JOIN
                     -- dbo.Designation ON dbo.DesigGrade.DesignationID = dbo.Designation.DesignationID