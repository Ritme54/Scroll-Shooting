using System;
using System.Collections.Generic;

public enum Condition { A, B, C } // ���� Ű Ÿ��

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
                dict[condition] = existing + action; // ��������Ʈ �ռ�
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

        // �� �ڵ鷯�� ���ܸ� ������ �ٸ� �ڵ鷯�� ������ ���� ���� ȣ��
        foreach (Action single in toInvoke.GetInvocationList())
        {
            try
            {
                single?.Invoke();
            }
            catch (Exception ex)
            {
                // �α� Ȥ�� ���� ó�� ��å
                UnityEngine.Debug.LogException(ex);
            }
        }
    }
}