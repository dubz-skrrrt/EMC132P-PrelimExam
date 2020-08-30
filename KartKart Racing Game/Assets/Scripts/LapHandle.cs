 using UnityEngine;
 using System.Collections;
 
 public class LapHandle : MonoBehaviour {
     
     public int CheckpointAmt;
    private void OnTriggerEnter (Collider other)
     {
         
         if (!other.gameObject.CompareTag("Player")) 
             return; //If it's not the player dont continue

        else
        {
            Debug.Log("hit");
             if (LapsAndCheckPoints.CheckpointIndex == CheckpointAmt)
             {
                 LapsAndCheckPoints.CheckpointIndex = 0;
                 LapsAndCheckPoints.lapNumber++;

                 Debug.Log(LapsAndCheckPoints.lapNumber);
                 Debug.Log("Next Lap");
             }
         }
     }
     
 }