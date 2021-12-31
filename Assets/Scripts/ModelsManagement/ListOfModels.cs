using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ListOfModels
{
    private GameObject[] modelsList;

    public GameObject[] ModelsList { get => modelsList; set => modelsList = value; }

    public void GetListOfModels()
    {
        modelsList = Resources.LoadAll<GameObject>("Input");
    }
}
