namespace KoudWS.Exceptions
{
    public class TvShowNotAdded : Exception
    {
        public TvShowNotAdded(string name) : base($"El programa de televisión '{name}' no fue agregado.")
        {
        }        
    }
}