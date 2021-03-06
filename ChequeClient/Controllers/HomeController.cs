﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChequeConsumer;
using ChequeClient.Models;
using ChequeConsumer.Dtos;
using ChequeConsumer.Interface;
using ChequeCommon;

namespace ChequeClient.Controllers
{
    public class HomeController : ChequeBaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {                        
            return View();
        }

        //
        // GET: /Home/

        public ActionResult RESTBilling() 
        {
            try
            {
                var chequeModel = ConvertoChequeModel(Constants.Rest);
                return View(Constants.BillingView, chequeModel);
                
            }
            catch (Exception)
            {
                LogProvider.Log(this.GetType(), LogLevel.Error, "Error has orrued when loading Billing by WCF REST");
                throw;
            }
        }


        public ActionResult SOAPBilling() 
        {
            try
            {
                var chequeModel = ConvertoChequeModel(Constants.Soap);
                return View(Constants.BillingView, chequeModel);
            }
            catch (Exception)
            {
                LogProvider.Log(this.GetType(), LogLevel.Error, "Error has orrued when loading Billing by WCF SOAP");
                throw;
            }
           
        }

        public ActionResult SaveBillingInformation(List<BillingDetails> listBillingDetails, DateTime chequeDate, string chequeNo, string restOrSaop)
        {
            try
            {
                List<BillingInformationDto> listBillingInfo = new List<BillingInformationDto>();
                foreach (BillingDetails item in listBillingDetails)
                {
                    BillingInformationDto billingInfo = new BillingInformationDto()
                    {
                        Id = item.Id,
                        MenuID = item.MenuID,
                        Price = item.Price,
                        Category = item.Category
                    };

                    listBillingInfo.Add(billingInfo);
                }
                if (restOrSaop == Constants.Rest)
                {
                    this.MenuItemConsumer.InsertChequeInfoByRestByEF(listBillingInfo, chequeDate, chequeNo); ;
                }
                else
                {
                    this.SaopServiceMenuItemConsumer.SaveMenuItemBySoap(listBillingInfo, chequeDate, chequeNo);
                }
                return Json(new { Result = Constants.JsonResultOK });
            }
            catch (Exception)
            {
                LogProvider.Log(this.GetType(), LogLevel.Error, "Error has orrued when save the bill!");
                return Json(new { Result = Constants.JsonResultError });
            }           
        }

        
        private ChequeDetails ConvertoChequeModel(string restOrSoap)
        {
            List<MenuItemDto> listMenuItem = new List<MenuItemDto>();
            ChequeDetails chequeModel = new ChequeDetails(); 
            try
            {
                if (restOrSoap == Constants.Rest)
                {
                    listMenuItem = this.MenuItemConsumer.LoadMenuItemByEF();
                }
                else
                {
                    listMenuItem = this.SaopServiceMenuItemConsumer.LoadMenuItemListUsingSoapService();
                }

                chequeModel.ListOfMenu = listMenuItem ?? new List<MenuItemDto>();
                chequeModel.InvoiceDate = DateTime.Now.ToString();
                chequeModel.Invoicenumber = Constants.InvoiceNo;
                chequeModel.RestOrSaop = Constants.Rest;
                chequeModel.SelectedMenuItem = new List<MenuItemDto>();
            }
            catch (Exception)
            {
                throw;
            }
            return chequeModel;
        }
    }
}
