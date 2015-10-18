using System;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum ItemClass { None, Weapon, UniqueItem, Ammunition, Consumable };
public enum ItemType { 
    Empty = 0, 

    AysMagicDynamiteShake = 11,
    Axe = 12,
    BookOfMusicalWildlife = 13,
    Brush = 14,
    BrushWithPaint = 15,
    BucketWithPaint = 16,
    ClownMask = 17,
    ClownNose = 18,
    CupOfCoffee = 19,
    CupOfTea = 20,
    GalleryKey = 21,
    Hammer = 22,
    MaskRemains = 23,
    PartyHat = 24,
    Purse = 25,
    RoughneckShot = 26,
    Scissors = 27,
    SelfMadeMask = 28,
    SpeakingTrumpet = 29,
    TeaLeaves = 30,
    AysSecretIngredients = 31,
    Carrot = 32,
    GoldenScreech = 33,
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