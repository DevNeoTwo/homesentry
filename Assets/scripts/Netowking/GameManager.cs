using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GameManager : NetworkBehaviour {

    public static GameManager instance;

    [SerializeField] private Transform[] spawnPoint = new Transform[0];

    [SerializeField] private NetworkPrefabRef[] customer = new NetworkPrefabRef[0];

    private void Awake() {
        instance = this;
    }

    public void CreateCustomers() {
        for (int i = 0; i < 10; i++)
            Runner.Spawn(customer[Random.Range(0, 2)], spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
    }

    public override void FixedUpdateNetwork() {
        if (!Spawner.instance.owner) return;
    }
}
