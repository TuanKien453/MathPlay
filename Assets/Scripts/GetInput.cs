using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour
{
    // Start is called before the first frame update
    private string input;
    private InputField inputField;
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearInput()
    {
        inputField.text = "";
    }

    public void ReadStringInput(string s)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            input = s;
            Debug.Log(input);
            ClearInput();
            Debug.Log("clear");
        }
        
        
    }
   public string getinput()
    {
        return input;
    }



    public void Enable()
    {
        Debug.Log("show");
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        Debug.Log("hide");
        gameObject.SetActive(false);
    }

}

