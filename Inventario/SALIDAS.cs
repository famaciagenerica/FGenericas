using System;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarmaciasGenericas
{
    public class SALIDAS : INotifyPropertyChanged, IDataErrorInfo
    {
        public bool Existe;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //This is used to implement validations and checks
        public string Error
        {
            get { return null; }
        }
        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "NameOfTheColumnToCheck")
                {
                    bool valid = true;
                    //checks
                    if (!valid)
                        return "ErrorMessage";
                }
                return null;
            }
        }

        private Int32 _idSalida;
        public Int32 idSalida
        {
            get { return _idSalida; }
            set
            {
                _idSalida = value;
                OnPropertyChanged(new PropertyChangedEventArgs("idSalida"));
            }
        }				private Int32 _idProducto;
        public Int32 idProducto
        {
            get { return _idProducto; }
            set
            {
                _idProducto = value;
                OnPropertyChanged(new PropertyChangedEventArgs("idProducto"));
            }
        }				private Decimal _Cantidad;
        public Decimal Cantidad
        {
            get { return _Cantidad; }
            set
            {
                _Cantidad = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cantidad"));
            }
        }				private DateTime _FechaSalida;
        public DateTime FechaSalida
        {
            get { return _FechaSalida; }
            set
            {
                _FechaSalida = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FechaSalida"));
            }
        }

        public SALIDAS()
        {
        }

        public SALIDAS(Int32 _idSalida, Int32 _idProducto, Decimal _Cantidad, DateTime _FechaSalida)
        {
            idSalida = _idSalida;
            idProducto = _idProducto;
            Cantidad = _Cantidad;
            FechaSalida = _FechaSalida;
        }

        public void Insert(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO SALIDAS(idSalida, idProducto, Cantidad, FechaSalida) VALUES (@pidSalida, @pidProducto, @pCantidad, @pFechaSalida)";
                cmd.Parameters.AddWithValue("@pidSalida", _idSalida);
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidad", _Cantidad);
                cmd.Parameters.AddWithValue("@pFechaSalida", _FechaSalida);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE SALIDAS SET idSalida = @pidSalida, idProducto = @pidProducto, Cantidad = @pCantidad, FechaSalida = @pFechaSalida WHERE ";
                cmd.Parameters.AddWithValue("@pidSalida", _idSalida);
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidad", _Cantidad);
                cmd.Parameters.AddWithValue("@pFechaSalida", _FechaSalida);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "Delete from SALIDAS WHERE ";

                cmd.ExecuteNonQuery();
            }
        }

        public void GetSALIDASBy(System.Data.SqlClient.SqlConnection connection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                Existe = false;
                cmd.Connection = connection;
                cmd.CommandText = "Select idSalida, idProducto, Cantidad, FechaSalida FROM SALIDAS WHERE ";

                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            _idSalida = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            _idProducto = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            _Cantidad = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            _FechaSalida = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                            Existe = true;
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
