using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : EquipmentUI
{
    public static Inventory Instance;
    [SerializeField] private Image slot;
    public static ObseverManager Inventory_obsever = new ObseverManager();
    [HideInInspector] public Image Image;
    private I_Obsever mouting_obseverFunc = new ObseverFunc();
    private void Awake()
    {
        Instance = this;
        InventorySet();
        equipmentData.EquipmentInfoDataSet();
        StartSet();
    }

    private void StartSet()
    {
        mouting_obseverFunc.Func = () => { EquipmentActive(equipmentSlot, 1); };
        OptionPanel.Mouting_obsever.obseverList.Add(mouting_obseverFunc);
        clickFunc = (image) =>
        {
            Image = image;
            OptionUISet(image.sprite, ButtonType.Mounting);
            Inventory_obsever.Notify();
            //equipmentData.EquipmentInfoData[image.sprite]
        };
    }

    private void InventorySet()
    {
        for (int i = 0; i < equipmentData.EquipmentInfo.Length; i++)
        {
            equipments.Add(Instantiate(slot));
            equipments.Last().transform.GetChild(0).TryGetComponent(out Image equipmentImage);
            equipmentImage.sprite = equipmentData.EquipmentInfo[i].GetUnitType();
            equipments.Last().transform.parent = transform.GetChild(0);
        }
    }


}
