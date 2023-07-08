using TDMPW_412_P3_EX_V2.MVVM.ViewModels;

namespace TDMPW_412_P3_EX_V2.MVVM.Views;

public partial class MateriaView : ContentPage
{
	public MateriaView()
	{
		InitializeComponent();
        BindingContext = new MateriaViewModel();
    }
}
