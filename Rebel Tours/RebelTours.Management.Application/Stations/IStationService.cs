using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Stations
{
    public interface IStationService : IService<StationDTO, StationSummary>
    {
        //CommandResult DeleteByCityId(int cityId);
    }
}
