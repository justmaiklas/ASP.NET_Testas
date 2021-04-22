using GalPavyks.Models;

namespace GalPavyks.Repository
{
    public interface IRepositoryWrapper
    {
        IPerson Person { get; }
        IMyLogger MyLogger { get; }

        void Save();
    }

}