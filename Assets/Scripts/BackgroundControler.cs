using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControler : MonoBehaviour
{   [Range(0,1)]
    public float parallaxEffectX;
    
    private float startpos, movedistX, lenghtBackground;
    public GameObject cam;
    float startposy;
    // Start is called before the first frame update
    private void Awake()
    {
        startpos = transform.position.x;
        lenghtBackground = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        movedistX = cam.transform.position.x * parallaxEffectX;
   

        float temp = cam.transform.position.x * (1 - parallaxEffectX);
        transform.position = new Vector3(movedistX + startpos, transform.position.y, transform.position.z);

        if (temp > startpos + lenghtBackground)
        {
            startpos += lenghtBackground;
            
        }   
        else if (temp < startpos - lenghtBackground)
        {
            startpos -= lenghtBackground;
            
        }

        

    }


   
    
}
