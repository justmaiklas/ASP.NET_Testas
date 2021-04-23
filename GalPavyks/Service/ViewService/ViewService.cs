using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalPavyks.Service.ViewService
{
    public class ViewService : IViewService //Sukurti ViewService kuris grazintu modalus success arba error i Views
    {


        public enum MessageTypes
        {
            Success,
            Warning
        }
    }
}
