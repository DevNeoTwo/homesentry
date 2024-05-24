using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CustomerController : NetworkBehaviour {

    [Networked(OnChanged = nameof(ChangeColor))] public NetworkString<_32> charColor { get; set; }


    [SerializeField] private GameObject[] hairStyles = new GameObject[0];
    [SerializeField] private Color[] hairColors = new Color[0];
    [SerializeField] private Renderer bodyRender;
    [SerializeField] private Color[] bodyColors = new Color[0];
    [SerializeField] private Color[] shirtsColors = new Color[0];
    [SerializeField] private Color[] pantsColors = new Color[0];


    void Start() {
        if (!Spawner.instance.owner) return;
        string aux = "";
        aux += Random.Range(0,6) + ",";//skin color
        aux += Random.Range(0, 6) + ",";//hair style
        aux += Random.Range(0, 9) + ",";//hair color
        aux += Random.Range(0, 9) + ",";//shirt color
        aux += Random.Range(0, 9);//pants color
        RPC_SetColor(aux);
    }

    public override void FixedUpdateNetwork() {

    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_SetColor(string color, RpcInfo rpcInfo = default) {
        this.charColor = color;
    }

    static void ChangeColor(Changed<CustomerController> changed) {
        changed.Behaviour.ChangeColor();
    }

    private void ChangeColor() {
        int skinColor = 0;
        int hairStyle = 0;
        int hairColor = 0;
        int shirt = 0;
        int pant = 0;
        try {
            skinColor = int.Parse(charColor.ToString().Split(",")[0]);
            hairStyle = int.Parse(charColor.ToString().Split(",")[1]);
            hairColor = int.Parse(charColor.ToString().Split(",")[2]);
            shirt = int.Parse(charColor.ToString().Split(",")[3]);
            pant = int.Parse(charColor.ToString().Split(",")[4]);
        } catch { }
        bodyRender.materials[0].color = bodyColors[skinColor];
        hairStyles[hairStyle].SetActive(true);
        hairStyles[hairStyle].GetComponent<Renderer>().material.color = hairColors[hairColor];
        bodyRender.materials[1].color = shirtsColors[shirt];
        bodyRender.materials[2].color = pantsColors[pant];
    }
}
