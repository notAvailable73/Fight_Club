using System.Collections;
using System.Collections.Generic;
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
        ChangeScene(2);
    }
    public void ChangeScene(int sceneID)
    {
        if (isPlayer1Selected == true && isPlayer2Selected == true)
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
