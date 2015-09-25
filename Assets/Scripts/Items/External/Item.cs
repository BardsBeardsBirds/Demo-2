using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum ItemClass { None, Weapon, UniqueItem, Ammunition, Consumable };
public enum ItemType { 
    Empty = 0, 
    //Story specific items// start at 0
    BookOfMusicalWildlife = 1, 
    TeaLeaves = 2,
    AysSecretIngredients = 3,
    Scissors = 4,
    ClownNose = 5, 
    ClownMask = 6,
    PartyHat = 7,
    DynamiteShake = 8,
    //consumables// start at 100
    RoughneckShot = 101,
    Carrot = 102, 
    //unique items// start at 200


};

public class Item
{


    [XmlAttribute("ID")]
    public int ID;
    [XmlElement("Type")]
    public ItemType IType;
    [XmlElement("Name")]
    public string ItemName;
    [XmlElement("Class")]
    public ItemClass Class;
  //  [XmlElement("Sprite")]
    public Sprite ItemIcon;
  //  [XmlElement("GameObject")]
 //   public GameObject ItemModel;
    [XmlElement("Amount")]
    public int ItemAmount;

    public Sprite FindIcon(Item item)
    {
        Sprite icon = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
        return icon;
    }

}