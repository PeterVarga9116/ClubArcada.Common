using System;
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

			 Result<T> Save(Credentials cr);

             void LoadCreatedBy(Credentials cr);
		}

        public abstract class BaseClass<IDataClassLight>
        {
            public User CreatedByUser { get;  set;} 
        }
  

	  public partial class WebContent : BaseClass<WebContent>, IDataClassLight, IDataClass<WebContent>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            WebContentData.Delete(cr, Id);
        }

		public Result<WebContent> Save(Credentials cr) 
		{
			return WebContentData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class AuditHistory : BaseClass<AuditHistory>, IDataClassLight, IDataClass<AuditHistory>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            AuditHistoryData.Delete(cr, Id);
        }

		public Result<AuditHistory> Save(Credentials cr) 
		{
			return AuditHistoryData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Banner : BaseClass<Banner>, IDataClassLight, IDataClass<Banner>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            BannerData.Delete(cr, Id);
        }

		public Result<Banner> Save(Credentials cr) 
		{
			return BannerData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class BusinessUnit : BaseClass<BusinessUnit>, IDataClassLight, IDataClass<BusinessUnit>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            BusinessUnitData.Delete(cr, Id);
        }

		public Result<BusinessUnit> Save(Credentials cr) 
		{
			return BusinessUnitData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashGame : BaseClass<CashGame>, IDataClassLight, IDataClass<CashGame>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashGameData.Delete(cr, Id);
        }

		public Result<CashGame> Save(Credentials cr) 
		{
            return CashGameData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashIn : BaseClass<CashIn>, IDataClassLight, IDataClass<CashIn>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashInData.Delete(cr, Id);
        }

		public Result<CashIn> Save(Credentials cr) 
		{
			return CashInData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashOut : BaseClass<CashOut>, IDataClassLight, IDataClass<CashOut>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashOutData.Delete(cr, Id);
        }

		public Result<CashOut> Save(Credentials cr) 
		{
			return CashOutData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashPlayer : BaseClass<CashPlayer>, IDataClassLight, IDataClass<CashPlayer>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashPlayerData.Delete(cr, Id);
        }

		public Result<CashPlayer> Save(Credentials cr) 
		{
			return CashPlayerData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashState : BaseClass<CashState>, IDataClassLight, IDataClass<CashState>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashStateData.Delete(cr, Id);
        }

		public Result<CashState> Save(Credentials cr) 
		{
			return CashStateData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashTable : BaseClass<CashTable>, IDataClassLight, IDataClass<CashTable>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashTableData.Delete(cr, Id);
        }

		public Result<CashTable> Save(Credentials cr) 
		{
			return CashTableData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Image : BaseClass<Image>, IDataClassLight, IDataClass<Image>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            ImageData.Delete(cr, Id);
        }

		public Result<Image> Save(Credentials cr) 
		{
			return ImageData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Jackpot : BaseClass<Jackpot>, IDataClassLight, IDataClass<Jackpot>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            JackpotData.Delete(cr, Id);
        }

		public Result<Jackpot> Save(Credentials cr) 
		{
			return JackpotData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class League : BaseClass<League>, IDataClassLight, IDataClass<League>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            LeagueData.Delete(cr, Id);
        }

		public Result<League> Save(Credentials cr) 
		{
			return LeagueData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Request : BaseClass<Request>, IDataClassLight, IDataClass<Request>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            RequestData.Delete(cr, Id);
        }

		public Result<Request> Save(Credentials cr) 
		{
			return RequestData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Shift : BaseClass<Shift>, IDataClassLight, IDataClass<Shift>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            ShiftData.Delete(cr, Id);
        }

		public Result<Shift> Save(Credentials cr) 
		{
			return ShiftData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class StructureDetail : BaseClass<StructureDetail>, IDataClassLight, IDataClass<StructureDetail>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            StructureDetailData.Delete(cr, Id);
        }

		public Result<StructureDetail> Save(Credentials cr) 
		{
			return StructureDetailData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Structure : BaseClass<Structure>, IDataClassLight, IDataClass<Structure>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            StructureData.Delete(cr, Id);
        }

		public Result<Structure> Save(Credentials cr) 
		{
			return StructureData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class TicketItem : BaseClass<TicketItem>, IDataClassLight, IDataClass<TicketItem>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TicketItemData.Delete(cr, Id);
        }

		public Result<TicketItem> Save(Credentials cr) 
		{
			return TicketItemData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Ticket : BaseClass<Ticket>, IDataClassLight, IDataClass<Ticket>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TicketData.Delete(cr, Id);
        }

		public Result<Ticket> Save(Credentials cr) 
		{
			return TicketData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class TournamentCashout : BaseClass<TournamentCashout>, IDataClassLight, IDataClass<TournamentCashout>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TournamentCashoutData.Delete(cr, Id);
        }

		public Result<TournamentCashout> Save(Credentials cr) 
		{
			return TournamentCashoutData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class TournamentPlayer : BaseClass<TournamentPlayer>, IDataClassLight, IDataClass<TournamentPlayer>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TournamentPlayerData.Delete(cr, Id);
        }

		public Result<TournamentPlayer> Save(Credentials cr) 
		{
			return TournamentPlayerData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Transaction : BaseClass<Transaction>, IDataClassLight, IDataClass<Transaction>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TransactionData.Delete(cr, Id);
        }

		public Result<Transaction> Save(Credentials cr) 
		{
			return TransactionData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Accounting : BaseClass<Accounting>, IDataClassLight, IDataClass<Accounting>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            AccountingData.Delete(cr, Id);
        }

		public Result<Accounting> Save(Credentials cr) 
		{
			return AccountingData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class User : BaseClass<User>, IDataClassLight, IDataClass<User>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            UserData.Delete(cr, Id);
        }

		public Result<User> Save(Credentials cr) 
		{
			return UserData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class Tournament : BaseClass<Tournament>, IDataClassLight, IDataClass<Tournament>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            TournamentData.Delete(cr, Id);
        }

		public Result<Tournament> Save(Credentials cr) 
		{
			return TournamentData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   

	  public partial class CashGameProtocolItem : BaseClass<CashGameProtocolItem>, IDataClassLight, IDataClass<CashGameProtocolItem>
	  {
		public bool IsNew { get { return Id.IsEmpty(); } set { } }

        public string DateCreatedFriendlyDateTime { get { return DateCreated.ToString("dd.MM.yyyy HH:mm"); } private set { } }

        public string DateCreatedFriendlyDate { get { return DateCreated.ToString("dd.MM.yyyy"); } private set { } }

		public void Delete(Credentials cr)
        {
            CashGameProtocolItemData.Delete(cr, Id);
        }

		public Result<CashGameProtocolItem> Save(Credentials cr) 
		{
			return CashGameProtocolItemData.Save(cr, this);
		}

        public void LoadCreatedBy(Credentials cr)
        {
             var result = UserData.GetById(cr, CreatedByUserId);

			 CreatedByUser = result.HasError ? null : result.Item;
        }

		internal void PrepareToSave(Credentials cr)
		{
            if(Id.IsEmpty())
                Id = Guid.NewGuid();

            if (DateCreated.IsNull() || (DateCreated.IsNotNull() && DateCreated.Year < DateTime.Now.AddYears(-10).Year))
                DateCreated = DateTime.Now;

            if(CreatedByUserId.IsEmpty())
                CreatedByUserId = cr.UserId;
		}
	  }   
}  
 
