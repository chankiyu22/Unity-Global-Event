using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chankiyu22.UnityGlobalEvent
{

[Serializable]
class GlobalEventGlobalEventUnityEvent
{
    [SerializeField]
    private GlobalEvent m_globalEvent = null;

    public GlobalEvent globalEvent
    {
        get
        {
            return m_globalEvent;
        }
    }

    [SerializeField]
    private GlobalEventUnityEvent m_actions = null;

    public GlobalEventUnityEvent actions
    {
        get
        {
            return m_actions;
        }
    }
}

public class GlobalEventDispatcher : MonoBehaviour
{
    private Dictionary<GlobalEvent, GlobalEventUnityEvent> m_globalEventMap = new Dictionary<GlobalEvent, GlobalEventUnityEvent>();

    [SerializeField]
    private List<GlobalEventGlobalEventUnityEvent> m_events = new List<GlobalEventGlobalEventUnityEvent>();

    public event EventHandler<GlobalEventEventArgs> OnEventInvoke;

    void Awake()
    {
        foreach (GlobalEventGlobalEventUnityEvent e in m_events)
        {
            m_globalEventMap.Add(e.globalEvent, e.actions);
            e.globalEvent.OnInvoke += HandleGlobalEventInvoke;
        }
    }

    void HandleGlobalEventInvoke(object sender, GlobalEventEventArgs args)
    {
        GlobalEvent globalEvent = args.globalEvent;

        if (m_globalEventMap.ContainsKey(globalEvent))
        {
            m_globalEventMap[globalEvent].Invoke(globalEvent);

            if (OnEventInvoke != null)
            {
                OnEventInvoke.Invoke(this, new GlobalEventEventArgs() {
                    globalEvent = globalEvent
                });
            }
        }
    }
}

}
