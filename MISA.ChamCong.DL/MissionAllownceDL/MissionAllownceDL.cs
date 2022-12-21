using Dapper;
using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.DL
{
    public class MissionAllownceDL : BaseDL<MissionAllownce>, IMissionAllownceDL
    {
        /// <summary>
        /// Danh sách đơn theo phân trang và tìm kiếm
        /// </summary>
        /// <param name="keyword">Từ khóa cần tìm</param>
        /// <param name="organization">Đơn vị cần tim</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <param name="pageNumber">Vị trí bản ghi bắt đầu</param>
        /// <returns></returns>
        public PaginResults<MissionAllownce> GetMissionByFilterAndPaging(string keyword, string organizationID, int pageSize, int pageNumber)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = Procedure.GET_MISSION_BY_PAGING;

            // Chuẩn bị tham số đầu vào

            var parameters = new DynamicParameters();

            parameters.Add("v_offset", (pageNumber - 1) * pageSize);
            parameters.Add("v_limit", pageSize);
            parameters.Add("v_soft", "ModifiedDate DESC");

            var lstCondition = new List<string>();
            var andCondition = new List<string>();
            string searchClause = "";
            if (keyword != null)
            {
                lstCondition.Add($"EmployeeCode LIKE '%{keyword}%'");
                lstCondition.Add($"EmployeeName LIKE '%{keyword}%'");
            }
            if (lstCondition.Count > 0)
            {
                andCondition.Add($"({string.Join(" OR ", lstCondition)})");
            }
            if (organizationID != null)
            {
                andCondition.Add($"OrganizationUnitID = '{organizationID}'");
            }
            if(andCondition.Count > 0)
            {
                searchClause += $" {string.Join(" AND ", andCondition)}";
            }
            parameters.Add("v_search", searchClause);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResult = mysqlConnection.QueryMultiple(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResult != null)
                {
                    var listEmployee = multipleResult.Read<MissionAllownce>().ToList();
                    var totalCount = multipleResult.Read<long>().Single();
                    return new PaginResults<MissionAllownce>()
                    {
                        Data = listEmployee,
                        TotalCount = totalCount,
                    };
                }
            }
            return new PaginResults<MissionAllownce>();
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public Guid InsertRecord(MissionAllownce record)
        {
            // Chuẩn bị câu lệnh sql
            string storeProcedureName = Procedure.INSERT_MISSION_ALLOWNCE;

            var parameters = new DynamicParameters();

            // Lấy rả các Prop của đối tượng
            var properties = record?.GetType().GetProperties();

            // Khởi tạo biến lưu giá trị
            object propValue;

            // Tạo id mới
            var newRecordID = Guid.NewGuid();

            foreach (var prop in properties)
            {
                // LẤy ra attribute KeyAttribute
                var keyAtrribute = Attribute.GetCustomAttribute(prop, typeof(Key));
                // Nếu có thì lưu id mới
                if (keyAtrribute != null)
                {
                    propValue = newRecordID;
                }
                // Lưu giá trị của đối tượng
                else
                {
                    propValue = prop.GetValue(record);
                }

                // Chuyền vào parameter
                parameters.Add($"v_{prop.Name}", propValue);
            }
            // Khởi tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                // Bắt đầu transaction 
                var transaction = mySqlConnection.BeginTransaction();
                // Thực hiện gọi vào DB
                var result = mySqlConnection.Execute(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                // return kết quả
                if (result > 0)
                {
                    transaction.Commit();
                    mySqlConnection.Close();
                    return newRecordID;
                }
                // Rollback về lại ban đầu
                else
                {
                    transaction.Rollback();
                    mySqlConnection.Close();
                    return newRecordID;
                }
            }

        }

        /// <summary>
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public Guid UpdateRecord(Guid recordID, MissionAllownce record)
        {
            // Chuẩn bị câu lệnh sql
            string storeProcedureName = Procedure.UPDATE_MISSION_ALLOWNCE;

            var parameters = new DynamicParameters();

            // Lấy rả các Prop của đối tượng
            var properties = record?.GetType().GetProperties();

            // Khởi tạo biến lưu giá trị
            object propValue;

            foreach (var prop in properties)
            {
                // Lưu giá trị của đối tượng
                propValue = prop.GetValue(record);

                // Chuyền vào parameter
                parameters.Add($"v_{prop.Name}", propValue);
            }
            // Khởi tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                // Bắt đầu transaction 
                var transaction = mySqlConnection.BeginTransaction();
                // Thực hiện gọi vào DB
                var result = mySqlConnection.Execute(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    transaction.Commit();
                    mySqlConnection.Close();
                    return recordID;
                }
                else
                {
                    transaction.Rollback();
                    mySqlConnection.Close();
                    return recordID;
                }
            }
        }

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
            string sql = $"DELETE FROM missionallowance WHERE MissionAllowanceID IN ('{str}');";

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
    }
}
