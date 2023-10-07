using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour
{
    // Start is called before the first frame update
    private string input;
    public InputField inputField;
    [SerializeField] private int characterLimit = 10;
    void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.characterLimit = characterLimit;
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
            ClearInput();
            input = s;
        }
        
        
    }
   public string getinput()
    {
        return input;
    }

    

    public void Enable()
    {
        Debug.Log("showInputField");
        gameObject.SetActive(true);
        inputField.ActivateInputField();
    }
    public void Disable()
    {
        Debug.Log("hideInputField");
        gameObject.SetActive(false);
    }

}

