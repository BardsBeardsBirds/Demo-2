using System;
using UnityEngine;


public class Minimap : MonoBehaviour
{
    public GameObject Player;
    public Camera MinimapCamera;

    public void Start()
    {
        Player = GameManager.Player;
        MinimapCamera = GameObject.Find("Minimap Camera").GetComponent<Camera>();  // later set up new minimap camera through code
    }

    public void Update()
    {
    //    MinimapCamera.transform.position = new Vector3(Player.transform.position.x, MinimapCamera.transform.position.y, Player.transform.position.z);
    }
}

