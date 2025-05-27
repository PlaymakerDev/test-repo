// using System.Collections.Generic;
using TMPro;
using UnityEngine;
// using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public InventoryPanel inventoryPanel;

    public GameEnd gameEnd;
    public void OpenInventoryPanel()
    {
        // OPEN
        inventoryPanel.gameObject.SetActive(true);
        // ADDITION
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        // CLOSE
        inventoryPanel.gameObject.SetActive(false);
        // ADDITION
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void ShowGameEnd()
    {
        if (isPlayerWin)
        {
            gameEndText.text = "You Win!";
            panelColor.color = new Color32(0, 255, 0, 168);

        }
        else
        {
            gameEndText.text = "You Lose!";
            panelColor.color = new Color32(255, 0, 0, 168);
        }
        // UPDATE INSTANCE
        gameEnd.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public float timeCounter = 30f;
    public ItemData targetItem;
    public int targetAmount = 5;
    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;
    public bool isPlayerWin;

    public TMP_Text gameEndText;
    public Image panelColor;


    public void Start()
    {
        // INIT GAME
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        targetItemIcon.sprite = targetItem.itemIcon;

        // if (targetItem != null)
        // {
        //     // INIT TARGET ITEM
        //     ItemData[] dataList = Resources.LoadAll<ItemData>("Data");
        //     targetItem = dataList[Random.Range(0, dataList.Length)];
        //     targetItemIcon.sprite = targetItem.itemIcon;
        // }
        // else
        // {
        //     return;
        // }
    }
    public void Update()
    {
        if (isPlayerWin)
        {
            return;
        }

        if (timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();
            targetCurrentAmountText.text = (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();

            // Debug.Log(targetCurrentAmountText.text = (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString());

            // Debug.Log(targetItem);
            // Debug.Log(InventoryManager.instance.GetItemAmount(targetItem).ToString());

            if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount)
            {
                Debug.Log("Player Win");
                isPlayerWin = true;
                ShowGameEnd();
            }
        }
        else
        {
            isPlayerWin = false;
            ShowGameEnd();
            // isPlayerWin = false;
            // SceneManager.LoadScene("MainMenu");
        }
    }
}
