﻿// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetLoadPlayerDataVector3 : FsmStateAction
	{

		[RequiredField]
		[Tooltip("The port on the remote machine to connect to.")]
		public FsmString DataName;

		[RequiredField]
		[Tooltip("The port on the remote machine to connect to.")]
		public FsmVector3 Data;

		public override void Reset()
		{
			
			
			DataName = "";
			
		}

		public override void OnEnter()
		{
			 Data.Value = TNManager.GetPlayerData<Vector3>(DataName.Value);
            Finish();
		}

	}
}