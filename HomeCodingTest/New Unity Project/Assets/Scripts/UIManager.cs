using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject GridPanel;
    public GameObject CubePref;
    public BoardDataManager BoardManager;

    private int offSetX = 20;
    private int offSetY = -20;
    private float space = 2.5f;
    private int xDimension;
    private int yDimension;

    // Clear Menu Content
    public void ClearMenuData()
    {
        BoardManager.ClearData();
    }


    // Hide Menu Panel on Submit button click
    public void DisableMenu()
    {
        MenuPanel.SetActive(false);

        // Generate Grid of Alphabets
        GenerateBoard();
    }
    
    // Show Menu Panel on Menu button click
    public void EnableMenu()
    {
        MenuPanel.SetActive(true);
    }

    private void GenerateBoard()
    {
        string[] boardDataArr = BoardManager.GetBoardData().Split(',');

        xDimension = int.Parse(BoardManager.GetXDimesion());
        yDimension = int.Parse(BoardManager.GetYDimesion());
        SetDefaultStuff();
        float width = 200 / xDimension - 15;
        float Height = 200 / yDimension - 15;

    }

    private void SetDefaultStuff()
    {
        if (xDimension == 0 || yDimension == 0)
        {
            if (yDimension != 0)
                xDimension = yDimension;
            else if (xDimension != 0)
                yDimension = xDimension;
            else
                xDimension = yDimension = 3;
        }
    }
}
