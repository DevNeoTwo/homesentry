using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class PlayerCustomizator : NetworkBehaviour {

    [Networked] public NetworkString<_32> charName { get; set; }
    [Networked] public NetworkString<_32> charColor { get; set; }

    [SerializeField] private TMP_Text nameTx;

    private ChangeDetector _changeDetector;

    public override void Spawned() {
        _changeDetector = GetChangeDetector(ChangeDetector.Source.SimulationState);
    }

    void Start() {
        
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
    public void RPC_SetColor(string color, RpcInfo rpcInfo = default) {
        this.charColor = color;
    }

    private void ChangeColor() {
        
    }
}
