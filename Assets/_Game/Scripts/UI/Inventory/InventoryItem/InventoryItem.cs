using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] Image _ItemImage;
    [SerializeField] Button _ItemButton;

    InventoryItemData _InventoryItem;


    void Start()
    {
        _ItemButton.onClick.AddListener(ConsumeItem);
    }

    void Update()
    {
        
    }

    public void SetContent(InventoryItemData inventoryItem) 
    { 
        _ItemImage.sprite = inventoryItem.Thumbnail;
        _InventoryItem = inventoryItem;
    }

    private void ConsumeItem() 
    {
        PopUpController.Instance.ShowPopUp($"<b>{_InventoryItem.name}</b> consumed.\n\n<i>{_InventoryItem.Message}</i>");
        Destroy(this.gameObject);
    }
}
