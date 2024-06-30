namespace KoudWS.Interfaces
{
    public interface IValidatorService
    {
        void IsNull(object? obj, Exception exception, string propertyName, string errorMessage = "");
    }
}