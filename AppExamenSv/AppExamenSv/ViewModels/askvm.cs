using AppExamenSv.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AppExamenSv.ViewModels;
using System.Net;
using Newtonsoft.Json;

namespace AppExamenSv.ViewModels
{
    
    public class askvm:BaseViewModel
    {
        RestRequest request;
        public Ask MyAsk { get; set; }
   
        

        public askvm()
        {
            MyAsk = new Ask();
            
        }
       

        public async Task<bool> Addask(   string pAsk1 )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
               
               MyAsk.Date  = Convert.ToDateTime( DateTime.Now.ToShortDateString());
                MyAsk.Ask1 = pAsk1;
                MyAsk.UserId = GlobalObjects.localuser.UsuarioID;
                MyAsk.AskStatusId = 1;
                MyAsk.IsStrike = false;
                MyAsk.AskDetail = null;
                MyAsk.AskId = 0;
                MyAsk.ImageUrl = null;
                
                

                bool R = await MyAsk.Addasknew();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }



        }

        public async Task<List<Ask>> Getask()
        {
            try
            {
                List<Ask> roles = new List<Ask>();

                roles = await MyAsk.GetAllask();

                if (roles == null)
                {
                    return null;
                }
                else
                {
                    return roles;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }




    }



}

 
 
 
 
 
 
 
 







