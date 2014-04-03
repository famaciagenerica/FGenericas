using System;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarmaciasGenericas
{
    public class INVENTARIO : INotifyPropertyChanged, IDataErrorInfo
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

        private Int32 _idProducto;
        public Int32 idProducto
        {
            get { return _idProducto; }
            set
            {
                _idProducto = value;
                OnPropertyChanged(new PropertyChangedEventArgs("idProducto"));
            }
        }				private Decimal _CantidadEntrada;
        public Decimal CantidadEntrada
        {
            get { return _CantidadEntrada; }
            set
            {
                _CantidadEntrada = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CantidadEntrada"));
            }
        }				private Decimal _CantidadSalida;
        public Decimal CantidadSalida
        {
            get { return _CantidadSalida; }
            set
            {
                _CantidadSalida = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CantidadSalida"));
            }
        }				private Decimal _Total;
        public Decimal Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Total"));
            }
        }

        public INVENTARIO()
        {
        }

        public INVENTARIO(Int32 _idProducto, Decimal _CantidadEntrada, Decimal _CantidadSalida, Decimal _Total)
        {
            idProducto = _idProducto;
            CantidadEntrada = _CantidadEntrada;
            CantidadSalida = _CantidadSalida;
            Total = _Total;
        }

        public void Insert(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO INVENTARIO(idProducto, CantidadEntrada, CantidadSalida, Total) VALUES (@pidProducto, @pCantidadEntrada, @pCantidadSalida, @pTotal)";
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidadEntrada", _CantidadEntrada);
                cmd.Parameters.AddWithValue("@pCantidadSalida", _CantidadSalida);
                cmd.Parameters.AddWithValue("@pTotal", _Total);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE INVENTARIO SET idProducto = @pidProducto, CantidadEntrada = @pCantidadEntrada, CantidadSalida = @pCantidadSalida, Total = @pTotal WHERE ";
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pCantidadEntrada", _CantidadEntrada);
                cmd.Parameters.AddWithValue("@pCantidadSalida", _CantidadSalida);
                cmd.Parameters.AddWithValue("@pTotal", _Total);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "Delete from INVENTARIO WHERE ";

                cmd.ExecuteNonQuery();
            }
        }

        public void GetINVENTARIOBy(System.Data.SqlClient.SqlConnection connection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                Existe = false;
                cmd.Connection = connection;
                cmd.CommandText = "Select idProducto, CantidadEntrada, CantidadSalida, Total FROM INVENTARIO WHERE ";

                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            _idProducto = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            _CantidadEntrada = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            _CantidadSalida = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            _Total = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                            Existe = true;
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
