using System.ComponentModel;

namespace ClubArcada.Common
{
    public enum eGameType
    {
        [Description("Vyberte si")]
        NotSet = 0,

        [Description("Freeze Out")]
        FreezeOut = 1,

        [Description("Limited Rebuy")]
        RebuyLimited = 2,

        [Description("Unlimited Rebuy")]
        RebuyUnlimited = 3,

        [Description("Double Chance")]
        DoubleChance = 4,

        [Description("Triple Chance")]
        TripleChance = 5,

        [Description("Freeroll")]
        Freeroll = 6,

        [Description("Cash Game")]
        CashGame = 7,

        [Description("Double Trouble")]
        DoubleTrouble = 8,

        [Description("Qualification")]
        Qualification = 9,

        [Description("Final")]
        Final = 10
    }

    public enum eTransactionType
    {
        [Description("Pôžicka (-)")]
        NotSet = 0,

        [Description("Pôžicka (+)")]
        Returned = 1,

        [Description("Bar (-)")]
        Bar = 2,

        [Description("Bar (+)")]
        BarReturned = 3,

        [Description("Turnaj (-)")]
        Tournament = 4,

        [Description("Turnaj (+)")]
        TournamentReturned = 5,

        [Description("Cash Game (-)")]
        CashGame = 6,

        [Description("Cash Game (+)")]
        CashGameReturned = 7,

        [Description("Bonus (+)")]
        Bonus = 8,

        [Description("Bonus (-)")]
        BonusReturned = 9,

        [Description("TR rake (+)")]
        TournamentRake = 20,

        [Description("TR liga (+)")]
        TournamentLeague = 21,

        [Description("TR dotácia (-)")]
        TournamentDotation = 22,

        [Description("TR strava (-)")]
        TournamentFood = 24,

        [Description("TR typovacka (-)")]
        TournamentLottery = 26,

        [Description("CG rake (+)")]
        CashGameRake = 30,

        [Description("CG jackpot (+)")]
        CashGameJackpot = 31,

        [Description("CG liga (+)")]
        CashGameLeague = 32,

        [Description("CG bar-úcet (-)")]
        CashGameFood = 33,

        [Description("CG bonus (-)")]
        CashGameBonus = 34,

        [Description("CG typovacka (-)")]
        CashGameLottery = 35,

        [Description("CG rozbiehac (-)")]
        CashGameRunHelp = 36,

        [Description("CG strava pl. (-)")]
        CashGameFoodPayed = 37,

        [Description("CG Tržba (+)")]
        CashGameInput = 38,

        [Description("Presun (-)")]
        Move = 40,

        [Description("Presun (+)")]
        MovePlus = 41,

        [Description("Iný výdaj (-)")]
        Away = 42,

        [Description("Zostatok z KVL (+)")]
        Zostatok = 150
    }

    public enum eAdminLevel
    {
        [Description("N/A")]
        NotSet = 0,

        [Description("Owner")]
        Admin = 1,

        [Description("Floor")]
        Floor = 2,

        [Description("Bar Manager")]
        BarManager = 3,

        [Description("Service")]
        Service = 4,

        [Description("System Administrator")]
        SystemAdmin = 5,

        [Description("General Manager")]
        Manager = 6
    }

    public enum eApplication
    {
        [Description("Admin")]
        NotSet = 0,

        [Description("Cash Timer")]
        Cashtimer = 1,

        [Description("Balance")]
        Bar = 2,

        [Description("Poker Timer")]
        PokerTimer = 3
    }

    public enum eAutoReturn
    {
        [Description("Off")]
        NotSet = 0,

        [Description("Netto")]
        Netto = 1,

        [Description("Full")]
        Full = 2
    }

    public enum eAuditHistoryType
    {
        NotSet = 0,

        TransactionCreate = 1,

        RequestCreate = 2,

        UserCreate = 3,

        CashInCreate = 4,

        CashOutCreate = 5
    }
}