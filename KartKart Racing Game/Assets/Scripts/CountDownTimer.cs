using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{
    public static float currentTime = 0f;
    float startingTime = 3f;
    public static float timer = 1f;
    [SerializeField] Text CountDownText;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        
        CountDownText.text = currentTime.ToString("0");

        if (currentTime <= 3)
        {
            CountDownText.color = Color.red;
        }
        if (currentTime <= 2)
        {
            CountDownText.color = Color.red;
        }
        if (currentTime <= 1.5)
        {
            CountDownText.color = Color.yellow;
        }


        if (currentTime <= 0)
        {
            currentTime = 0;
            CountDownText.color = Color.green;
            CountDownText.text = "GO";

            timer -= 1 *Time.deltaTime;

            if (timer <= 0){
                
                timer = 0;
                CountDownText.text = " ";
            }
            
        }
    }
}
