using TDMPW_412_P3_EX_V2.MVVM.ViewModels;
namespace TDMPW_412_P3_EX_V2.MVVM.Views;

public partial class InicioView : ContentPage
{
	public InicioView()
	{
		InitializeComponent();
        BindingContext = new InicioViewModel();
	}

    void btnMateria_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new MateriaView());
    }

    void btnSemestre_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new SemestreView());
    }
}
