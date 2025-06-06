using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [Tooltip("To add GameOnver ScreenPanel")]
    [SerializeField] Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
