using System;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarmaciasGenericas
{
    public class PRODUCTOS : INotifyPropertyChanged, IDataErrorInfo
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
        }				private String _Nombre;
        public String Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nombre"));
            }
        }				private String _Descripcion;
        public String Descripcion
        {
            get { return _Descripcion; }
            set
            {
                _Descripcion = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Descripcion"));
            }
        }				private String _Tipo;
        public String Tipo
        {
            get { return _Tipo; }
            set
            {
                _Tipo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Tipo"));
            }
        }				private String _Quimico;
        public String Quimico
        {
            get { return _Quimico; }
            set
            {
                _Quimico = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Quimico"));
            }
        }				private Decimal _Precio;
        public Decimal Precio
        {
            get { return _Precio; }
            set
            {
                _Precio = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Precio"));
            }
        }				private Decimal _Descuento;
        public Decimal Descuento
        {
            get { return _Descuento; }
            set
            {
                _Descuento = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Descuento"));
            }
        }

        public PRODUCTOS()
        {
        }

        public PRODUCTOS(Int32 _idProducto, String _Nombre, String _Descripcion, String _Tipo, String _Quimico, Decimal _Precio, Decimal _Descuento)
        {
            idProducto = _idProducto;
            Nombre = _Nombre;
            Descripcion = _Descripcion;
            Tipo = _Tipo;
            Quimico = _Quimico;
            Precio = _Precio;
            Descuento = _Descuento;
        }

        public void Insert(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO PRODUCTOS(idProducto, Nombre, Descripcion, Tipo, Quimico, Precio, Descuento) VALUES (@pidProducto, @pNombre, @pDescripcion, @pTipo, @pQuimico, @pPrecio, @pDescuento)";
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pNombre", _Nombre);
                cmd.Parameters.AddWithValue("@pDescripcion", _Descripcion);
                cmd.Parameters.AddWithValue("@pTipo", _Tipo);
                cmd.Parameters.AddWithValue("@pQuimico", _Quimico);
                cmd.Parameters.AddWithValue("@pPrecio", _Precio);
                cmd.Parameters.AddWithValue("@pDescuento", _Descuento);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE PRODUCTOS SET idProducto = @pidProducto, Nombre = @pNombre, Descripcion = @pDescripcion, Tipo = @pTipo, Quimico = @pQuimico, Precio = @pPrecio, Descuento = @pDescuento WHERE ";
                cmd.Parameters.AddWithValue("@pidProducto", _idProducto);
                cmd.Parameters.AddWithValue("@pNombre", _Nombre);
                cmd.Parameters.AddWithValue("@pDescripcion", _Descripcion);
                cmd.Parameters.AddWithValue("@pTipo", _Tipo);
                cmd.Parameters.AddWithValue("@pQuimico", _Quimico);
                cmd.Parameters.AddWithValue("@pPrecio", _Precio);
                cmd.Parameters.AddWithValue("@pDescuento", _Descuento);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(System.Data.SqlClient.SqlConnection connection)
        {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "Delete from PRODUCTOS WHERE ";

                cmd.ExecuteNonQuery();
            }
        }

        public void GetPRODUCTOSBy(System.Data.SqlClient.SqlConnection connection)
        {

            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            {
                Existe = false;
                cmd.Connection = connection;
                cmd.CommandText = "Select idProducto, Nombre, Descripcion, Tipo, Quimico, Precio, Descuento FROM PRODUCTOS WHERE ";

                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            _idProducto = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            _Nombre = reader.IsDBNull(1) ? null : reader.GetString(1);
                            _Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2);
                            _Tipo = reader.IsDBNull(3) ? null : reader.GetString(3);
                            _Quimico = reader.IsDBNull(4) ? null : reader.GetString(4);
                            _Precio = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                            _Descuento = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
                            Existe = true;
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
