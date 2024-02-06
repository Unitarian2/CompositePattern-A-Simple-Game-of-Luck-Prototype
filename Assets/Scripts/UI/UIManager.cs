using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI modifierText;
    [SerializeField] private TextMeshProUGUI earnedRewardText;
    [SerializeField] private TextMeshProUGUI briefcaseLeftText;

    [SerializeField] private EventHandler eventHandler;

    private void OnEnable()
    {
        eventHandler.OnRewardCollected += EventHandler_OnRewardCollected;
        eventHandler.OnModifierChanged += EventHandler_OnModifierChanged;
        eventHandler.OnBriefcaseOpened += EventHandler_OnBriefcaseOpened;
    }

    private void OnDisable()
    {
        eventHandler.OnRewardCollected -= EventHandler_OnRewardCollected;
        eventHandler.OnModifierChanged -= EventHandler_OnModifierChanged;
        eventHandler.OnBriefcaseOpened -= EventHandler_OnBriefcaseOpened;
    }

    private void Start()
    {
        modifierText.text = "Modifier : 1x";
        
    }
    private void EventHandler_OnRewardCollected(float value, float modifier)
    {
        earnedRewardText.text = $"Earned Reward Value : {value * modifier}";
    }
    private void EventHandler_OnModifierChanged(int modifier)
    {
        modifierText.text = $"Modifier : {modifier}x";
    }
    private void EventHandler_OnBriefcaseOpened(int briefcaseLeft)
    {
        briefcaseLeftText.text = $"Briefcase Left : {briefcaseLeft}";
    }
}
