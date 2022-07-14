using Dapper;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data
{
    public class LecturerDAL
    {
        private string GetConnString()
        {
            return "Data Source=.\\SQLEXPRESS;Initial Catalog=SampleAdoDb;Integrated Security=SSPI";
        }
       /* public IEnumerable<Lecturer> GetAll()
        {
            List<Lecturer> lstLecturers = new List<Lecturer>();
            using(SqlConnection conn=new SqlConnection(GetConnString()))
            {
                string strSql = @"Select * from Lecturers order by Nama asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstLecturers.Add(new Lecturer()
                        {
                            Nik = dr["Nik"].ToString(),
                            Nama = dr["Nama"].ToString(),
                            Alamat = dr["Alamat"].ToString(),
                            Telp = dr["Telp"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstLecturers;
        }*/

       // mengambil semua data
        public IEnumerable<Lecturer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Lecturers order by Nama asc";
                var result = conn.Query<Lecturer>(strSql);
                return result;
            }

        }
        //menampilkan data by id
        public Lecturer GetbyId(string nik)
        {
            
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Lecturers where Nik = @Nik";
                var param = new { Nik = nik };
                var result = conn.QueryFirst<Lecturer>(strSql, param);
                return result;
            }
        }
        //insert data
        public void Insert(Lecturer lecturer)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"insert into Lecturers(Nik,Nama,Alamat,Telp) 
                                values(@Nik,@Nama,@Alamat,@Telp)";
                var param = new { Nik = lecturer.Nik, Nama = lecturer.Nama, Alamat = lecturer.Alamat, Telp = lecturer.Telp };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if(result != 1)
                    
                        throw new Exception($"Data gagal di tambahakan Lecturere {lecturer.Nama}");
                    }
                    catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Number} - {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}");
                }
                }
            }
        //update data
        public void Update(Lecturer lecturer)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"update Lecturers  set Nama = @Nama, Alamat = @Alamat, Telp = @Telp where Nik = @Nik";
                var param = new { 
                Nama= lecturer.Nama,
                Alamat = lecturer.Alamat,
                Telp = lecturer.Telp,
                Nik = lecturer.Nik
                };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)

                        throw new Exception($"Data gagal di update Lecturere {lecturer.Nama}");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Number} - {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}");
                }
            }
        }
        //delete data
        public void Delete(string Nik)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"delete from Lecturers where Nik = @Nik";
                var param = new { Nik = Nik };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)

                        throw new Exception($"Data gagal di hapus {Nik}");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Number} - {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}");
                }

            }
        }
        // menampilakn berdasarkan nama tertentu
        public IEnumerable<Lecturer>GetByNama(string Nama)
        {
            using (SqlConnection conn = new SqlConnection(GetConnString()))
            {
                string strSql = @"select * from Lecturers where Nama like @Nama";
                var param = new { Nama = $"%{ Nama}%" };
                var result = conn.Query<Lecturer>(strSql,param);
                return result;
            }
        }

        }
    }

