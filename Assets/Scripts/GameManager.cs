
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Popup UI")]
    public Canvas GameMenu;

    public TMP_Text Title;
    public TMP_Text Message;

    public Button ContinueButton;
    public Button RestartButton;

    [Header("Scene Settings")]
    public string nextSceneName = "Scene_1";

    private bool isShowingMenu = false;

    void Start()
    {
        // An Popup khi bat dau game
        GameMenu.enabled = isShowingMenu;

        // Noi dung Popup duoc thiet lap bang C#
        Title.text = "Welcome to Unity!";
        Message.text = "Do you want to continue?";

        // Thay doi chu tren hai Button
        ContinueButton.GetComponentInChildren<TMP_Text>()
            .text = "Enter";

        RestartButton.GetComponentInChildren<TMP_Text>()
            .text = "Restart";
    }

    // Chuyen sang Scene tiep theo
    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Choi lai Scene hien tai
    public void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
