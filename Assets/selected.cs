using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selected : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI select1;
    public TextMeshProUGUI select2;
    [SerializeField] public static bool isPlayer1Selected, isPlayer2Selected;
    void Start()
    {
        isPlayer2Selected = false;
        isPlayer1Selected = false;
    }

    void Update()
    {
        selection();
    }
    public void selection()
    {
        if (isbothPlayerSelected())
        {
            ChangeScene(2);
        }
    }
    public bool isbothPlayerSelected()
    {
        return isPlayer1Selected && isPlayer2Selected;
    }
    public void ChangeScene(int sceneID)
    {
        if (staticClass.player1selected == 0 && staticClass.player2selected == 0)
        {
            SceneManager.LoadScene(sceneID); //alif alif
        }
        else if (staticClass.player1selected == 0 && staticClass.player2selected == 1)
        {
            SceneManager.LoadScene(sceneID); //alif vs emon
        }
        else if (staticClass.player1selected == 0 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID); //alif vs mainul
        }
        else if (staticClass.player1selected == 1 && staticClass.player2selected == 0)
        {
            SceneManager.LoadScene(sceneID); //emon vs alif
        }
        else if (staticClass.player1selected == 1 && staticClass.player2selected == 1)
        {
            SceneManager.LoadScene(sceneID); //emon vs emon
        }
        else if (staticClass.player1selected == 1 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID); //emon vs mainul
        }
        else if (staticClass.player1selected == 2 && staticClass.player2selected == 0)
        {
            SceneManager.LoadScene(sceneID); //mainul vs alif

        }
        else if (staticClass.player1selected == 2 && staticClass.player2selected == 1)
        {
            SceneManager.LoadScene(sceneID); //mainul vs emon
        }
        else if (staticClass.player1selected == 2 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID); //mainul vs mainul
        }
        else if (staticClass.player1selected == 0 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID);
        }
        else if (staticClass.player1selected == 0 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID);
        }
        else if (staticClass.player1selected == 0 && staticClass.player2selected == 2)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
    public void selectPlayer1()
    {
        isPlayer1Selected = true;
        select1.text = "selected";
    }
    public void selectPlayer2()
    {
        isPlayer2Selected = true;
        select2.text = "selected";
    }
}
