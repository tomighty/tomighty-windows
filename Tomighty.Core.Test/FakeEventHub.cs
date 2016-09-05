//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tomighty.Test
{
    public class FakeEventHub : IEventHub
    {
        private readonly List<Subscriber> subscribers = new List<Subscriber>();
        private readonly List<object> publishedEvents = new List<object>();

        public IEnumerable<T> PublishedEvents<T>()
        {
            return publishedEvents.Where(e => e.GetType() == typeof(T)).Select(e => (T) e);
        }

        public void Publish(object @event)
        {
            publishedEvents.Add(@event);

            foreach (var subscriber in subscribers)
            {
                subscriber.Handle(@event);
            }
        }

        public void Subscribe<T>(Action<T> eventHandler)
        {
            Action<object> proxy = @event => eventHandler((T) @event);
            subscribers.Add(new Subscriber(typeof(T), proxy));
        }

        private class Subscriber
        {
            private readonly Type eventType;
            private readonly Action<object> eventHandler;

            public Subscriber(Type eventType, Action<object> eventHandler)
            {
                this.eventType = eventType;
                this.eventHandler = eventHandler;
            }

            public void Handle(object @event)
            {
                if (eventType == @event.GetType())
                {
                    eventHandler(@event);
                }
            }
        }
    }
}