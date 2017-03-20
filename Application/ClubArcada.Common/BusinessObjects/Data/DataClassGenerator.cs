﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubArcada.Common;
using ClubArcada.Common.BusinessObjects.Data;
using ClubArcada.Common.BusinessObjects.DataClasses;

namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public interface IDataClassLight
    {
        bool IsNew { get; set; }

        Guid Id { get; set; }

        Guid CreatedByUserId { get; set; }

        DateTime DateCreated { get; set; }
    }

    public interface IDataClass<T> where T : class
    {
        void Delete(Credentials cr);

        T Save(Credentials cr);

        T Load(Credentials cr);
    }

    public abstract class BaseClass<IDataClassLight>
    {

    }


    public partial class User : BaseClass<User>, IDataClassLight, IDataClass<User>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            UserData.Delete(cr, Id);
        }

        public User Save(Credentials cr)
        {
            return UserData.Save(cr, this);
        }

        public User Load(Credentials cr)
        {
            return UserData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Accounting : BaseClass<Accounting>, IDataClassLight, IDataClass<Accounting>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            AccountingData.Delete(cr, Id);
        }

        public Accounting Save(Credentials cr)
        {
            return AccountingData.Save(cr, this);
        }

        public Accounting Load(Credentials cr)
        {
            return AccountingData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class AuditHistory : BaseClass<AuditHistory>, IDataClassLight, IDataClass<AuditHistory>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            AuditHistoryData.Delete(cr, Id);
        }

        public AuditHistory Save(Credentials cr)
        {
            return AuditHistoryData.Save(cr, this);
        }

        public AuditHistory Load(Credentials cr)
        {
            return AuditHistoryData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Banner : BaseClass<Banner>, IDataClassLight, IDataClass<Banner>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            BannerData.Delete(cr, Id);
        }

        public Banner Save(Credentials cr)
        {
            return BannerData.Save(cr, this);
        }

        public Banner Load(Credentials cr)
        {
            return BannerData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class BusinessUnit : BaseClass<BusinessUnit>, IDataClassLight, IDataClass<BusinessUnit>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            BusinessUnitData.Delete(cr, Id);
        }

        public BusinessUnit Save(Credentials cr)
        {
            return BusinessUnitData.Save(cr, this);
        }

        public BusinessUnit Load(Credentials cr)
        {
            return BusinessUnitData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class CashIn : BaseClass<CashIn>, IDataClassLight, IDataClass<CashIn>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            CashInData.Delete(cr, Id);
        }

        public CashIn Save(Credentials cr)
        {
            return CashInData.Save(cr, this);
        }

        public CashIn Load(Credentials cr)
        {
            return CashInData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class CashOut : BaseClass<CashOut>, IDataClassLight, IDataClass<CashOut>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            CashOutData.Delete(cr, Id);
        }

        public CashOut Save(Credentials cr)
        {
            return CashOutData.Save(cr, this);
        }

        public CashOut Load(Credentials cr)
        {
            return CashOutData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class CashPlayer : BaseClass<CashPlayer>, IDataClassLight, IDataClass<CashPlayer>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            CashPlayerData.Delete(cr, Id);
        }

        public CashPlayer Save(Credentials cr)
        {
            return CashPlayerData.Save(cr, this);
        }

        public CashPlayer Load(Credentials cr)
        {
            return CashPlayerData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class CashState : BaseClass<CashState>, IDataClassLight, IDataClass<CashState>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            CashStateData.Delete(cr, Id);
        }

        public CashState Save(Credentials cr)
        {
            return CashStateData.Save(cr, this);
        }

        public CashState Load(Credentials cr)
        {
            return CashStateData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class CashTable : BaseClass<CashTable>, IDataClassLight, IDataClass<CashTable>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            CashTableData.Delete(cr, Id);
        }

        public CashTable Save(Credentials cr)
        {
            return CashTableData.Save(cr, this);
        }

        public CashTable Load(Credentials cr)
        {
            return CashTableData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Image : BaseClass<Image>, IDataClassLight, IDataClass<Image>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            ImageData.Delete(cr, Id);
        }

        public Image Save(Credentials cr)
        {
            return ImageData.Save(cr, this);
        }

        public Image Load(Credentials cr)
        {
            return ImageData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Jackpot : BaseClass<Jackpot>, IDataClassLight, IDataClass<Jackpot>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            JackpotData.Delete(cr, Id);
        }

        public Jackpot Save(Credentials cr)
        {
            return JackpotData.Save(cr, this);
        }

        public Jackpot Load(Credentials cr)
        {
            return JackpotData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class League : BaseClass<League>, IDataClassLight, IDataClass<League>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            LeagueData.Delete(cr, Id);
        }

        public League Save(Credentials cr)
        {
            return LeagueData.Save(cr, this);
        }

        public League Load(Credentials cr)
        {
            return LeagueData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Request : BaseClass<Request>, IDataClassLight, IDataClass<Request>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            RequestData.Delete(cr, Id);
        }

        public Request Save(Credentials cr)
        {
            return RequestData.Save(cr, this);
        }

        public Request Load(Credentials cr)
        {
            return RequestData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Shift : BaseClass<Shift>, IDataClassLight, IDataClass<Shift>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            ShiftData.Delete(cr, Id);
        }

        public Shift Save(Credentials cr)
        {
            return ShiftData.Save(cr, this);
        }

        public Shift Load(Credentials cr)
        {
            return ShiftData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class StructureDetail : BaseClass<StructureDetail>, IDataClassLight, IDataClass<StructureDetail>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            StructureDetailData.Delete(cr, Id);
        }

        public StructureDetail Save(Credentials cr)
        {
            return StructureDetailData.Save(cr, this);
        }

        public StructureDetail Load(Credentials cr)
        {
            return StructureDetailData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Structure : BaseClass<Structure>, IDataClassLight, IDataClass<Structure>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            StructureData.Delete(cr, Id);
        }

        public Structure Save(Credentials cr)
        {
            return StructureData.Save(cr, this);
        }

        public Structure Load(Credentials cr)
        {
            return StructureData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class TournamentCashout : BaseClass<TournamentCashout>, IDataClassLight, IDataClass<TournamentCashout>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            TournamentCashoutData.Delete(cr, Id);
        }

        public TournamentCashout Save(Credentials cr)
        {
            return TournamentCashoutData.Save(cr, this);
        }

        public TournamentCashout Load(Credentials cr)
        {
            return TournamentCashoutData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class TournamentPlayer : BaseClass<TournamentPlayer>, IDataClassLight, IDataClass<TournamentPlayer>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            TournamentPlayerData.Delete(cr, Id);
        }

        public TournamentPlayer Save(Credentials cr)
        {
            return TournamentPlayerData.Save(cr, this);
        }

        public TournamentPlayer Load(Credentials cr)
        {
            return TournamentPlayerData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Tournament : BaseClass<Tournament>, IDataClassLight, IDataClass<Tournament>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            TournamentData.Delete(cr, Id);
        }

        public Tournament Save(Credentials cr)
        {
            return TournamentData.Save(cr, this);
        }

        public Tournament Load(Credentials cr)
        {
            return TournamentData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }

    public partial class Transaction : BaseClass<Transaction>, IDataClassLight, IDataClass<Transaction>
    {
        public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public void Delete(Credentials cr)
        {
            TransactionData.Delete(cr, Id);
        }

        public Transaction Save(Credentials cr)
        {
            return TransactionData.Save(cr, this);
        }

        public Transaction Load(Credentials cr)
        {
            return TransactionData.GetById(cr, this.Id);
        }

        internal void PrepareToSave(Credentials cr)
        {
            if (IsNew)
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.Now;
                CreatedByUserId = cr.UserId;
            }
        }
    }
}

