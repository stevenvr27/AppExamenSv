using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamenSv.Models
{
    public class AnswerDTO
    {

        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int AskId { get; set; }
         
     
        public string pregunta  { get; set; }  
    }
}
