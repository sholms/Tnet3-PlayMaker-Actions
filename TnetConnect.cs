// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetConnect : FsmStateAction
	{

		[RequiredField]
		[Tooltip("IP address of the host. Either a dotted IP address or a domain name.")]
		public FsmString remoteIP;

		[RequiredField]
		[Tooltip("The port on the remote machine to connect to.")]
		public FsmInt remotePort;

		public override void Reset()
		{
			
			remoteIP = "127.0.0.1";
			remotePort = 5127;
		}

		public override void OnEnter()
		{
			TNet.TNManager.Connect(remoteIP.Value,remotePort.Value);

		}

	}
}