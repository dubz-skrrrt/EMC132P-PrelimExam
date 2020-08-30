using UnityEngine;
using System.Collections;
 
 public class CheckPointHandle : MonoBehaviour {
     
     public int Index;
    
     void  Start ()
     {
 
     }
     
     void  OnTriggerEnter ( Collider other  )
     {
         //Is it the Player who enters the collider?
         if (!other.gameObject.CompareTag("Player")) 
             return; //If it's not the player dont continue

        else
        {
           
            
            if (LapsAndCheckPoints.CheckpointIndex == Index +1 || LapsAndCheckPoints.CheckpointIndex == Index -1)
            {
                LapsAndCheckPoints.CheckpointIndex = Index;

                Debug.Log("Checkpoint: " + Index);
            }
 
        }
     }
 
 }