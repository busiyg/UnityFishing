﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CannonInfoModel {
    public CannonType type;
    public float speed;
    public int damage;
    public int prize;
    public int Size;
    public int id;
    public string CannonName;
    public Sprite CannonSprite;
    public Sprite BulletSprite;
}

public enum CannonType {
    bullet=0,
    laser=1

}