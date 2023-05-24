using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoPanelController : MonoBehaviour
{
    public GameObject RoomInfoPanel;
    public GameObject RoomInfoButton;

    void Start()
    {
        RoomInfoPanel.SetActive(false);

        //ready 버튼이 눌리면 RoomInfoButtonClicked 활성화
        Button roomInfoBtn = GameObject.Find("RoomInfoBtn").GetComponent<Button>();
        roomInfoBtn.onClick.AddListener(RoomInfoButtonClicked);

        Button readyBtn = GameObject.Find("ReadyBtn").GetComponent<Button>();
        readyBtn.onClick.AddListener(OnReadyButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RoomInfoPanel.SetActive(false);
        }
    }

    public void RoomInfoButtonClicked()
    {
        RoomInfoPanel.SetActive(true);
    }

    public void OnReadyButtonClicked()
    {
        SceneManager.LoadScene("GamePalyScene2");
        //여기 오타났음...ㅎㅎ^,^;
    }
}

