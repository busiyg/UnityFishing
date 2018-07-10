using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BezierPathModel  {
    public List<Transform> ControlTrans;
    public int segmentNum;
    public List<Vector3> PathTrans;
    public int PathID;

}
