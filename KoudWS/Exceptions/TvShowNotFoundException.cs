namespace KoudWS.Exceptions
{
    public class TvShowNotFoundException : Exception
    {
        public TvShowNotFoundException(string name) : base($"El programa de televisión '{name}' no existe.")
        {

        }
    }
}