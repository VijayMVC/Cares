CREATE VIEW [dbo].[AdditionalDriverChargeView]
AS
SELECT DISTINCT 
                      dbo.AdditionalDriverCharge.AdditionalDriverChargeID, dbo.AdditionalDriverCharge.ChildAdditionalDriverChargeID, 
                      dbo.AdditionalDriverCharge.AdditionalDriverChargeRate, dbo.AdditionalDriverCharge.TariffTypeCode, dbo.AdditionalDriverCharge.RevisionNumber, 
                      dbo.AdditionalDriverCharge.StartDt, dbo.AdditionalDriverCharge.IsActive, dbo.AdditionalDriverCharge.IsDeleted, dbo.AdditionalDriverCharge.IsPrivate, 
                      dbo.AdditionalDriverCharge.IsReadOnly, dbo.AdditionalDriverCharge.RowVersion, dbo.AdditionalDriverCharge.RecCreatedDt, 
                      dbo.AdditionalDriverCharge.RecLastUpdatedDt, dbo.AdditionalDriverCharge.RecCreatedBy, dbo.AdditionalDriverCharge.RecLastUpdatedBy, 
                      dbo.TariffType.TariffTypeCode + '-' + dbo.TariffType.TariffTypeName AS TariffTypeCodeName, dbo.Company.CompanyID, 
                      dbo.Company.CompanyCode + '-' + dbo.Company.CompanyName AS CompanyCodeName, dbo.Department.DepartmentID, 
                      dbo.Department.DepartmentCode + '-' + dbo.Department.DepartmentName AS DepartmentCodeName, dbo.Operation.OperationID, 
                      dbo.Operation.OperationCode + '-' + dbo.Operation.OperationName AS OperationCodeName
FROM         dbo.Department INNER JOIN
                      dbo.Company ON dbo.Department.CompanyID = dbo.Company.CompanyID INNER JOIN
                      dbo.Operation ON dbo.Department.DepartmentID = dbo.Operation.DepartmentID INNER JOIN
                      dbo.TariffType ON dbo.Operation.OperationID = dbo.TariffType.OperationID INNER JOIN
                      dbo.AdditionalDriverCharge ON dbo.AdditionalDriverCharge.TariffTypeCode = dbo.TariffType.TariffTypeCode
WHERE     (dbo.AdditionalDriverCharge.ChildAdditionalDriverChargeID IS NULL)
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AdditionalDriverChargeView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lias = 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AdditionalDriverChargeView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[19] 4[17] 2[33] 3) )"
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
         Begin Table = "AdditionalDriverCharge"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "TariffType"
            Begin Extent = 
               Top = 6
               Left = 310
               Bottom = 123
               Right = 502
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 6
               Left = 540
               Bottom = 123
               Right = 739
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Company"
            Begin Extent = 
               Top = 6
               Left = 777
               Bottom = 123
               Right = 964
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Operation"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 243
               Right = 228
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
         Width = 1500
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
         A', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AdditionalDriverChargeView';

