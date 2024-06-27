using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoplayer : MonoBehaviour
{
    [SerializeField] string vidio;
    [SerializeField] GameObject objdesactivar;
    cambiarnivel cambianivelscript;
    [SerializeField]string lvl;
    void Start()
    {
        cambianivelscript = GetComponent<cambiarnivel>();
        
    }

    void playvideo()
    {
        VideoPlayer videoplay=GetComponent<VideoPlayer>();
        if (videoplay)
        {
            string videopath=System.IO.Path.Combine(Application.streamingAssetsPath,vidio);
            Debug.Log(videopath);
            videoplay.url = videopath;
            videoplay.Play();
            videoplay.loopPointReached += videofinish;
        }
    }
    private void videofinish(VideoPlayer vp)
    {
        cambianivelscript.cambiaescena(lvl);
    }

    public void playvidio()
    {
        objdesactivar.gameObject.SetActive(false);

        playvideo();
    }
}
