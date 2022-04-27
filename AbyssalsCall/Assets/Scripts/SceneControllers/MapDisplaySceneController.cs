using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplaySceneController : SceneController
{
    public MapDisplayObject MapDisplayObjectPrefab;

    MapDisplayObject mapDisplay;

    public override void SetupScene()
    {
        mapDisplay = Instantiate(MapDisplayObjectPrefab, Vector3.zero, Quaternion.identity);
        mapDisplay.UpdateMap();
    }
}
