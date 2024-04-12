using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewItem : MonoBehaviour
{
    /* Here I'm going to get the name of the object from the item's name and then
    search for the object in the array list for the item reference to set to 
    the PlayerStatusSingleton. It's gonna be an expensive operation but it will work. 
    */
    public TextMeshProUGI objectNameBox;
    public string objectName;

    void Start()
    {
        objectNameBox = objectNameBox.text;
    }
    // Start is called before the first frame update
    public void viewItem()
    {
        PlayerSingleton.selectedItem = null;
        SceneManager.LoadScene("ItemMenu");
    }
}
