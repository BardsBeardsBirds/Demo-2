using System;
using System.Collections.Generic;
using UnityEngine;


public class LoadInventoryData
{
    public void LoadInventory(SaveGameData data)
    {
        //unique items
        for (int i = 0; i < data.Axe; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Axe);
        }
        for (int i = 0; i < data.AysSecretIngredients; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.AysSecretIngredients);
        }
        for (int i = 0; i < data.BookOfMusicalWildlife; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.BookOfMusicalWildlife);
        }
        for (int i = 0; i < data.Brush; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Brush);
        }
        for (int i = 0; i < data.BrushWithPaint; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.BrushWithPaint);
        }
        for (int i = 0; i < data.BucketWithPaint; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.BucketWithPaint);
        }
        for (int i = 0; i < data.ClownMask; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.ClownMask);
        }
        for (int i = 0; i < data.ClownNose; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.ClownNose);
        }
        for (int i = 0; i < data.GalleryKey; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.GalleryKey);
        }
        for (int i = 0; i < data.GoldenScreech; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.GoldenScreech);
        }
        for (int i = 0; i < data.Hammer; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Hammer);
        }
        for (int i = 0; i < data.MaskRemains; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.MaskRemains);
        }
        for (int i = 0; i < data.PartyHat; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.PartyHat);
        }
        for (int i = 0; i < data.Purse; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Purse);
        }
        for (int i = 0; i < data.Scissors; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Scissors);
        }
        for (int i = 0; i < data.SelfMadeMask; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.SelfMadeMask);
        }
        for (int i = 0; i < data.SpeakingTrumpet; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.SpeakingTrumpet);
        }
        for (int i = 0; i < data.TeaLeaves; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.TeaLeaves);
        }

        //consumables
        for (int i = 0; i < data.AysMagicDynamiteShake; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.AysMagicDynamiteShake);
        }
        for (int i = 0; i < data.Carrot; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.Carrot);
        }
        for (int i = 0; i < data.CupOfCoffee; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.CupOfCoffee);
        }
        for (int i = 0; i < data.CupOfTea; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.CupOfTea);
        }
        for (int i = 0; i < data.RoughneckShot; i++)
        {
            Inventory.Instance.LoadItemsFromSave(ItemType.RoughneckShot);
        }
        
        //for (int i = 0; i < data.RoughneckShot; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(1);
        //}
        //for (int i = 0; i < data.Carrot; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(2);
        //    Debug.Log("added " + data.Carrot + " " + ItemType.Carrot);
        //}
        //for (int i = 0; i < data.MaskOfMockery; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(3);
        //}
    }
}