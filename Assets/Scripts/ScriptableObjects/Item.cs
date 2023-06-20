using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject{
    

    [Header("Only gameplay")]
    public ItemType type;
    public ActionType actionType;

    [Header("Only UI")]
    public bool isStackable = true;

    [Header("Both")]
    public Sprite image;

}

public enum ItemType {
    Basic,
    Weapon
}

public enum ActionType {
    Rocket,
    None
}


