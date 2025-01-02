using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    [SerializeField] public GameObject[] clonePrefabs = new GameObject[3];
    public GameObject currentSelectedClone;
    public static CloneManager Singleton;
    private GameObject cloneCursor;

    // Start is called before the first frame update

    void Start()
    {
        Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetSelected(clonePrefabs[2]);
            if (clonePrefabs[2].activeSelf == false)
            {
                clonePrefabs[2].SetActive(true);
            }
        }

        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SetSelected(clonePrefabs[1]);
            
            if (clonePrefabs[1].activeSelf == false)
            {
                clonePrefabs[1].SetActive(true);
            }
        }

        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SetSelected(clonePrefabs[0]);
            if (clonePrefabs[0].activeSelf == false)
            {
                clonePrefabs[0].SetActive(true);
            }
        }
    }

    public void SetSelected(GameObject clone)
    {
        currentSelectedClone = clone;
        Debug.Log(clone.name.ToString() + " is Selected");
    }

    
}
