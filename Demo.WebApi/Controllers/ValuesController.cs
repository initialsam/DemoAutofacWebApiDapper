using Demo.Common;
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
    public class ValuesController : ApiController
    {
        private readonly IDemoSerive _demoService;
        public ValuesController(IDemoSerive demoService)
        {
            _demoService = demoService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 有呼叫DemoCrud跟HappyString
        /// </summary>
        /// <remarks>呼叫demoService的DemoCrud，HappyString</remarks> 
        /// <param name="id"></param>
        /// <returns>HappyString的結果</returns>
        [NoZero]
        public string Get(int id)
        {
            Debug.WriteLine($"ValuesController MyGuid:{_demoService.MyGuid}");
            var account = _demoService.GetAccount(id);
            _demoService.DemoCrud(id);
            return _demoService.HappyString(id);
        }

        public string Get(string key, int id)
        {
            return _demoService.GetAccount(key, id);
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
