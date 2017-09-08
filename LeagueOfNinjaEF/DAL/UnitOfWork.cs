using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LoNContext context = new LoNContext();
        private GenericRepository<Models.Type> typeRepository;
        private GenericRepository<Equipment> equipmentRepository;
        private GenericRepository<Ninja> ninjaRepository;

        public GenericRepository<Models.Type> TypeRepository
        {
            get
            {
                if (this.typeRepository == null)
                {
                    this.typeRepository = new GenericRepository<Models.Type>(context);
                }
                return typeRepository;
            }
        }

        public GenericRepository<Equipment> EquipmentRepository
        {
            get
            {
                if (this.equipmentRepository == null)
                {
                    this.equipmentRepository = new GenericRepository<Equipment>(context);
                }
                return equipmentRepository;
            }
        }

        public GenericRepository<Ninja> NinjaRepository
        {
            get
            {
                if (this.ninjaRepository == null)
                {
                    this.ninjaRepository = new GenericRepository<Ninja>(context);
                }
                return ninjaRepository;
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
