using Dapper;
using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.Common.Entities.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.DL
{
    public class MissionAllownceDetailDL : BaseDL<MissionAllownceDetail>, IMissionAllownceDetailDL
    {
        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="listEmployeeID">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public ListID DeleteMultipleEmployee(ListID listEmployeeID)
        {

            MySqlTransaction transaction = null;

            var ids = new List<Guid>();

            foreach (Guid id in listEmployeeID.IDs)
            {
                ids.Add(id);
            }

            var str = string.Join("','", ids);

            //Chuẩn bị câu lệnh SQL
            string sql = $"DELETE FROM missionallowancedetail WHERE MissionAllowanceDetailID IN ('{str}');";

            int numberOfRowsAffected = 0;

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                try
                {
                    transaction = mySqlConnection.BeginTransaction();
                    //Thực hiện gọi vào DB
                    numberOfRowsAffected = mySqlConnection.Execute(sql, transaction: transaction);
                    if (numberOfRowsAffected == listEmployeeID.IDs.Count)
                    {
                        transaction.Commit();

                    }
                    else
                    {

                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            //Xử lý kết quả trả về

            //Thành công: Trả về Id nhân viên thêm thành công
            if (numberOfRowsAffected > 0)
            {
                return listEmployeeID;
            }
            return null;
        }

        /// <summary>
        /// lấy Danh sách nhân viên đi công tác cùng
        /// </summary>
        /// <param name="missionAllownceDetailsID">Id đơn</param>
        /// <returns>Danh sách nhân viên</returns>
        public List<MissionAllownceDetail> GetMissionAllownceDetailsByID(Guid missionAllownceDetailsID)
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = Procedure.GET_MISSION_DETAIL_BY_ID;

            var parameters = new DynamicParameters();
            parameters.Add("v_MissionAllowanceID", missionAllownceDetailsID);

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var records = (List<MissionAllownceDetail>)mySqlConnection.Query<MissionAllownceDetail>(storeProcedureName,parameters ,commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }

        /// <summary>
        /// Thêm nhiều bản ghi vào bảng người đi làm cùng
        /// </summary>
        /// <param name="missionAllownceDetails">Danh sách bản ghi</param>
        /// <returns>Trả về danh sách id thêm thành công</returns>
        public List<Guid> InsertMultipleMissionDetail(List<MissionAllownceDetail> missionAllownceDetails)
        {
            var listEmployee = new List<string>();
            var listID = new List<Guid>();

            foreach(MissionAllownceDetail missionDetail in missionAllownceDetails)
            {
                
                // Lấy ra các Prop của đối tượng
                var properties = missionDetail?.GetType().GetProperties();
                var employee = new List<string>();
                var newRecordID = Guid.NewGuid();

                foreach (var prop in properties)
                {
                    object propValue;
                    // LẤy ra attribute KeyAttribute
                    var keyAtrribute = Attribute.GetCustomAttribute(prop, typeof(Key));


                    if (keyAtrribute != null)
                    {
                        propValue = newRecordID;
                        listID.Add(newRecordID);
                    }
                    else { 
                        propValue = prop.GetValue(missionDetail);
                    }
                    employee.Add(propValue.ToString());
                }

                var str = string.Join("', '" ,employee);

                string insertSql = $"INSERT INTO missionallowancedetail (MissionAllowanceDetailID, MissionAllowanceID, EmployeeCode, EmployeeID, EmployeeName, JobPositionID, JobPositionName, OrganizationUnitID, OrganizationUnitName, MobilePhone,CreateDate, CreateBy, ModifiedDate, ModifiedBy, TenantID) VALUES ('{str}');";

                listEmployee.Add(insertSql);
            }

            var sql = string.Join(" ", listEmployee); 

            // Khởi tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                // Bắt đầu transaction 
                var transaction = mySqlConnection.BeginTransaction();
                // Thực hiện gọi vào DB
                var result = mySqlConnection.Execute(sql, transaction: transaction);
                // return kết quả
                if (result > 0)
                {
                    transaction.Commit();
                    mySqlConnection.Close();
                    return listID;
                }
                // Rollback về lại ban đầu
                else
                {
                    transaction.Rollback();
                    mySqlConnection.Close();
                    return null;
                }
            }
        }
    } 
}
