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
        // �ʱ� ���´� ��� Panel ��Ȱ��ȭ
        enterCodePanel.SetActive(false);
        warningPanel.SetActive(false);

        // GameStartBtn�� OnGameStartButtonClicked()  ����
        Button gameStartBtn = GameObject.Find("GameStartBtn").GetComponent<Button>();
        gameStartBtn.onClick.AddListener(OnGameStartButtonClicked);

        // JoinBtn�� OnJoinButtonClicked() ����
        joinBtn.onClick.AddListener(OnJoinButtonClicked);

        // Esc Ű ������ ���� ���� Panel �ݱ�
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
            // �ڵ尡 ������ WaitingScene���� ��ȯ
            Debug.Log("WaitingScene���� ��ȯ�մϴ�.");
            SceneManager.LoadScene("WaitingRoomScene");
        }
        else
        {
            // �ڵ尡 Ʋ���� WarningPanel Ȱ��ȭ
            warningPanel.SetActive(true);
        }
        */
        SceneManager.LoadScene("WaitingRoomScene");
    }
}