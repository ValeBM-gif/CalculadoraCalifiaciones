using System;
using System.Windows.Input;
using System.ComponentModel;
using PropertyChanged;
using System.Text.RegularExpressions;
using TDMPW_412_P3_EX_V2.MVVM.Views;
using System.Globalization;

namespace TDMPW_412_P3_EX_V2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MateriaViewModel
	{
        public string LblMateria { get; set; }
        public string TxtMateria { get; set; }

        public string TxtR1 { get; set; }
        public string TxtR2 { get; set; }
        public string TxtR3 { get; set; }

        public string TxtValor1 { get; set; }
        public string TxtValor2 { get; set; }
        public string TxtValor3 { get; set; }

        public string TxtCalificacion1 { get; set; }
        public string TxtCalificacion2 { get; set; }
        public string TxtCalificacion3 { get; set; }

        public string LblCalificacion { get; set; }

        public ICommand CmdMateria => new Command(() =>
        {
            LblMateria = TxtMateria;
        });

        public ICommand CmdCalcular => new Command(() =>
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
                            cal2 = double.Parse(TxtCalificacion2, CultureInfo.InvariantCulture),
                            cal3 = double.Parse(TxtCalificacion3, CultureInfo.InvariantCulture);

                        double r1 = 0, r2 = 0, r3 = 0;

                        double calFinal = 0;

                        r1 = cal1 * v1 / 100; //1.96+2+5.64
                        r2 = cal2 * v2 / 100; //19.6 + 2 + 56.4
                        r3 = cal3 * v3 / 100;

                        calFinal = Math.Round(r1 + r2 + r3, 2);

                        LblCalificacion = "Calificación: " + calFinal.ToString() +" :)";
                    }
                }
            }
            
        });

        public bool validarMateriaInsertada()
        {
            if (LblMateria == "Materia...")
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
            if (TxtR1 == null || TxtR2 == null || TxtR3 == null ||
            TxtCalificacion1 == null || TxtCalificacion2 == null || TxtCalificacion3 == null
            || TxtValor1 == null || TxtValor2 == null || TxtValor3 == null ||
            TxtR1 == "" || TxtR2 == "" || TxtR3 == "" ||
            TxtCalificacion1 == "" || TxtCalificacion2 == "" || TxtCalificacion3 == ""
            || TxtValor1 == "" || TxtValor2 == "" || TxtValor3 == "")
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
                regex.IsMatch(TxtCalificacion2) &&
                regex.IsMatch(TxtCalificacion3))
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
            if ((double.Parse(TxtValor1, CultureInfo.InvariantCulture))+
                (double.Parse(TxtValor2, CultureInfo.InvariantCulture))+
                (double.Parse(TxtValor3, CultureInfo.InvariantCulture)) == 100)
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Valores inválidos", "La suma de valores debe completar 100%", "OK");
                return false;
            }
            
        }

        public MateriaViewModel()
		{
            LblMateria = "Materia...";
            LblCalificacion = "Calificación...";
		}
    }
}

