using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    // Vars needed for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;
    
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        
        //Voice commands for playing sound
        keyActs.Add("Hello box box", Talk);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args){
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }   

    void Talk(){
	    soundSource.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
	    soundSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
