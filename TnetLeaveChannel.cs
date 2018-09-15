// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetLeaveChannel : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Leave Channel")]
		public FsmInt Channel;

		public override void OnEnter()
		{
			TNet.TNManager.LeaveChannel (Channel.Value);

		}

	}
}