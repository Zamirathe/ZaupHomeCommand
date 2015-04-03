﻿using Rocket.RocketAPI;
using SDG;
using Steamworks;
using UnityEngine;
using System;

namespace Zamirathe_HomeCommand
{
    public class CommandHome : IRocketCommand
    {
        public bool RunFromConsole
        {
            get
            {
                return false;
            }
        }
        public string Name
        {
            get
            {
                return "home";
            }
        }
        public string Help
        {
            get
            {
                return "Teleports you to your bed if you have one.";
            }
        }
        public void Execute(CSteamID playerid, string bed)
        {
            Player player = PlayerTool.getPlayer(playerid);
            HomePlayer homeplayer = player.transform.GetComponent<HomePlayer>();
            object[] cont = HomeCommand.CheckConfig(player, playerid, homeplayer);
            if (!(bool)cont[0]) return;
            // A bed was found, so let's run a few checks.
            homeplayer.GoHome((Vector3)cont[1], (byte)cont[2], player);
        }
    }
}
