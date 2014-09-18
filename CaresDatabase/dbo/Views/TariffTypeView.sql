CREATE VIEW [dbo].[TariffTypeView]
AS
SELECT     dbo.TariffType.TariffTypeID, dbo.TariffType.OperationID, dbo.TariffType.MeasurementUnitID, dbo.TariffType.TariffTypeCode, dbo.TariffType.TariffTypeName, 
                      dbo.TariffType.TariffTypeDescription, dbo.TariffType.PricingStrategyID, dbo.TariffType.DurationFrom, dbo.TariffType.DurationTo, dbo.TariffType.GracePeriod, 
                      dbo.TariffType.EffectiveDate, dbo.TariffType.RowVersion, dbo.TariffType.RevisionNumber, dbo.TariffType.ChildTariffTypeID, dbo.TariffType.RecCreatedDt, 
                      dbo.TariffType.RecLastUpdatedDt, dbo.TariffType.RecLastUpdatedBy, dbo.TariffType.RecCreatedBy, dbo.TariffType.IsActive, dbo.TariffType.IsDeleted, 
                      dbo.TariffType.IsPrivate, dbo.TariffType.IsReadOnly, 
                      dbo.MeasurementUnit.MeasurementUnitCode + '-' + dbo.MeasurementUnit.MeasurementUnitName AS MeasurementUnitCodeName, 
                      dbo.MeasurementUnit.MeasurementUnitKey, dbo.Operation.OperationCode + '-' + dbo.Operation.OperationName AS OperationCodeName, dbo.Operation.DepartmentID,
                       dbo.Department.DepartmentCode + '-' + dbo.Department.DepartmentName AS DepartmentCodeName, dbo.Department.CompanyID, 
                      dbo.Company.CompanyCode + '-' + dbo.Company.CompanyName AS CompanyCodeName, 
                      dbo.PricingStrategy.PricingStrategyCode + '-' + dbo.PricingStrategy.PricingStrategyName AS PricingStrategyCodeName
FROM         dbo.TariffType INNER JOIN
                      dbo.MeasurementUnit ON dbo.TariffType.MeasurementUnitID = dbo.MeasurementUnit.MeasurementUnitID INNER JOIN
                      dbo.Operation ON dbo.TariffType.OperationID = dbo.Operation.OperationID INNER JOIN
                      dbo.Department ON dbo.Operation.DepartmentID = dbo.Department.DepartmentID INNER JOIN
                      dbo.Company ON dbo.Department.CompanyID = dbo.Company.CompanyID INNER JOIN
                      dbo.PricingStrategy ON dbo.TariffType.PricingStrategyID = dbo.PricingStrategy.PricingStrategyID
WHERE     (dbo.TariffType.ChildTariffTypeID IS NULL)
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TariffTypeView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TariffTypeView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[24] 2[30] 3) )"
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
         Begin Table = "TariffType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "MeasurementUnit"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 123
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "Operation"
            Begin Extent = 
               Top = 6
               Left = 532
               Bottom = 123
               Right = 722
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 126
               Left = 263
               Bottom = 243
               Right = 462
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Company"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 243
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "PricingStrategy"
            Begin Extent = 
               Top = 6
               Left = 760
               Bottom = 123
               Right = 975
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TariffTypeView';

