using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PCopa0030482211041
{
    class Jogo
    {
        // Propriedades
        public int Id { get; set; }

        public int EstadioId { get; set; }

        public int PaisId1 { get; set; }

        public int PaisId2 { get; set; }

        public DateTime Datahora { get; set; }

        public char Grupo { get; set; }

        public string Observacao { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daJogo;
            DataTable dtJogo = new DataTable();

            try
            {
                daJogo = new SqlDataAdapter("SELECT * FROM JOGO", frmPrincipal.conexao);
                daJogo.Fill(dtJogo);
                daJogo.FillSchema(dtJogo, SchemaType.Source);

            }
            catch (Exception)
            {
                throw;
            }

            return dtJogo;
        }

        public int Excluir() 
        {
            int nReg = 0; 

            try
            { 
                SqlCommand mycommand; 
                mycommand = new SqlCommand("DELETE FROM JOGO WHERE ID = @id", frmPrincipal.conexao); 

                mycommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                mycommand.Parameters["@id"].Value = Id;

                nReg = mycommand.ExecuteNonQuery(); 
            } 
            catch (Exception)
            { 
                throw;
            }
 
            return nReg;
        }

        public int Salvar() // Inclusão
        {
            int retorno = 0;

            try
            { 
                SqlCommand mycommand; 

                mycommand = new SqlCommand("INSERT INTO JOGO VALUES (@pais1, @pais2, @estadio, @datahora, @observacao)", frmPrincipal.conexao); 

                mycommand.Parameters.Add(new SqlParameter("@pais1", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@pais2", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@estadio", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@datahora", SqlDbType.Date));
                mycommand.Parameters.Add(new SqlParameter("@observacao", SqlDbType.VarChar));

                mycommand.Parameters["@pais1"].Value = PaisId1; 
                mycommand.Parameters["@pais2"].Value = PaisId2;
                mycommand.Parameters["@estadio"].Value = EstadioId;
                mycommand.Parameters["@datahora"].Value = Datahora;
                mycommand.Parameters["@observacao"].Value = Observacao;

                retorno = mycommand.ExecuteNonQuery();

            } 
            catch (Exception) 
            { 
                throw; 
            }
 
            return retorno; 
        }
    }
}
