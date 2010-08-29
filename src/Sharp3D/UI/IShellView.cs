using Sharp3D.UI.ViewModels;

namespace Sharp3D.UI
{
    public interface IShellView
    {
        void Show();

        ShellViewModel ViewModel { set; }
    }
}