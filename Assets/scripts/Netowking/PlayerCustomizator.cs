using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class PlayerCustomizator : NetworkBehaviour {

    [Networked] public NetworkString<_32> charName { get; set; }
    [Networked] public NetworkString<_32> charColor { get; set; }

    [SerializeField] private TMP_Text nameTx;

    [SerializeField] private GameObject[] hairStyles = new GameObject[0];
    [SerializeField] private Color[] hairColors = new Color[0];
    [SerializeField] private SkinnedMeshRenderer bodyRender;
    [SerializeField] private Color[] bodyColors = new Color[0];
    [SerializeField] private Texture2D[] shirts = new Texture2D[0];
    [SerializeField] private Texture2D[] pants = new Texture2D[0];


    private ChangeDetector _changeDetector;

    public override void Spawned() {
        _changeDetector = GetChangeDetector(ChangeDetector.Source.SimulationState);
    }

    void Start() {
        if (HasInputAuthority) {
            string color = PlayerData.instance.skinId + "," + PlayerData.instance.styleHairId + "," + PlayerData.instance.colorHairId + "," + PlayerData.instance.shirtId + "," + PlayerData.instance.pantId;
            RPC_SetColor(PlayerData.instance.playerName, color);
        }
    }

    void Update() {
        foreach (var change in _changeDetector.DetectChanges(this)) {
            switch (change) {
                case nameof(charColor):
                    ChangeColor();
                    break;
                case nameof(charName):
                    nameTx.text = charName.ToString();
                    break;
            }
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetColor(string playerName, string color, RpcInfo rpcInfo = default) {
        this.charColor = color;
        this.charName = playerName;
    }

    private void ChangeColor() {
        int skinColor = 0;
        int hairStyle = 0;
        int hairColor = 0;
        int shirt = 0;
        int pant = 0;
        try {
            skinColor = int.Parse(charColor.ToString().Split(",")[0]) - 1;
            hairStyle = int.Parse(charColor.ToString().Split(",")[1]) - 1;
            hairColor = int.Parse(charColor.ToString().Split(",")[2]) - 1;
            shirt = int.Parse(charColor.ToString().Split(",")[3]) - 1;
            pant = int.Parse(charColor.ToString().Split(",")[4]) - 1;
        } catch {}
        bodyRender.materials[0].color = bodyColors[skinColor];
        hairStyles[hairStyle].SetActive(true);
        hairStyles[hairStyle].GetComponent<MeshRenderer>().material.color = hairColors[hairColor];
        bodyRender.materials[1].mainTexture = shirts[shirt];
        bodyRender.materials[2].mainTexture = pants[pant];
    }
}
