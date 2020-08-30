 using UnityEngine;
 using System.Collections;
 
 public class LapHandle : MonoBehaviour {
     
     public int CheckpointAmt;
     public static bool nextlap;
    private void Start(){
        nextlap = false;
    }
    public void OnTriggerEnter (Collider other)
     {
         
         if (!other.gameObject.CompareTag("Player")) 
             return; //If it's not the player dont continue

        else
        {
            
             if (LapsAndCheckPoints.CheckpointIndex == CheckpointAmt && !nextlap)
             {
                LapsAndCheckPoints.CheckpointIndex = 0;
                LapsAndCheckPoints.lapNumber++;
                nextlap = true;
                Debug.Log("Lap number " + LapsAndCheckPoints.lapNumber);
                 
             }
         }
     }
     
 }