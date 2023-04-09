using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject enterCodePanel;
    public InputField roomCodeInputField;
    public GameObject warningPanel;
    public Button joinBtn;

    void Start()
    {
        // 초기 상태는 모든 Panel 비활성화
        enterCodePanel.SetActive(false);
        warningPanel.SetActive(false);

        // GameStartBtn에 OnGameStartButtonClicked()  연결
        Button gameStartBtn = GameObject.Find("GameStartBtn").GetComponent<Button>();
        gameStartBtn.onClick.AddListener(OnGameStartButtonClicked);

        // JoinBtn에 OnJoinButtonClicked() 연결
        joinBtn.onClick.AddListener(OnJoinButtonClicked);

        // Esc 키 누르면 현재 열린 Panel 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enterCodePanel.activeSelf)
            {
                enterCodePanel.SetActive(false);
            }
            else if (warningPanel.activeSelf)
            {
                warningPanel.SetActive(false);
            }
        }
    }

    public void OnGameStartButtonClicked()
    {
        enterCodePanel.SetActive(true);
    }

    public void OnJoinButtonClicked()
    {
        /*
        if (roomCodeInputField.text == "1234")
        {
            // 코드가 맞으면 WaitingScene으로 전환
            Debug.Log("WaitingScene으로 전환합니다.");
            SceneManager.LoadScene("WaitingRoomScene");
        }
        else
        {
            // 코드가 틀리면 WarningPanel 활성화
            warningPanel.SetActive(true);
        }
        */
        SceneManager.LoadScene("WaitingRoomScene");
    }
}