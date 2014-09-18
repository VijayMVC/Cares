CREATE VIEW [dbo].[CreditLimitView]
AS
SELECT     dbo.CreditLimit.CreditLimitID, dbo.CreditLimit.IsIndividual, dbo.CreditLimit.Description, dbo.CreditLimit.CreditLimit, dbo.CreditLimit.BPRatingTypeID, 
                      dbo.CreditLimit.BPSubTypeID, dbo.CreditLimit.IsActive, dbo.CreditLimit.IsDeleted, dbo.CreditLimit.IsReadOnly, dbo.CreditLimit.IsPrivate, dbo.CreditLimit.RowVersion, 
                      dbo.CreditLimit.RecCreatedBy, dbo.CreditLimit.RecCreatedDt, dbo.CreditLimit.RecLastUpdatedBy, dbo.CreditLimit.RecLastUpdatedDt, 
                      dbo.BPRatingType.BPRatingTypeCode + '-' + dbo.BPRatingType.BPRatingTypeName AS BPRatingTypeCodeName, 
                      dbo.BPSubType.BPSubTypeCode + '-' + dbo.BPSubType.BPSubTypeName AS BPSubTypeCodeName, dbo.BPSubType.BPSubTypeKey, 
                      dbo.BPSubType.BPMainTypeID, dbo.BPMainType.BPMainTypeCode + '-' + dbo.BPMainType.BPMainTypeName AS BPMainTypeCodeName, 
                      dbo.BPMainType.BPMainTypeKey
FROM         dbo.CreditLimit INNER JOIN
                      dbo.BPRatingType ON dbo.CreditLimit.BPRatingTypeID = dbo.BPRatingType.BPRatingTypeID INNER JOIN
                      dbo.BPSubType ON dbo.CreditLimit.BPSubTypeID = dbo.BPSubType.BPSubTypeID INNER JOIN
                      dbo.BPMainType ON dbo.BPSubType.BPMainTypeID = dbo.BPMainType.BPMainTypeID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CreditLimitView';


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
         Begin Table = "CreditLimit"
            Begin Extent = 
               Top = 9
               Left = 33
               Bottom = 126
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "BPRatingType"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 123
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "BPSubType"
            Begin Extent = 
               Top = 6
               Left = 498
               Bottom = 123
               Right = 694
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "BPMainType"
            Begin Extent = 
               Top = 6
               Left = 732
               Bottom = 123
               Right = 932
            End
            DisplayFlags = 280
            TopColumn = 1
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CreditLimitView';

