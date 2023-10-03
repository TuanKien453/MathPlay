using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EnermyController : MonoBehaviour
{
    public GetInput input;
    public PlayerHealth playerHealth;
    public Text text;
    private MathQuiz mathQuiz;

    // Start is called before the first frame update
    void Start()
    {
        input.Disable();
        mathQuiz = gameObject.AddComponent<MathQuiz>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
            PuzzleEvent();
        }
        
    }
    void PuzzleEvent()
    {
        input.Enable();
        Time.timeScale = 0;
        Debug.Log("PlayerCollisedEnermy");
        mathQuiz.GenerateRandomQuiz();
        string math=mathQuiz.ConvertToMathString();
        text.text = math;
    }
}
