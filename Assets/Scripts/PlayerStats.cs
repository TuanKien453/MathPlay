using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damageDealt = 14.5f;
    public float currentHealthBar;

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
    void Start()
    {
        slider.value = currentHealth / maxHealth;
        currentHealthBar = maxHealth;

    }



    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        StartCoroutine(UpdateSliderCoroutine());
        float roundedDamage = Mathf.Round(damage * 10f) / 10f;
        currentHealth -= roundedDamage;
        if (currentHealth <= 0)
        {
            Debug.Log("gameover");
            OnPlayerDeath?.Invoke();
        }
    }

    private IEnumerator UpdateSliderCoroutine()
    {
        while (true)
        {
            currentHealthBar -= 0.5f;
            slider.value = currentHealthBar / maxHealth;
            yield return null;
            if (currentHealth >= currentHealthBar)
            {
                yield break; 
            }
        }
    }



}