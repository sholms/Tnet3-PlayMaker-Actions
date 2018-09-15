// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetSetPlayerName : FsmStateAction
	{
		public FsmString PlayerName;
		public override void OnEnter()
		{
			
			 TNManager.playerName = PlayerName.Value;

		}

	}
}