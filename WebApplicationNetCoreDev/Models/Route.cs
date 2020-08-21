using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Models
{
    public class Route
    {
        public string RouteId { get; set; }
        public string RouteController { get; set; }
        public string RouteAction { get; set; }
        public string RouteUrlAction { get; set; }
        public string RouteUrlAbsoluteAction { get; set; }
    }
}