﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SolicitudInscripcion
{
    internal class Inscripcion
    {
        
        public int NumeroRegistro { get;}
        public string Nombre { get; }
        public string Apellido { get; }
        public int CodigoInscripcion { get; }
        public int CodigoCurso { get;  }

        public Inscripcion(int nroRegistro, string nombre, string apellido, int codigoInscripcion)
        {
            NumeroRegistro = nroRegistro;
            Nombre = nombre;
            Apellido = apellido;
            CodigoInscripcion = codigoInscripcion;
        }
      
        public void ImprimirComprobante(Inscripcion unaInscripcion, List<Curso> cursos, List<Curso> cursosAlternativos)
        {
            Console.Clear();

            string archivo = NumeroRegistro + ".txt";
            FileStream filestream = new FileStream(archivo, FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

            Console.WriteLine("COMPROBANTE DE INSCRIPCION");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Nro Registro: {unaInscripcion.NumeroRegistro}");
            Console.WriteLine($"{unaInscripcion.Nombre} {unaInscripcion.Apellido}");
            Console.WriteLine($"Codigo Inscripcion #{unaInscripcion.CodigoInscripcion}");

            Console.WriteLine("\nCursos originales:");
            Console.WriteLine("Codigo \tNombre Materia\t\t\tDocente\t\tDia\tHorario\tSede");
            foreach (Curso curso in cursos)
            {
                Console.WriteLine($"{curso.CodigoCurso}-{curso.NombreMateria}-{curso.Docente}-{curso.Dias}-{curso.Horario}-{curso.Sede}");
            }

            if (cursosAlternativos.Count > 0)
            {
                Console.WriteLine("\nCursos alternativos:");
                Console.WriteLine("Codigo \tNombre Materia\t\t\tDocente\t\tDia\tHorario\tSede");
                foreach (Curso curso in cursosAlternativos)
                {
                    Console.WriteLine($"{curso.CodigoCurso}-{curso.NombreMateria}-{curso.Docente}-{curso.Dias}-{curso.Horario}-{curso.Sede}");
                }

            }
            

        }
    }
}
