﻿using System;
using System.Atomic.Implementations;
using UnityEngine;

namespace Entity.Components
{
    public sealed class HitPointsComponent
    {
        public event Action<int> ValueChanged
        {
            add => _hitPoints.Subscribe(value);
            remove => _hitPoints.Unsubscribe(value);
        }
        public int Value
        {
            get => _hitPoints.Value;
            set => _hitPoints.Value = Mathf.Clamp(value, 0, _maxHitPoints.Value);
        }

        public int MaxHitPoints => _maxHitPoints.Value;

        private readonly AtomicVariable<int> _hitPoints;
        private readonly AtomicVariable<int> _maxHitPoints;

        public HitPointsComponent(AtomicVariable<int> hitPoints, AtomicVariable<int> maxHitPoints)
        {
            _hitPoints = hitPoints;
            _maxHitPoints = maxHitPoints;
        }
    }
}
