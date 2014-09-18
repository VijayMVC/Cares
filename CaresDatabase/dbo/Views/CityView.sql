CREATE VIEW [dbo].[CityView]
AS
SELECT     dbo.City.CityID, dbo.City.CityCode, dbo.City.CityName, dbo.City.CityDescription, dbo.City.RegionID, dbo.City.SubRegionID, dbo.City.CountryID, dbo.City.RowVersion, 
                      dbo.City.IsActive, dbo.City.IsPrivate, dbo.City.IsReadOnly, dbo.City.IsDeleted, dbo.City.RecCreatedDt, dbo.City.RecCreatedBy, dbo.City.RecLastUpdatedDt, 
                      dbo.City.RecLastUpdatedBy, dbo.Country.CountryCode + '-' + dbo.Country.CountryName AS CountryCodeName, 
                      dbo.Region.RegionCode + '-' + dbo.Region.RegionName AS RegionCodeName, 
                      dbo.SubRegion.SubRegionCode + '-' + dbo.SubRegion.SubRegionName AS SubRegionCodeName
FROM         dbo.City INNER JOIN
                      dbo.Country ON dbo.City.CountryID = dbo.Country.CountryID LEFT OUTER JOIN
                      dbo.Region ON dbo.City.RegionID = dbo.Region.RegionID LEFT OUTER JOIN
                      dbo.SubRegion ON dbo.City.SubRegionID = dbo.SubRegion.SubRegionID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CityView';


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
         Begin Table = "City"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 123
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 6
               Left = 475
               Bottom = 123
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "SubRegion"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 243
               Right = 231
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'CityView';

