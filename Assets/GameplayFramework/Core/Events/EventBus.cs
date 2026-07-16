using System;
using System.Collections.Generic;

namespace GameplayFramework.Core.Events
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, Delegate> _subscribers = new();
        public static void Subscribe<T>(Action<T> listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException(nameof(listener));
            }
            Type eventType = typeof(T);
            if (_subscribers.TryGetValue(eventType, out var existingDelegate))
            {
                _subscribers[eventType] = Delegate.Combine(existingDelegate, listener);
            }
            else
            {
                _subscribers[eventType] = listener;
            }
        }

        public static void Unsubscribe<T>(Action<T> listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException(nameof(listener));
            }
            Type eventType = typeof(T);
            if (_subscribers.TryGetValue(eventType, out var existingDelegate))
            {
                var newDelegate = Delegate.Remove(existingDelegate, listener);
                if (newDelegate == null)
                {
                    _subscribers.Remove(eventType);
                }
                else
                {
                    _subscribers[eventType] = newDelegate;
                }
            }
        }

        public static void Publish<T>(T eventData)
        {
            Type eventType = typeof(T);
            if (_subscribers.TryGetValue(eventType, out var existingDelegate))
            {
                if (existingDelegate is Action<T> action)
                {
                    action(eventData);
                }
            }
        }



    }


}
