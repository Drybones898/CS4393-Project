using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCartController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI total;

    void Update()
    {
        total.text = "Total: $" + PlayerSingleton.cartTotal.ToString();
    }
}
