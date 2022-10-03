using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Singleton;
    public VideoPlayer player;
    public List<string> urls = new List<string>();
    public RenderTexture texture;

    public void UpdateVideoStatus(bool playing) {
        if(playing) {
            player.url = urls[MapManager.Singleton.mapId]; 
            player.Play();
        }else{
            player.Stop();
            texture.Release();
        }
        
    }

    void Start() {
        Singleton = this;
    }
}
