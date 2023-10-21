using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControler : MonoBehaviour
{
    public GameObject mathText;


    public void HideMathText()
    {
        mathText.SetActive(false);
    }

    public void ShowMathText()
    {
        mathText.SetActive(true);
    }


}
