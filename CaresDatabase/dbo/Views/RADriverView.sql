CREATE VIEW [dbo].[RADriverView]
AS
SELECT     dbo.RADriver.RADriverID, dbo.RADriver.ChaufferID, dbo.RADriver.RAMainID, dbo.RADriver.DriverName, dbo.RADriver.IsChauffer, dbo.RADriver.DesigGradeID, 
                      dbo.RADriver.TariffType, dbo.RADriver.Rate, dbo.RADriver.TotalCharge, dbo.RADriver.ChargedDay, dbo.RADriver.ChargedHour, dbo.RADriver.ChargedMinute, 
                      dbo.RADriver.LicenseExpDt, dbo.RADriver.LicenseNo, dbo.RADriver.StartDtTime, dbo.RADriver.EndDtTime, dbo.RADriver.RowVersion, dbo.RADriver.IsActive, 
                      dbo.RADriver.IsDeleted, dbo.RADriver.IsPrivate, dbo.RADriver.IsReadOnly, dbo.RADriver.RecCreatedDt, dbo.RADriver.RecCreatedBy, 
                      dbo.RADriver.RecLastUpdatedDt, dbo.RADriver.RecLastUpdatedBy, dbo.Employee.EmpFName + ' ' + dbo.Employee.EmpLName AS ChaufferName, 
                      dbo.DesigGrade.DesigGradeCode + '-' + dbo.DesigGrade.DesigGradeName AS DesigGradeCodeName
FROM         dbo.RADriver LEFT OUTER JOIN
                      dbo.DesigGrade ON dbo.RADriver.DesigGradeID = dbo.DesigGrade.DesigGradeID LEFT OUTER JOIN
                      dbo.Employee ON dbo.RADriver.ChaufferID = dbo.Employee.EmployeeID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'RADriverView';


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
         Begin Table = "RADriver"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 123
               Right = 436
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "DesigGrade"
            Begin Extent = 
               Top = 6
               Left = 474
               Bottom = 123
               Right = 671
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'RADriverView';

