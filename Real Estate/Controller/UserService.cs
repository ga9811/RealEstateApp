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

      

        public PropertyModel GetPropertyById(int propertyId)
        {
            string sql = "SELECT * FROM property WHERE id = @p0"; 
            return BasicDao<PropertyModel>.QuerySingle(sql, propertyId);
        }


        public int AddProperty(PropertyModel property)
        {
        

            string sql = "INSERT INTO property (type, square_feet, price, address, bedrooms, bathrooms, " +
                        "year_of_build, offer_type, inspection_status, inspection_date, repair_status, repair_date, " +
                        "photo, balcony, pool, backyard, garage, description, client_id) " +
                        "VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, " +
                        "@p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18)";

            return BasicDao<PropertyModel>.Update(sql,
                property.type ?? (object)DBNull.Value,
                property.square_feet ?? (object)DBNull.Value,
                property.price ?? (object)DBNull.Value,
                property.address ?? (object)DBNull.Value,
                property.bedrooms ?? (object)DBNull.Value,
                property.bathrooms ?? (object)DBNull.Value,
                property.year_of_build ?? (object)DBNull.Value,
                property.offer_type ?? (object)DBNull.Value,
                property.inspection_status ?? (object)DBNull.Value,
                property.inspection_date ?? (object)DBNull.Value,
                property.repair_status ?? (object)DBNull.Value,
                property.repair_date ?? (object)DBNull.Value,
                property.photo ?? (object)DBNull.Value,
                property.balcony ?? (object)DBNull.Value,
                property.pool ?? (object)DBNull.Value,
                property.backyard ?? (object)DBNull.Value,
                property.garage ?? (object)DBNull.Value,
                property.description ?? (object)DBNull.Value,
                property.client_id ?? (object)DBNull.Value);
        }

        public int DeleteProperty(int propertyId)
        {
            string sql = "DELETE FROM property WHERE id = @p0";
            return BasicDao<PropertyModel>.Update(sql, propertyId);
        }

        public int UpdateProperty(PropertyModel property)
        {
            string sql = "UPDATE property SET type = @p0, square_feet = @p1, price = @p2, address = @p3, bedrooms = @p4, " +
                         "bathrooms = @p5, year_of_build = @p6, offer_type = @p7, inspection_status = @p8, inspection_date = @p9, " +
                         "repair_status = @p10, repair_date = @p11, photo = @p12, balcony = @p13, pool = @p14, backyard = @p15, " +
                         "garage = @p16, description = @p17, client_id = @p18 WHERE id = @p19";

            return BasicDao<PropertyModel>.Update(sql,
                property.type ?? (object)DBNull.Value,
                property.square_feet ?? (object)DBNull.Value,
                property.price ?? (object)DBNull.Value,
                property.address ?? (object)DBNull.Value,
                property.bedrooms ?? (object)DBNull.Value,
                property.bathrooms ?? (object)DBNull.Value,
                property.year_of_build ?? (object)DBNull.Value,
                property.offer_type ?? (object)DBNull.Value,
                property.inspection_status ?? (object)DBNull.Value,
                property.inspection_date ?? (object)DBNull.Value,
                property.repair_status ?? (object)DBNull.Value,
                property.repair_date ?? (object)DBNull.Value,
                property.photo ?? (object)DBNull.Value,
                property.balcony ?? (object)DBNull.Value,
                property.pool ?? (object)DBNull.Value,
                property.backyard ?? (object)DBNull.Value,
                property.garage ?? (object)DBNull.Value,
                property.description ?? (object)DBNull.Value,
                property.client_id ?? (object)DBNull.Value,
                property.id); // Assuming `id` is the primary key of the property
        }
    }
}
