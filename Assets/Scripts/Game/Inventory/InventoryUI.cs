using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;
    public Transform equipmentParent;
    public GameObject inventoryUI;

    Inventory inventory;
    EquipmentManager equipmentManager;
    InventorySlot[] iSlots;
    EquipmentSlot[] eSlots;
    
	void Start() {
        inventory = Inventory.instance;
        equipmentManager = EquipmentManager.instance;
        inventory.onItemChangedCallback += UpdateUI;
        equipmentManager.onItemChangedCallback += UpdateUI;
        iSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        eSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();

        inventory.onItemChangedCallback.Invoke();
    }
	
	void Update() {
		if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
        for (int i = 0; i < iSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                iSlots[i].addItem(inventory.items[i]);
            }
            else
            {
                iSlots[i].clearSlot();
            }
        }
        for (int j = 0; j < eSlots.Length; j++)
        {
            if (equipmentManager.currentEquipment[j] != null)
            {
                eSlots[j].addItem(equipmentManager.currentEquipment[j]);
            }
            else
            {
                eSlots[j].clearSlot();
            }
        }
    }
}
