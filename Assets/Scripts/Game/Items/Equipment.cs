using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
    public EquipmentType equipType;
    public int attackModifier;
    public int defenseModifier;

    public override void use()
    {
        base.use();
        EquipmentManager.instance.equip(this);
        removeFromInventory();
    }
}

public enum EquipmentType
{
    Head,
    Chest,
    Legs,
    Feet,
    Weapon
}
