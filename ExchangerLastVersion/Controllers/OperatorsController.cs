using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Entities;
using CourseWork.Models;
using AutoMapper;

namespace CourseWork.Controllers
{
    public class OperatorsController : Controller
    {
        public static int currentEditionID;

        public IActionResult AddPage()
        {
            return View();
        }
        public IActionResult AddStadium(string name, string surname, string adress,int phone)
        {
            OperatorModel operators = new OperatorModel()
            {
                Name = name,
                Surname = surname,
                Adress = adress,
                Phone = phone
            };

            using (var db = new BL())
                db.AddOperator(Mapper.Map<OperatorBl>(operators));

            return Redirect("~/Home/Index");
        }

        public IActionResult SearchPage()
        {
            return View();
        }
        

        public IActionResult ShowAllPage()
        {
            List<OperatorModel> list = null;

            using (var db = new BL())
                list = Mapper.Map<List<OperatorModel>>(db.GetOperator());

            return View(list);
        }
        public IActionResult Delete(int id)
        {
            using (var db = new BL())
                db.RemoveOperator(id);

            return Redirect("~/Home/Index");
        }
        public IActionResult DeleteAllStadiums()
        {
            using (var db = new BL())
            {
                foreach (OperatorModel stadium in Mapper.Map<List<OperatorModel>>(db.GetOperator()))
                    db.RemoveOperator(stadium.Id);
            }

            return Redirect("~/Home/Index");
        }

        public IActionResult EditPage(int id)
        {
            OperatorModel @operator = null;

            using (var db = new BL())
            {
                var stadiums = Mapper.Map<List<OperatorModel>>(db.GetOperator());
                foreach (OperatorModel model in stadiums)
                {
                    if (model.Id == id)
                    {
                        @operator = model;
                        break;
                    }
                }
            }

            if (@operator != null)
            {
                currentEditionID = @operator.Id;
                ViewData["ClientName"] = @operator.Name;
                ViewData["ClientSurname"] = @operator.Surname;
                ViewData["ClientAdress"] = @operator.Adress;
                ViewData["ClientPhone"] = @operator.Phone;
            }

            return View();
        }
        public IActionResult SaveChanges(string name, string surname, string adress, int phone)
        {
            OperatorModel @operator = new OperatorModel()
            {
                Id = currentEditionID,
                Name = name,
                Surname = surname,
                Adress = adress,
                Phone = phone
            };

            using (var db = new BL())
                db.UpdateOperator(Mapper.Map<OperatorBl>(@operator));

            return Redirect("~/Home/Index");
        }
    }
}
