﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AppWebCompleto.Models
{
    public class Usuarios
    {
        private readonly static string _conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public bool Login()
        {
            var result = false;
            var sql = "SELECT Id, Nome, Senha FROM Usuarios WHERE Email = '" + this.Email + "' ";

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    if (this.Senha == dr["senha"].ToString())
                                    {
                                        this.Id = Convert.ToInt32(dr["id"]);
                                        this.Nome = dr["nome"].ToString();
                                        result = true;
                                    }
                                }
                            }
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return result;

        }
      
        




    }
}