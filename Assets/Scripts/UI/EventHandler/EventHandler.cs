using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EventHandler : ScriptableObject
{
    public event Action<float,float> OnRewardCollected;
    public event Action<int> OnModifierChanged;
    public event Action<int> OnBriefcaseOpened;

    public void OnBriefcaseOpenedEvent(int currentBriefcase) { OnBriefcaseOpened?.Invoke(currentBriefcase); }

    public void OnModifierChangedEvent(int modifier) { OnModifierChanged?.Invoke(modifier); }

    public void OnRewardCollectedEvent(float rewardValue,int modifier) { OnRewardCollected?.Invoke(rewardValue, modifier); }
}
