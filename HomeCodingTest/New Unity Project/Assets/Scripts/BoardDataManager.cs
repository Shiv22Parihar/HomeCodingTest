using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;


public class BoardDataManager : MonoBehaviour
{

    #region Input Fields
    public InputField BoardDimensionX;
    public InputField BoardDimensionY;
    public InputField BoardData;
    public InputField MinConstraint;
    public InputField MaxConstraint;
    public InputField Dictionary;
    #endregion

    #region Output Variables
    public Text OutputData;
    public Text OutputDataWordCount;
    #endregion

    #region Local Variables
    private int XDimension;
    private int YDimension;
    private int MinConstrnt;
    private int MaxConstrnt;
    private HashSet<string> InputDictionary;
    private string[] BoardDataArr;
    private List<string> OutputWordList = new List<string>();
    #endregion

    #region Calling Method

    public void StartGame()
    {
        // Assign Input Data
        SetDataToLocalVariables();

        // Create board input and call method to get words
        // check if any words are added in dictionary
        if (InputDictionary != null && InputDictionary.Count > 0)
            GetWords(CreateBoggleBoard(BoardDataArr));

        // Set output text area
        SetOutputData();
        
        // To Avoid Multiple results on Multiple Click on Get Words button
        ClearLocalVariablesData();
    }

    #endregion

    #region Helper Methods

    // Set input data to local variables
    private void SetDataToLocalVariables()
    {
        XDimension = GetXDimesion();
        YDimension = GetYDimesion();
        MinConstrnt = int.Parse(MinConstraint.text);
        MaxConstrnt = int.Parse(MaxConstraint.text);
        InputDictionary = new HashSet<string>(Dictionary.text.Split(','));
        BoardDataArr = GetBoardData();

        //Set Default dimesion
        SetDefaultStuff();
    }

    // In case user doesn't enters Dimensions, set default data
    private void SetDefaultStuff()
    {
        if (XDimension == 0 || YDimension == 0)
        {
            if (YDimension != 0)
                XDimension = YDimension;
            else if (XDimension != 0)
                YDimension = XDimension;
            else
                XDimension = YDimension = 3;
        }
    }

    // Method to create a boggle board string[,] array
    private string[,] CreateBoggleBoard(string[] input)
    {
        string[,] board = new string[YDimension, XDimension];
        int k = 0;
        for (int i = 0; i < YDimension; i++)
            for (int j = 0; j < XDimension; j++)
                if (k < input.Length)
                {
                    board[i, j] = input[k];
                    k++;
                }
                else
                    board[i, j] = GetRandomAlphabet();

        return board;
    }

    // Set the output word list and count to the respective text fields
    private void SetOutputData()
    {
        OutputDataWordCount.text = "Count : " + OutputWordList.Count;
        if (OutputWordList.Count > 0)
        {
            OutputData.text = String.Join(",", OutputWordList); 
        }
        else
        {
            OutputData.text = "No Word Found...";
        }
    }

    // To get Random Character incase user doesn't give complete input
    private string GetRandomAlphabet()
    {
        string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        return Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
    }

    // To clear the input text fields
    public void ClearData()
    {
        // Clean Text Input fields
        BoardDimensionX.Select();
        BoardDimensionX.text = "";
        BoardDimensionY.Select();
        BoardDimensionY.text = "";
        BoardData.Select();
        BoardData.text = "";
        MinConstraint.Select();
        MinConstraint.text = "";
        MaxConstraint.Select();
        MaxConstraint.text = "";
        Dictionary.Select();
        Dictionary.text = "";

        // Output text fields
        OutputData.text = "";
        OutputDataWordCount.text = "Count : 0000";
    }

    // To clear the input text fields
    public void ClearLocalVariablesData()
    {
        // Clean local variables
        XDimension = 0;
        YDimension = 0;
        MinConstrnt = 0;
        MaxConstrnt = 0;
        InputDictionary = null;
        BoardDataArr = null;
        OutputWordList = new List<string>();

    }
    // Method to return board data array given by user
    public string[] GetBoardData()
    {
        return BoardData.text.Split(',');
    }

    // Method to get Number of columns in the board
    public int GetXDimesion()
    {
        return int.Parse(BoardDimensionX.text);
    }

    // Method to get Number of rows in the board
    public int GetYDimesion()
    {
        return int.Parse(BoardDimensionY.text);
    }
    #endregion

    #region Boggle Words Finder

    // Method to initiate the recursive call
    private void GetWords(string[,] board)
    {
        // Position visited
        bool[,] posVisited = new bool[YDimension, XDimension];
        string str = "";

        // Initializing recursion for every character
        for (int i = 0; i < YDimension; i++)
            for (int j = 0; j < XDimension; j++)
                GetAllWords(board, posVisited, i, j, str);
    }

    // Recursive Function to get all the words  
    private void GetAllWords(string[,] board, bool[,] posVisited, int i, int j, String str)
    {
        posVisited[i, j] = true;
        str = str + board[i, j];

        // Add the word to the output list 
        if (InputDictionary.Contains(str))
            AddWord(str);

        // Iterating through all the adjacent cells recursively
        for (int row = i - 1; row <= i + 1 && row < YDimension; row++)
            for (int col = j - 1; col <= j + 1 && col < XDimension; col++)
                if (row >= 0 && col >= 0 && !posVisited[row, col])
                    GetAllWords(board, posVisited, row, col, str);


        // Make position visited as false for other Characters & Remove the char from string
        str = "" + str[str.Length - 1];
        posVisited[i, j] = false;
    }

    // Add word with constraint check
    private void AddWord(string str)
    {
        int wordLength = str.Length;
        if (wordLength >= MinConstrnt)
            if (MaxConstrnt > 0 && MaxConstrnt >= wordLength)
                OutputWordList.Add(str);
    }


    #endregion
}
