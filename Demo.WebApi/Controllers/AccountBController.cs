using Demo.Service;
using System;
using System.Collections.Generic;
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
        public AccountBController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET api/values

        public string Get(int id)
        {
            var account = _accountService.GetAccount(id);
            return account;
        }

    }
}
