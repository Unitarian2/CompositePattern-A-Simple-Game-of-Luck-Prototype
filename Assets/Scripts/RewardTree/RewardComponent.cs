using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewardComponent
{
    public readonly List<RewardComponent> rewards = new();

    public abstract RewardObject RewardObject { get; set; }

    public void Add(RewardComponent component)
    {
        rewards.Add(component);
    }

    public void Remove(RewardComponent component)
    {
        rewards.Remove(component);
    }
    public abstract void Operation(List<RewardObject> rewardObjectList);
}
