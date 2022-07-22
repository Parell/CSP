using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma) && Time.timeScale != 1)
        {
            Time.timeScale--;
        }
        if (Input.GetKeyDown(KeyCode.Period) && Time.timeScale != 4)
        {
            Time.timeScale++;
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Time.timeScale = 1;
        }
    }
}
