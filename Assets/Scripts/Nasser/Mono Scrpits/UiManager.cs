using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerUi;
    [SerializeField]
    GameObject abilityParentObj;
    [SerializeField]
    GameObject abilityObj;
    [SerializeField]
    GameObject gameOverObj;
    [SerializeField]
    GameObject pauseGameObj;
    [SerializeField]
    GameObject victoryGameObj;

    [SerializeField]
    PlayerUiElemnt PlayerUiElemnt;

    GameObject[] ablitiesArray;

    float playerAbilityCount;

    public Abilites abilitesIndex;
    public int  playerIndex;

    public enum Abilites
    {
        Water,
        Fire,
        Ground,
        Wind,
        Ice
    }

    private void Awake()
    {
        playerUi.transform.GetChild(0).GetComponent<Image>().sprite = PlayerUiElemnt.PlayerIcon;
        playerAbilityCount = PlayerUiElemnt.PlayerAbilities.Length;
        ablitiesArray = new GameObject[(int)playerAbilityCount];
        for (int i = 0; i < playerAbilityCount; i++)
        {

            GameObject childObject = Instantiate(abilityObj) as GameObject;
            childObject.transform.parent = abilityParentObj.transform;
            childObject.transform.GetChild(0).GetComponent<Image>().sprite = PlayerUiElemnt.PlayerAbilities[i].AbilityIcon;
            childObject.transform.GetChild(1).GetComponent<Image>().sprite = PlayerUiElemnt.PlayerAbilities[i].AbilityValueIcon;
            childObject.transform.GetChild(1).GetComponent<Image>().fillAmount = PlayerUiElemnt.PlayerAbilities[i].AbilityValue / 10 ;
            childObject.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = ((int )PlayerUiElemnt.PlayerAbilities[i].AbilityValue).ToString();
            ablitiesArray[i] = childObject;



        }
    }
    // Start is called before the first frame update
    void Start()
    {

        gameOverObj.SetActive(false);
        victoryGameObj.SetActive(false);
        pauseGameObj.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnUiPuasedPannelCalled();
            Debug.Log("OnUiPuasedPannelCalled");
        }*/
        
        for (int i = 0; i < playerAbilityCount; i++)
        {
            ablitiesArray[i].transform.GetChild(1).GetComponent<Image>().fillAmount = PlayerUiElemnt.PlayerAbilities[i].AbilityValue / 10;
            ablitiesArray[i].transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = PlayerUiElemnt.PlayerAbilities[i].AbilityValue.ToString();
        }
    }
    public void OnUiButtonExit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
    }
    public void OnUiButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnUiButtonNextLvel()
    {
        victoryGameObj.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnUiButtonResume()
    {
       // Time.timeScale = 1;
        pauseGameObj.SetActive(false);
    }

    public void OnUiVictoryPannelCalled()
    {
        victoryGameObj.SetActive(true);
    }

    public void OnUiGameOverPannelCalled()
    {
        gameOverObj.SetActive(true);
    }
    [ContextMenu("puase")]
    public void OnUiPuasedPannelCalled()
    {
        Debug.Log("Test q");
        pauseGameObj.SetActive(false);
        Debug.Log(pauseGameObj.active);
        pauseGameObj.SetActive(true);
        Debug.Log(pauseGameObj.active);

    }

    [ContextMenu("Decrise ")]
    public void OncCnageAblityCount(/*int index*/)
    {
        if (PlayerUiElemnt.PlayerAbilities[0].AbilityValue > 0)
        {
            PlayerUiElemnt.PlayerAbilities[0].AbilityValue -= 1f;
            ablitiesArray[0].transform.GetChild(1).GetComponent<Image>().fillAmount = 
                PlayerUiElemnt.PlayerAbilities[0].AbilityValue / PlayerUiElemnt.PlayerAbilities[0].MaxAbilityValue;
            ablitiesArray[0].transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = ((int)PlayerUiElemnt.PlayerAbilities[0].AbilityValue).ToString();
        }
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().playAudio("Click");
    }

}
