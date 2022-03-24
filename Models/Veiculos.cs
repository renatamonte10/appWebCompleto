using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace AppWebCompleto.Models
{
    public class Veiculos
    {
        private readonly static string _conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    

        public int Id { get; set; }
        [Display(Name ="Marca:")]
        [Required(ErrorMessage ="A marca do veículo é obrigatória.")]
        public string Nome { get; set; }
        [Display(Name = "Modelo:")]
        [Required(ErrorMessage = "A modelo do veículo é obrigatório.")]
        public string Modelo { get; set; }
        public short Ano { get; set; }
        [Range (1800, 2050, ErrorMessage = "O ano deve estar entre {1} e and {2}.")]
        public short Fabricacao { get; set; }
        [Required(ErrorMessage = "A cor do veículo é obrigatória.")]
        public string Cor { get; set; }
        [Range(1, 5, ErrorMessage = "O combustível deve estar entre {1} e and {2}.")]
        public byte Combustivel { get; set; }
        public bool Automatico { get; set; }
        [Range(0.01, 9999999.99, ErrorMessage = "O valor deve estar entre {1} e and {2}.")]
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public Veiculos()
        {
        }

        public Veiculos(int id, string nome, string modelo, short ano, short fabricacao, string cor, byte combustivel, bool automatico, decimal valor, bool ativo)
        {
            Id = id;
            Nome = nome;
            Modelo = modelo;
            Ano = ano;
            Fabricacao = fabricacao;
            Cor = cor;
            Combustivel = combustivel;
            Automatico = automatico;
            Valor = valor;
            Ativo = ativo;
        }

        public static List<Veiculos> GetCarros()
        {
            var listaCarros = new List<Veiculos>();
            var sql = "SELECT * FROM tb_Veiculos";

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
                                while (dr.Read())
                                {
                                    listaCarros.Add(new Veiculos(
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Nome"].ToString(),
                                        dr["Modelo"].ToString(),
                                        Convert.ToInt16(dr["Ano"]),
                                        Convert.ToInt16(dr["Fabricacao"]),
                                        dr["Cor"].ToString(),
                                        Convert.ToByte(dr["Combustivel"]),
                                        Convert.ToBoolean(dr["Automatico"]),
                                        Convert.ToDecimal(dr["Valor"]),
                                        Convert.ToBoolean(dr["Ativo"])
                                        ));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                Console.WriteLine("Falha: " + ex.Message);
            }

            return listaCarros;
        }


        public void Salvar()
        {
            var sql = "";

            if (Id == 0)
                sql = "INSERT INTO tb_Veiculos (nome, modelo, ano, fabricacao, cor, combustivel, automatico, valor, ativo)" +
                    " VALUES (@nome, @modelo, @ano, @fabricacao, @cor, @combustivel, @automatico, @valor, @ativo)";
            else
                sql = "UPDATE tb_Veiculos SET nome=@nome, modelo=@modelo, ano=@ano, fabricacao=@fabricacao, cor=@cor, combustivel=@combustivel, automatico=@automatico, valor=@valor, ativo=@ativo WHERE id=" + Id;


            try
            {
                using (SqlConnection cn = new SqlConnection(_conn)) //o problema está aqui. talvez no insert.
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@modelo", Modelo);
                        cmd.Parameters.AddWithValue("@ano", Fabricacao);
                        cmd.Parameters.AddWithValue("@fabricacao", Fabricacao);
                        cmd.Parameters.AddWithValue("@cor", Cor);
                        cmd.Parameters.AddWithValue("@combustivel", Combustivel);
                        cmd.Parameters.AddWithValue("@automatico", Automatico);
                        cmd.Parameters.AddWithValue("@valor", Valor);
                        cmd.Parameters.AddWithValue("@ativo", Ativo);

                        cmd.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Console.WriteLine("Falha em SQL: " + ex.Message);
                }
                else
                {
                    Console.WriteLine("Falha: " + ex.Message);
                }
                
            }

        }

        public void Excluir()
        {
            var sql = "DELETE FROM tb_Veiculos WHERE id=" + Id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void GetVeiculo(int id)
        {
            var sql = "SELECT nome,modelo,ano,fabricacao,cor,combustivel,automatico,valor,ativo FROM tb_Veiculos WHERE id=" + id;
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
                                    Id = id;
                                    Nome = dr["nome"].ToString();
                                    Modelo = dr["modelo"].ToString();
                                    Ano = Convert.ToInt16(dr["ano"]);
                                    Fabricacao = Convert.ToInt16(dr["fabricacao"]);
                                    Cor = dr["cor"].ToString();
                                    Combustivel = Convert.ToByte(dr["combustivel"]);
                                    Automatico = Convert.ToBoolean(dr["automatico"]);
                                    Valor = Convert.ToDecimal(dr["valor"]);
                                    Ativo = Convert.ToBoolean(dr["ativo"]);

                                }
                            }
                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
                Nome = "Falha: " + ex.Message;
                Console.WriteLine("Falha: " + ex.Message);
            }
        }



    }
}