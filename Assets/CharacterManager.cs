using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase CharacterDB;
    public SpriteRenderer artworkSprite;
    [SerializeField]
    public TextMeshProUGUI characterName;
    public int selectedOption;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCH(selectedOption);
         
    }
    public void next()
    {
        selectedOption++;
        if (selectedOption >= CharacterDB.characterCount)
        {
            selectedOption = 0;
        }
        updateCH(selectedOption);
        save();
    }
    public void prev()
    {
        selectedOption--;
        if (selectedOption < 0 )
        {
            selectedOption = CharacterDB.characterCount-1;
        }
        updateCH(selectedOption);
        save();
    }
    void updateCH(int selectedOption)
    {
        Character character = CharacterDB.GetCharacter(selectedOption);
        characterName.text = character.characterName;
        artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    
}
