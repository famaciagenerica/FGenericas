using System;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarmaciasGenericas
{
    public class ENTRADAS : INotifyPropertyChanged, IDataErrorInfo
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

        private Int32 _idEntrada;
        public Int32 idEntrada
        {
            get { return _idEntrada; }
            set
            {
                _idEntrada = value;
                OnPropertyChanged(new PropertyChangedEventArgs("idEntrada"));
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
        }				private DateTime _FechaEntrada;
        public DateTime FechaEntrada
        {
            get { return _FechaEntrada; }
            set
            {
                _FechaEntrada = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FechaEntrada"));
            }
        }				private DateTime _FechaCaducidad;
        public DateTime FechaCaducidad
        {
            get { return _FechaCaducidad; }
            set
            {
                _FechaCaducidad = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FechaCaducidad"));
            }
        }

        public ENTRADAS()
        {
        }

        public ENTRADAS(Int32 _idEntrada, Int32 _idProducto, Decimal _Cantidad, DateTime _FechaEntrada, DateTime _FechaCaducidad)
        {
            idEntrada = _idEntrada;
            idProducto = _idProducto;
            Cantidad = _Cantidad;
            FechaEntrada = _FechaEntrada;
            FechaCaducidad = _FechaCaducidad;
        }

        public void Insert(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO ENTRADAS(idEntrada, idProducto, Cantidad, FechaEntrada, FechaCaducidad) VALUES (@pidEntrada, @pidProducto, @pCantidad, @pFechaEntrada, @pFechaCaducidad)";
                cmd.Parameters.AddWithValue("@pidEntrada", _idEntrada);
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidad", _Cantidad);
                cmd.Parameters.AddWithValue("@pFechaEntrada", _FechaEntrada);
                cmd.Parameters.AddWithValue("@pFechaCaducidad", _FechaCaducidad);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE ENTRADAS SET idEntrada = @pidEntrada, idProducto = @pidProducto, Cantidad = @pCantidad, FechaEntrada = @pFechaEntrada, FechaCaducidad = @pFechaCaducidad WHERE ";
                cmd.Parameters.AddWithValue("@pidEntrada", _idEntrada);
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidad", _Cantidad);
                cmd.Parameters.AddWithValue("@pFechaEntrada", _FechaEntrada);
                cmd.Parameters.AddWithValue("@pFechaCaducidad", _FechaCaducidad);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "Delete from ENTRADAS WHERE ";

                cmd.ExecuteNonQuery();
            }
        }

        public void GetENTRADASBy(System.Data.SqlClient.SqlConnection connection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                Existe = false;
                cmd.Connection = connection;
                cmd.CommandText = "Select idEntrada, idProducto, Cantidad, FechaEntrada, FechaCaducidad FROM ENTRADAS WHERE ";

                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            _idEntrada = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            _idProducto = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            _Cantidad = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            _FechaEntrada = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3);
                            _FechaCaducidad = reader.IsDBNull(4) ? DateTime.Now : reader.GetDateTime(4);
                            Existe = true;
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
