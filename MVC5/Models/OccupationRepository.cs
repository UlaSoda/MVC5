using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5.Models
{   
	public  class OccupationRepository : EFRepository<Occupation>, IOccupationRepository
	{

	}

	public  interface IOccupationRepository : IRepository<Occupation>
	{

	}
}