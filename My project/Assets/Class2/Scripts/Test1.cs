using System;
using System.Collections.Generic;

public enum Condition { A, B, C } // 예시 키 타입

public static class EventBus
{
    private static readonly Dictionary<Condition, Action> dict = new Dictionary<Condition, Action>();
    private static readonly object sync = new object();

    public static void Subscribe(Condition condition, Action action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        lock (sync)
        {
            if (dict.TryGetValue(condition, out var existing))
            {
                dict[condition] = existing + action; // 델리게이트 합성
            }
            else
            {
                dict[condition] = action;
            }
        }
    }

    public static void Unsubscribe(Condition condition, Action action)
    {
        if (action == null) return;
        lock (sync)
        {
            if (dict.TryGetValue(condition, out var existing))
            {
                existing -= action;
                if (existing == null)
                    dict.Remove(condition);
                else
                    dict[condition] = existing;
            }
        }
    }

    public static void Publish(Condition condition)
    {
        Action toInvoke = null;
        lock (sync)
        {
            dict.TryGetValue(condition, out toInvoke);
        }

        if (toInvoke == null) return;

        // 각 핸들러가 예외를 던져도 다른 핸들러에 영향이 없게 안전 호출
        foreach (Action single in toInvoke.GetInvocationList())
        {
            try
            {
                single?.Invoke();
            }
            catch (Exception ex)
            {
                // 로깅 혹은 예외 처리 정책
                UnityEngine.Debug.LogException(ex);
            }
        }
    }
}