using System;

namespace MicroLibs.Moeda.Factories
{
    internal class SingleFactory<TResult> : Factory<TResult>
    {
        private TResult _value;

        public SingleFactory(Func<IScope, TResult> func) : base(func) {

        }
        public override TResult Get(IScope scope)
        {
            if(_value == null) {
                _value = base.Get(scope);
            }
            return _value;
        }
    }
}