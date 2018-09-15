// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetLoadChannelDataInt : FsmStateAction
	{

		[RequiredField]
		[Tooltip("IP address of the host. Either a dotted IP address or a domain name.")]
		public FsmInt Channel;

		[RequiredField]
		[Tooltip("The port on the remote machine to connect to.")]
		public FsmString DataName;

		[RequiredField]
		[Tooltip("The port on the remote machine to connect to.")]
		public FsmInt Data;

		public override void Reset()
		{
			
			Channel = 0;
			DataName = "";
			Data = 0;
		}

		public override void OnEnter()
		{
			 Data.Value = TNManager.GetChannelData<int>(Channel.Value, DataName.Value);
            Finish();
		}

	}
}