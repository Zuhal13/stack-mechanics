using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{

    public static StackManager instance;

    [SerializeField] private float distancebetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        distancebetweenObjects = prevObject.localScale.y;
    }
    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        Vector3 despos = prevObject.localPosition;
        despos.y += downOrUp ? distancebetweenObjects : -distancebetweenObjects;
        pickedObject.transform.localPosition = despos;
        prevObject = pickedObject.transform;
    }

    public void Stairs(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        Vector3 despos = prevObject.localPosition;
        despos.y += downOrUp ? distancebetweenObjects : -distancebetweenObjects;
        despos.z += pickedObject.transform.localScale.z;
        pickedObject.transform.localPosition = despos;
        prevObject = pickedObject.transform;


    }
}
