﻿using System;
using System.Collections.Generic;

using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Commands;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace ZaupHomeCommand
{
    public class CommandHome : IRocketCommand
    {
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
        public string Syntax
        {
            get
            {
                return "";
            }
        }
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }
        public List<string> Permissions
        {
            get { return new List<string>() { }; }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public void Execute(IRocketPlayer caller, string[] bed)
        {
            UnturnedPlayer playerid = (UnturnedPlayer)caller;
            HomePlayer homeplayer = playerid.GetComponent<HomePlayer>();
            object[] cont = HomeCommand.CheckConfig(playerid);
            if (!(bool)cont[0]) return;
            // A bed was found, so let's run a few checks.
            homeplayer.GoHome((Vector3)cont[1], (byte)cont[2], playerid);
        }
    }
}
