using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Linq;
using Unity.VisualScripting;

public class EquipmentUI : MonoBehaviour, I_Click
{
    [SerializeField] private GameObject optionPanel;
    public EquipmentData equipmentData;
    protected Image equipmentSlot;
    protected static List<GameObject> disappearImage = new();
    protected Action<Image> clickFunc = (image) => { };

    public virtual void OnClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Image>().TryGetComponent(out Image image))
        {
            equipmentSlot = image;
            clickFunc(image);
        }
    }

    protected void OptionUISet(Sprite sprite,ButtonType type)
    {
        optionPanel.transform.parent.gameObject.SetActive(true);
        optionPanel.gameObject.TryGetComponent(out OptionPanel optionUI);
        optionUI.EquipmentName.text = $"{equipmentData.EquipmentInfoData[sprite].GetName()}";
        optionUI.EquipmentImage.sprite = equipmentData.EquipmentInfoData[sprite].GetUnitType();
        optionUI.EquipmentExplain.text = $"{equipmentData.EquipmentInfoData[sprite].GetExplain()}";
        optionUI.EquipmentRank.text = $"��� : {equipmentData.EquipmentInfoData[sprite].GetEquipmentRank()}";
        if(type.Equals(ButtonType.Mounting))
            optionUI.clearBtn.gameObject.SetActive(false);
        else
            optionUI.clearBtn.gameObject.SetActive(true);
    }

    protected void EquipmentActive(Image image, int num)
    {
        if (num.Equals(1))
        {
            disappearImage.Add(image.gameObject.transform.parent.gameObject);
            image.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else if (num.Equals(2))
        {
            disappearImage.ForEach(x => { if (x.transform.GetChild(0).gameObject.GetComponent<Image>().sprite.Equals(image.sprite)) { x.gameObject.SetActive(true); image.sprite = null; } });
        }
    }
}
