using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class OnDeath : MonoBehaviour
{
    public GameObject DeathUi;
    public Image myImage;
    public float transitionTime = 2f;

    private float elapsedTime = 0f;
    private bool isTransitionComplete = true;

    private float transitionEndTime;
    private bool isFinishTransition = false;
    private void Start()
    {
        PlayerStats.OnPlayerDeath += HandlePlayerDeath;

    }

    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= HandlePlayerDeath;
    }
    void Update()
    {
        if (!isTransitionComplete)
        {

            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionTime);


            Color newColor = new Color(myImage.color.r, myImage.color.g, myImage.color.b, alpha);
            myImage.color = newColor;


            elapsedTime += Time.unscaledDeltaTime;

            if (elapsedTime >= transitionTime)
            {
                transitionEndTime = Time.realtimeSinceStartup + 3f;
                isTransitionComplete = true;
                isFinishTransition = true;
            }
        }

        if (Time.realtimeSinceStartup >= transitionEndTime && isFinishTransition)
        {
            FinishTransition();
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player has died.");
        DeathUi.SetActive(true);
        isTransitionComplete = false;

    }
    private void FinishTransition()
    {

        StartCoroutine(SceneManager.LoadLevelAsync("Menu"));
    }

}
