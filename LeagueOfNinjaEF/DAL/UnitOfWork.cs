using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private LoNContext context;
        private IRepository<Models.Type> _TypeRepository;
        private IRepository<Equipment> _EquipmentRepository;
        private IRepository<Ninja> _NinjaRepository;

        public UnitOfWork()
        {
            context = new LoNContext();
        }

        public IRepository<Models.Type> TypeRepository
        {
            get
            {
                if (_TypeRepository == null)
                {
                    this._TypeRepository = new GenericRepository<Models.Type>(context);
                }
                return _TypeRepository;
            }
            set
            {
                _TypeRepository = value;
            }
        }
        
        public IRepository<Equipment> EquipmentRepository
        {
            get
            {
                if (_EquipmentRepository == null)
                {
                    _EquipmentRepository = new GenericRepository<Equipment>(context);
                }
                return _EquipmentRepository;
            }
            set
            {
                _EquipmentRepository = value;
            }
        }

        public IRepository<Ninja> NinjaRepository
        {
            get
            {
                if (_NinjaRepository == null)
                {
                    _NinjaRepository = new GenericRepository<Ninja>(context);
                }
                return _NinjaRepository;
            }
            set
            {
                _NinjaRepository = value;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
