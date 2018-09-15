// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetGetChannelList : FsmStateAction
	{

		[RequiredField]
        [Tooltip("Channel list and Num of player. The fist value is the channel id and the second is the player number(you need to split)")]
        [UIHint(UIHint.Variable)]
        public FsmArray storeValue;

        public FsmString valuestring;
		public override void Reset(){
			storeValue = null;
            valuestring = null;
            storeValue.Reset();
           
		}
		public override void OnEnter()
		{
			TNManager.GetChannelList(_CallOnChannelList);
            storeValue.Reset();

		}

		void _CallOnChannelList (TNet.List<Channel.Info> chList)
        {
                for (int x = 0; x < chList.size; x++)
                {
                      int Players = chList[x].players;
                      int ChannelID = chList[x].id;

                        string value = (ChannelID.ToString() + "," + Players.ToString());
                        valuestring = value;

                       storeValue.Resize(storeValue.Length + 1);
                       storeValue.Set(storeValue.Length - 1, valuestring.Value);

                       Finish();
                }
        }

	}
}