using System;
using System.Collections.Generic;
using MicroLibs.Moeda.Factories;
using MicroLibs.Moeda.Qualifiers;

namespace MicroLibs.Moeda
{
    public class Module {
        
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public void Single<TResult>(Func<IScope, TResult> action, IQualifier qualifier = null)
        {
            var key = CreateKey(typeof(TResult), qualifier);
            _dictionary[key] = new SingleFactory<TResult>(action);
        }

        public void Factory<TResult>(Func<IScope, TResult> action, IQualifier qualifier = null) {
            var key = CreateKey(typeof(TResult), qualifier);
            _dictionary[key] = new Factory<TResult>(action);
        }

        internal Dictionary<string, object> GetDictionary()
        {
            return _dictionary;
        }

        private static string CreateKey(Type type, IQualifier qualifier)
        {
            return IndexKeyUtils.CreateKey(type, qualifier);
        }
    }
}