using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : RewardComponent
{
    public override RewardObject RewardObject { get; set ; }

    public override void Operation(List<RewardObject> rewardObjectList)
    {
        //Branch'lerin hepsinin rewardObject'inin Briefcase olmasýný istiyoruz.
        foreach (RewardObject obj in rewardObjectList)
        {
            if (obj is Briefcase)
            {
                RewardObject = RewardObjectFactory.Instance.Get(obj);
            }
        }

        foreach (var reward in rewards)
        {
            reward.Operation(rewardObjectList);
        }
    }
}
