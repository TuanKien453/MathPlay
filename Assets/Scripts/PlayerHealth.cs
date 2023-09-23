using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   
    public Slider slider;

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            Debug.Log("gameover");
        }
    }

}
