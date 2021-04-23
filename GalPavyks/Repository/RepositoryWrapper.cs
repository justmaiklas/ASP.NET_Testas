using GalPavyks.Models;


namespace GalPavyks.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private IPerson _person;
        private readonly AppDbContext _appDbContext;
        private IMyLogger _myLogger; //PERKELTI I SERVISUS? ARBA IS VIS NAUDOTI KAIP INDEPENDENT LOGERI

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            if (_myLogger == null)
                _myLogger = new MyLogger(); //PERKELTI I SERVISUS? ARBA IS VIS NAUDOTI KAIP INDEPENDENT LOGERI
            if (_person==null)
                _person = new PersonRepository(_appDbContext);
        }
        public IMyLogger MyLogger //PERKELTI I SERVISUS? ARBA IS VIS NAUDOTI KAIP INDEPENDENT LOGERI
        {
            get
            {
                return _myLogger;
            }
        }
        public IPerson Person
        {
            get
            {
                return _person;
            }
        }
        
        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
