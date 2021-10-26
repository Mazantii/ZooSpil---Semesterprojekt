using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    public Transform c_Spawnpoint;
    [HideInInspector]   public int c_PlayerNumber;
    public PlayerHealth Death;
    [HideInInspector]   public GameObject Player;
    [HideInInspector]   public int c_Wins;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, new Vector3(- 66f, 2f, - 20f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Death.Dead == true)
        {
            Destroy(Player);
        }
    }
}
