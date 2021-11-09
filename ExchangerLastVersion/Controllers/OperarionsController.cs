using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Entities;
using ExchangerLastVersion.Models;
using AutoMapper;

namespace ExchangerLastVersion.Controllers
{
    public class OperarionsController : Controller
    {
        public static int currentEditionID;

        public IActionResult AddPage()
        {
            using (var db = new BL())
            {
                OperarionViewModel model = new OperarionViewModel()
                {
                    Clients = Mapper.Map<List<ClientModel>>(db.GetClient()),
                    Operators = Mapper.Map<List<OperatorModel>>(db.GetOperator())
                };

                return View(model);
            }
        }
        //public IActionResult AddGame(string date, int spectators, int place, int[] players, string result)
        //{
        //    List<ClientModel> chosenPlayers = new List<ClientModel>();
        //    OperatorModel chosenPlace = null;
        //    Models.Result chosenResult = 0;

        //    using (var db = new BL())
        //    {
        //        List<ClientModel> listPlayers = Mapper.Map<List<ClientModel>>(db.GetClient());

        //        // Forming the list of players from DataBase
        //        for (int i = 0; i < players.Length; i++)
        //        {
        //            foreach (ClientModel playerModel in listPlayers)
        //            {
        //                if (playerModel.Id == players[i])
        //                {
        //                    chosenPlayers.Add(playerModel);
        //                    break;
        //                }
        //            }
        //        }

        //        // Getting the stadium by id from DataBase
        //        foreach (OperatorModel model in Mapper.Map<List<OperatorModel>>(db.GetOperator()))
        //        {
        //            if (model.Id == place)
        //            {
        //                chosenPlace = model;
        //                break;
        //            }
        //        }

        //        // Determining the result of the game by input string
        //        switch (result)
        //        {
        //            case "Won":
        //                chosenResult = Models.Result.Won;
        //                break;

        //            case "Failed":
        //                chosenResult = Models.Result.Failed;
        //                break;

        //            case "Noone":
        //                chosenResult = Models.Result.Noone;
        //                break;

        //            case "NotPlayed":
        //                chosenResult = Models.Result.NotPlayed;
        //                break;
        //        }

        //        // Changing state of involved players
        //        foreach (ClientModel player in chosenPlayers)
        //        {
        //            player.IsInGame = true;
        //            db.UpdatePlayer(Mapper.Map<PlayerBL>(player));
        //        };

        //        // Forming game to DataBase
        //        OperationModel game = new OperationModel()
        //        {
        //            Players = chosenPlayers,
        //            Spectators = spectators,
        //            Date = date,
        //            Place = chosenPlace,
        //            GameResult = chosenResult,
        //        };

        //        db.AddGame(Mapper.Map<GameBL>(game));
        //    }

        //    return Redirect("~/Home/Index");
        //}

        public IActionResult ShowAllPage()
        {
            List<OperationModel> list = null;

            using (var db = new BL())
                list = Mapper.Map<List<OperationModel>>(db.GetOperation());

            return View(list);
        }
    }
}
