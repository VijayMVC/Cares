
CREATE VIEW [dbo].[BPMainView]
AS
SELECT     BPM.BPMainID, BPM.CompanyID, BPM.BPMainCode, BPM.BPMainName, BPM.BPMainDescription, 
                      BPM.IsSystemGuarantor, BPM.SystemGuarantorID, BPM.NonSystemGuarantor, BPM.BusinessLegalStatusID, BPM.IsIndividual, 
                      BPM.DealingEmployeeID, BPM.RowVersion, BPM.IsActive, BPM.IsDeleted, BPM.IsPrivate, BPM.IsReadOnly, 
                      BPM.RecCreatedDt, BPM.RecCreatedBy, BPM.RecLastUpdatedDt, BPM.RecLastUpdatedBy, 
					  BPM.PaymentTermID,PT.PaymentTermCode + '-' + PT.PaymentTermName AS PaymentTermCodeName,
					  BRT.BPRatingTypeID,BRT.BPRatingTypeCode+'-'+BRT.BPRatingTypeName BPRatingTypeCodeName,
                      CMP.CompanyCode + '-' + CMP.CompanyName AS CompanyCodeName, CMP.IsActive AS CompanyIsActive,
						case BPM.IsIndividual when 1 then 'I-'+Cast(BPM.BPMainID as nvarchar(20)) 
													 when 0 then 'C-'+Cast(BPM.BPMainID as nvarchar(20)) 
						end BPMainIDSequence,
					  BPM.BPEmailAddress, BPM.BPIsValid
						
													 
FROM         BPMain BPM
					LEFT OUTER JOIN Company CMP ON BPM.CompanyID = CMP.CompanyID
					left outer join BPRatingType BRT on BPM.BPRatingTypeID=BRT.BPRatingTypeID
					inner join PaymentTerm PT on BPM.PaymentTermID = PT.PaymentTermID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'BPMainView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BPMain"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "Company"
            Begin Extent = 
               Top = 68
               Left = 264
               Bottom = 176
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'BPMainView';

