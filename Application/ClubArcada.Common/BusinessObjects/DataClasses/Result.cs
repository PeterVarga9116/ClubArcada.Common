namespace ClubArcada.Common.BusinessObjects.DataClasses
{
    public class Result<T>
    {
        public static Result<T> New(T item, string errorDetails = null)
        {
            return new Result<T>()
            {
                Item = item,
                ErrorDetails = errorDetails,
                HasError = errorDetails.IsNotNullOrEmpty()
            };
        }

        public T Item { get; set; }

        public bool HasError { get; set; }

        public string ErrorDetails { get; set; }
    }
}
