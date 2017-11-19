using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion    

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public Equipment[] currentEquipment;
    Inventory inventory;

    public int attackBonus;
    public int defenseBonus;

    void Start()
    {
        int nbSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[nbSlots];
        inventory = Inventory.instance;
    }

    public void equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipType;
        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        updateBonus();
    }

    public void unequip(EquipmentType type)
    {
        int slotIndex = (int)type;

        if (currentEquipment[slotIndex] != null)
        {
            inventory.add(currentEquipment[slotIndex]);
            currentEquipment[slotIndex] = null;
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        updateBonus();
    }

    private void updateBonus()
    {
        this.attackBonus = 0;
        this.defenseBonus = 0;

        for (int i = 0; i < currentEquipment.Length; i++)
        {
            if (this.currentEquipment[i] != null)
            {
                this.attackBonus += this.currentEquipment[i].attackModifier;
                this.defenseBonus += this.currentEquipment[i].defenseModifier;
            }
        }
    }
}