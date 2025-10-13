using UnityEngine;
using UnityEngine.UI;  // Required for Button!

public class start_game : MonoBehaviour
{
    public Button button;
    public Rigidbody player;
    public MonoBehaviour controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.useGravity = false;
        controller.enabled = false;

        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        player.useGravity = true;
        controller.enabled = true;
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
