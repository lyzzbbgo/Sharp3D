using System.ComponentModel.Composition;
using Sharp3D.Common.UI;
using Sharp3D.Scene;
using Sharp3D.Scene.Cameras;
using Sharp3D.Scene.Lights;
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Models;
using Sharp3D.Scene.Primitives;

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
            var scene = new Scene.Scene
            {
                Models =
                {
                    new Sphere(5, new Point3(0, 0, 0))
                    {
                        Material =  new StandardMaterial { Diffuse = new Color(255, 0, 0) },
                        Phi = 32,
                        Theta = 32
                    }
                },

                Lights =
                {
                    new PointLight(new Color(255, 255, 255), new Point3(0, 0, 10)),
                    new DirectionalLight(new Color(255, 255, 255), new Vector3(0, 0, -1))
                },

                Cameras =
                {
                    new StandardCamera(new Point3(0, 0, 50), new Vector3(0, 0, -50))   
                }
            };

            //var scene = new Scene.Scene
            //{
            //    Models =
            //    {
            //        new Mesh
            //        {
            //            Material =  new StandardMaterial { Diffuse = new Color(255, 255, 0) },
            //            Positions = { new Point3(-1, 0, 0), new Point3(0, 1, 0), new Point3(1, 0, 0) },
            //            TriangleIndices = { 0, 2, 1 }
            //        }
            //    },

            //    Lights =
            //    {
            //        new PointLight(new Color(255, 255, 0), new Point3(0, 0, 5))
            //    },

            //    Cameras =
            //    {
            //        new StandardCamera(new Point3(0, 0, 10), new Vector3(0, 0, -10))   
            //    }
            //};

            return scene;
        }
    }
}