using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Models;
using GalPavyks.Service.PersonService;
using GalPavyks.Service.ViewService;

namespace GalPavyks.Service
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IPersonService _personService;
        private IViewService _viewService;

        public ServiceWrapper(AppDbContext appDbContext)
        {

            if (_personService == null)
                _personService = new PersonService.PersonService(appDbContext);
            if (_viewService == null)
                _viewService = new ViewService.ViewService(); //Sukurti ViewService kuris grazintu modalus success arba error i Views
        }
        public IViewService ViewService //Sukurti ViewService kuris grazintu modalus success arba error i Views
        {
            get
            {
                return _viewService;
            }
        }
        public IPersonService PersonService
        {
            get
            {
                return _personService;
            }
        }
    }
}
