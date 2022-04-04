namespace backendEscuela.Models
{
	public class Solicitud
	{
		private static int IdAuto = 0;
		public Solicitud()
		{
			Id = ++IdAuto;
		}

		public int Id { get; set; }
		private bool _valid = true;
		private string _nombre;
		public string Nombre
		{
			get => _nombre;
			set
			{
				if (value.Length > 20)
				{
					_valid = false;
					return;
				}
				_nombre = value;
			}
		}

		private string _apellidos;
		public string Apellidos
		{
			get => _apellidos;
			set
			{
				if (value.Length > 20)
				{
					_valid = false;
					return;
				}
				_apellidos = value;
			}
		}

		private int _identificacion;
		public int Identificacion
		{
			get => _identificacion;
			set
			{
				if (value > 999999999)
				{
					_valid = false;
					return;
				}
				_identificacion = value;
			}
		}

		private int _edad;
		public int Edad
		{
			get => _edad;
			set
			{
				if (value > 99)
				{
					_valid = false;
					return;
				}
				_edad = value;
			}
		}

		private string _casa;
		public string Casa
		{
			get => _casa;
			set
			{
				if (!value.Equals("Gryffindor") && !value.Equals("Hufflepuff") && !value.Equals("Ravenclaw") && !value.Equals("Slytherin"))
				{
					_valid = false;
					return;
				}
				_casa = value;
			}
		}
		public bool IsValid()
		{
			return _valid && Id <= IdAuto && _casa != null; 
		}

	}
}