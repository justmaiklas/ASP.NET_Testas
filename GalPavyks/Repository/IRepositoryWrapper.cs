using GalPavyks.Models;

namespace GalPavyks.Repository
{
    public interface IRepositoryWrapper
    {
        IPerson Person { get; }

        void Save();
    }

}