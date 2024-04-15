using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public void viewHome()
    {
        SceneManager.LoadScene("SearchMenu");
    }
}
