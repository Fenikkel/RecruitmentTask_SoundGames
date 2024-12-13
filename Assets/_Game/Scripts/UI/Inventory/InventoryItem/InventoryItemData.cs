using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "SoundGames/InventoryItemData", order = 1)]
public class InventoryItemData : ScriptableObject
{
    public Sprite Thumbnail;
    public string Name;
    public string Message;
}
