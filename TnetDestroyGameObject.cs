﻿// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;



namespace HutongGames.PlayMaker.Actions
{
    
	[ActionCategory("Tnet Networking")]
	public class TnetDestroyGameObject : FsmStateAction
	{
        [RequiredField]
		[Tooltip("GameObject to destroy")]
		public FsmGameObject GameObject;

		public override void OnEnter()
		{
			TNet.TNManager.Destroy (GameObject.Value);

		}

	}
}