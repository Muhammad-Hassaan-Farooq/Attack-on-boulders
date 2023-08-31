using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    [SerializeField]
    Button backBtn;
    [SerializeField]
    Button oneBtn;
    [SerializeField]
    Button twoBtn;
    [SerializeField]
    Button threeBtn;
    [SerializeField]
    Button fourBtn;
    [SerializeField]
    Button fiveBtn;
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            goBack();
        });
        oneBtn.onClick.AddListener(() =>
        {
            goOne();
        });
        twoBtn.onClick.AddListener(() =>
        {
            goTwo();
        });
        threeBtn.onClick.AddListener(() =>
        {
            goThree();
        });
        fourBtn.onClick.AddListener(() =>
        {
            goFour();
        });
        fiveBtn.onClick.AddListener(() =>
        {
            goFive();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void goBack()
    {
        SceneManager.LoadScene("Start_Screen", LoadSceneMode.Single);
    }
    private void goOne()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    private void goTwo()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
    private void goThree()
    {
        SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
    }
    private void goFour()
    {
        SceneManager.LoadScene("Level 4", LoadSceneMode.Single);
    }
    private void goFive()
    {
        SceneManager.LoadScene("Level 5", LoadSceneMode.Single);
    }
}
