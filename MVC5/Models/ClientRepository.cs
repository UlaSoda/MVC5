using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5.Models
{
    public class ClientRepository : EFRepository<Client>, IClientRepository
    {
        public override IQueryable<Client> All()
        {
            return base.All().Take(10);
        }

        public Client Find(int id)
        {
            return this.All().Where(c => c.ClientId == id).FirstOrDefault();
        }

        public void Delete(Client client)
        {
            foreach (var ord in client.Order.ToList())
            {
                var ol = ord.OrderLine;

                foreach (var item in ol.ToList())
                {
                    UnitOfWork.Context.Entry(item).State = EntityState.Deleted;
                }
                UnitOfWork.Context.Entry(ord).State = EntityState.Deleted;
            }
            base.Delete(client);
        }
    }

    public interface IClientRepository : IRepository<Client>
    {

    }
}