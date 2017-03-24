CREATE VIEW dbo.view_tournament
AS
SELECT        dbo.Tournaments.Id, dbo.Tournaments.LeagueId, dbo.Tournaments.CreatedByUserId, dbo.Tournaments.AttachedTournamentId, dbo.Tournaments.DateCreated, dbo.Tournaments.DateDeleted, 
                         dbo.Tournaments.Name, dbo.Tournaments.Date, dbo.Tournaments.GameType, dbo.Tournaments.Description, dbo.Tournaments.DateEnded, dbo.Tournaments.IsHidden, dbo.Tournaments.IsRunning, 
                         dbo.Tournaments.StructureId, dbo.Tournaments.BuyInPrize, dbo.Tournaments.RebuyPrize, dbo.Tournaments.AddOnPrize, dbo.Tournaments.BuyInStack, dbo.Tournaments.RebuyStack, 
                         dbo.Tournaments.AddOnStack, dbo.Tournaments.BonusStack, dbo.Tournaments.IsFullPointed, dbo.Tournaments.IsLeague, dbo.Tournaments.GTD, dbo.Tournaments.ReBuyCount, dbo.Tournaments.IsFood, 
                         dbo.Tournaments.BountyDesc, dbo.Tournaments.SpecialAddonPrize, dbo.Tournaments.SpecialAddonStack, dbo.Tournaments.FullStackBonus, dbo.Tournaments.IsPercentageBonus, dbo.Tournaments.LogicType, 
                         dbo.Tournaments.IsHighlighted, dbo.Tournaments.RakePercentage, dbo.Tournaments.LeaguePercentage, dbo.Tournaments.ReEntryCount, dbo.TournamentCashouts.Rake, dbo.TournamentCashouts.Prizepool, 
                         dbo.TournamentCashouts.Food, dbo.TournamentCashouts.Dotation, dbo.TournamentCashouts.Places, dbo.TournamentCashouts.RunnerHelp, dbo.TournamentCashouts.Tips, dbo.TournamentCashouts.CGBank, 
                         dbo.TournamentCashouts.APCBank, dbo.TournamentCashouts.Comment, dbo.TournamentCashouts.Floor, dbo.TournamentCashouts.Dealer
FROM            dbo.Tournaments INNER JOIN
                         dbo.TournamentCashouts ON dbo.Tournaments.Id = dbo.TournamentCashouts.TournamentId
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'view_tournament';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[7] 2[20] 3) )"
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
         Begin Table = "Tournaments"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 251
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TournamentCashouts"
            Begin Extent = 
               Top = 16
               Left = 482
               Bottom = 405
               Right = 658
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'view_tournament';

