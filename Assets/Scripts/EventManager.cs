using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager 
{
    //buttonClick contains functions which called when OnButtonClick call
    public static event UnityAction<int> ButtonClick;

    public static void OnButtonClick(int id)
    {
        if(ButtonClick != null) { 
            ButtonClick(id);
        }
    }

}
