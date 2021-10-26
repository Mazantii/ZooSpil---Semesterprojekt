using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayers : MonoBehaviour
{
    public PlayerHealth Death;
    public GameObject Player;
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
