using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sChManager : MonoBehaviour
{
    public CharacterDatabase CharacterDB;
    public SpriteRenderer artworkSprite;
    [SerializeField]
    public TextMeshProUGUI characterName;
    //public int selectedOption;


    void Start()
    {
        //staticClass.player2selected = 0;
        //selectedOption = staticClass.player2selected;

        //if (!PlayerPrefs.HasKey("selectedOption2"))
        //{
        //    selectedOption = 0;
        //}
        //else
        //{
        //    Load();
        //}
        updateCH(staticClass.player2selected);

    }
    public void next()
    {
        staticClass.player2selected++;
        if (staticClass.player2selected >= CharacterDB.characterCount)
        {
            staticClass.player2selected = 0;
        }
        updateCH(staticClass.player2selected);
        //save();
    }
    public void prev()
    {
        staticClass.player2selected--;
        if (staticClass.player2selected < 0)
        {
            staticClass.player2selected = CharacterDB.characterCount - 1;
        }
        updateCH(staticClass.player2selected);
        //save();
    }
    void updateCH(int selectedOption)
    {
        Character character = CharacterDB.GetCharacter(selectedOption);
        characterName.text = character.characterName;
        artworkSprite.sprite = character.characterSprite;
    }
    //private void Load()
    //{
    //    selectedOption = PlayerPrefs.GetInt("selectedOption2");
    //}
    //private void save()
    //{
    //    //PlayerPrefs.SetInt("selectedOption2", selectedOption);
    //    staticClass.player2selected = selectedOption;
    //}
}
