namespace MicroLibs.Moeda.Factories
{
    internal interface IFactory<TResult> {

        TResult Get(IScope scope);

    }
}