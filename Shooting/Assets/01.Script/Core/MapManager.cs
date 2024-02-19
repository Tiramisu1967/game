using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapManager : BaseManager
{
    public float ScrollSpeed;
    public Transform[] Backgrounds;

    private float _imageHeight;
    private float _bottomPos;

    public override void Init(GameManager gameManger)
    {
        base.Init(gameManger);
        _imageHeight = Backgrounds[0].GetChild(0).GetComponent<SpriteRenderer>().size.y;
        _bottomPos = Backgrounds[0].GetChild(0).position.y - _imageHeight;
    }

    private void Update()
    {

        ScrollBackground();
    }

    public void ScrollBackground()
    {
        for(int i = 0; i < Backgrounds.Length; i++)
        {
            if (null == Backgrounds[i])
                continue;
            Backgrounds[i].transform.position += new Vector3(0, -ScrollSpeed, 0) * Time.deltaTime;
            if (Backgrounds[i].position.y < _bottomPos)
            {
;
                int index = i;
                if(index < 0)
                {
                    index = Backgrounds.Length - 1;
                }
                Backgrounds[i].transform.position += new Vector3(0, 32f, 0);
            }
        }
    }
}
