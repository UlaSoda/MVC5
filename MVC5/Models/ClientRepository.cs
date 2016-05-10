using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5.Models
{
    public override IQueryable<Client> All()
    {
        return base.All().Take(10);
    }

    public Client Find(int id)
    {
        return this.All().Where(c => c.ClientId == id).FirstOrDefault();
    }
}