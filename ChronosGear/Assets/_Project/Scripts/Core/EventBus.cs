using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, Delegate> _events = new();
    
    public static void Subscribe<T>(Action<T> handler) where T : struct
    {
        var type = typeof(T);
        if (_events.ContainsKey(type))
            _events[type] = Delegate.Combine(_events[type], handler);
        else
            _events[type] = handler;
    }
    
    public static void Unsubscribe<T>(Action<T> handler) where T : struct
    {
        var type = typeof(T);
        if (_events.ContainsKey(type))
            _events[type] = Delegate.Remove(_events[type], handler);
    }
    
    public static void Publish<T>(T evt) where T : struct
    {
        var type = typeof(T);
        if (_events.TryGetValue(type, out var handler))
            ((Action<T>)handler)?.Invoke(evt);
    }
}

// Basic Event Definitions
public struct OnPlayerDamaged { public int Damage; public int CurrentHP; }
public struct OnSkillUsed { public string SkillId; public float TPCost; } // Time Points
public struct OnEnemyDefeated { public string EnemyId; public int ShardsDrop; }
public struct OnAgingChanged { public float OldValue; public float NewValue; }
