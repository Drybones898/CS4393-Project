using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewCart : MonoBehaviour
{
    // Start is called before the first frame update
    public void viewCart()
    {
        SceneManager.LoadScene("CartMenu");
    }
}
