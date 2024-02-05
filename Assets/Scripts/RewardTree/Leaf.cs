using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Leaf : RewardComponent
{
    public override RewardObject RewardObject { get; set; }

    public override void Operation(List<RewardObject> rewardObjectList)
    {
        //�nce Briefcase'i listeden ��kar�yoruz. ��nk� parasal bir de�eri yok.
        List<RewardObject> rewardList = new List<RewardObject>();
        foreach (RewardObject reward in rewardObjectList)
        {
            if (reward is Briefcase) continue;
            rewardList.Add(reward);
        }

        int chosenRewardIndex = Random.Range(0, rewardList.Count);
        RewardObject = RewardObjectFactory.Instance.Get(rewardList[chosenRewardIndex]);
        
    }
}
