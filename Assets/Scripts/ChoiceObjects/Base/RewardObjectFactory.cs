using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObjectFactory : Singleton<RewardObjectFactory>
{
    List<RewardObject> spawnedRewardObjects = new();
    public RewardObject Get(RewardObject rewardObjectToGet)
    {
        RewardObject spawn = Instantiate(rewardObjectToGet);
        spawnedRewardObjects.Add(spawn);
        return spawn;
    }

    public void DespawnAll()
    {
        foreach (RewardObject spawn in spawnedRewardObjects)
        {
            Destroy(spawn.gameObject);
        }
        spawnedRewardObjects.Clear();
    }
}
