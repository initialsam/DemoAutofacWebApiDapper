﻿using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class AccountBService : IAccountService
    {
        private readonly IDemoRepository _demoRepository;

        public AccountBService(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }

        public string GetAccount(int value)
        {
            var a = _demoRepository.GetType();
            return $"AccountB|{value}";
        }
    }
}
