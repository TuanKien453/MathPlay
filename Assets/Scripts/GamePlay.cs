using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using static MathQuiz;

public class GamePlay : MonoBehaviour
{   
    public GetInput input;
    public PlayerStats playerStats;
    public Slider currentTimeDisplay;
    public Rigidbody2D playerRigidbody;
    public Text text;
    public UiControler Ui;

    [SerializeField] private float timeCounter = 6f;
    private float currentTime;
    private EnermyStats enermyStats;
    private MathQuiz mathQuiz;

    private string answer;
    private Boolean isanswer=false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeCounter;
        mathQuiz = gameObject.AddComponent<MathQuiz>();
        Ui.HideMathText();
        input.InputDisable();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && isanswer)
        {
            input.clickOnInputField();
            answer = input.getinput();
            Debug.Log(answer);
            
            if (mathQuiz.CheckAnswer(answer))
            {   
                Debug.Log("true");
                PuzzleEvent();
                enermyStats.Takedamage(playerStats.damageDealt);
            }
            else
            {
                Debug.Log("False");
                playerStats.takeDamage(enermyStats.damageDealt);
                PuzzleEvent();
            }

            if (enermyStats.CurrentHealth <= 0)
            {
                isanswer = false;
                Time.timeScale = 1;
                Ui.HideMathText();
                input.InputDisable();
            }
        }

        if (currentTime > 0 && isanswer)
        {
            currentTime -= Time.unscaledDeltaTime;
            currentTimeDisplay.value = currentTime / timeCounter;
        }
        else if(isanswer)
        {   
            Debug.Log("False");
            playerStats.takeDamage(enermyStats.damageDealt);
            PuzzleEvent();
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {

            if (other.gameObject.tag == "Enermy")
            {
                enermyStats = other.gameObject.GetComponent<EnermyStats>();
                isanswer = true;
                Ui.ShowMathText();
                input.InputEnable();
                PuzzleEvent();
                input.clickOnInputField();
            }
    }

    void PuzzleEvent()
    {
        currentTime = timeCounter;
        Time.timeScale = 0f;
        Debug.Log("PlayerCollisedEnermy");
        GenerateRandomAddSubMath(0);
        string math=mathQuiz.ConvertToMathString();
        text.text = math;
    }

    public void GenerateRandomAddSubMath(int difficulty)
    {
        MathQuiz.OperationType randomOperator;
        if (UnityEngine.Random.value > 0.5f)
        {
            randomOperator = MathQuiz.OperationType.Addition;
        }
        else
        {
            randomOperator = MathQuiz.OperationType.Subtraction;
        }
        mathQuiz.GenerateRandomQuiz(difficulty, randomOperator);
    }
}
