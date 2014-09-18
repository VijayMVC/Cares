CREATE VIEW [dbo].[NRTQueueView]
AS
SELECT     dbo.NRTMain.NRTMainID, dbo.NRTMain.NRTTypeID, dbo.NRTMain.NRTMainDecsription, dbo.NRTMain.OpenLocationID, dbo.NRTMain.CloseLocationID, 
                      dbo.NRTMain.NRTStatusID, dbo.NRTMain.StartDtTime, dbo.NRTMain.EndDtTime, dbo.NRTMain.RowVersion, dbo.NRTMain.IsActive, dbo.NRTMain.IsPrivate, 
                      dbo.NRTMain.IsDeleted, dbo.NRTMain.IsReadOnly, dbo.NRTMain.RecCreatedBy, dbo.NRTMain.RecCreatedDt, dbo.NRTMain.RecLastUpdatedBy, 
                      dbo.NRTMain.RecLastUpdatedDt, dbo.NRTType.NRTTypeCode + '-' + dbo.NRTType.NRTTypeName AS NRTTypeCodeName, 
                      dbo.RAStatus.RAStatusCode + '-' + dbo.RAStatus.RAStatusName AS Status, dbo.OperationsWorkplace.LocationCode AS OpenLocation, 
                      COW.LocationCode AS CloseLocation
FROM         dbo.NRTMain INNER JOIN
                      dbo.NRTType ON dbo.NRTMain.NRTTypeID = dbo.NRTType.NRTTypeID INNER JOIN
                      dbo.RAStatus ON dbo.NRTMain.NRTStatusID = dbo.RAStatus.RAStatusID INNER JOIN
                      dbo.OperationsWorkplace ON dbo.NRTMain.OpenLocationID = dbo.OperationsWorkplace.OperationsWorkplaceID INNER JOIN
                      dbo.OperationsWorkplace AS COW ON dbo.NRTMain.CloseLocationID = COW.OperationsWorkplaceID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTQueueView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTQueueView';


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
         Begin Table = "NRTMain"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 13
         End
         Begin Table = "NRTType"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 123
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RAStatus"
            Begin Extent = 
               Top = 6
               Left = 478
               Bottom = 123
               Right = 665
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OperationsWorkplace"
            Begin Extent = 
               Top = 6
               Left = 703
               Bottom = 123
               Right = 906
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COW"
            Begin Extent = 
               Top = 6
               Left = 944
               Bottom = 123
               Right = 1147
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
         Or', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTQueueView';

