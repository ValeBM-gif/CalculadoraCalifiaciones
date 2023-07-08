using TDMPW_412_P3_EX_V2.MVVM.ViewModels;
namespace TDMPW_412_P3_EX_V2.MVVM.Views;

public partial class SemestreView : ContentPage
{
	public SemestreView()
	{
		InitializeComponent();
		BindingContext = new SemestreViewModel();
	}
}
