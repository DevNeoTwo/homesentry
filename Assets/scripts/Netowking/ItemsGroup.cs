using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemsGroup : MonoBehaviour {

    [SerializeField] private int itemID;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (other.GetComponent<NetworkObject>().HasStateAuthority == Spawner.instance.localPlayer) {
                if (other.GetComponent<PlayerMovement>().bussy.ToString() == "T")
                    other.GetComponent<PlayerMovement>().TakeItem(itemID);
            }
        }
    }
}
