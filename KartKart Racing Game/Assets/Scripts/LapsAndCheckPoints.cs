using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsAndCheckPoints : MonoBehaviour
{

    public static int lapNumber; 
    public static int CheckpointIndex;
    // Start is called before the first frame update
    void Start()
    {
        lapNumber = 0; //starting Lap
        CheckpointIndex = 0; // Current Checkpoint
    }

    
}
