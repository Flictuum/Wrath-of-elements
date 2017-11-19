﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    public Button removeButton;
    Item item;

    public void addItem(Item newItem)
    {
        this.item = newItem;
        this.icon.sprite = this.item.icon;
        this.icon.enabled = true;
        this.removeButton.interactable = true;
    }

    public void clearSlot()
    {
        this.item = null;
        this.icon.sprite = null;
        this.icon.enabled = false;
        this.removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.remove(this.item);
    }

    public void useItem()
    {
        if (item != null)
        {
            item.use();
        }
    }
}
