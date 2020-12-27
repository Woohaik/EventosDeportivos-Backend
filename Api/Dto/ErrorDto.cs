using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class ErrorDto
    {
        public readonly string mainMessage;
        public readonly string[] innerErrors;


        public ErrorDto(Exception ex)
        {

        }
    }
}