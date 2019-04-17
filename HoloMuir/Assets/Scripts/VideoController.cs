using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoController : MonoBehaviour
{   
    //Place video player fom heiarchy here
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    
    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    // Start is called before the first frame update
    void Start() {   

        //Voice commands for playing sound
        keyActs.Add("Hello John Muir", HelloResponse);
        keyActs.Add("questions, John Muir.", AskResponse);
        keyActs.Add("Goodbye John Muir", ByeResponse);
        keyActs.Add("protect places like Yosemite?", ProtectYosemiteResponse);
        keyActs.Add(" one of a kind?", UniqueResponse);
        keyActs.Add("mass deforestation?", PreservationForestResponse);
        keyActs.Add("forest preservation?", PreservationForestResponse);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();

    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args){
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    } 

    public void PlayVideo(int clipIndex){
        videoPlayer.clip = videoClips[clipIndex];
        StartCoroutine(PrepareWait());
    }

    IEnumerator PrepareWait(){
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared){
            yield return null;   //Wait
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    void HelloResponse(){
        PlayVideo(0);
    }

    void AskResponse(){
        PlayVideo(1);
    }
    void ByeResponse(){
	    //soundSource.clip = sounds[0];
	    //soundSource.Play();
        PlayVideo(2);
        
    }
    void ProtectYosemiteResponse(){
        //PlayVideo();
    }
    void UniqueResponse(){
        //PlayVideo();
    }
    void PreservationForestResponse(){
        //PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
