using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] screens;
    public TMP_Text moneyCounter;
    public TMP_Text currLevel;
    public TMP_Text nextLevel;
    public GameObject[] levelButtons;
    public void showScreen(int screenIndex)
    {
        for (int i = 0;i<screens.Length;i++)
        {
            screens[i].SetActive(i == screenIndex);
        }
    }

    public void startGame()
    {
        showScreen(-1);
        Model.inst().isPaused = false;
    }

    public void nextBtn()
    {
        if (Model.level + 1 <= Model.inst().levels.Length)
        {
            Model.level += 1;
        }
        SceneManager.LoadScene("Scenes/Main");
    }

    private void Update()
    {
        moneyCounter.text = Model.bril.ToString();
        currLevel.text = Model.level.ToString();
        if (Model.level == Model.inst().levels.Length)
        {
            nextLevel.text = "?";
        }
        else
        {
            nextLevel.text = (Model.level + 1).ToString();
        }
        for (int i = 0;i<levelButtons.Length;i++)
        {
            levelButtons[i].SetActive(i < Model.level);
        }
    }

    public void loadLevel(int lvl)
    {
        Controller.setLevel(lvl);
        showScreen(0);
    }
}
