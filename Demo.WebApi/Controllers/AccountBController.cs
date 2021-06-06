using Demo.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    /// <summary>
    /// 預設產生的Api
    /// </summary>
    public class AccountBController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IDemoSerive _demoSerive;

        
        public AccountBController(IAccountService accountService, IDemoSerive demoSerive)
        {
            _accountService = accountService;
            _demoSerive = demoSerive;
        }
        // GET api/values
        [NoZero]
        public string Get(int id)
        {
            var account = _accountService.GetAccount(id);
            Debug.WriteLine($"AccountBController MyGuid:{_demoSerive.MyGuid}");
            return account;
        }

    }
}
