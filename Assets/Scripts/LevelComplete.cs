using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public GameObject levelCompleteText;
    Scene_Manager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText.SetActive(false);
        sceneManager = FindObjectOfType<Scene_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelCompleteText.SetActive(true);
            Invoke(nameof(nextScene), 1);
        }
    }
    void nextScene()
    {
        sceneManager.NextLevel();
    }


}
