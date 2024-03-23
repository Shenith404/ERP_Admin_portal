using Authentication.Core.Entity;
using Authentication.DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataService.IRepository
{
    public interface IRefreshToknesRepository :IGenericRepository<RefreshToken>
    {
    }
}
