//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Collections.Generic;

namespace Tomighty
{
    public class SynchronousEventHub : IEventHub
    {
        private readonly IDictionary<Type, List<Action<object>>> allSubscribers = new Dictionary<Type, List<Action<object>>>();

        public void Publish(object @event)
        {
            var eventType = @event.GetType();

            if (!allSubscribers.ContainsKey(eventType))
                return;

            foreach (var subscriber in allSubscribers[eventType])
            {
                subscriber(@event);
            }
        }

        public void Subscribe<T>(Action<T> eventHandler)
        {
            List<Action<object>> subscribers;
            var eventType = typeof(T);

            if (allSubscribers.ContainsKey(eventType))
            {
                subscribers = allSubscribers[eventType];
            }
            else
            {
                subscribers = new List<Action<object>>();
                allSubscribers[eventType] = subscribers;
            }

            subscribers.Add(e => eventHandler((T) e));
        }
    }
}