using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{   
    public Slider slider;

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damageDealt = 10f;

    private float currentHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = currentHealth / maxHealth;
        currentHealthBar = maxHealth;
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
