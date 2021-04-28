using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalPavyks.Repository;
using GalPavyks.Service.PersonService;
using GalPavyks.Service.ViewService;

namespace GalPavyks.Service
{
    public interface IServiceWrapper
    {
        IPersonService PersonService { get; }
        IViewService ViewService { get; } //Sukurti ViewService kuris grazintu modalus success arba error i Views
        //IRepositoryWrapper repositoryWrapper { get; }


    }
}
