using GalPavyks.Models;

namespace GalPavyks.Repository
{
    public interface IRepositoryWrapper
    {
        IPerson Person { get; }
        IMyLogger MyLogger { get; } //PERKELTI I SERVISUS? ARBA IS VIS NAUDOTI KAIP INDEPENDENT LOGERI

        void Save();
    }

}