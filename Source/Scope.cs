namespace MicroLibs.Moeda
{
    public class Scope : IScope
    {
        private readonly MoedaApp _moedaApp;

        public Scope(MoedaApp moedaApp)
        {
            _moedaApp = moedaApp;
        }


        public TResult Get<TResult>()
        {
            return _moedaApp.Get<TResult>();
        }
    }
}