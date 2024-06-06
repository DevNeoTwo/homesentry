using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GameManager : NetworkBehaviour {

    public static GameManager instance;

    [SerializeField] private List<Transform> spawnPoint = new List<Transform>();

    [SerializeField] private NetworkPrefabRef[] customer = new NetworkPrefabRef[0];

    [Networked(OnChanged = nameof(ChangeTime))] public NetworkString<_8> textTime { get; set; }

    public Transform cajaPoint;
    public Transform portalPoint;

    [SerializeField] private int gameTime;

    public IEnumerator SetTimer() {
        while (gameTime > 0) {
            yield return new WaitForSeconds(1);
            gameTime--;
            System.TimeSpan t = System.TimeSpan.FromSeconds(gameTime);
            RPC_SetTime(t.ToString("mm\\:ss")); ;
        }
    }



    private void Awake() {
        instance = this;
    }

    private void Start() {
        for (int i = 0; i < this.transform.childCount; i++) {
            spawnPoint.Add(this.transform.GetChild(i).transform);
        }
    }

    public void CreateCustomers(int amount) {
        for (int i = 0; i < amount; i++)
            Runner.Spawn(customer[Random.Range(0, 2)], spawnPoint[Random.Range(10, spawnPoint.Count)].transform.position, Quaternion.identity);
    }

    public override void FixedUpdateNetwork() {
        if (!Spawner.instance.owner) return;
    }

    public Vector3 GetDestination() {
        return spawnPoint[Random.Range(0, spawnPoint.Count)].position;
    }


    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_SetTime(string t, RpcInfo rpcInfo = default) {
        this.textTime = t;
        Debug.Log(t);
    }

    static void ChangeTime(Changed<GameManager> changed) {
        changed.Behaviour.ChangeTime();
    }

    private void ChangeTime() {
        UIManager.instance.SetTime(textTime.ToString());
        Debug.Log(textTime);
    }

}