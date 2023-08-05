using Real_Estate.DAO;
using Real_Estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Controller
{
    public class UserService
    {
        public Agents getAgentByUserName(string username)
        {
            string sql = "select * from agents where username = @p0";
            return BasicDao<Agents>.QuerySingle(sql, username);

        }

        public List<ScheduleModel> getAgentSchedule(int agentId)
{
            string sql = "SELECT S.schedule_type AS schedule_type, S.schedule_time AS schedule_time, A.name AS agent_name, C.name AS client_name " +
                         "FROM Schedules S " +
                         "JOIN agents A ON S.agent_id = A.id " +
                         "JOIN clients C ON S.client_id = C.id " +
                         "WHERE S.agent_id = @p0 AND S.schedule_time >= getdate() " +
                         "ORDER BY S.schedule_time";


            return BasicDao<ScheduleModel>.QueryMulti(sql, agentId);
        }

        public List<PropertyModel> getPropertyStatus()
        {
            
            string sql = "SELECT id , address, inspection_status, inspection_date, " +
                "repair_status,repair_date " +
                        "FROM property " +
                        "WHERE inspection_date >= getdate() OR repair_date >= getdate() " +
                        "ORDER BY inspection_date, repair_date";


            return BasicDao<PropertyModel>.QueryMulti(sql);
        }

    }
}
