using System;
using System.Collections.Generic;
using Plugins.EventBus;
using UnityEngine;

namespace EventBus
{

    public class EventBus
    {
        private static Dictionary<Type, List<Delegate>> _events =  new Dictionary<Type, List<Delegate>>();

        public static void Subscribe<T>(Action<T> handler) where T : class
        {
            if (_events.ContainsKey(typeof(T)))
            {
                _events[typeof(T)].Add(handler);
            }
            else
            {
                _events.Add(typeof(T), new List<Delegate> { handler });
            }
        }

        public static void Unsubscribe<T>(Action<T> handler) where T : class
        {
            if (!_events.ContainsKey(typeof(T)) || !_events[typeof(T)].Contains(handler))
            {
                throw new ArgumentException(nameof(T));
            }
            _events[typeof(T)].Remove(handler);
        }

        public static void Publish<T>(T ev) where T : IEvent
        {
            if (!_events.ContainsKey(typeof(T)))
            {
                throw new ArgumentException(nameof(T));
            }
            foreach (var callback in _events[typeof(T)])
            {
                (callback as Action<T>)?.Invoke(ev);
            }
        }
    }
}