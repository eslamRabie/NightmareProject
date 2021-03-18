using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImangerLevel1 : MonoBehaviour
{
    
    [SerializeField]
    GameObject selectAbilityUi;
    [SerializeField]
    TMP_Text onSelectAbilityUi;
    [SerializeField]
    GameObject selectCharcterUi;


    [SerializeField]
    ShowModels showModels;


    GameObject[] ablitiesArray;

    float playerAbilityCount;

    public Abilites abilitesIndex;
    public int playerIndex;

    public enum Abilites
    {
        Water,
        Fire,
        Ground,
        Wind,
        Ice
    }

    // Start is called before the first frame update
    void Start()
    {
        selectAbilityUi.SetActive(true);
        selectCharcterUi.SetActive(false);
        onSelectAbilityUi.gameObject.SetActive(false);

    }

    public void OncSelectAblity(int index)
    {
        // 0  -- water
        // 1  -- fire
        // 2  -- ground
        // 3  -- Wind
        // 4  -- ice
        onSelectAbilityUi.gameObject.SetActive(true);
        abilitesIndex = (Abilites)index;
        onSelectAbilityUi.text = "you select " + (Abilites)index;
        Debug.Log("index " + abilitesIndex);
        FindObjectOfType<AudioManager>().playAudio("Click");

    }

    public void Selectplayer()
    {
        selectAbilityUi.SetActive(false);
        selectCharcterUi.SetActive(true);
        FindObjectOfType<AudioManager>().playAudio("Click");

    }

    public void OncSelectcharcter()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playerIndex = showModels.selectedPlayer;
        Debug.Log("index " + playerIndex);
        FindObjectOfType<AudioManager>().playAudio("Click");
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().playAudio("Click");
    }
}
