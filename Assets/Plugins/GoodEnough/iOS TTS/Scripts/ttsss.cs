using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoodEnough.TextToSpeech;
public class ttsss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void speak(string S)
    {
        
        TTS.Speak(S);
    }
}
