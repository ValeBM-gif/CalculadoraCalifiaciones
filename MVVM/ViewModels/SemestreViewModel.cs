using System;
using System.Globalization;
using System.Windows.Input;
using System.Text.RegularExpressions;
using PropertyChanged;

namespace TDMPW_412_P3_EX_V2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SemestreViewModel
	{
        public string LblMateria { get; set; }
        public string TxtMateria { get; set; }

        public string TxtValor1 { get; set; }
        public string TxtValor2 { get; set; }
        public string TxtValor3 { get; set; }

        public string TxtCalificacion1 { get; set; }
        public string TxtCalificacion2 { get; set; }

        public string LblCalificacion3 { get; set; }
        public string LblCalificacion6 { get; set; }

        public string LblMensaje { get; set; }

        public ICommand CmdMateria => new Command(() =>
        {
            LblMateria = TxtMateria;
        });

        public ICommand CmdCalcular => new Command(() =>
        {
            calcular10();
            calcular6();
            
        });

        public void calcular10()
        {
            if (validarMateriaInsertada())
            {
                if (validarVacios() && validarValores() && validarCalificaciones())
                {
                    if (validarValoresCompleten100())
                    {
                        double v1 = double.Parse(TxtValor1, CultureInfo.InvariantCulture),
                            v2 = double.Parse(TxtValor2, CultureInfo.InvariantCulture),
                            v3 = double.Parse(TxtValor3, CultureInfo.InvariantCulture),
                            cal1 = double.Parse(TxtCalificacion1, CultureInfo.InvariantCulture),
                            cal2 = double.Parse(TxtCalificacion2, CultureInfo.InvariantCulture);


                        double r1 = 0, r2 = 0;

                        double calNecesaria = 0;

                        r1 = cal1 * v1 / 100; //1.96+2+5.64
                        r2 = cal2 * v2 / 100; //19.6 + 2 + 56.4
                        calNecesaria = (10 - r1 - r2) * 100 / v3;

                        LblCalificacion3 = "Necesitas " + Math.Round(calNecesaria, 2).ToString()+" para sacar 10 final";

                        Console.WriteLine("vas a imprimir o nada???", 1);
                        if (calNecesaria <= 10)
                        {
                            LblMensaje = "Aún alcanzas el 10, ánimo :)";
                        }
                        else
                        {
                            LblMensaje = "Esfuérzate + el prox semestre :(";
                        }
                    }
                }
            }
        }

        public void calcular6()
        {
            if (validarMateriaInsertada())
            {
                if (validarVacios() && validarValores() && validarCalificaciones())
                {
                    if (validarValoresCompleten100())
                    {
                        double v1 = double.Parse(TxtValor1, CultureInfo.InvariantCulture),
                            v2 = double.Parse(TxtValor2, CultureInfo.InvariantCulture),
                            v3 = double.Parse(TxtValor3, CultureInfo.InvariantCulture),
                            cal1 = double.Parse(TxtCalificacion1, CultureInfo.InvariantCulture),
                            cal2 = double.Parse(TxtCalificacion2, CultureInfo.InvariantCulture);


                        double r1 = 0, r2 = 0;

                        double calNecesaria = 0;

                        r1 = cal1 * v1 / 100; //1.96+2+5.64
                        r2 = cal2 * v2 / 100; //19.6 + 2 + 56.4
                        calNecesaria = (6 - r1 - r2) * 100 / v3;

                        LblCalificacion6 = "Necesitas " + Math.Round(calNecesaria, 2).ToString() + " para sacar 6 final";

                        Console.WriteLine("vas a imprimir o nada???", 1);
                    }
                }
            }
        }

        public bool validarMateriaInsertada()
        {
            if(LblMateria == "Materia...")
            {
                App.Current.MainPage.DisplayAlert("Materia Vacía", "¡Recuerda insertar una materia!", "OK");
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public bool validarVacios()
        {
            if (TxtCalificacion1 == "" || TxtCalificacion2 == "" 
            || TxtValor1 == "" || TxtValor2 == "" || TxtValor3 == "" ||
            TxtCalificacion1 == null || TxtCalificacion2 == null
            || TxtValor1 == null || TxtValor2 == null || TxtValor3 == null)
            {
                App.Current.MainPage.DisplayAlert("Campos Vacíos", "¡No dejes campos vacíos!", "OK");
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool validarValores()
        {
            Regex regex = new Regex(@"^(?:[1-9]|[1-9][0-9]|100)$");
            if (regex.IsMatch(TxtValor1) &&
                regex.IsMatch(TxtValor2) &&
                regex.IsMatch(TxtValor3))
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Valores inválidos", "En los campos de valor inserta un número entero del 1 al 100", "OK");
                return false;
            }

        }

        public bool validarCalificaciones()
        {
            Regex regex = new Regex(@"^(?:[0-9](?:\.[0-9])?|10(?:\.0)?)$");

            if (regex.IsMatch(TxtCalificacion1) &&
                regex.IsMatch(TxtCalificacion2))
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Calificaciones inválidas", "En los campos de calificación inserta un número del 1 al 10", "OK");
                return false;
            }

        }

        public bool validarValoresCompleten100()
        {
            if ((double.Parse(TxtValor1, CultureInfo.InvariantCulture)) +
                (double.Parse(TxtValor2, CultureInfo.InvariantCulture)) +
                (double.Parse(TxtValor3, CultureInfo.InvariantCulture)) == 100)
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Calificaciones inválidas", "La suma de valores debe completar 100%", "OK");
                return false;
            }

        }

        public SemestreViewModel()
		{
            LblCalificacion3 = "Calificación para 10 final...";
            LblCalificacion6 = "Calificación para 6 final...";
            LblMateria = "Materia...";
            LblMensaje = "...";
        }
	}
}

