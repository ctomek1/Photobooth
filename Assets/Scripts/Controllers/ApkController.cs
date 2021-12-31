using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApkController : MonoBehaviour
{
    [SerializeField]
    private Transform gameObjectsContainer;

    private ListOfModels listOfModelsController = new ListOfModels();
    private GameObject[] listOfModels;
    private List<GameObject> instantiatedObjects = new List<GameObject>();
    private GameObject currModel;
    private int currIndex = 0;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        listOfModelsController.GetListOfModels();
        listOfModels = listOfModelsController.ModelsList;
        for(int i = 0; i < listOfModels.Length; i++)
        {
            var model = Instantiate(listOfModels[i]);
            model.SetActive(false);
            model.transform.SetParent(gameObjectsContainer);
            instantiatedObjects.Add(model);
        }
        currModel = instantiatedObjects[0];
        currModel.SetActive(true);
    }

    private void Update()
    {
        playerInput.HandleZooming();
    }
    public void OnForwardButtonClick()
    {
        currModel.SetActive(false);
        currIndex++;
        Debug.LogError(currIndex);
        if (currIndex == listOfModels.Length)
        {
            currIndex = 0;
        }
        currModel = instantiatedObjects[currIndex];
        ResetGameObject(currModel);
    }
    
    public void OnBackButtonClick()
    {
        currModel.SetActive(false);
        currIndex--;        
        if (currIndex == -1)
        {
            currIndex = listOfModels.Length - 1;
        }
        currModel = instantiatedObjects[currIndex];
        ResetGameObject(currModel);
    }

    private void ResetGameObject(GameObject gameObject)
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.parent.rotation = Quaternion.identity;
        gameObject.SetActive(true);
    }
}
