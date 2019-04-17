using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;

public class VoiceController_Model : MonoBehaviour
{
    public FaceAnimation MuirAnim;

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
        keyActs.Add("Goodbye John Muir", ByeResponse);
        keyActs.Add("protect places like Yosemite", ProtectYosemiteResponse);
        keyActs.Add("one of a kind", UniqueResponse);
        keyActs.Add("mass deforestation", PreservationForestResponse);
        keyActs.Add("forest preservation", PreservationForestResponse);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args){
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }   

    void ByeResponse(){
	    soundSource.clip = sounds[0];
	    soundSource.Play();
        MuirAnim.Talking();
    }
    void ProtectYosemiteResponse(){
	    soundSource.clip = sounds[1];
	    soundSource.Play();
        MuirAnim.Talking();
    }
    void UniqueResponse(){
	    soundSource.clip = sounds[2];
	    soundSource.Play();
        MuirAnim.Talking();
    }
    void PreservationForestResponse(){
	    soundSource.clip = sounds[3];
	    soundSource.Play();
        MuirAnim.Talking();
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundSource.isPlaying){
            MuirAnim.NotTalking();
        }
    }
}
