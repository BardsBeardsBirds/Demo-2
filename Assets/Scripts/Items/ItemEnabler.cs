using UnityEngine;
using System.Collections;

public class ItemEnabler : MonoBehaviour 
{    
    public void Awake()
    {
        InGameObjectManager.Instance.Scissors.SetActive(false);
        InGameObjectManager.Instance.Brush.SetActive(false);

        if(!WorldEvents.BlewUpMisterB)
            InGameObjectManager.Instance.GalleryKey.SetActive(false);
        if (!WorldEvents.BlewUpMisterB)
            InGameObjectManager.Instance.Purse.SetActive(false); 
    }

    public void EnableItem(ItemType item)
    {
        if (item == ItemType.GalleryKey)
            InGameObjectManager.Instance.GalleryKey.SetActive(true);

        else if (item == ItemType.Scissors)
            InGameObjectManager.Instance.Scissors.SetActive(true);

        else if (item == ItemType.Purse)
            InGameObjectManager.Instance.Purse.SetActive(true);
    }

    public void DisableItem(ItemType item)
    {
        if (item == ItemType.Axe)
            InGameObjectManager.Instance.Axe.SetActive(false);
        
        else if (item == ItemType.Hammer)
            InGameObjectManager.Instance.Hammer.SetActive(false);
        else if (item == ItemType.GoldenScreech)
            InGameObjectManager.Instance.GoldenScreech.SetActive(false);
        else if (item == ItemType.AysSecretIngredients)
            InGameObjectManager.Instance.AysSecretIngredients.SetActive(false);
    }
}
