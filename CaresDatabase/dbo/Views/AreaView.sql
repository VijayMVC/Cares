CREATE VIEW [dbo].[AreaView]
AS
SELECT     dbo.Area.AreaID, dbo.Area.AreaCode, dbo.Area.AreaName, dbo.Area.AreaDescription, dbo.Area.CityID, dbo.Area.RowVersion, dbo.Area.IsActive, 
                      dbo.Area.IsPrivate, dbo.Area.IsReadOnly, dbo.Area.IsDeleted, dbo.Area.RecCreatedDt, dbo.Area.RecCreatedBy, dbo.Area.RecLastUpdatedDt, 
                      dbo.Area.RecLastUpdatedBy, dbo.Country.CountryID, dbo.Country.CountryCode + '-' + dbo.Country.CountryName AS CountryCodeName, 
                      dbo.City.CityCode + '-' + dbo.City.CityName AS CityCodeName, dbo.SubRegion.SubRegionID, 
                      dbo.SubRegion.SubRegionCode + '-' + dbo.SubRegion.SubRegionName AS SubRegionCodeName, dbo.Region.RegionID, 
                      dbo.Region.RegionCode + '-' + dbo.Region.RegionName AS RegionCodeName
FROM         dbo.Area INNER JOIN
                      dbo.City ON dbo.Area.CityID = dbo.City.CityID LEFT OUTER JOIN
                      dbo.SubRegion ON dbo.City.SubRegionID = dbo.SubRegion.SubRegionID LEFT OUTER JOIN
                      dbo.Region ON dbo.City.RegionID = dbo.Region.RegionID AND dbo.SubRegion.RegionID = dbo.Region.RegionID LEFT OUTER JOIN
                      dbo.Country ON dbo.City.CountryID = dbo.Country.CountryID AND dbo.Region.CountryID = dbo.Country.CountryID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AreaView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'   End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AreaView';


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
         Begin Table = "Area"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 6
               Left = 247
               Bottom = 114
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SubRegion"
            Begin Extent = 
               Top = 6
               Left = 456
               Bottom = 114
               Right = 640
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 114
               Left = 247
               Bottom = 222
               Right = 419
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
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AreaView';

