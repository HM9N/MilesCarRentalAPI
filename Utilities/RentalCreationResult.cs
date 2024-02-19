namespace MilesCarRentalApi.Utilities
{
    public class RentalCreationResult
    {
        public bool Success { get; }
        public string Message { get; }

        public RentalCreationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    }
}
