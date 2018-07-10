using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathManager : MonoBehaviour {
    private static PathManager Instance;
    // Use this for initialization
    public static PathManager GetInstance() {
        return Instance;
    }

    public List<BezierPathModel> BezierPath = new List<BezierPathModel>();

    private void Awake() {
        Instance = this;
        InitPath();
    }

    void Start () {
		
	}

    public void InitPath() {
        foreach (var obj in BezierPath) {
            if (obj.ControlTrans!=null) {
                obj.PathTrans = calculate(obj.ControlTrans, obj.segmentNum);
            }      
        }
    }

    public List<Vector3> calculate(List<Transform> poss, int precision) {

        //维度，坐标轴数（二维坐标，三维坐标...）
        int dimersion = 2;

        //贝塞尔曲线控制点数（阶数）
        int number = poss.Count;

        //控制点数不小于 2 ，至少为二维坐标系
        if (number < 2 || dimersion < 2)
            return null;

        List<Vector3> result = new List<Vector3>();

        //计算杨辉三角
        int[] mi = new int[number];
        mi[0] = mi[1] = 1;
        for (int i = 3; i <= number; i++) {

            int[] t = new int[i - 1];
            for (int j = 0; j < t.Length; j++) {
                t[j] = mi[j];
            }

            mi[0] = mi[i - 1] = 1;
            for (int j = 0; j < i - 2; j++) {
                mi[j + 1] = t[j] + t[j + 1];
            }
        }

        //计算坐标点
        for (int i = 0; i < precision; i++) {
            float t = (float)i / precision;
            Vector3 temp_ = new Vector3(0, 0, 0);
            for (int k = 0; k < number; k++) {
                temp_.x += Mathf.Pow(1 - t, number - k - 1) * poss[k].position.x * Mathf.Pow(t, k) * mi[k];
                temp_.y += Mathf.Pow(1 - t, number - k - 1) * poss[k].position.y * Mathf.Pow(t, k) * mi[k];
            }

            result.Add(temp_);
        }
        return result;
    }

    public List<Vector3> ReturnPath(int id) {
        foreach (var obj in BezierPath) {
            if (id== obj.PathID) {
                if (obj.PathTrans!=null) {
                    return obj.PathTrans;
                    break;
                }
            }

        }
        return null;
    }
}
