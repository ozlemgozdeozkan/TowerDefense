using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SoldierController : MonoBehaviour
{
    NavMeshAgent soldier;
    [SerializeField]
    GameObject[] home = new GameObject[1];


    public static int coinCount;
    [SerializeField]
    public Text coinCountText;

    private int currentHome = 0;
    void Start()
    {
        home[0] = GameObject.FindGameObjectWithTag("home2");
        soldier = GetComponent<NavMeshAgent>();
        GoHome();
        coinCountText = GameObject.Find("CoinText").GetComponent<Text>();
        coinCountText.text = coinCount.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            coinCount += 5;
            coinCountText.text = coinCount.ToString();
            Destroy(other.gameObject);
        }
    }

    void GoHome()
    {
        soldier.SetDestination(home[currentHome].transform.position);
    }


}
