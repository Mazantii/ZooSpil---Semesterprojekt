using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool UseRelativeRotation = true;

    private Quaternion RelativeRotation;

    // Start is called before the first frame update
    void Start()
    {
        RelativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (UseRelativeRotation)
        {
            transform.rotation = RelativeRotation;
        }
    }
}
