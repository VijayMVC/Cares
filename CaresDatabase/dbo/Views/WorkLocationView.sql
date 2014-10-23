CREATE VIEW dbo.WorkLocationView
AS
SELECT        WLC.WorkLocationID, WLC.WorkLocationCode, WLC.WorkLocationName, WLC.WorkLocationDescription, WLC.CompanyID, WLC.RowVersion, WLC.IsActive, 
                         WLC.IsDeleted, WLC.IsPrivate, WLC.IsReadOnly, WLC.RecCreatedDt, WLC.RecCreatedBy, WLC.RecLastUpdatedDt, WLC.RecLastUpdatedBy, 
                         CMP.CompanyCode + '-' + CMP.CompanyName AS CompanyCodeName, ADR.AddressID, ADR.ContactPerson, ADR.StreetAddress, ADR.EmailAddress, ADR.WebPage, 
                         ADR.ZipCode, ADR.POBox, ADR.CountryID, ADR.RegionID, ADR.SubRegionID, ADR.CityID, ADR.AreaID, ADR.AddressTypeID, 
                         CNT.CountryCode + '-' + CNT.CountryName AS CountryCodeName, CT.CityCode + '-' + CT.CityName AS CityCodeName, 
                         AR.AreaCode + '-' + AR.AreaName AS AreaCodeName, RG.RegionCode + '-' + RG.RegionName AS RegionCodeName, 
                         SRG.SubRegionCode + '-' + SRG.SubRegionName AS SubRegionCodeName
FROM            dbo.WorkLocation AS WLC INNER JOIN
                         dbo.Company AS CMP ON CMP.CompanyID = WLC.CompanyID LEFT OUTER JOIN
                         dbo.Address AS ADR ON WLC.AddressID = ADR.AddressID INNER JOIN
                         dbo.Country AS CNT ON CNT.CountryID = ADR.CountryID LEFT OUTER JOIN
                         dbo.Region AS RG ON RG.RegionID = ADR.RegionID LEFT OUTER JOIN
                         dbo.SubRegion AS SRG ON SRG.SubRegionID = ADR.SubRegionID LEFT OUTER JOIN
                         dbo.City AS CT ON CT.CityID = ADR.CityID LEFT OUTER JOIN
                         dbo.Area AS AR ON AR.AreaID = ADR.AreaID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WorkLocationView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'        End
         Begin Table = "AR"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 663
               Right = 225
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WorkLocationView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[13] 2[28] 3) )"
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
         Begin Table = "WLC"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CMP"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ADR"
            Begin Extent = 
               Top = 138
               Left = 277
               Bottom = 267
               Right = 464
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CNT"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 399
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RG"
            Begin Extent = 
               Top = 270
               Left = 268
               Bottom = 399
               Right = 455
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SRG"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 531
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CT"
            Begin Extent = 
               Top = 402
               Left = 282
               Bottom = 531
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 0
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WorkLocationView';

