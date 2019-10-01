using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Refference Variables
    public GameObject MenuPanel;
    public GameObject GridPanel;
    public GameObject CubePref;
    public BoardDataManager BoardManager;
    #endregion

    #region Local Variables
    private int xDimension;
    private int yDimension;
    #endregion

    #region Methods

    // Clear Menu Content
    public void ClearMenuData()
    {
        BoardManager.ClearData();
        BoardManager.ClearLocalVariablesData();
    }

    // Hide Menu Panel on Submit button click
    public void AcceptData()
    {
        DisableMenu();

        // Generate Grid of Alphabets
        GenerateBoard();
    }

    public void DisableMenu()
    {
        MenuPanel.SetActive(false);
    }

    // Show Menu Panel on Menu button click
    public void EnableMenu()
    {
        // Clear the data in the menu
        ClearMenuData();

        // Delete the childs gameobjects of GridPanel
        foreach (Transform child in GridPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        // Enable Menu panel

        MenuPanel.SetActive(true);
    }

    // Create Board based on user input
    private void GenerateBoard()
    {
        // Get data to generate board from Board Manager
        string[] boardDataArr = BoardManager.GetBoardData();
        xDimension = BoardManager.GetXDimesion();
        yDimension = BoardManager.GetYDimesion();

        // Update the Cell size of the Grid Panel on the baseis of number of coloumns
        GridLayoutGroup gt = GridPanel.GetComponent<GridLayoutGroup>();
        float width = 200 / xDimension;
        float Height = 200 / yDimension;
        gt.cellSize = new Vector2(width, Height);

        // Create Boggle board all the boxes and add the corresponding Text to it
        for (int i = 0; i < xDimension * yDimension; i++)
        {
            GameObject cO = Instantiate(CubePref, Vector3.one, Quaternion.identity) as GameObject;
            Text data = cO.GetComponentInChildren<Text>();
            if (boardDataArr.Length > i)
                data.text = boardDataArr[i];
            cO.transform.parent = GridPanel.transform;
        }
    }

    #endregion
}
