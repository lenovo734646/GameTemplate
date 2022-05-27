﻿using AssemblyCommon;
using AssemblyCommon.Bridges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AShower : IShowDownloadProgress
{
	public StartThisGame thisP;
	float timeElapse_ = 0.0f;
	public override void Desc(string desc)
	{
		if(!isDestoryed) thisP.Progress(desc);
	}

	public override void Progress(long downed, long totalLength)
	{
		if (isDestoryed) return;
		if (Time.time - timeElapse_ > 1.0f && totalLength > 0)
			thisP.Progress(string.Format(LanguageStartup.DownloadProgress, (int)(downed * 100.0f / totalLength)));
	}

	public override void SetState(DownloadState st)
	{
		if (isDestoryed) return;
		if (st == DownloadState.Downloading) {
			timeElapse_ = Time.time;
		}
	}
}

public class StartThisGame : MonoBehaviour
{
	AShower show_ = new AShower();
	public BridgeToHotfix bridge_;
	bool exit_ = false;
	Text txtPro = null;
	// Start is called before the first frame update
	void Start()
	{
		show_.thisP = this;
		bridge_ = GetComponent<BridgeToHotfix>();

		var canvas = GameObject.Find("Canvas");
		var btn = canvas.FindChildDeeply("Button").GetComponent<Button>();
		txtPro = canvas.FindChildDeeply("txtProgress").GetComponent<Text>();

		show_.SetUIRoot(canvas.FindChildDeeply("txtProgress"));
		btn.onClick.AddListener(() => {
			btn.gameObject.SetActive(false);
			this.StartCor(bridge_.DoStart(show_, false), false);
		});
		show_.Desc(LanguageStartup.IsPreparingHotfixModule);
	}

	public void Progress(string prog)
	{
		txtPro.text = prog;
	}

	// Update is called once per frame
	void Update()
	{
		//如果
		if (bridge_.Prepared() && !exit_) {
			Progress(LanguageStartup.IsLoadingHotfixModule);
			HotfixCaller.SetHotfixValue("defaultGameFromHost", "BCBM");
			HotfixCaller.RunGame("Hotfix.Common.AppController", "Assets/Res/Games/BCBM/HotFixDll.json", "Assets/Res/Games/BCBM/HotFixDll_pdb.json", show_);
			//解开循环引用
			show_ = null;
			//删除本组件,用不着了
			GameObject.Destroy(this);
			exit_ = true;
		}
	}
}
