using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public SpawnerManager spawnerManager;
    public float moveSpeed = 2f;
    private int lineToMove = 1;
    public float lineDistance = 4;
    public Canvas canvas; // поле для канваса
    public TMP_Text coinsText; // поле для количества очков
    private float coins = 0;
    public GameObject canvasLose;

    //public float increment;

    void Start()
    {
        Time.timeScale = 1;
        canvasLose.SetActive(false);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }
        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }
        Vector3 targetPosition= transform.position.z * transform.forward +transform.position.y*transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;
        transform.position = targetPosition;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("SpawnTrigger"))
            {
            spawnerManager.SpawnTriggerEntered();
        }
        if (collision.gameObject.tag == ("Obstancle"))
            {
            canvasLose.SetActive(true);
            Time.timeScale = 0;
           // spawnerManager.SpawnTriggerEntered();
        }
        if (collision.gameObject.tag == ("Coin"))
        {
            coins += 10; // 
            coinsText.text = coins.ToString(); 
            
        }
        if (collision.gameObject.tag == ("Time"))
        {
            Time.timeScale = Time.timeScale + 0.5f;
        }


    }
    public void CanvasButtonExit() // метод кнопки выхода из игры
    {
        Application.Quit();
    }
    public void CanvasButtonReset() // метод кнопки перезапуска игры
    {
        SceneManager.LoadScene("SampleScene");
    }

}