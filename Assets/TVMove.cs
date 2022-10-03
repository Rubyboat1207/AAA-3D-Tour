using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVMove : MonoBehaviour
{
    public static TVMove Singleton;

    [System.Serializable]
    public struct locrot {
        public Vector3 location;
        public Vector3 rotation;
    }

    [SerializeField] List<locrot> positions;
    
    public void UpdateLocation(int pos) {
        transform.position = positions[pos].location;
        transform.rotation = Quaternion.Euler(positions[pos].rotation);
    }

    void Awake() {
        Singleton = this;
    }
}
