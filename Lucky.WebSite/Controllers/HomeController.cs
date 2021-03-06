﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lucky.Core;
using Lucky.Core.Cache;
using Lucky.Core.Logging;
using Lucky.Core.Utility;
using Lucky.Entity;
using Lucky.Entity.Mapping;
using Lucky.IService;
using Lucky.Service;
using Lucky.ViewModels.Models.News;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Lucky.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private ICacheManager _cacheManager;
        public ILogger _Logger;
        private IAreaService _areaService;
        private IDistributorConfigService _distributorConfigService;
        private IHrDbContext _dbContext;
        private INewsArticlesService _articlesRepository;

        public HomeController(
            ICacheManager cacheManager,
            ILogger logger,
            IAreaService areaService,
            IHrDbContext hrDbContext,
            IDistributorConfigService distributorConfigService,
            INewsArticlesService articlesRepository
            )
        {
            _cacheManager = cacheManager;
            _Logger = logger;
            _areaService = areaService;
            _dbContext = hrDbContext;
            _distributorConfigService = distributorConfigService;
            _articlesRepository = articlesRepository;
        }
        // GET: Home
        [OutputCache(Duration = 60)]
        public  ActionResult Index()
        {
            //List<NewsArticlesViewModel> list = _articlesRepository.GetArticlesViewModels();
           return Globals.Execute(() => View());
            
        }
        
    }

}