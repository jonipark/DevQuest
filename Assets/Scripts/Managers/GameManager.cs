using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private GameObject confirmationDialog;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckGameEndCondition()
    {
        if (enemies.Count == 0)
        {
            Debug.Log("Game Over! You Win!");
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
        }
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }

    public void OnQuitButtonPressed()
    {
        confirmationDialog.SetActive(true);
    }

    public void OnConfirmQuitPressed()
    {
        QuitGame();
    }

    public void OnCancelQuitPressed()
    {
        confirmationDialog.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
