using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameObjectManager : MonoBehaviour
{
    public static InGameObjectManager Instance;
    public List<GameObject> Objects = new List<GameObject>();
    public List<GameObject> TreasureChests = new List<GameObject>();

    public static bool PickedUpCarrot = false;
    public static bool PickedUpMaskOfMockery = false;

    public ItemEnabler ItemEnablerGO;

    //References to representations of objects in the world
    public GameObject Axe;
    public GameObject Hammer;
    public GameObject Brush;
    public GameObject Bucket;
    public GameObject GalleryKey;
    public GameObject Purse;
    public GameObject Scissors;
    public GameObject PartyHat;
    public GameObject TeaLeaves;
    public GameObject GoldenScreech;
    public GameObject AysSecretIngredients;

    public Doors ElevatorDoor1;
    public Doors ElevatorDoor2;
    public Doors ElevatorDoor3;
    public Doors ElevatorDoor4;
    public Doors GateDoor;

    public ElevatorButton ElevatorUp;
    public ElevatorButton ElevatorDown;

    public void Awake()
    {
        Instance = this;

        if (Instance.ElevatorDoor1 == null)
            Debug.LogError("Could not find elevator door 1!");
        if (Instance.ElevatorDoor2 == null)
            Debug.LogError("Could not find elevator door 2!");
        if (Instance.ElevatorDoor3 == null)
            Debug.LogError("Could not find elevator door 3!");
        if (Instance.ElevatorDoor4 == null)
            Debug.LogError("Could not find elevator door 4!");
        if (Instance.GateDoor == null)
            Debug.LogError("Could not find gate door script!");
    }

    void Start()
    {


        Objects.Add(Axe);
        Objects.Add(Hammer);
        Objects.Add(Brush);
        Objects.Add(Bucket);
        Objects.Add(GalleryKey);
        Objects.Add(Purse);
        Objects.Add(Scissors);
        Objects.Add(PartyHat);
        Objects.Add(TeaLeaves);
        Objects.Add(GoldenScreech);
        Objects.Add(AysSecretIngredients);

        foreach (GameObject chest in GameObject.FindGameObjectsWithTag("TreasureChest"))
        {
            TreasureChests.Add((chest) as GameObject);
        }     
    }

    public void TurnOffObject(GameObject obj)
    {
        Debug.Log(obj);
        obj.gameObject.SetActive(false);
    }

    public void LoadInGameObjectsInfo()
    {
        //if (PickedUpCarrot)

    }

    private GameObject findInObjects(string name)
    {
        GameObject gameObject = null;

        foreach (GameObject go in Objects)
        {
            if (go.name == name)
                gameObject = go;
        }
        if (gameObject == null)
            Debug.LogWarning(("game object is null ") + name);
        return gameObject;
    }
}
