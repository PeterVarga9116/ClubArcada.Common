namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public partial class Shift
    {
        public EnumModel TypeEnum
        {
            get
            {
                return new EnumModel() { id = (int)Type, name = ((eShiftType)Type).GetDescription() };
            }
            set
            {
                this.Type = value.id;
            }
        }

        public void PrepareToSave()
        {
            UserId = User.Id;
            Type = TypeEnum.id;
        }
    }
}
