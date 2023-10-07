using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathQuiz : MonoBehaviour
{
    // Start is called before the first frame update
    private int operand1;
    private int operand2;
    private int result;
    private int operators;
    public enum OperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    };

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

        if (result < 0 || (dif == 0 && result > 10) || (dif == 1 && result <= 10))
        {
            GenerateRandomQuiz(dif);
        }
        Debug.Log("result: " + result);
        Debug.Log("operand1: " + operand1);
        Debug.Log("operand2: " + operand2);
    }



    public void GenerateRandomQuiz(int dif, OperationType type)
    {

        operand1 = Random.Range(1, 10);
        operand2 = Random.Range(1, 10);

        if (type == OperationType.Addition)
        {
            result = operand1 + operand2;
        }
        else if (type == OperationType.Subtraction)
        {
            result = operand1 - operand2;
        }
        else if (type == OperationType.Multiplication)
        {
            result = operand1 * operand2;
        }
        else if (type == OperationType.Division)
        {
            result = operand1 / operand2;
        }

        if (result < 0 || (dif == 0 && result > 10) || (dif == 1 && result <= 10))
        {
            GenerateRandomQuiz(dif, type);
        }

        Debug.Log("result: " + result);
        Debug.Log("operand1: " + operand1);
        Debug.Log("operand2: " + operand2);
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


    public bool CheckAnswer(string answer)
    {
        if (result.ToString() == answer)
        {
            return true;
        }
        else
        {

            return false;
        }
    }
}
