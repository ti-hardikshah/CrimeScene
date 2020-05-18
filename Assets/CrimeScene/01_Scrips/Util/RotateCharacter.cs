using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{


    public GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateParent(obj.transform);
    }

    void RotateParent(Transform child)
    {
        var childRot = child.rotation;
        //var childPos = child.position;
        child.parent.transform.rotation = childRot;
        child.rotation = childRot;
        //child.position = childPos;
    }
}
