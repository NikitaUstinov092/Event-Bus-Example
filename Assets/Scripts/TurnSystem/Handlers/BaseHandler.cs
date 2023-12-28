using System;
using Zenject;

namespace TurnSystem.Handlers
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        [Inject]
        protected EventBus EventBus { get; }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<T>(HandleEvent);
        }

        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<T>(HandleEvent);
        }

        protected abstract void HandleEvent(T evt);
    }
}