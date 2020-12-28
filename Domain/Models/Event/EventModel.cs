using Domain.Models.IEventContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Event
{
    public class EventModel : IEvent
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre Requerido")]
        public string name { get; set; }

        [Required(ErrorMessage = "Limite Requerido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Limite Solo Numeros Permitidos mayor a 0")]
        public int limit { get; set; }

        [Required(ErrorMessage = "Fecha y hora de comienzo Requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Inicio de Evento debe de estar en formato Fecha")]
        public DateTime start { get; set; }

        [Required(ErrorMessage = "Fecha y hora de fin Requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Fin de Evento debe de estar en formato Fecha")]
        public DateTime finish { get; set; }

        [Required(ErrorMessage = "Tipo de evento requerido")]
        public EventTypes eventType { get; set; }
    }
}
