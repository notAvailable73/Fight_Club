using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public CharacterDatabase CharacterDB;
    //public SpriteRenderer artworkSprite;
    public GameObject characterObject;
    public int selectedOption = 0;
    // Start is called before the first frame update
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
        Instantiate(characterObject);
    }
    void updateCH(int selectedOption)
    {
        Character character = CharacterDB.GetCharacter(selectedOption);
        this.characterObject = character.characterObject;
        //this.artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}



