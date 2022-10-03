using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager Singleton;

    public List<Material> skyboxes = new List<Material>();
    public int mapId = 0;
    int prevID = 0;
    public Animation Map;
    public bool risen = false;
    public Animation FadeAnimator;
    public float mapChangeTimer = 0;
    public List<Button> buttons = new List<Button>();
    public LocationSpecificObjects[] objects;

    [System.Serializable]
    public struct LocationSpecificObjects {
        public int id;
        public GameObject[] objects;
    }

    void Start() {
        Singleton = this;
        TVMove.Singleton.UpdateLocation(mapId);
    }


    public void RiseMap() {
        print("what");
        toggleRisen();
    }

    public void toggleRisen() {
        risen = !risen;
        panoCamController.Singleton.disabled = risen;
        Map.Play(risen ? "pleasework" : "goback");
        foreach(var button in buttons) {
            button.interactable = risen;
        }
    }


    public void gotoLocation(int id) {
        prevID = mapId;
        mapId = id;
        loadMap(true);
    }
    public void gotoLocationNoClose(int id) {
        prevID = mapId;
        mapId = id;
        loadMap(false);
    }

    public void loadMap(bool shouldclose) {
        FadeAnimator.Play("FadeOut");
        mapChangeTimer = 0;
        if(shouldclose){
            risen = false;
            panoCamController.Singleton.disabled = risen;
            Map.Play(risen ? "pleasework" : "goback");
            foreach(var button in buttons) {
                button.interactable = risen;
            }
        }
    }
    

    void Update() {
        if(mapChangeTimer >= 0) {
            mapChangeTimer += Time.deltaTime;
            if(Mathf.Floor(mapChangeTimer) == 1) {
                RenderSettings.skybox = skyboxes[mapId];
                mapChangeTimer = -1;
                foreach(var lso in objects) {
                    if(lso.id == mapId) {
                        foreach(var go in lso.objects) {
                            go.SetActive(true);
                        }
                    }else if(lso.id == prevID){
                        foreach(var go in lso.objects) {
                            go.SetActive(false);
                        }
                    }
                }
                TVMove.Singleton.UpdateLocation(mapId);
                VideoManager.Singleton.UpdateVideoStatus(false);
            }
        }
        
    }
}
