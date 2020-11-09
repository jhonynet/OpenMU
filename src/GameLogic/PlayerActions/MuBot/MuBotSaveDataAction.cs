﻿// <copyright file="MuBotSaveDataAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.MuBot
{
    using System;
    using Microsoft.Extensions.Logging;
    using MUnique.OpenMU.GameLogic.MuBot;

    /// <summary>
    /// Action to update mu bot status.
    /// </summary>
    public class MuBotSaveDataAction
    {
        /// <summary>
        /// Toggle mu bot status.
        /// </summary>
        /// <param name="player">the player.</param>
        /// <param name="data">mu bot data to be saved.</param>
        public void SaveData(Player player, Span<byte> data)
        {
            try
            {
                player.SelectedCharacter.MuBotData = data.ToArray();
                player.PersistenceContext.SaveChanges();
                player.SendCurrentMuBotData();
            }
            catch (Exception e)
            {
                player.Logger.LogWarning($"Cannot save MuBotData => {e}");
            }
        }
    }
}
