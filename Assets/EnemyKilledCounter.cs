using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKilledCounter : MonoBehaviour
{
    public Text counterText;
    public Object enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        counterText.text = "Enemies Killed: " + enemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementEnemyCount()
    {

        counterText.text = "Enemies Killed: " + enemyCount.ToString();
    }
}
