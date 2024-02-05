using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EventHandler : ScriptableObject
{
    public event Action<float> OnRewardCollected;

    public void OnRewardCollectedEvent(float value) { OnRewardCollected?.Invoke(value); }
}
