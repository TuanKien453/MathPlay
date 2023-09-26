using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyHealth : MonoBehaviour
{
    public Canvas canvas;
    public Transform enemyTransform;
    public Slider slider;
    public float CurrentHealth;
    public float MaxHealth;
    public float HealthBaroffsetY;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(enemyTransform.position + new Vector3(0, HealthBaroffsetY, 0));
        slider.transform.position = targetPosition;
    }
    public void Hide()
    {
        canvas.enabled = false;
    }

    public void Show()
    {
        canvas.enabled = true;
    }
}
