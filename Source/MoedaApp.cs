using System;
using System.Collections.Generic;
using MicroLibs.Moeda.Factories;
using MicroLibs.Moeda.Qualifiers;
using UnityEngine;

namespace MicroLibs.Moeda
{
    public class MoedaApp
    {
        
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        private readonly Dictionary<Type, Module> _modules = new Dictionary<Type, Module>();

        private readonly IScope _scope;

        public MoedaApp()
        {
            _scope = new Scope(this);
        }

        public void Load(Module module)
        {
            foreach (var value in module.GetDictionary())
            {
                if (_dictionary.ContainsKey(value.Key))
                {
                    throw new Exception($"Duplicate object {value.Key}");
                }

                _dictionary[value.Key] = value.Value;
            }

            _modules[module.GetType()] = module;
        }

        public void Unload<T>() where T: Module
        {
            var module = _modules[typeof(T)];
            if (module == null)
            {
                Debug.Log($"Not found {typeof(T)}");
                return;
            }
            foreach (var value in module.GetDictionary())
            {
                _dictionary.Remove(value.Key);
            }
        }

        public TResult Inject<TResult>(IQualifier qualifier = null) {
            return Get<TResult>(qualifier);
        }

        public Lazy<TResult> InjectLazy<TResult>(IQualifier qualifier = null) {
            return new Lazy<TResult>(() => Get<TResult>(qualifier));
        }

        internal TResult Get<TResult>(IQualifier qualifier = null)
        {
            var key = CreateKey(typeof(TResult), qualifier);
            return ((IFactory<TResult>)_dictionary[key]).Get(_scope);
        }

        private static string CreateKey(Type type, IQualifier qualifier)
        {
            return IndexKeyUtils.CreateKey(type, qualifier);
        }
    }
}