namespace ClubArcada.Common.BusinessObjects.Data
{

    public partial class UserData
    {
        public static List<User> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Users.Where(i => i.DateDeleted == null).ToList() : dc.Users.ToList();
            }
        }

        public static User GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Users.SingleOrDefault(u => u.Id == id);
            }
        }

        public static User Save(Credentials cr, User item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static User Create(Credentials cr, User item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Users.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static User Update(Credentials cr, User item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Users.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<User>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Users.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<User>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<User>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Users.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Users.ToList();
                    }
                };

                return await new Task<List<User>>(a);
            }
        }

        public async static Task<User> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<User> a = () =>
                {
                    return dc.Users.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<User>(a);
            }
        }
    }

    public partial class AccountingData
    {
        public static List<Accounting> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Accountings.Where(i => i.DateDeleted == null).ToList() : dc.Accountings.ToList();
            }
        }

        public static Accounting GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Accountings.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Accounting Save(Credentials cr, Accounting item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Accounting Create(Credentials cr, Accounting item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Accountings.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Accounting Update(Credentials cr, Accounting item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Accountings.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Accounting>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Accountings.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Accounting>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Accounting>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Accountings.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Accountings.ToList();
                    }
                };

                return await new Task<List<Accounting>>(a);
            }
        }

        public async static Task<Accounting> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Accounting> a = () =>
                {
                    return dc.Accountings.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Accounting>(a);
            }
        }
    }

    public partial class AuditHistoryData
    {
        public static List<AuditHistory> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.AuditHistories.Where(i => i.DateDeleted == null).ToList() : dc.AuditHistories.ToList();
            }
        }

        public static AuditHistory GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.AuditHistories.SingleOrDefault(u => u.Id == id);
            }
        }

        public static AuditHistory Save(Credentials cr, AuditHistory item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static AuditHistory Create(Credentials cr, AuditHistory item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.AuditHistories.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static AuditHistory Update(Credentials cr, AuditHistory item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.AuditHistories.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<AuditHistory>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.AuditHistories.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<AuditHistory>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<AuditHistory>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.AuditHistories.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.AuditHistories.ToList();
                    }
                };

                return await new Task<List<AuditHistory>>(a);
            }
        }

        public async static Task<AuditHistory> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<AuditHistory> a = () =>
                {
                    return dc.AuditHistories.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<AuditHistory>(a);
            }
        }
    }

    public partial class BannerData
    {
        public static List<Banner> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Banners.Where(i => i.DateDeleted == null).ToList() : dc.Banners.ToList();
            }
        }

        public static Banner GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Banners.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Banner Save(Credentials cr, Banner item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Banner Create(Credentials cr, Banner item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Banners.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Banner Update(Credentials cr, Banner item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Banners.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Banner>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Banners.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Banner>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Banner>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Banners.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Banners.ToList();
                    }
                };

                return await new Task<List<Banner>>(a);
            }
        }

        public async static Task<Banner> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Banner> a = () =>
                {
                    return dc.Banners.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Banner>(a);
            }
        }
    }

    public partial class BusinessUnitData
    {
        public static List<BusinessUnit> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.BusinessUnits.Where(i => i.DateDeleted == null).ToList() : dc.BusinessUnits.ToList();
            }
        }

        public static BusinessUnit GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.BusinessUnits.SingleOrDefault(u => u.Id == id);
            }
        }

        public static BusinessUnit Save(Credentials cr, BusinessUnit item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static BusinessUnit Create(Credentials cr, BusinessUnit item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.BusinessUnits.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static BusinessUnit Update(Credentials cr, BusinessUnit item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.BusinessUnits.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<BusinessUnit>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.BusinessUnits.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<BusinessUnit>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<BusinessUnit>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.BusinessUnits.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.BusinessUnits.ToList();
                    }
                };

                return await new Task<List<BusinessUnit>>(a);
            }
        }

        public async static Task<BusinessUnit> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<BusinessUnit> a = () =>
                {
                    return dc.BusinessUnits.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<BusinessUnit>(a);
            }
        }
    }

    public partial class CashInData
    {
        public static List<CashIn> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.CashIns.Where(i => i.DateDeleted == null).ToList() : dc.CashIns.ToList();
            }
        }

        public static CashIn GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashIns.SingleOrDefault(u => u.Id == id);
            }
        }

        public static CashIn Save(Credentials cr, CashIn item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static CashIn Create(Credentials cr, CashIn item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashIns.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static CashIn Update(Credentials cr, CashIn item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.CashIns.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<CashIn>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashIns.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<CashIn>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashIn>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashIns.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashIns.ToList();
                    }
                };

                return await new Task<List<CashIn>>(a);
            }
        }

        public async static Task<CashIn> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashIn> a = () =>
                {
                    return dc.CashIns.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<CashIn>(a);
            }
        }
    }

    public partial class CashOutData
    {
        public static List<CashOut> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.CashOuts.Where(i => i.DateDeleted == null).ToList() : dc.CashOuts.ToList();
            }
        }

        public static CashOut GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashOuts.SingleOrDefault(u => u.Id == id);
            }
        }

        public static CashOut Save(Credentials cr, CashOut item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static CashOut Create(Credentials cr, CashOut item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashOuts.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static CashOut Update(Credentials cr, CashOut item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.CashOuts.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<CashOut>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashOuts.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<CashOut>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashOut>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashOuts.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashOuts.ToList();
                    }
                };

                return await new Task<List<CashOut>>(a);
            }
        }

        public async static Task<CashOut> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashOut> a = () =>
                {
                    return dc.CashOuts.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<CashOut>(a);
            }
        }
    }

    public partial class CashPlayerData
    {
        public static List<CashPlayer> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.CashPlayers.Where(i => i.DateDeleted == null).ToList() : dc.CashPlayers.ToList();
            }
        }

        public static CashPlayer GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashPlayers.SingleOrDefault(u => u.Id == id);
            }
        }

        public static CashPlayer Save(Credentials cr, CashPlayer item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static CashPlayer Create(Credentials cr, CashPlayer item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashPlayers.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static CashPlayer Update(Credentials cr, CashPlayer item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.CashPlayers.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<CashPlayer>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashPlayers.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<CashPlayer>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashPlayer>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashPlayers.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashPlayers.ToList();
                    }
                };

                return await new Task<List<CashPlayer>>(a);
            }
        }

        public async static Task<CashPlayer> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashPlayer> a = () =>
                {
                    return dc.CashPlayers.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<CashPlayer>(a);
            }
        }
    }

    public partial class CashStateData
    {
        public static List<CashState> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.CashStates.Where(i => i.DateDeleted == null).ToList() : dc.CashStates.ToList();
            }
        }

        public static CashState GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashStates.SingleOrDefault(u => u.Id == id);
            }
        }

        public static CashState Save(Credentials cr, CashState item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static CashState Create(Credentials cr, CashState item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashStates.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static CashState Update(Credentials cr, CashState item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.CashStates.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<CashState>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashStates.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<CashState>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashState>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashStates.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashStates.ToList();
                    }
                };

                return await new Task<List<CashState>>(a);
            }
        }

        public async static Task<CashState> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashState> a = () =>
                {
                    return dc.CashStates.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<CashState>(a);
            }
        }
    }

    public partial class CashTableData
    {
        public static List<CashTable> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.CashTables.Where(i => i.DateDeleted == null).ToList() : dc.CashTables.ToList();
            }
        }

        public static CashTable GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.CashTables.SingleOrDefault(u => u.Id == id);
            }
        }

        public static CashTable Save(Credentials cr, CashTable item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static CashTable Create(Credentials cr, CashTable item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashTables.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static CashTable Update(Credentials cr, CashTable item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.CashTables.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<CashTable>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashTables.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<CashTable>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashTable>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashTables.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashTables.ToList();
                    }
                };

                return await new Task<List<CashTable>>(a);
            }
        }

        public async static Task<CashTable> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashTable> a = () =>
                {
                    return dc.CashTables.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<CashTable>(a);
            }
        }
    }

    public partial class ImageData
    {
        public static List<Image> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Images.Where(i => i.DateDeleted == null).ToList() : dc.Images.ToList();
            }
        }

        public static Image GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Images.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Image Save(Credentials cr, Image item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Image Create(Credentials cr, Image item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Images.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Image Update(Credentials cr, Image item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Images.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Image>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Images.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Image>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Image>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Images.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Images.ToList();
                    }
                };

                return await new Task<List<Image>>(a);
            }
        }

        public async static Task<Image> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Image> a = () =>
                {
                    return dc.Images.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Image>(a);
            }
        }
    }

    public partial class JackpotData
    {
        public static List<Jackpot> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Jackpots.Where(i => i.DateDeleted == null).ToList() : dc.Jackpots.ToList();
            }
        }

        public static Jackpot GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Jackpots.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Jackpot Save(Credentials cr, Jackpot item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Jackpot Create(Credentials cr, Jackpot item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Jackpots.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Jackpot Update(Credentials cr, Jackpot item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Jackpots.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Jackpot>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Jackpots.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Jackpot>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Jackpot>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Jackpots.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Jackpots.ToList();
                    }
                };

                return await new Task<List<Jackpot>>(a);
            }
        }

        public async static Task<Jackpot> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Jackpot> a = () =>
                {
                    return dc.Jackpots.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Jackpot>(a);
            }
        }
    }

    public partial class LeagueData
    {
        public static List<League> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Leagues.Where(i => i.DateDeleted == null).ToList() : dc.Leagues.ToList();
            }
        }

        public static League GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Leagues.SingleOrDefault(u => u.Id == id);
            }
        }

        public static League Save(Credentials cr, League item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static League Create(Credentials cr, League item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Leagues.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static League Update(Credentials cr, League item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Leagues.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<League>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Leagues.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<League>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<League>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Leagues.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Leagues.ToList();
                    }
                };

                return await new Task<List<League>>(a);
            }
        }

        public async static Task<League> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<League> a = () =>
                {
                    return dc.Leagues.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<League>(a);
            }
        }
    }

    public partial class RequestData
    {
        public static List<Request> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Requests.Where(i => i.DateDeleted == null).ToList() : dc.Requests.ToList();
            }
        }

        public static Request GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Requests.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Request Save(Credentials cr, Request item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Request Create(Credentials cr, Request item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Requests.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Request Update(Credentials cr, Request item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Requests.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Request>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Requests.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Request>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Request>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Requests.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Requests.ToList();
                    }
                };

                return await new Task<List<Request>>(a);
            }
        }

        public async static Task<Request> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Request> a = () =>
                {
                    return dc.Requests.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Request>(a);
            }
        }
    }

    public partial class ShiftData
    {
        public static List<Shift> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Shifts.Where(i => i.DateDeleted == null).ToList() : dc.Shifts.ToList();
            }
        }

        public static Shift GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Shifts.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Shift Save(Credentials cr, Shift item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Shift Create(Credentials cr, Shift item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Shifts.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Shift Update(Credentials cr, Shift item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Shifts.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Shift>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Shifts.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Shift>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Shift>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Shifts.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Shifts.ToList();
                    }
                };

                return await new Task<List<Shift>>(a);
            }
        }

        public async static Task<Shift> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Shift> a = () =>
                {
                    return dc.Shifts.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Shift>(a);
            }
        }
    }

    public partial class StructureDetailData
    {
        public static List<StructureDetail> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.StructureDetails.Where(i => i.DateDeleted == null).ToList() : dc.StructureDetails.ToList();
            }
        }

        public static StructureDetail GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.StructureDetails.SingleOrDefault(u => u.Id == id);
            }
        }

        public static StructureDetail Save(Credentials cr, StructureDetail item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static StructureDetail Create(Credentials cr, StructureDetail item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.StructureDetails.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static StructureDetail Update(Credentials cr, StructureDetail item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.StructureDetails.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<StructureDetail>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.StructureDetails.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<StructureDetail>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<StructureDetail>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.StructureDetails.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.StructureDetails.ToList();
                    }
                };

                return await new Task<List<StructureDetail>>(a);
            }
        }

        public async static Task<StructureDetail> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<StructureDetail> a = () =>
                {
                    return dc.StructureDetails.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<StructureDetail>(a);
            }
        }
    }

    public partial class StructureData
    {
        public static List<Structure> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Structures.Where(i => i.DateDeleted == null).ToList() : dc.Structures.ToList();
            }
        }

        public static Structure GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Structures.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Structure Save(Credentials cr, Structure item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Structure Create(Credentials cr, Structure item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Structures.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Structure Update(Credentials cr, Structure item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Structures.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Structure>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Structures.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Structure>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Structure>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Structures.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Structures.ToList();
                    }
                };

                return await new Task<List<Structure>>(a);
            }
        }

        public async static Task<Structure> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Structure> a = () =>
                {
                    return dc.Structures.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Structure>(a);
            }
        }
    }

    public partial class TournamentCashoutData
    {
        public static List<TournamentCashout> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.TournamentCashouts.Where(i => i.DateDeleted == null).ToList() : dc.TournamentCashouts.ToList();
            }
        }

        public static TournamentCashout GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.TournamentCashouts.SingleOrDefault(u => u.Id == id);
            }
        }

        public static TournamentCashout Save(Credentials cr, TournamentCashout item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static TournamentCashout Create(Credentials cr, TournamentCashout item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.TournamentCashouts.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static TournamentCashout Update(Credentials cr, TournamentCashout item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.TournamentCashouts.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<TournamentCashout>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.TournamentCashouts.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<TournamentCashout>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<TournamentCashout>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.TournamentCashouts.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.TournamentCashouts.ToList();
                    }
                };

                return await new Task<List<TournamentCashout>>(a);
            }
        }

        public async static Task<TournamentCashout> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<TournamentCashout> a = () =>
                {
                    return dc.TournamentCashouts.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<TournamentCashout>(a);
            }
        }
    }

    public partial class TournamentPlayerData
    {
        public static List<TournamentPlayer> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.TournamentPlayers.Where(i => i.DateDeleted == null).ToList() : dc.TournamentPlayers.ToList();
            }
        }

        public static TournamentPlayer GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);
            }
        }

        public static TournamentPlayer Save(Credentials cr, TournamentPlayer item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static TournamentPlayer Create(Credentials cr, TournamentPlayer item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.TournamentPlayers.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static TournamentPlayer Update(Credentials cr, TournamentPlayer item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.TournamentPlayers.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<TournamentPlayer>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<TournamentPlayer>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<TournamentPlayer>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.TournamentPlayers.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.TournamentPlayers.ToList();
                    }
                };

                return await new Task<List<TournamentPlayer>>(a);
            }
        }

        public async static Task<TournamentPlayer> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<TournamentPlayer> a = () =>
                {
                    return dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<TournamentPlayer>(a);
            }
        }
    }

    public partial class TournamentData
    {
        public static List<Tournament> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Tournaments.Where(i => i.DateDeleted == null).ToList() : dc.Tournaments.ToList();
            }
        }

        public static Tournament GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Tournaments.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Tournament Save(Credentials cr, Tournament item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Tournament Create(Credentials cr, Tournament item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Tournaments.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Tournament Update(Credentials cr, Tournament item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Tournaments.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Tournament>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Tournaments.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Tournament>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Tournament>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Tournaments.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Tournaments.ToList();
                    }
                };

                return await new Task<List<Tournament>>(a);
            }
        }

        public async static Task<Tournament> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Tournament> a = () =>
                {
                    return dc.Tournaments.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Tournament>(a);
            }
        }
    }

    public partial class TransactionData
    {
        public static List<Transaction> GetList(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return onlyActive.True() ? dc.Transactions.Where(i => i.DateDeleted == null).ToList() : dc.Transactions.ToList();
            }
        }

        public static Transaction GetById(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                return dc.Transactions.SingleOrDefault(u => u.Id == id);
            }
        }

        public static Transaction Save(Credentials cr, Transaction item)
        {
            var loaded = GetById(cr, item.Id);
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        private static Transaction Create(Credentials cr, Transaction item)
        {
            item.PrepareToSave(cr);

            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Transactions.InsertOnSubmit(item);
                dc.SubmitChanges();
            }

            return GetById(cr, item.Id);
        }

        private static Transaction Update(Credentials cr, Transaction item)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var itemToUpdate = dc.Transactions.SingleOrDefault(u => u.Id == item.Id);

                if (itemToUpdate.IsNotNull())
                {
                    string[] igoreList = { "Id", "DateCreated", "CreatedByUserId" };

                    item.CompareAndUpdate<Transaction>(ref itemToUpdate, igoreList);

                    dc.SubmitChanges();
                }
            }

            return GetById(cr, item.Id);
        }

        public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Transactions.SingleOrDefault(u => u.Id == id);

                if (toDelete.IsNotNull())
                {
                    toDelete.DateDeleted = DateTime.Now;
                    dc.SubmitChanges();
                }
            }
        }

        public async static Task<List<Transaction>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Transaction>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Transactions.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Transactions.ToList();
                    }
                };

                return await new Task<List<Transaction>>(a);
            }
        }

        public async static Task<Transaction> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Transaction> a = () =>
                {
                    return dc.Transactions.SingleOrDefault(u => u.Id == id);

                };

                return await new Task<Transaction>(a);
            }
        }
    }


}