using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : EquipmentUI
{
    [SerializeField] private Equipment[] equipments = new Equipment[4];
    [SerializeField] private UnitData playerData;
    private EquipmentInfo equipmentInfo;
    private ObseverFunc<EquipmentInfo> Inventory_obseverFunc = new();
    private ObseverFunc<OptionPanel> Mouting_obseverFunc = new();
    private ObseverFunc<OptionPanel> Clear_obseverFunc = new();
    private ObseverFunc<OptionPanel> StartSet_obseverFunc = new();
    public void Awake()
    {
        ObseverSet();
        StartSet();
        //PlayerText();
    }

    private void ObseverSet()
    {
        OptionPanel optionPanel;
        StartSet_obseverFunc.Obsevers = (panel) =>
        {
            optionPanel = panel;
            PlayerText(optionPanel);
        };
        OptionPanel.StartSet_obsever.AddObsever(StartSet_obseverFunc);
        Inventory_obseverFunc.Obsevers = (t) => equipmentInfo = t;
        Inventory.Inventory_obsever.obseverList.Add(Inventory_obseverFunc);
        Mouting_obseverFunc.Obsevers = (panel) =>
        {
            optionPanel = panel;
            optionPanel.transform.parent.parent.gameObject.SetActive(false);
            Mounting();
            PlayerText(optionPanel);
        };
        OptionPanel.Mouting_obsever.obseverList.Add(Mouting_obseverFunc);
        Clear_obseverFunc.Obsevers = (panel) =>
        {
            optionPanel = panel;
            optionPanel.transform.parent.parent.gameObject.SetActive(false);
            Clear();
            EquipmentActive(equipmentSlot, 2);
            PlayerText(optionPanel);
        };
        OptionPanel.Clear_obsever.obseverList.Add(Clear_obseverFunc);
    }

    private void StartSet()
    {
        clickFunc = (image) =>
        {
            OptionUISet(image.sprite, ButtonType.Clear);
        };
    }

    private void Mounting()
    {
        foreach (var equipment in equipments)
        {
            if (equipmentInfo.GetEquipmentType().Equals(equipment.equipmentType))
            {
                equipment.TryGetComponent(out Image image);
                image.transform.GetChild(0).TryGetComponent(out Image equipmentImage);
                equipmentImage.sprite = equipmentInfo.GetUnitType();
                playerData.unitInfo.SumUnitData(equipmentInfo.GetUnitStat());
                break;
            }
        }
    }

    private void Clear()
    {
        playerData.unitInfo.MinusUnitData(equipmentData.EquipmentInfoData[equipmentSlot.sprite].GetUnitStat());
    }

    private void PlayerText(OptionPanel optionPanel)
    {
        UnitStat playerState = playerData.unitInfo.GetUnitStat();
        optionPanel.PlayerAttackText.text = $"공격력 : {playerState.attackPower}";
        optionPanel.PlayerHpText.text = $"생명력 : {playerState.maxHp}";
    }
}
