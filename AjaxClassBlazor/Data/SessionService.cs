using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxClassBlazor.Data
{
    public class SessionService
    {
        public SessionData logData { get; set; } = new SessionData()
        {
            account = "",
            token = "",
            logText = "login",
            logHref = "/login",
        };

    }
}
