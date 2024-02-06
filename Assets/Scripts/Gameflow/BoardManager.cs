using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject chosenObjMain;
    [SerializeField] private GameObject chosenObjChild1;
    [SerializeField] private GameObject chosenObjChild2;
    [SerializeField] private GameObject chosenObjChild3;
    [SerializeField] private GameObject chosenObjChild4;

    [SerializeField] private List<RewardObject> rewardObjectList;
    RewardComponent mainBranch;
    [SerializeField] private EventHandler eventHandler;

    bool isRewardCollected;
    int modifier = 1;
    int briefcaseLeft;
    public int maxBriefcaseAmount;

    private void OnEnable()
    {
        InputHandler.OnGameObjectClicked += InputHandler_OnGameObjectClicked;
    }

    

    private void OnDisable()
    {
        InputHandler.OnGameObjectClicked -= InputHandler_OnGameObjectClicked;
    }

    
    void Start()
    {
        PopulateRewardTree();
        briefcaseLeft = maxBriefcaseAmount;
        
    }

    private void InputHandler_OnGameObjectClicked(GameObject obj)
    {
        if (!isRewardCollected)
        {
            if (obj != mainBranch.RewardObject.gameObject)
            {
                //Brifcase'e t�kland�ysa, Bir Branch'e t�kland� demektir.
                if (obj.TryGetComponent(out Briefcase briefcase))
                {
                    //�anta a�ma hakk�m�z kalmad�ysa bir aksiyon alm�yoruz.
                    if(briefcaseLeft > 0)
                    {
                        RewardObjectFactory.Instance.DespawnAll();
                        PopulateRewardTree();
                        modifier++;
                        eventHandler.OnModifierChangedEvent(modifier);
                        briefcaseLeft--;
                        eventHandler.OnBriefcaseOpenedEvent(briefcaseLeft);
                    }
                    
                }
                //Se�eneklerden birine t�kland� demektir.
                else if (obj.TryGetComponent(out RewardObject rewardObject))
                {
                    Debug.Log("Collected Reward Value" + rewardObject.Value);
                    isRewardCollected = true;
                    eventHandler.OnRewardCollectedEvent(rewardObject.Value, modifier);
                }
            }
        }
        //Main Object'i se�menin bir etkisi yok.
        
    }

    private void PopulateRewardTree()
    {
        mainBranch = new Branch();//Ana branch'i a�t�k
        List<RewardComponent> rewardComponents = GetRandomRewardComponents();//4 adet rastgele Reward Component ald�k

        foreach (RewardComponent component in rewardComponents)//Her birini ana branch'e ekledik.
        {
            mainBranch.Add(component);
        }

        mainBranch.Operation(rewardObjectList);//Ana branch dahil t�m a�ac�n atamalar�n� yapt�k.

        AssignPositions(mainBranch);
    }

    private void AssignPositions(RewardComponent mainBranch)
    {     
        mainBranch.RewardObject.gameObject.transform.position = chosenObjMain.transform.position;
        mainBranch.rewards[0].RewardObject.gameObject.transform.position = chosenObjChild1.transform.position;
        mainBranch.rewards[1].RewardObject.gameObject.transform.position = chosenObjChild2.transform.position;
        mainBranch.rewards[2].RewardObject.gameObject.transform.position = chosenObjChild3.transform.position;
        mainBranch.rewards[3].RewardObject.gameObject.transform.position = chosenObjChild4.transform.position;
    }

    private List<RewardComponent> GetRandomRewardComponents()
    {
        List<RewardComponent> rewards = new();
        for (int i = 0;i < 4;i++)
        {
            int choice = UnityEngine.Random.Range(0, 2);
            if(choice == 0)
            {
                rewards.Add(new Leaf());
            }
            else
            {
                rewards.Add(new Branch());
            }
        }

        return rewards;
    }

}
