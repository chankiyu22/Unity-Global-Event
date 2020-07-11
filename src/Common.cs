using System;
using UnityEngine.Events;

namespace Chankiyu22.UnityGlobalEvent
{

[Serializable]
public class GlobalEventUnityEvent : UnityEvent<GlobalEvent> {}

public class GlobalEventEventArgs : EventArgs
{
    public GlobalEvent globalEvent;
}

}
