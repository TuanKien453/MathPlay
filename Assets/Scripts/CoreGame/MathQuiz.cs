using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathQuiz : MonoBehaviour
{
    // Start is called before the first frame update
    private int operand1;
    private int operand2;
    private int result;
    private OperationType operators;
    public enum OperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    };



    //dif = 0 result <=10 dif=1 result <=20
    public void GenerateRandomQuiz(int dif, OperationType type)
    {

        operand1 = Random.Range(1, 10);
        operand2 = Random.Range(1, 10);
        operators = type;
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

        if (result < 0 || (dif == 0 && result > 10) || (dif == 1 && result <= 20))
        {
            GenerateRandomQuiz(dif, type);
        }
    }


    public string ConvertToMathString()
    {
        string operatorSymbol;

        switch (operators)
        {
            case OperationType.Addition:
                operatorSymbol = "+";
                break;
            case OperationType.Subtraction:
                operatorSymbol = "-";
                break;
            case OperationType.Multiplication:
                operatorSymbol = "*";
                break;
            case OperationType.Division:
                operatorSymbol = "/";
                break;
            default:
                operatorSymbol = "";
                break;
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
