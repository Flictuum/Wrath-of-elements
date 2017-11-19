using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour {
    public Sprite placeholder;
    public Image icon;
    public GameObject itemDesc;

    Equipment item;
    Text[] texts;
    EquipmentManager equipManager;

    void Start()
    {
        equipManager = EquipmentManager.instance;
    }

    public void addItem(Equipment newItem)
    {
        this.item = newItem;
        this.icon.sprite = this.item.icon;
    }

    public void clearSlot()
    {
        this.item = null;
        this.icon.sprite = this.placeholder;
    }

    public void useItem()
    {
        if (item != null)
        {
            equipManager.unequip(item.equipType);
        }
    }

    public void displayDescription()
    {
        texts = itemDesc.GetComponentsInChildren<UnityEngine.UI.Text>();
        if (item != null)
        {
            texts[0].text = item.name;
            texts[1].text = item.equipType.ToString() + " ATK:" + item.attackModifier + " DEF: " + item.defenseModifier;
        }
    }
}
