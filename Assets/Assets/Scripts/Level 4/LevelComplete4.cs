using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete4 : MonoBehaviour
{

    [SerializeField]
    Button nextBtn;

    [SerializeField]
    Button mainMenuBtn;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn.onClick.AddListener(() =>
        returnToMain());

        nextBtn.onClick.AddListener(() =>
        nextLevel());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void returnToMain()
    {
        SceneManager.LoadScene("Start_Screen", LoadSceneMode.Single);
    }

    private void nextLevel()
    {
        SceneManager.LoadScene("Level 5", LoadSceneMode.Single);
    }
}
