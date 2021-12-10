using System;

namespace MicroLibs.Moeda.Factories
{
    internal class Factory<TResult> : IFactory<TResult>
    {
        private readonly Func<IScope, TResult> _func;

        public Factory(Func<IScope, TResult> func) {
            _func = func;
        }

        public virtual TResult Get(IScope scope)
        {
            return _func.Invoke(scope);
        }
    }
}