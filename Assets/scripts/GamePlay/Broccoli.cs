using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Broccoli : Food
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        score = -3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
