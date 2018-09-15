// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actionss
{
	[ActionCategory("Tnet Networking")]
	public class TnetChannelJoinOrCreate : FsmStateAction
	{

		[RequiredField]
		[Tooltip("Level that will be loaded first.")]
		public FsmString levelname;

		[RequiredField]
		[Tooltip("ID of the channel. Every player joining this channel will see one another.")]
		public FsmInt channelid;

        [RequiredField]
		[Tooltip("Whether the channel will remain active even when the last player leaves.")]
		public FsmBool persistent;

		[RequiredField]
		[Tooltip("Maximum number of players that can be in this channel at once.")]
		public FsmInt playerLimit;

		[RequiredField]
		[Tooltip("Leave Curret Channel")]
		public FsmBool leavecurrentchannel;

		public override void Reset()
		{
			channelid = 0;
            levelname = "level 1";
            persistent = false;
            playerLimit = 5;
            leavecurrentchannel = true;
		}

		public override void OnEnter()
		{
			TNet.TNManager.JoinChannel(channelid.Value,levelname.Value,persistent.Value,playerLimit.Value,null,leavecurrentchannel.Value);
			Finish();
		}

	}
}