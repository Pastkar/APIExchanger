using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Entities;
using AutoMapper;
using ExchangerLastVersion.Models;

namespace ExchangerLastVersion.Controllers
{
    public class ClientsController : Controller
    {
        public static int currentEditionID;

        public IActionResult AddPage()
        {
            return View();
        }
        public IActionResult AddClients(string name, string surname,  string birthDay, string adress, int phone,int passport)
        {
            ClientModel client = new ClientModel()
            {
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Adress = adress,
                Phone = phone,
                Passport = passport
            };

            using (var db = new BL())
                db.AddClient(Mapper.Map<ClientBl>(client));

            return Redirect("~/Home/Index");
        }

        public IActionResult SearchPage()
        {
            return View();
        }
        public IActionResult SearchResult(string name, string surname)
        {
            List<ClientModel> foundClient = new List<ClientModel>();

            using (var db = new BL())
            {
                foreach (ClientModel client in Mapper.Map<List<ClientModel>>(db.GetClient()))
                {
                    if (client.Name == name && client.Surname == surname)
                        foundClient.Add(client);
                }
            }

            return View("ShowAllPage", foundClient);
        }

        public IActionResult ShowAllPage()
        {
            List<ClientModel> list = null;

            using (var db = new BL())
                list = Mapper.Map<List<ClientModel>>(db.GetClient());

            return View(list);
        }
        public IActionResult Delete(int id)
        {
            using (var db = new BL())
                db.RemoveClient(id);

            return Redirect("~/Home/Index");
        }
        public IActionResult DeleteAllClients()
        {
            using (var db = new BL())
            {
                foreach (ClientModel client in Mapper.Map<List<ClientModel>>(db.GetClient()))
                    db.RemoveClient(client.Id);
            }

            return Redirect("~/Home/Index");
        }

        public IActionResult EditPage(int id)
        {
            ClientModel client = null;

            using (var db = new BL())
            {
                var clients = Mapper.Map<List<ClientModel>>(db.GetClient());
                foreach (ClientModel model in clients)
                {
                    if (model.Id == id)
                    {
                        client = model;
                        break;
                    }
                }
            }

            if (client != null)
            {
                currentEditionID = client.Id;
                ViewData["ClientName"] = client.Name;
                ViewData["ClientSurname"] = client.Surname;
                ViewData["ClientBirthDay"] = client.BirthDay;
                ViewData["ClientAdress"] = client.Adress;
                ViewData["ClientPhone"] = client.Phone;
                ViewData["ClientPassport"] = client.Passport;
            }

            return View();
        }
        public IActionResult SaveChanges(int id, string name, string surname, string birthDay, string adress, int phone, int passport)
        {
            ClientModel Client = new ClientModel()
            {
                Id = currentEditionID,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Adress = adress,
                Passport = passport,
                Phone = phone
        };

            using (var db = new BL())
                db.UpdateClient(Mapper.Map<ClientBl>(Client));

            return Redirect("~/Home/Index");
        }
    }
}
