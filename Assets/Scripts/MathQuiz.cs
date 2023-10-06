using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathQuiz : MonoBehaviour
{
    // Start is called before the first frame update
    private int operand1;
    private int operand2;
    private int result;



    public void GenerateRandomQuiz(int dif)
    {
        operand1 = Random.Range(1, 10);
        operand2 = Random.Range(1, 10);
        bool isAddition = Random.value > 0.5f;

        if (isAddition)
        {
            result = operand1 + operand2;
        }
        else
        {
            result = operand1 - operand2;
        }

        if (dif == 0 && result > 10) 
        {
            GenerateRandomQuiz(dif);
        }
        else if (dif == 1 && result <= 10) 
        {
            GenerateRandomQuiz(dif);
        }
    }

    public string ConvertToMathString()
    {
        string operatorSymbol;
        if (result >= 0)
        {
            operatorSymbol = "+";
        }
        else
        {
            operatorSymbol = "-";
        }

        string mathString = operand1.ToString() + " " + operatorSymbol + " " + operand2.ToString() + " = ?";
        return mathString;
    }


    public bool CheckAnswer(int answer)
    {
        return answer == result;
    }
}
