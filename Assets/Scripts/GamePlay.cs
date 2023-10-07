using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{   
    public GetInput input;
    public PlayerHealth playerHealth;
    public EnermyHealth enermyHealth;
    public Rigidbody2D playerRigidbody;
    public Text text;
 

    private MathQuiz mathQuiz;
    private Vector3 knockbackDirection;
    private string answer;
    // Start is called before the first frame update
    void Start()
    {
        input.Disable();
        mathQuiz = gameObject.AddComponent<MathQuiz>();
        enermyHealth.HideMathText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            answer = input.getinput();
            Debug.Log(answer);
            if (mathQuiz.CheckAnswer(answer))
            {   
                Debug.Log("true");
                Time.timeScale = 1;
                enermyHealth.Takedamage(10f);

                enermyHealth.HideMathText();
                input.Disable();
            }
            else
            {
                Debug.Log("False");
                playerHealth.takeDamage(10f);
                Time.timeScale = 1;
                enermyHealth.HideMathText();
                input.Disable();
            }

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enermy") {
            enermyHealth.ShowMathText();
            input.Enable();
            PuzzleEvent();
        }
        
    }

    void PuzzleEvent()
    {

        Time.timeScale = 0;
        Debug.Log("PlayerCollisedEnermy");
        mathQuiz.GenerateRandomQuiz(0);
        string math=mathQuiz.ConvertToMathString();
        text.text = math;

    }



 
}
