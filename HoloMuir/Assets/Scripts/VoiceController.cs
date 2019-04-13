using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using UnityEngine.Video;

public class VoiceController : MonoBehaviour
{
    public FaceAnimation MuirAnim;

    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    // Vars needed for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;

    //temp
    public VideoPlayer video;
    
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        
        //Voice commands for playing sound
        keyActs.Add("Goodbye John Muir", ByeResponse);
        keyActs.Add("Who’s job is it to protect places like Yosemite?", ProtectYosemiteResponse);
        keyActs.Add("Do you think Yosemite is one of a kind?", UniqueResponse);
        keyActs.Add("How can we help stop mass deforestation?", PreservationForestResponse);
        keyActs.Add("How can we get more support for forest preservation?", PreservationForestResponse);

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
        video.GetComponent<VideoController>().PlayVideo();
        
    }
    void ProtectYosemiteResponse(){
	    soundSource.clip = sounds[1];
	    soundSource.Play();
        MuirAnim.Talking();
        video.GetComponent<VideoController>().PlayVideo();
    }
    void UniqueResponse(){
	    soundSource.clip = sounds[2];
	    soundSource.Play();
        MuirAnim.Talking();
        video.GetComponent<VideoController>().PlayVideo();
    }
    void PreservationForestResponse(){
	    soundSource.clip = sounds[3];
	    soundSource.Play();
        MuirAnim.Talking();
        video.GetComponent<VideoController>().PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundSource.isPlaying){
            MuirAnim.NotTalking();
        }
    }
}
