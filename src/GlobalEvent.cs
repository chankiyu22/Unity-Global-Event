using System;
using UnityEngine;

namespace Chankiyu22.UnityGlobalEvent
{

[CreateAssetMenu(menuName="Unity Global Event/Global Event")]
public class GlobalEvent : ScriptableObject
{
    [SerializeField]
    private string m_description;

    public event EventHandler<GlobalEventEventArgs> OnInvoke;

    public void Invoke()
    {
        if (OnInvoke != null)
        {
            OnInvoke.Invoke(this, new GlobalEventEventArgs() {
                globalEvent = this
            });
        }
    }
}

}
