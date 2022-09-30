using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer player;
    public List<string> urls = new List<string>();

    public void UpdateVideoStatus(bool playing) {
        player.url = urls[MapManager.Singleton.mapId]; 
        if(playing) {
            player.Play();
        }else{
            player.Stop();
        }
        
    }
}
