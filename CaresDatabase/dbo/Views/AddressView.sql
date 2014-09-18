
CREATE VIEW [dbo].[AddressView]
AS
SELECT     dbo.Address.AddressID, dbo.Address.ContactPerson, dbo.Address.StreetAddress, dbo.Address.EmailAddress, dbo.Address.WebPage, 
              dbo.Address.ZipCode, dbo.Address.POBox, dbo.Address.CountryID, dbo.Address.RegionID, dbo.Address.SubRegionID, dbo.Address.CityID, 
              dbo.Address.AreaID, dbo.Address.AddressTypeID, dbo.Address.BPMainID ,dbo.Address.EmployeeID, 
			  dbo.Address.RowVersion, dbo.Address.IsActive, dbo.Address.IsDeleted, dbo.Address.IsPrivate, dbo.Address.IsReadOnly, 
			  dbo.Address.RecCreatedDt, dbo.Address.RecCreatedBy, dbo.Address.RecLastUpdatedDt, dbo.Address.RecLastUpdatedBy, 
              dbo.AddressType.AddressTypeCode + '-' + dbo.AddressType.AddressTypeName AS AddressTypeCodeName, 
			  dbo.Country.CountryCode + '-' + dbo.Country.CountryName AS CountryCodeName, dbo.City.CityCode + '-' + dbo.City.CityName AS CityCodeName, 
              dbo.Area.AreaCode + '-' + dbo.Area.AreaName AS AreaCodeName, dbo.Region.RegionCode + '-' + dbo.Region.RegionName AS RegionCodeName, 
              dbo.SubRegion.SubRegionCode + '-' + dbo.SubRegion.SubRegionName AS SubRegionCodeName
FROM         dbo.Address INNER JOIN
              dbo.AddressType ON dbo.Address.AddressTypeID = dbo.AddressType.AddressTypeID INNER JOIN
              dbo.Country ON dbo.Address.CountryID = dbo.Country.CountryID LEFT OUTER JOIN
              dbo.Region ON dbo.Address.RegionID = dbo.Region.RegionID AND dbo.Country.CountryID = dbo.Region.CountryID LEFT OUTER JOIN
              dbo.SubRegion ON dbo.Address.SubRegionID = dbo.SubRegion.SubRegionID AND dbo.Region.RegionID = dbo.SubRegion.RegionID LEFT OUTER JOIN
              dbo.City ON dbo.SubRegion.SubRegionID = dbo.City.SubRegionID AND dbo.Region.RegionID = dbo.City.RegionID AND 
              dbo.Address.CityID = dbo.City.CityID AND dbo.Country.CountryID = dbo.City.CountryID LEFT OUTER JOIN
              dbo.Area ON dbo.Address.AreaID = dbo.Area.AreaID AND dbo.City.CityID = dbo.Area.CityID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AddressView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'           TopColumn = 0
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AddressView';


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
         Begin Table = "Address"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 20
         End
         Begin Table = "AddressType"
            Begin Extent = 
               Top = 72
               Left = 234
               Bottom = 180
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 481
               Bottom = 114
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 6
               Left = 691
               Bottom = 114
               Right = 862
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Area"
            Begin Extent = 
               Top = 6
               Left = 900
               Bottom = 114
               Right = 1071
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 131
               Left = 509
               Bottom = 239
               Right = 680
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SubRegion"
            Begin Extent = 
               Top = 128
               Left = 733
               Bottom = 236
               Right = 917
            End
            DisplayFlags = 280
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AddressView';

