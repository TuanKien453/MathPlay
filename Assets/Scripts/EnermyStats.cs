using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyStats : MonoBehaviour
{

    public Transform enemyTransform;
    public Slider slider;
    public float CurrentHealth;
    public float MaxHealth;
    public float HealthBaroffsetY;
    public float damageDealt = 15f;
    public float TimeCounter=6f;
    public GameObject UiHealthBar;
    private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        UiHealthBar.SetActive(false);
        parentObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(enemyTransform.position + new Vector3(0, HealthBaroffsetY, 0));
        slider.transform.position = targetPosition;
        

    }

    public void Takedamage(float damage)
    {   
        CurrentHealth -= damage;
        slider.value = CurrentHealth/MaxHealth;
        if (CurrentHealth <= 0)
        {
            Destroy(parentObject);
            Debug.Log("enermy die");
        }
    }
    public void ShowHealthBar()
    {
        UiHealthBar.SetActive(true);
    }

}
