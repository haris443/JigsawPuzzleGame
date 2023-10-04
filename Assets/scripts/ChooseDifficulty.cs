using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseDifficulty : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject parent;
    public static ChooseDifficulty instance;
    public GameObject levelPanel;
    public GameObject difficultyPanel;
    public GameObject gameNameText;
    public GameObject levelSelText;
    public static int num;
    public int unlockLevels;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(GeneratingBtns());
        unlockLevels = PlayerPrefs.GetInt("unlockImg", 0);
        levelPanel.SetActive(false);
        levelSelText.SetActive(false);
        gameNameText.SetActive(true);
        difficultyPanel.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNumberOfPieces(int num)
    {
        SoundManager.instance.playSound(0);
        SpriteDivider.totalPieces = num;
        levelPanel.SetActive(true);
        levelSelText.SetActive(true);
        difficultyPanel.SetActive(false);
        gameNameText.SetActive(false);
       // SceneManager.LoadScene("PuzzleGame");
    }
    public void displayDiffPanel()
    {
        SoundManager.instance.playSound(0);
        difficultyPanel.SetActive(true);
        gameNameText.SetActive(true);
        levelPanel.SetActive(false);
        levelSelText.SetActive(false);
    }
    public void SetTimer(int seconds)
    {
        TimerOfPuzzleGame.totalTime = seconds;

    }
    public IEnumerator GeneratingBtns()
    {
        yield return new WaitForSeconds(.6f);
        

        for (int i = 0; i <= DataRetriever.retrievedNumber; i++)
        {
             GameObject btn = Instantiate(buttonPrefab, parent.transform);
            int numtoDisp = i + 1;
            btn.transform.GetChild(0).GetComponent<Text>().text = numtoDisp.ToString();
            btn.transform.GetComponent<BtnScript>().levelNumOfBtn = i;
           
            if (i<= unlockLevels)
            {
                btn.transform.GetChild(1).gameObject.SetActive(false);
                btn.transform.GetChild(0).gameObject.SetActive(true);
                btn.transform.GetComponent<Button>().interactable = true; ;
                //Debug.Log(btn.name);

            }
        }


    }
}
