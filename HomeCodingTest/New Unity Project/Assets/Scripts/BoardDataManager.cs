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
    private string[] InputDictionary;
    private string[] BoardDataArr;
    private List<string> OutputWordList;
    #endregion

    #region Calling Method

    public void StartGame()
    {
        // Assign Input Data
        SetDataToLocalVariables();

        // Create board input and call method to get words
        // check if any words are added in dictionary
        if(InputDictionary != null && InputDictionary.Length > 0)
            GetWords(CreateBoggleBoard(BoardDataArr));

        // Set output text area
        SetOutputData();
    } 

    #endregion

    #region Helper Methods

    private void SetDataToLocalVariables()
    {
        XDimension = int.Parse(BoardDimensionX.text);
        YDimension = int.Parse(BoardDimensionY.text);
        MinConstrnt = int.Parse(MinConstraint.text);
        MaxConstrnt = int.Parse(MaxConstraint.text);
        InputDictionary = Dictionary.text.Split(',');
        BoardDataArr = BoardData.text.Split(',');

        //Set Default dimesion
        SetDefaultStuff();
    }

    private void SetDefaultStuff()
    {
        if(XDimension == 0 || YDimension == 0)
        {
            if(YDimension != 0)
                XDimension = YDimension;
            else if(XDimension != 0)
                YDimension = XDimension;
            else
                XDimension = YDimension = 3;
        }
    }

    private string[,] CreateBoggleBoard(string[] input)
    {
        string[,] board = new string[XDimension, YDimension];
        int k = 0;
        for (int i = 0; i < XDimension; i++)
            for (int j = 0; j < YDimension; j++)
                if(k < input.Length)
                {
                    board[i, j] = input[k];
                    k++;
                }
                else
                    board[i, j] = GetRandomAlphabet();

        return board;
    }

    private void SetOutputData()
    {
        OutputDataWordCount.text = OutputWordList.Count.ToString();
        OutputData.text = String.Join(",", OutputWordList);
    } 

    private string GetRandomAlphabet()
    {
        string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        return Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
    }

    public void ClearData()
    {
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
    }

    public string GetBoardData()
    {
        return BoardData.text;
    }

    public string GetXDimesion()
    {
        return BoardDimensionX.text;
    }

    public string GetYDimesion()
    {
        return BoardDimensionY.text;
    }
    #endregion

    #region Boggle Words Finder

    // Method to initiate the recursive call
    private void GetWords(string[,] board)
    {
        // Position visited
        bool[,] posVisited = new bool[XDimension, YDimension];
        string str = "";

        // Initializing recursion for every character
        for (int i = 0; i < XDimension; i++)
            for (int j = 0; j < YDimension; j++)
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
        for (int row = i - 1; row <= i + 1 && row < XDimension; row++)
                for (int col = j - 1; col <= j + 1 && col < YDimension; col++)
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
        if (wordLength > MinConstrnt)
            if (MaxConstrnt > 0 && MaxConstrnt > wordLength)
                OutputWordList.Add(str);
    }


    #endregion
}
