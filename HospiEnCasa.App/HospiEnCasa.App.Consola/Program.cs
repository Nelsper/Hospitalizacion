using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        //Vamos a declarar e inicializar un objeto de tipo RepositorioPaciente que sera un campo propio de la clase Program
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());


        static void Main(string[] args)
        {
            bool control = true;
            while (control)
            {
                Console.WriteLine("Bienvenido al programa Hospital en Casa G44\n");
                System.Console.WriteLine("#### Menu Principal ####");
                System.Console.WriteLine("1. Adicionar Paciente");
                System.Console.WriteLine("2. Borrar Paciente");
                System.Console.WriteLine("3. Buscar Paciente");
                System.Console.WriteLine("4. Asignar Medico");
                System.Console.WriteLine("5. Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AdicionarPaciente();
                        break;

                    case 2:
                        System.Console.WriteLine("Eliminar Paciente");
                        System.Console.WriteLine("Digite el Id a Eliminar");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarPaciente(idEliminar);
                        break;

                    case 3:
                        System.Console.WriteLine("Buscar Paciente");
                        System.Console.WriteLine("Digite el Id a Buscar");
                        int idBuscar = Convert.ToInt32(Console.ReadLine());
                        BuscarPaciente(idBuscar);
                        break;

                    case 4:
                        break;

                    case 5:
                        System.Console.WriteLine("Gracias por Usar el Programa");
                        control = false;
                        break;
                    
                    default:
                        System.Console.WriteLine("Opcion No Validad");
                        break;
                }
            }
            
        }
        //Metodos para realizar el CRUD con la base de datos
        private static void AdicionarPaciente()
        {
            var paciente = new Paciente{
                Nombre = "Bob",
                Apellidos = "Esponja",
                NumeroTelefono = "22334455",
                Genero = Genero.Masculino,
                Direccion = "Casa Pina",
                Longitud = 10.0002F,
                Latitud = 2.1212F,
                Ciudad = "Fondo de Bikini",
                FechaNacimiento = new DateTime(2009,11,14)
            };

            Console.WriteLine($"El Paciente {paciente.Nombre} {paciente.Apellidos} sera ingresado a la BD");
            _repoPaciente.AddPaciente(paciente);
            System.Console.WriteLine();
            System.Console.WriteLine($"El Paciente {paciente.Nombre} {paciente.Apellidos} ha sido ingresado a la BD");
        }

        //Metodo para eliminar pacientes
        private static void EliminarPaciente(int idPaciente)
        {
            System.Console.WriteLine("Esta seguro de Eliminar el Paciente? \n1. Si\n2. No");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                System.Console.WriteLine($"El Paciente con id {idPaciente} sera eliminado");
                _repoPaciente.DeletePaciente(idPaciente);
                System.Console.WriteLine("Paciente Eliminado con Exito");
            }
        }

        //Metodo Buscar Paciente
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            System.Console.WriteLine($"El Paciente con id {idPaciente} es {paciente.Nombre} {paciente.Apellidos}");
            System.Console.WriteLine($"Su informacion es: ");
            System.Console.WriteLine($"Telefono: {paciente.NumeroTelefono}");
        }

    }
}
