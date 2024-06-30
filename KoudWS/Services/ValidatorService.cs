using KoudWS.Exceptions;
using KoudWS.Interfaces;

namespace KoudWS.Services
{
    public class ValidatorService : IValidatorService
    {
        public void IsNull(object? obj, Exception exception, string propertyName, string errorMessage = "")
        {
            try
            {
                if (obj == null)
                {
                    switch (exception)
                    {
                        case InvalidOperationException:
                            GenerateInvalidOperationException(propertyName, errorMessage);
                            break;
                        case ArgumentException:
                            GenerateArgumentException(propertyName, errorMessage);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GenerateInvalidOperationException(string propertyName, string errorMessage = "")
        {
            try
            {
                string message = ErrorMessageIsEmpty(errorMessage) ? $"'{propertyName}' no ha sido inicializado correctamente." : errorMessage;

                throw new InvalidOperationException(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GenerateArgumentException(string propertyName, string errorMessage = "")
        {
            try
            {
                string message = ErrorMessageIsEmpty(errorMessage) ? $"'{propertyName}' no ha sido inicializado correctamente." : errorMessage;
                throw new ArgumentException(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool ErrorMessageIsEmpty(string errorMessage) => errorMessage == "";
    }
}