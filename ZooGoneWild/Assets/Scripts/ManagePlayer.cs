using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    [HideInInspector]   public int c_PlayerNumber;
    [HideInInspector]   public GameObject Player;
    [HideInInspector]   public GameObject c_Instance;
    [HideInInspector]   public int c_Wins;

    public Transform Spawnpoint;
    public PlayerHealth c_Death;
    public GameObject c_Animal;

    // Start is called before the first frame update
    public void Setup()
    {
        
        Instantiate(Player, new Vector3(- 66f, 2f, - 20f), Quaternion.identity);
        c_Animal = GameObject.Find("Animal");
    }

    // Update is called once per frame
    void Update()
    {
        if (c_Death.Dead == true)
        {
            Destroy(Player);
        }
    }
}
