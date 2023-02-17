using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn_Soldier : MonoBehaviour
{
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private float spawnInterval = 8.0f; 
    [SerializeField] private Image healthBar;
    [SerializeField] private Button upgradeButton;

    private float timeSinceLastSpawn = 0.0f;
    private int coinCount = SoldierController.coinCount;
    private SoldierController soldierController;
    private ButtonRandomizer buttonRandomizer;

    void Start()
    {
        soldierController = GameObject.FindGameObjectWithTag("Soldier").GetComponent<SoldierController>();
        buttonRandomizer = FindObjectOfType<ButtonRandomizer>();

        if (ButtonRandomizer.isPlay)
        {
            buttonRandomizer.LoadPlayScene();
        }

        upgradeButton.interactable = false;
        SpawnSoldier();
    }

    void Update()
    {
        coinCount = SoldierController.coinCount;

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {           
            timeSinceLastSpawn = 0.0f;
            SpawnSoldier();
        }

        CheckUpgradeButton();
    }

    private void CheckUpgradeButton()
    {
        if (coinCount >= 100 && coinCount % 100 == 0)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }

    public void UpgradeSoldierCount()
    {
        spawnInterval -= 0.1f;
        spawnInterval = Mathf.Clamp(spawnInterval, 0.1f, 10f);
    }

    public void OnUpgradeButtonClick()
    {
        SoldierController.coinCount -= 100;
        UpgradeSoldierCount();
    }

    void SpawnSoldier()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 location = new Vector3(-6.7f, 0.6f, 0f);
            Instantiate(soldierPrefab, location, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            healthBar.fillAmount -= 0.1f;
            SoldierController.coinCount++;            
        }
    }
}
