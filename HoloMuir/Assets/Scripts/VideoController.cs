using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{   
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.Prepare();
    }

    public void PlayVideo(){
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
