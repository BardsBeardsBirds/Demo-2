﻿using UnityEngine;
using System.Collections;

public class ItemLoader : MonoBehaviour
{
    public static ItemLoader Instance;
    public const string path = "Xml/items"; //in resources folder
    private ItemDatabase _database;

    void Start()
    {
        Instance = this;

        _database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        GetAllItems();
    }

    public void GetAllItems()
    {
        ItemContainer ic = ItemContainer.Load(path);

        foreach (Item item in ic.items)
        {
            _database.Items.Add(item);
        }
    }
}
