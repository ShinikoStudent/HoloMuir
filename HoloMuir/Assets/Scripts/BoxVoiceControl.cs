using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using UnityEngine.Video;

public class BoxVoiceControl : MonoBehaviour
{
    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    // Var needed for color manipulation
    private MeshRenderer cubeRend;

    // Vars needed for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;

    public VideoPlayer video;

    // Start is called before the first frame update
    void Start(){
        cubeRend = GetComponent<MeshRenderer>();
        soundSource = GetComponent<AudioSource>();

        //Voice commands for changing color
        keyActs.Add("red", Red);
        keyActs.Add("Turn the color to green", Green);
        keyActs.Add("blue", Blue);
        keyActs.Add("white", White); 
        keyActs.Add("Move square down", move); 

        //Voice commands for playing sound
        keyActs.Add("John Muir, where are you?", Talk); 
        keyActs.Add("Play video", playClip);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args){
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }   

    void playClip(){
        
    }
    
    void Talk(){
	    soundSource.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
	    //soundSource.Play();
    }

    // Test functions for box
    void move(){
        transform.Translate(transform.position.x, transform.position.y-1, transform.position.z);
    }
    void Red(){
        cubeRend.material.SetColor("_Color", Color.red);
    }
    void Green(){
        cubeRend.material.SetColor("_Color", Color.green);
    }
    void Blue(){
        cubeRend.material.SetColor("_Color", Color.blue);
    }
    void White(){
        cubeRend.material.SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
