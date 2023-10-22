using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private float speed=0.2f;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);

        if (transform.position.x >= 500f) transform.position= new Vector3(speed * Time.deltaTime, 0, 0); ;
    }
}
