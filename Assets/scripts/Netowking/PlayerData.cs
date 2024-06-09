using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Fusion;

public class PlayerData : MonoBehaviour {

    public static PlayerData instance;

    [SerializeField] private NetworkRunner runner;

    public string playerName;
    public int styleHairId;
    public int colorHairId;
    public int shirtId;
    public int pantId;
    public int skinId;
    public bool genre;

    public Sprite playerImage;
    [SerializeField] private Camera cam;

    public bool gameMode;

    private void Awake() {
        instance = this;
    }

    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() { }

    public void Play() {
        StartCoroutine(GetData());
    }

    IEnumerator GetData() {
        playerName = charactereditor.instance.nombrejugador;
        styleHairId = peloeditor.instance.estilocabello;
        colorHairId = peloeditor.instance.colorcabello;
        shirtId = camisaspantalones.instance.top;
        pantId = camisaspantalones.instance.bottom;
        skinId = charactereditor.instance.color;
        genre = charactereditor.instance.mujer;


        yield return new WaitForEndOfFrame();

        cam.transform.position += new Vector3(0, 1f, 2.5f);

        RenderTexture render = new RenderTexture(128, 128, 16);
        cam.targetTexture = render;
        Texture2D texture = new Texture2D(128, 128, TextureFormat.RGBA32, false);
        Rect rect = new Rect(0,0,128,128);

        cam.Render();
        RenderTexture currentRender = RenderTexture.active;
        RenderTexture.active = render;

        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        cam.targetTexture = null;
        RenderTexture.active = currentRender;
        Destroy(render);

        playerImage = Sprite.Create(texture, rect, Vector2.zero);

        StartGame();
    }

    public virtual Task StartGame() {
        GameMode mode = PlayerPrefs.GetString("gamemode") == "vs" ? GameMode.Shared : GameMode.Single;
        runner.ProvideInput = false;
        return runner.StartGame(
            new StartGameArgs {
                GameMode = mode,
                Scene = 4,
                SessionName = "",
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            }
        ); ;
    }
}
