using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Required when Using UI elements.
using System;
using System.Text;
using UnityEngine;
using System.Linq;

public class Console : MonoBehaviour
{
    public InputField mainInputField;
    string input;

    List<Token> Lex(string input)
    {
        var result = new List<Token>();
        for(int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '+':
                    result.Add(new Token(Token.Type.Plus, "+"));
                    break;
                case '-':
                    result.Add(new Token(Token.Type.Minus, "-"));
                    break;
                case '(':
                    result.Add(new Token(Token.Type.LParen, "("));
                    break;
                case ')':
                    result.Add(new Token(Token.Type.RParen, ")"));
                    break;

                //default is used for numbers, to make sure 12 is not seen as a 1 and 2 but as 12
                default:
                    //add input[] on index i to StringBuilder sb
                    var sb = new StringBuilder(input[i].ToString());
                    if(i == input.Length - 1)
                    {
                        result.Add(new Token(Token.Type.Integer, sb.ToString()));
                        break;
                    }
                    for (int j = i + 1; j < input.Length; ++j)
                    {                        
                        //check if the following number is also an integer (j = i + 1)
                        if (char.IsDigit(input[j])) {
                            sb.Append(input[j]); //add the digit to the stringbuilder to create a complete number
                            ++i; //increment i to check the next number in the string
                            if (i == input.Length - 1)
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                            }
                        }
                        else
                        {
                            //if the next number is not an integer, add the completed number to the result
                            result.Add(new Token(Token.Type.Integer, sb.ToString()));
                            break;
                        }
                    }
                    break;
            }
        }
        return result;
    }

    IElement Parse(IReadOnlyList<Token> tokens)
    {
        var result = new BinaryOperation();
        bool haveLHS = false; //indicates whether the left hand side of this binary operation has already been initialized
        for(int i = 0; i < tokens.Count; i++)
        {
            var token = tokens[i];

            switch (token.MyType)
            {
                case Token.Type.Integer:
                    var integer = new Integer(int.Parse(token.Text)); //converse the text of the token to an int
                    if (!haveLHS)
                    {
                        result.Left = integer;
                        haveLHS = true;
                    }
                    else
                    {
                        result.Right = integer;
                    }
                    break;
                case Token.Type.Plus:
                    result.MyType = BinaryOperation.Type.Addition;
                    break;
                case Token.Type.Minus:
                    result.MyType = BinaryOperation.Type.Subtraction;
                    break;
                /*case Token.Type.LParen:
                    int j = i;
                    var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                    var element = Parse(subexpression);
                    if (!haveLHS)
                    {
                        result.Left = element;
                        haveLHS = true;
                    }
                    else
                    {
                        result.Right = element;
                    }
                    break;
                default:*/
                    throw new ArgumentOutOfRangeException();
            }
        }

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainInputField.text = "Lisa is cool..";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            input = mainInputField.text;
            var tokens = Lex(input);
            Debug.Log(string.Join("\t", tokens));
            mainInputField.text = "";

            var parsed = Parse(tokens);
            Debug.Log("Value: " + parsed.Value);
        }


    }
}

public class BinaryOperation : IElement
{
    public enum Type
    {
        Addition, Subtraction
    }

    public Type MyType;
    public IElement Left, Right;

    public int Value
    {
        get
        {
            switch (MyType)
            {
                case Type.Addition:
                    return Left.Value + Right.Value;
                case Type.Subtraction:
                    return Left.Value - Right.Value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

public interface IElement
{
    int Value { get; }
}

public class Integer : IElement
{
    public Integer(int value)
    {
        Value = value;
    }

    public int Value { get; }
}

public class Token
{
    public enum Type
    {
        Integer, Plus, Minus, LParen, RParen
    }

    public Type MyType;
    public string Text;

    public Token(Type myType, string text)
    {
        if(text == null)
        {
            throw new ArgumentNullException(paramName: nameof(text));
        }
        MyType = myType;
        Text = text;
    }

    public override string ToString()
    {
        return $"'{Text}'";
    }
}

