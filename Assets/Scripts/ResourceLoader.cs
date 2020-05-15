using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.Core
{
    public class ResourceLoader : Singleton<ResourceLoader>
    {

        // [HideInInspector] public GameObject exampleFab;

        protected override void Awake()
        {
            base.Awake();
            LoadResources();
        }

        private void LoadResources()
        {
            // example = Resources.Load<GameObject>("Prefabs/example");
        }
    }
}