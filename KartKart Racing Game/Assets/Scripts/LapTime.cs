using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LapTime : MonoBehaviour
{

    public float startTime;
    public float timeTaken;
    private string displayTimeLaps;
    private int lapnumber = 0;
    public float timeComplete;
    public  Text TimeText;
    public Text LapTimeText;
    public float resetStartTime = 0f;
    public List<float> completeTimes = new List <float>();
    // Start is called before the first frame update
   void start()
   {
       startTime = -4f;
   }
    // Update is called once per frame
    void Update()
    {
        if (CountDownTimer.timer <= 0)
        {
            //to compensate for the countdown timer
            
            timeTaken = startTime + Time.timeSinceLevelLoad;
            TimeText.text = FormatTime(timeTaken);
        }
        
        if (LapHandle.nextlap)
        {
            timeComplete = timeTaken ;
            completeTimes.Add(Mathf.Round(timeComplete * 100f)/100f);
            lapnumber++;
            //displayTimeList();
        }
        checkTimeList();
        if (LapsAndCheckPoints.lapNumber == 3){
            SceneManager.LoadScene("MenuScene");
        }
    }

    
    private string FormatTime(float time)
    {
        //to format time text with minutes/seconds/mlsec
        float totalTime = time;
        int minutes = (int) (totalTime/60) % 60;
        int seconds = (int) totalTime % 60;
        int milSec = (int) (Time.timeSinceLevelLoad*10) % 10;

        string answer = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milSec.ToString("00");
        return answer;
    }


    private void checkTimeList()
    {
    displayTimeLaps = "";
    var arrayoftimes = completeTimes.ToArray();
        for (int i = 0; i < arrayoftimes.Length; i++)
        {
            displayTimeLaps += "Lap " + (i+1) + ": " + arrayoftimes[i] + "\n";
           // LapsTimeText.fontSize = 54;

           if (arrayoftimes.Length > 0){
               displayTimeList();
           }
           
        }
    LapHandle.nextlap = false;
    }

    public void displayTimeList(){
        LapTimeText.fontSize = 44;
        
        LapTimeText.text = displayTimeLaps;
        
    }
}
