using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatsSelector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text levelUpNameText;
    [SerializeField] private Text levelUpExplanText;
    [SerializeField] private Image selectorImage;

    private LevelUpStatInfo levelUpStatInfo;


    public void OnEnable()
    {
        levelUpStatInfo = LevelSystem.Instance.UmJunSik.GetRandomLevelUpStat();
        SetStatsSelectorUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Player.Instance.GetUnitData().SumUnitStat(levelUpStatInfo.LevelUpStats);
        LevelUISystem.Instance.LevelUpEnd();
    }

    public void SetStatsSelectorUI()
    {
        selectorImage.sprite = levelUpStatInfo.sprite;
        levelUpNameText.text = levelUpStatInfo.name;
        levelUpExplanText.text = levelUpStatInfo.explan;
    }
}