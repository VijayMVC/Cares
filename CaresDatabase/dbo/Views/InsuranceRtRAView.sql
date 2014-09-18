
Create VIEW [dbo].[InsuranceRtRAView]
AS
SELECT     dbo.InsuranceType.InsuranceTypeCode, dbo.InsuranceRtMain.InsuranceRtMainID, dbo.InsuranceRtMain.TariffTypeCode, dbo.InsuranceRtMain.InsuranceRtMainCode, 
                      dbo.InsuranceRt.InsuranceRtID, dbo.InsuranceRt.InsuranceTypeID, dbo.InsuranceRt.HireGroupDetailID, dbo.InsuranceRt.InsuranceRate, dbo.InsuranceRt.StartDt, 
                      dbo.InsuranceRt.IsDeleted, dbo.InsuranceRt.RecCreatedDt
FROM         dbo.InsuranceType INNER JOIN
                      dbo.InsuranceRt ON dbo.InsuranceType.InsuranceTypeID = dbo.InsuranceRt.InsuranceTypeID INNER JOIN
                      dbo.InsuranceRtMain ON dbo.InsuranceRt.InsuranceRtMainID = dbo.InsuranceRtMain.InsuranceRtMainID