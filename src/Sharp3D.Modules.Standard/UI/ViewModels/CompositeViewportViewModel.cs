using System.ComponentModel.Composition;
using Sharp3D.Common.UI;
using Sharp3D.Scene;

namespace Sharp3D.Modules.Standard.UI.ViewModels
{
    [Export]
    public class CompositeViewportViewModel : ViewModel
    {
        public IScene Scene
        {
            get { return CreateDemoScene(); }
        }

        private static IScene CreateDemoScene()
        {
            var scene = new Scene.Scene();

            return scene;
        }
    }
}