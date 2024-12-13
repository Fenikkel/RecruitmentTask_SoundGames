using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject _ItemPrefab;
    [SerializeField] GameObject _ItemContainer;

    [SerializeField] InventoryItemData[] _InventoryItems;


    void Start()
    {
        foreach (Transform child in _ItemContainer.transform) 
        { 
            Destroy(child.gameObject);
        }

        GameObject newItem;
        InventoryItem inventoryItem;
        
        for (int i = 0; i < _InventoryItems.Length; i++)
        {
            newItem = Instantiate(_ItemPrefab);
            newItem.transform.SetParent(_ItemContainer.transform,false);
            inventoryItem = newItem.GetComponent<InventoryItem>();
            inventoryItem.SetContent(_InventoryItems[i]);
        }
    }
}
