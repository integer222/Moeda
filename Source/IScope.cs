namespace MicroLibs.Moeda
{
    public interface IScope
    {
        public TResult Get<TResult>();
    }
}