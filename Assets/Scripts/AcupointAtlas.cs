using System;
using System.Collections.Generic;

[Serializable]
public class AcupointAtlas
{
    // public List<Acupoint> acupoints;
    public List<Acupoint> acupoints;
    public string atlasName;

    public AcupointAtlas(string _atlasName) {

        atlasName = _atlasName;
        acupoints = new List<Acupoint>();
    }

    public void addToAtlas(Acupoint _acupoint) {
        
        acupoints.Add(_acupoint);
    }

    public void render() {

        foreach(var acupoint in acupoints) {

            acupoint.render();
        }
    }

    public override string ToString() {
        return atlasName;
    }
}
