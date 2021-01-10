using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class ErrorDto
    {
        public readonly string mainMessage;
        public readonly List<string> exList;


        public ErrorDto(Exception ex)
        {
            Type AgregattEx = typeof(AggregateException);
            exList = new List<string>();
            if (AgregattEx == ex.GetType())
            {
                AggregateException theEx = (AggregateException)ex;

                foreach (Exception singleEx in theEx.InnerExceptions)
                {
                    exList.Add(singleEx.Message);
                }
            }

            mainMessage = ex.Message;



        }
    }
}