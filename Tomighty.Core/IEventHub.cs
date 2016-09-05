//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;

namespace Tomighty
{
    public interface IEventHub
    {
        void Publish(object @event);
        void Subscribe<T>(Action<T> eventHandler);
    }
}