namespace ClubArcada.Common.BusinessObjects.Data {

        public abstract class BaseClass
        {

        }
  
  public partial class WebContentData : BaseClass
  {
		public static Result<List<WebContent>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.WebContents.Where(i => i.DateDeleted == null).ToList() : dc.WebContents.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<WebContent>>.New(result, null);
					}
					else
					{
						return Result<List<WebContent>>.New(new List<WebContent>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<WebContent>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<WebContent> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.WebContents.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<WebContent>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<WebContent>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<WebContent> Save(Credentials cr, WebContent item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<WebContent> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.WebContents.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<WebContent> Create(Credentials cr, WebContent item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.WebContents.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<WebContent>.New(dc.WebContents.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<WebContent>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<WebContent> Update(Credentials cr, WebContent item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.WebContents.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<WebContent>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<WebContent>.New(dc.WebContents.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<WebContent>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.WebContents.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
				{
					toDelete.DateDeleted = DateTime.Now;
					dc.SubmitChanges();
				}
			}
        }

        public async static Task<List<WebContent>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<WebContent>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.WebContents.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.WebContents.ToList();
                    }
                };

                return await new Task<List<WebContent>>(a);
            }
        }

        public async static Task<WebContent> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<WebContent> a = () =>
                {
                    return dc.WebContents.SingleOrDefault(u => u.Id == id);
     
                };
			
                return await new Task<WebContent>(a);
            }
        }
  }  
  
  public partial class AuditHistoryData : BaseClass
  {
		public static Result<List<AuditHistory>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.AuditHistories.Where(i => i.DateDeleted == null).ToList() : dc.AuditHistories.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<AuditHistory>>.New(result, null);
					}
					else
					{
						return Result<List<AuditHistory>>.New(new List<AuditHistory>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<AuditHistory>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<AuditHistory> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.AuditHistories.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<AuditHistory>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<AuditHistory>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<AuditHistory> Save(Credentials cr, AuditHistory item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<AuditHistory> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.AuditHistories.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<AuditHistory> Create(Credentials cr, AuditHistory item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.AuditHistories.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<AuditHistory>.New(dc.AuditHistories.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<AuditHistory>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<AuditHistory> Update(Credentials cr, AuditHistory item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.AuditHistories.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<AuditHistory>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<AuditHistory>.New(dc.AuditHistories.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<AuditHistory>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.AuditHistories.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class BannerData : BaseClass
  {
		public static Result<List<Banner>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Banners.Where(i => i.DateDeleted == null).ToList() : dc.Banners.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Banner>>.New(result, null);
					}
					else
					{
						return Result<List<Banner>>.New(new List<Banner>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Banner>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Banner> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Banners.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Banner>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Banner>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Banner> Save(Credentials cr, Banner item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Banner> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Banners.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Banner> Create(Credentials cr, Banner item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Banners.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Banner>.New(dc.Banners.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Banner>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Banner> Update(Credentials cr, Banner item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Banners.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Banner>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Banner>.New(dc.Banners.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Banner>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Banners.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class BusinessUnitData : BaseClass
  {
		public static Result<List<BusinessUnit>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.BusinessUnits.Where(i => i.DateDeleted == null).ToList() : dc.BusinessUnits.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<BusinessUnit>>.New(result, null);
					}
					else
					{
						return Result<List<BusinessUnit>>.New(new List<BusinessUnit>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<BusinessUnit>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<BusinessUnit> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.BusinessUnits.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<BusinessUnit>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<BusinessUnit>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<BusinessUnit> Save(Credentials cr, BusinessUnit item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<BusinessUnit> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.BusinessUnits.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<BusinessUnit> Create(Credentials cr, BusinessUnit item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.BusinessUnits.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<BusinessUnit>.New(dc.BusinessUnits.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<BusinessUnit>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<BusinessUnit> Update(Credentials cr, BusinessUnit item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.BusinessUnits.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<BusinessUnit>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<BusinessUnit>.New(dc.BusinessUnits.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<BusinessUnit>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.BusinessUnits.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashGameData : BaseClass
  {
		public static Result<List<CashGame>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashGames.Where(i => i.DateDeleted == null).ToList() : dc.CashGames.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashGame>>.New(result, null);
					}
					else
					{
						return Result<List<CashGame>>.New(new List<CashGame>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashGame>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashGame> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashGames.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashGame>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashGame>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashGame> Save(Credentials cr, CashGame item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashGame> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashGames.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashGame> Create(Credentials cr, CashGame item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashGames.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashGame>.New(dc.CashGames.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashGame>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashGame> Update(Credentials cr, CashGame item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashGames.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashGame>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashGame>.New(dc.CashGames.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashGame>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashGames.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
				{
					toDelete.DateDeleted = DateTime.Now;
					dc.SubmitChanges();
				}
			}
        }

        public async static Task<List<CashGame>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashGame>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashGames.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashGames.ToList();
                    }
                };

                return await new Task<List<CashGame>>(a);
            }
        }

        public async static Task<CashGame> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashGame> a = () =>
                {
                    return dc.CashGames.SingleOrDefault(u => u.Id == id);
     
                };
			
                return await new Task<CashGame>(a);
            }
        }
  }  
  
  public partial class CashInData : BaseClass
  {
		public static Result<List<CashIn>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashIns.Where(i => i.DateDeleted == null).ToList() : dc.CashIns.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashIn>>.New(result, null);
					}
					else
					{
						return Result<List<CashIn>>.New(new List<CashIn>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashIn>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashIn> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashIns.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashIn>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashIn>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashIn> Save(Credentials cr, CashIn item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashIn> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashIns.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashIn> Create(Credentials cr, CashIn item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashIns.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashIn>.New(dc.CashIns.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashIn>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashIn> Update(Credentials cr, CashIn item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashIns.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashIn>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashIn>.New(dc.CashIns.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashIn>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashIns.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashOutData : BaseClass
  {
		public static Result<List<CashOut>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashOuts.Where(i => i.DateDeleted == null).ToList() : dc.CashOuts.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashOut>>.New(result, null);
					}
					else
					{
						return Result<List<CashOut>>.New(new List<CashOut>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashOut>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashOut> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashOuts.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashOut>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashOut>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashOut> Save(Credentials cr, CashOut item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashOut> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashOuts.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashOut> Create(Credentials cr, CashOut item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashOuts.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashOut>.New(dc.CashOuts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashOut>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashOut> Update(Credentials cr, CashOut item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashOuts.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashOut>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashOut>.New(dc.CashOuts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashOut>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashOuts.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashPlayerData : BaseClass
  {
		public static Result<List<CashPlayer>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashPlayers.Where(i => i.DateDeleted == null).ToList() : dc.CashPlayers.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashPlayer>>.New(result, null);
					}
					else
					{
						return Result<List<CashPlayer>>.New(new List<CashPlayer>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashPlayer>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashPlayer> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashPlayers.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashPlayer>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashPlayer> Save(Credentials cr, CashPlayer item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashPlayer> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashPlayers.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashPlayer> Create(Credentials cr, CashPlayer item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashPlayers.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashPlayer>.New(dc.CashPlayers.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashPlayer> Update(Credentials cr, CashPlayer item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashPlayers.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashPlayer>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashPlayer>.New(dc.CashPlayers.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashPlayers.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashStateData : BaseClass
  {
		public static Result<List<CashState>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashStates.Where(i => i.DateDeleted == null).ToList() : dc.CashStates.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashState>>.New(result, null);
					}
					else
					{
						return Result<List<CashState>>.New(new List<CashState>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashState>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashState> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashStates.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashState>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashState>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashState> Save(Credentials cr, CashState item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashState> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashStates.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashState> Create(Credentials cr, CashState item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashStates.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashState>.New(dc.CashStates.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashState>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashState> Update(Credentials cr, CashState item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashStates.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashState>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashState>.New(dc.CashStates.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashState>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashStates.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashTableData : BaseClass
  {
		public static Result<List<CashTable>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashTables.Where(i => i.DateDeleted == null).ToList() : dc.CashTables.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashTable>>.New(result, null);
					}
					else
					{
						return Result<List<CashTable>>.New(new List<CashTable>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashTable>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashTable> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashTables.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashTable>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashTable>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashTable> Save(Credentials cr, CashTable item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashTable> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashTables.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashTable> Create(Credentials cr, CashTable item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashTables.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashTable>.New(dc.CashTables.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashTable>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashTable> Update(Credentials cr, CashTable item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashTables.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashTable>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashTable>.New(dc.CashTables.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashTable>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashTables.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class ImageData : BaseClass
  {
		public static Result<List<Image>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Images.Where(i => i.DateDeleted == null).ToList() : dc.Images.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Image>>.New(result, null);
					}
					else
					{
						return Result<List<Image>>.New(new List<Image>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Image>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Image> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Images.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Image>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Image>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Image> Save(Credentials cr, Image item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Image> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Images.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Image> Create(Credentials cr, Image item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Images.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Image>.New(dc.Images.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Image>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Image> Update(Credentials cr, Image item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Images.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Image>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Image>.New(dc.Images.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Image>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Images.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class JackpotData : BaseClass
  {
		public static Result<List<Jackpot>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Jackpots.Where(i => i.DateDeleted == null).ToList() : dc.Jackpots.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Jackpot>>.New(result, null);
					}
					else
					{
						return Result<List<Jackpot>>.New(new List<Jackpot>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Jackpot>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Jackpot> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Jackpots.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Jackpot>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Jackpot>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Jackpot> Save(Credentials cr, Jackpot item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Jackpot> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Jackpots.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Jackpot> Create(Credentials cr, Jackpot item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Jackpots.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Jackpot>.New(dc.Jackpots.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Jackpot>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Jackpot> Update(Credentials cr, Jackpot item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Jackpots.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Jackpot>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Jackpot>.New(dc.Jackpots.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Jackpot>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Jackpots.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class LeagueData : BaseClass
  {
		public static Result<List<League>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Leagues.Where(i => i.DateDeleted == null).ToList() : dc.Leagues.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<League>>.New(result, null);
					}
					else
					{
						return Result<List<League>>.New(new List<League>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<League>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<League> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Leagues.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<League>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<League>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<League> Save(Credentials cr, League item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<League> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Leagues.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<League> Create(Credentials cr, League item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Leagues.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<League>.New(dc.Leagues.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<League>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<League> Update(Credentials cr, League item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Leagues.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<League>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<League>.New(dc.Leagues.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<League>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Leagues.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class RequestData : BaseClass
  {
		public static Result<List<Request>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Requests.Where(i => i.DateDeleted == null).ToList() : dc.Requests.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Request>>.New(result, null);
					}
					else
					{
						return Result<List<Request>>.New(new List<Request>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Request>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Request> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Requests.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Request>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Request>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Request> Save(Credentials cr, Request item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Request> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Requests.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Request> Create(Credentials cr, Request item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Requests.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Request>.New(dc.Requests.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Request>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Request> Update(Credentials cr, Request item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Requests.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Request>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Request>.New(dc.Requests.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Request>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Requests.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class ShiftData : BaseClass
  {
		public static Result<List<Shift>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Shifts.Where(i => i.DateDeleted == null).ToList() : dc.Shifts.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Shift>>.New(result, null);
					}
					else
					{
						return Result<List<Shift>>.New(new List<Shift>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Shift>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Shift> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Shifts.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Shift>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Shift>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Shift> Save(Credentials cr, Shift item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Shift> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Shifts.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Shift> Create(Credentials cr, Shift item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Shifts.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Shift>.New(dc.Shifts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Shift>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Shift> Update(Credentials cr, Shift item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Shifts.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Shift>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Shift>.New(dc.Shifts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Shift>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Shifts.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class StructureDetailData : BaseClass
  {
		public static Result<List<StructureDetail>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.StructureDetails.Where(i => i.DateDeleted == null).ToList() : dc.StructureDetails.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<StructureDetail>>.New(result, null);
					}
					else
					{
						return Result<List<StructureDetail>>.New(new List<StructureDetail>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<StructureDetail>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<StructureDetail> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.StructureDetails.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<StructureDetail>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<StructureDetail>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<StructureDetail> Save(Credentials cr, StructureDetail item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<StructureDetail> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.StructureDetails.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<StructureDetail> Create(Credentials cr, StructureDetail item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.StructureDetails.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<StructureDetail>.New(dc.StructureDetails.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<StructureDetail>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<StructureDetail> Update(Credentials cr, StructureDetail item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.StructureDetails.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<StructureDetail>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<StructureDetail>.New(dc.StructureDetails.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<StructureDetail>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.StructureDetails.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class StructureData : BaseClass
  {
		public static Result<List<Structure>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Structures.Where(i => i.DateDeleted == null).ToList() : dc.Structures.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Structure>>.New(result, null);
					}
					else
					{
						return Result<List<Structure>>.New(new List<Structure>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Structure>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Structure> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Structures.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Structure>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Structure>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Structure> Save(Credentials cr, Structure item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Structure> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Structures.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Structure> Create(Credentials cr, Structure item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Structures.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Structure>.New(dc.Structures.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Structure>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Structure> Update(Credentials cr, Structure item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Structures.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Structure>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Structure>.New(dc.Structures.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Structure>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Structures.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class TicketItemData : BaseClass
  {
		public static Result<List<TicketItem>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.TicketItems.Where(i => i.DateDeleted == null).ToList() : dc.TicketItems.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<TicketItem>>.New(result, null);
					}
					else
					{
						return Result<List<TicketItem>>.New(new List<TicketItem>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<TicketItem>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<TicketItem> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.TicketItems.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<TicketItem>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<TicketItem>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<TicketItem> Save(Credentials cr, TicketItem item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<TicketItem> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.TicketItems.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<TicketItem> Create(Credentials cr, TicketItem item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.TicketItems.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<TicketItem>.New(dc.TicketItems.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TicketItem>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<TicketItem> Update(Credentials cr, TicketItem item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.TicketItems.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<TicketItem>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<TicketItem>.New(dc.TicketItems.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TicketItem>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.TicketItems.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
				{
					toDelete.DateDeleted = DateTime.Now;
					dc.SubmitChanges();
				}
			}
        }

        public async static Task<List<TicketItem>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<TicketItem>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.TicketItems.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.TicketItems.ToList();
                    }
                };

                return await new Task<List<TicketItem>>(a);
            }
        }

        public async static Task<TicketItem> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<TicketItem> a = () =>
                {
                    return dc.TicketItems.SingleOrDefault(u => u.Id == id);
     
                };
			
                return await new Task<TicketItem>(a);
            }
        }
  }  
  
  public partial class TicketData : BaseClass
  {
		public static Result<List<Ticket>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Tickets.Where(i => i.DateDeleted == null).ToList() : dc.Tickets.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Ticket>>.New(result, null);
					}
					else
					{
						return Result<List<Ticket>>.New(new List<Ticket>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Ticket>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Ticket> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Tickets.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Ticket>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Ticket>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Ticket> Save(Credentials cr, Ticket item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Ticket> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Tickets.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Ticket> Create(Credentials cr, Ticket item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Tickets.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Ticket>.New(dc.Tickets.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Ticket>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Ticket> Update(Credentials cr, Ticket item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Tickets.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Ticket>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Ticket>.New(dc.Tickets.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Ticket>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Tickets.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
				{
					toDelete.DateDeleted = DateTime.Now;
					dc.SubmitChanges();
				}
			}
        }

        public async static Task<List<Ticket>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<Ticket>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.Tickets.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.Tickets.ToList();
                    }
                };

                return await new Task<List<Ticket>>(a);
            }
        }

        public async static Task<Ticket> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<Ticket> a = () =>
                {
                    return dc.Tickets.SingleOrDefault(u => u.Id == id);
     
                };
			
                return await new Task<Ticket>(a);
            }
        }
  }  
  
  public partial class TournamentCashoutData : BaseClass
  {
		public static Result<List<TournamentCashout>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.TournamentCashouts.Where(i => i.DateDeleted == null).ToList() : dc.TournamentCashouts.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<TournamentCashout>>.New(result, null);
					}
					else
					{
						return Result<List<TournamentCashout>>.New(new List<TournamentCashout>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<TournamentCashout>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<TournamentCashout> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.TournamentCashouts.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<TournamentCashout>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentCashout>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<TournamentCashout> Save(Credentials cr, TournamentCashout item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<TournamentCashout> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.TournamentCashouts.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<TournamentCashout> Create(Credentials cr, TournamentCashout item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.TournamentCashouts.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<TournamentCashout>.New(dc.TournamentCashouts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentCashout>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<TournamentCashout> Update(Credentials cr, TournamentCashout item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.TournamentCashouts.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<TournamentCashout>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<TournamentCashout>.New(dc.TournamentCashouts.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentCashout>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.TournamentCashouts.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class TournamentPlayerData : BaseClass
  {
		public static Result<List<TournamentPlayer>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.TournamentPlayers.Where(i => i.DateDeleted == null).ToList() : dc.TournamentPlayers.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<TournamentPlayer>>.New(result, null);
					}
					else
					{
						return Result<List<TournamentPlayer>>.New(new List<TournamentPlayer>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<TournamentPlayer>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<TournamentPlayer> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<TournamentPlayer>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<TournamentPlayer> Save(Credentials cr, TournamentPlayer item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<TournamentPlayer> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.TournamentPlayers.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<TournamentPlayer> Create(Credentials cr, TournamentPlayer item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.TournamentPlayers.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<TournamentPlayer>.New(dc.TournamentPlayers.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<TournamentPlayer> Update(Credentials cr, TournamentPlayer item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.TournamentPlayers.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<TournamentPlayer>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<TournamentPlayer>.New(dc.TournamentPlayers.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<TournamentPlayer>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.TournamentPlayers.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class TransactionData : BaseClass
  {
		public static Result<List<Transaction>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Transactions.Where(i => i.DateDeleted == null).ToList() : dc.Transactions.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Transaction>>.New(result, null);
					}
					else
					{
						return Result<List<Transaction>>.New(new List<Transaction>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Transaction>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Transaction> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Transactions.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Transaction>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Transaction>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Transaction> Save(Credentials cr, Transaction item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Transaction> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Transactions.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Transaction> Create(Credentials cr, Transaction item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Transactions.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Transaction>.New(dc.Transactions.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Transaction>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Transaction> Update(Credentials cr, Transaction item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Transactions.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Transaction>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Transaction>.New(dc.Transactions.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Transaction>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Transactions.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class AccountingData : BaseClass
  {
		public static Result<List<Accounting>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Accountings.Where(i => i.DateDeleted == null).ToList() : dc.Accountings.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Accounting>>.New(result, null);
					}
					else
					{
						return Result<List<Accounting>>.New(new List<Accounting>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Accounting>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Accounting> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Accountings.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Accounting>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Accounting>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Accounting> Save(Credentials cr, Accounting item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Accounting> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Accountings.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Accounting> Create(Credentials cr, Accounting item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Accountings.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Accounting>.New(dc.Accountings.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Accounting>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Accounting> Update(Credentials cr, Accounting item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Accountings.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Accounting>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Accounting>.New(dc.Accountings.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Accounting>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Accountings.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class UserData : BaseClass
  {
		public static Result<List<User>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Users.Where(i => i.DateDeleted == null).ToList() : dc.Users.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<User>>.New(result, null);
					}
					else
					{
						return Result<List<User>>.New(new List<User>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<User>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<User> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Users.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<User>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<User>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<User> Save(Credentials cr, User item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<User> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Users.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<User> Create(Credentials cr, User item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Users.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<User>.New(dc.Users.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<User>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<User> Update(Credentials cr, User item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Users.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<User>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<User>.New(dc.Users.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<User>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Users.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class TournamentData : BaseClass
  {
		public static Result<List<Tournament>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.Tournaments.Where(i => i.DateDeleted == null).ToList() : dc.Tournaments.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<Tournament>>.New(result, null);
					}
					else
					{
						return Result<List<Tournament>>.New(new List<Tournament>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<Tournament>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<Tournament> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.Tournaments.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<Tournament>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<Tournament>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<Tournament> Save(Credentials cr, Tournament item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<Tournament> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.Tournaments.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<Tournament> Create(Credentials cr, Tournament item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.Tournaments.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<Tournament>.New(dc.Tournaments.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Tournament>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<Tournament> Update(Credentials cr, Tournament item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.Tournaments.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<Tournament>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<Tournament>.New(dc.Tournaments.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<Tournament>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.Tournaments.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
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
  
  public partial class CashGameProtocolItemData : BaseClass
  {
		public static Result<List<CashGameProtocolItem>> GetList(Credentials cr, bool? onlyActive = true, bool? loadCreatedByUser = true)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = onlyActive.True() ? dc.CashGameProtocolItems.Where(i => i.DateDeleted == null).ToList() : dc.CashGameProtocolItems.ToList();

					if(result.Any())
					{
						if(loadCreatedByUser.True())
						{
							foreach(var r in result)
							{
								r.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == r.CreatedByUserId);
							}
						}

						return Result<List<CashGameProtocolItem>>.New(result, null);
					}
					else
					{
						return Result<List<CashGameProtocolItem>>.New(new List<CashGameProtocolItem>(), null);
					}
				}
			}
			catch(Exception exp)
			{
				return Result<List<CashGameProtocolItem>>.New(null, exp.GetExceptionDetails());
			}
            
        }

		public static Result<CashGameProtocolItem> GetById(Credentials cr, Guid id)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var result = dc.CashGameProtocolItems.SingleOrDefault(u => u.Id == id);

					if(result.IsNotNull())
						result.CreatedByUser = dc.Users.SingleOrDefault(u => u.Id == result.CreatedByUserId);
                
					return Result<CashGameProtocolItem>.New(result, null);
				}
			}
			catch(Exception exp)
			{
				return Result<CashGameProtocolItem>.New(null, exp.GetExceptionDetails());
			}
        }

		public static Result<CashGameProtocolItem> Save(Credentials cr, CashGameProtocolItem item)
        {
            var loaded = GetById(cr, item.Id).Item;
            return loaded.IsNull() ? Create(cr, item) : Update(cr, item);
        }

        public static void SaveAll(Credentials cr, List<CashGameProtocolItem> items)
        {
            foreach(var i in items)
                i.PrepareToSave(cr);
            
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                dc.CashGameProtocolItems.InsertAllOnSubmit(items);
                dc.SubmitChanges();
            }
        }

		private static Result<CashGameProtocolItem> Create(Credentials cr, CashGameProtocolItem item)
        {
            item.PrepareToSave(cr);
            
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					dc.CashGameProtocolItems.InsertOnSubmit(item);
					dc.SubmitChanges();

					return Result<CashGameProtocolItem>.New(dc.CashGameProtocolItems.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashGameProtocolItem>.New(null, exp.GetExceptionDetails());
			}
        }

		private static Result<CashGameProtocolItem> Update(Credentials cr, CashGameProtocolItem item)
        {
			try
			{
				using (var dc = CADBDataContext.New(cr.ConnectionString))
				{
					var itemToUpdate = dc.CashGameProtocolItems.SingleOrDefault(u => u.Id == item.Id);
				
					if(itemToUpdate.IsNotNull())
					{
						string[] igoreList = { "Id", "DateCreated", "CreatedByUserId", "CreatedByUser", "Detail" };
						item.CompareAndUpdate<CashGameProtocolItem>(ref itemToUpdate, igoreList);
						dc.SubmitChanges();
					}

					return Result<CashGameProtocolItem>.New(dc.CashGameProtocolItems.SingleOrDefault(c => c.Id == item.Id));
				}
			}
			catch(Exception exp)
			{
				return Result<CashGameProtocolItem>.New(null, exp.GetExceptionDetails());
			}
        }

		public static void Delete(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                var toDelete = dc.CashGameProtocolItems.SingleOrDefault(u => u.Id == id);
				
				if(toDelete.IsNotNull())
				{
					toDelete.DateDeleted = DateTime.Now;
					dc.SubmitChanges();
				}
			}
        }

        public async static Task<List<CashGameProtocolItem>> GetListAsync(Credentials cr, bool? onlyActive = true)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<List<CashGameProtocolItem>> a = () =>
                {
                    if (onlyActive.True())
                    {
                        return dc.CashGameProtocolItems.Where(i => i.DateDeleted == null).ToList();
                    }
                    else
                    {
                        return dc.CashGameProtocolItems.ToList();
                    }
                };

                return await new Task<List<CashGameProtocolItem>>(a);
            }
        }

        public async static Task<CashGameProtocolItem> GetByIdAsync(Credentials cr, Guid id)
        {
            using (var dc = CADBDataContext.New(cr.ConnectionString))
            {
                Func<CashGameProtocolItem> a = () =>
                {
                    return dc.CashGameProtocolItems.SingleOrDefault(u => u.Id == id);
     
                };
			
                return await new Task<CashGameProtocolItem>(a);
            }
        }
  }  
  

}  
 