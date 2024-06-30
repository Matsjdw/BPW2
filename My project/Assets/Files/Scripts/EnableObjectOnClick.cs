using UnityEngine;
using TMPro;

public class EnableObjectOnClick : MonoBehaviour
{
    public GameObject objectToEnable;

    private void Start()
    {
        // Make sure the target object is initially disabled
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        // Check if the object to enable is valid
        if (objectToEnable != null)
        {
            // Enable the object
            objectToEnable.SetActive(true);
        }
        else
        {
            Debug.LogError("Object to enable is not assigned!");
        }
    }
}
