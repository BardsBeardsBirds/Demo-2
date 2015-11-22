using System;
using System.Collections.Generic;
using UnityEngine;


public class SaveInventoryData
{
    public void SaveInventory(SaveGameData data)
    {
        foreach (Item item in Inventory.Instance.Items)
        {
            if(item.Class == ItemClass.UniqueItem)
            {
                switch (item.IType)
	            {
                case ItemType.Axe:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.Axe = data.Axe + 1;
                    }
                    Debug.Log("I saved " + data.Axe + " " + item.IType);
                 break;
                case ItemType.BookOfMusicalWildlife:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.BookOfMusicalWildlife = data.BookOfMusicalWildlife + 1;
                    }
                    Debug.Log("I saved " + data.BookOfMusicalWildlife + " " + item.IType);
                 break;
                case ItemType.Brush:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.Brush = data.Brush + 1;
                    }
                    Debug.Log("I saved " + data.Brush + " " + item.IType);
                 break;
                case ItemType.BrushWithPaint:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.BrushWithPaint = data.BrushWithPaint + 1;
                    }
                    Debug.Log("I saved " + data.BrushWithPaint + " " + item.IType);
                 break;
                case ItemType.BucketWithPaint:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.BucketWithPaint = data.BucketWithPaint + 1;
                    }
                    Debug.Log("I saved " + data.BucketWithPaint + " " + item.IType);
                 break;
                case ItemType.ClownMask:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.ClownMask = data.ClownMask + 1;
                    }
                    Debug.Log("I saved " + data.ClownMask + " " + item.IType);
                 break;
                case ItemType.ClownNose:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.ClownNose = data.ClownNose + 1;
                    }
                    Debug.Log("I saved " + data.ClownNose + " " + item.IType);
                 break;
                case ItemType.GalleryKey:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.GalleryKey = data.GalleryKey + 1;
                    }
                    Debug.Log("I saved " + data.GalleryKey + " " + item.IType);
                 break;
                case ItemType.Hammer:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.Hammer = data.Hammer + 1;
                    }
                    Debug.Log("I saved " + data.Hammer + " " + item.IType);
                 break;
                case ItemType.MaskRemains:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.MaskRemains = data.MaskRemains + 1;
                    }
                    Debug.Log("I saved " + data.MaskRemains + " " + item.IType);
                 break;
                case ItemType.PartyHat:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.PartyHat = data.PartyHat + 1;
                    }
                    Debug.Log("I saved " + data.PartyHat + " " + item.IType);
                 break;
                case ItemType.Purse:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.Purse = data.Purse + 1;
                    }
                    Debug.Log("I saved " + data.Purse + " " + item.IType);
                 break;
                case ItemType.Scissors:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.Scissors = data.Scissors + 1;
                    }
                    Debug.Log("I saved " + data.Scissors + " " + item.IType);
                 break;
                case ItemType.SelfMadeMask:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.SelfMadeMask = data.SelfMadeMask + 1;
                    }
                    Debug.Log("I saved " + data.SelfMadeMask + " " + item.IType);
                 break;
                case ItemType.SpeakingTrumpet:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.SpeakingTrumpet = data.SpeakingTrumpet + 1;
                    }
                    Debug.Log("I saved " + data.SpeakingTrumpet + " " + item.IType);
                 break;
                case ItemType.TeaLeaves:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.TeaLeaves = data.TeaLeaves + 1;
                    }
                    Debug.Log("I saved " + data.TeaLeaves + " " + item.IType);
                 break;
                case ItemType.AysSecretIngredients:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.AysSecretIngredients = data.AysSecretIngredients + 1;
                    }
                    Debug.Log("I saved " + data.AysSecretIngredients + " " + item.IType);
                 break;
                case ItemType.GoldenScreech:
                    for (int i = 0; i < item.ItemAmount; i++)
                    {
                        data.GoldenScreech = data.GoldenScreech + 1;
                    }
                    Debug.Log("I saved " + data.GoldenScreech + " " + item.IType);
                 break;
                default:
                        Debug.LogWarning("do not know this unique item: " + item.IType);
                 break;
	            }   
            }
            else if(item.Class == ItemClass.Consumable)
            {
                switch (item.IType)
                {
                    case ItemType.Empty:
                        break;
                    case ItemType.AysMagicDynamiteShake:
                        for (int i = 0; i < item.ItemAmount; i++)
                        {
                            data.AysMagicDynamiteShake = data.AysMagicDynamiteShake + 1;
                        }
                        Debug.Log("I saved " + data.AysMagicDynamiteShake + " " + item.IType);
                        break;
                    case ItemType.Carrot:
                        for (int i = 0; i < item.ItemAmount; i++)
                        {
                            data.Carrot = data.Carrot + 1;
                        }
                        Debug.Log("I saved " + data.Carrot + " " + item.IType);
                        break;
                    case ItemType.CupOfCoffee:
                        for (int i = 0; i < item.ItemAmount; i++)
                        {
                            data.CupOfCoffee = data.CupOfCoffee + 1;
                        }
                        Debug.Log("I saved " + data.CupOfCoffee + " " + item.IType);
                        break;
                    case ItemType.CupOfTea:
                        for (int i = 0; i < item.ItemAmount; i++)
                        {
                            data.CupOfTea = data.CupOfTea + 1;
                        }
                        Debug.Log("I saved " + data.CupOfTea + " " + item.IType);
                        break;
                    case ItemType.RoughneckShot:
                        for (int i = 0; i < item.ItemAmount; i++)
                        {
                            data.RoughneckShot = data.RoughneckShot + 1;
                        }
                        Debug.Log("I saved " + data.RoughneckShot + " " + item.IType);
                        break;
                    default:
                        Debug.LogWarning("do not know this consumable item: " + item.IType);
                        break;
                }
            }
            else
            {
                Debug.LogWarning("This " + item.IType + " was not saved!");
            }
        }

    }
}
