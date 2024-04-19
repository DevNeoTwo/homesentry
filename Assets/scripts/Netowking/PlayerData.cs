using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Fusion;

public class PlayerData : MonoBehaviour {

    public static PlayerData instance;

    [SerializeField] private NetworkRunner runner;

    public int styleHairId;
    public int colorHairId;
    public int shirtId;
    public int pantalon;
    public int skinId;
    public bool genre;

    private void Awake() {
        instance = this;
    }

    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        
    }

    public void Play() {
        styleHairId = peloeditor.instance.estilocabello;
        colorHairId = peloeditor.instance.colorcabello;
        shirtId = camisaspantalones.instance.top;
        pantalon = camisaspantalones.instance.bottom;
        skinId = charactereditor.instance.color;
        genre = charactereditor.instance.mujer;
        StartGame("test");
    }

    public virtual Task StartGame(string room) {
        runner.ProvideInput = false;
        return runner.StartGame(
            new StartGameArgs {
                GameMode = GameMode.Shared,
                Scene = SceneRef.FromIndex(4),
                SessionName = room,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            }
        ); ;
    }
}
