using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class SearchBarController : MonoBehaviour
{
    public SearchSingleton SearchSingleton;

    [Header("Search Bar")]
    [SerializeField] public TMP_InputField searchField;
    [SerializeField] public Button searchButton;

    void Start()
    {
        searchButton.onClick.AddListener(delegate
        {
            SearchSingleton.lastSearch = searchField.text;
            if (SceneManager.GetActiveScene().ToString() != "SearchMenu");
            SceneManager.LoadScene("SearchMenu");
        });

    }
}
