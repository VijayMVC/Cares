
CREATE VIEW [dbo].[NRTVehicleView]
AS
SELECT     dbo.NRTVehicle.NRTVehicleID, dbo.NRTVehicle.NRTMainID, dbo.NRTVehicle.VehicleID, dbo.NRTVehicle.RowVersion, dbo.NRTVehicle.IsActive, 
                      dbo.NRTVehicle.IsDeleted, dbo.NRTVehicle.IsPrivate, dbo.NRTVehicle.IsReadOnly, dbo.NRTVehicle.RecCreatedDt, dbo.NRTVehicle.RecCreatedBy, 
                      dbo.NRTVehicle.RecLastUpdatedDt, dbo.NRTVehicle.RecLastUpdatedBy, dbo.Vehicle.PlateNumber, dbo.Vehicle.ModelYear, dbo.Vehicle.VehicleMakeID, 
                      dbo.Vehicle.VehicleCategoryID, dbo.Vehicle.VehicleModelID, dbo.VehicleMake.VehicleMakeCode + '-' + dbo.VehicleMake.VehicleMakeName AS VehicleMakeCodeName,
                       dbo.VehicleCategory.VehicleCategoryCode + '-' + dbo.VehicleCategory.VehicleCategoryName AS VehicleCategoryCodeName, 
                      dbo.VehicleModel.VehicleModelCode + '-' + dbo.VehicleModel.VehicleModelName AS VehicleModelCodeName,
						dbo.Vehicle.RowVersion as VehicleRowVersion,dbo.Vehicle.TankSize
						
FROM         dbo.NRTVehicle INNER JOIN
                      dbo.Vehicle ON dbo.NRTVehicle.VehicleID = dbo.Vehicle.VehicleID INNER JOIN
                      dbo.VehicleMake ON dbo.Vehicle.VehicleMakeID = dbo.VehicleMake.VehicleMakeID INNER JOIN
                      dbo.VehicleCategory ON dbo.Vehicle.VehicleCategoryID = dbo.VehicleCategory.VehicleCategoryID INNER JOIN
                      dbo.VehicleModel ON dbo.Vehicle.VehicleModelID = dbo.VehicleModel.VehicleModelID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTVehicleView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTVehicleView';


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
         Begin Table = "NRTVehicle"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "Vehicle"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 123
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "VehicleMake"
            Begin Extent = 
               Top = 6
               Left = 497
               Bottom = 123
               Right = 697
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VehicleCategory"
            Begin Extent = 
               Top = 6
               Left = 735
               Bottom = 123
               Right = 955
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VehicleModel"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 243
               Right = 241
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'NRTVehicleView';

