using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion    

    Equipment[] currentEquipment;
    Inventory inventoty;

    void Start()
    {
        int nbSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[nbSlots];
        inventoty = Inventory.instance;
    }

    public void equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventoty.add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }
}