// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using TNet;
using System.IO;
using UnityTools = TNet.UnityTools;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Tnet Networking")]
	public class TnetPlayMakerSpawn : ComponentAction<PlayMakerTNSpawnProxy>
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayMakerTNSpawnProxy))]
        public FsmOwnerDefault gameObject;
		//public FsmEvent Spawn;

		[System.NonSerialized]
		 PlayMakerTNSpawnProxy tno;

		 [RequiredField]
		[Tooltip("prefab path")]
		public FsmString prefabPath;

		 [RequiredField]
		[Tooltip("Channel number")]
		public FsmInt channel;

		 [RequiredField]
		[Tooltip("is persistent?")]
		public FsmBool persistent;

        [RequiredField]
		[Tooltip("set position")]
		public FsmVector3 position;

        [RequiredField]
		[Tooltip("set rotation")]
		public FsmQuaternion rotation;
		

		public override void Reset()
		{
			prefabPath = "";
            channel = 0;
            persistent = false;
            
			
		}

		public override void OnEnter()
		{
            if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				tno = (PlayMakerTNSpawnProxy)this.cachedComponent;
				Execute ();
			}

			Finish();
			

			

		}
        void Execute()
		{
			tno.position = position.Value;
            tno.rotation = rotation.Value;
            tno.persistent = persistent.Value;
            tno.channelID = channel.Value;
            tno.prefabPath = prefabPath.Value;
			
            tno.SpawnGameObject(1);
		}

	}
}