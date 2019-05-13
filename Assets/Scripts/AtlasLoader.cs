using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtlasLoader : MonoBehaviour
{
    // [SerializeField]
    // private string atlasPath;
    // private AcupointAtlas atlas;

    private string atlasPath;

    public AtlasLoader(string _atlasPath) {
        atlasPath = _atlasPath;
    }

    [ContextMenu("Load Atlas")]
    public AcupointAtlas LoadAtlas() {
        AcupointAtlas atlas;

        using (StreamReader stream = new StreamReader(atlasPath)) {

            string json = stream.ReadToEnd();
            Debug.Log(json);
            atlas = JsonUtility.FromJson<AcupointAtlas>(json);
        }

        Debug.Log("Points Loaded: " + atlas.acupoints.Count);
        return atlas;
    }

    [ContextMenu("Save Atlas")]
    public void SaveAtlas(AcupointAtlas _atlas, string _atlasPath) {

        using (StreamWriter stream = new StreamWriter(_atlasPath)) {

            string json = JsonUtility.ToJson(_atlas);
            stream.Write(json);
        }
    }

    [ContextMenu("Write Acupoint")]
    private void WriteAcupoint(AcupointAtlas atlas, string _atlasPath) {

        using (StreamWriter stream = new StreamWriter(_atlasPath)) {

            string json = JsonUtility.ToJson(atlas);
            stream.Write(json);
        }
    }
}
