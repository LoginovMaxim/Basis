﻿using System;
using Basis.App.Views;

namespace Basis.App.Pool
{
    public interface IPoolService
    {
        bool TryAddViewPool(Type viewObjectType, IViewPool viewPool);
        bool TryRemoveViewPool(Type viewObjectType);
        bool TrySpawnView<TViewObjectType>(int entityId) where TViewObjectType : IViewObject;
        bool TrySpawnView<TViewObjectType>(int entityId, out IViewObject viewObject) where TViewObjectType : IViewObject;
        bool TryDespawnView(int entityId);
    }
}